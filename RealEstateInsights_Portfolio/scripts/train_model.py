
import os
from pathlib import Path
import joblib
import numpy as np
import pandas as pd
import matplotlib.pyplot as plt

from sklearn.model_selection import train_test_split
from sklearn.compose import ColumnTransformer
from sklearn.preprocessing import OneHotEncoder, StandardScaler
from sklearn.pipeline import Pipeline
from sklearn.metrics import mean_absolute_error, mean_squared_error, r2_score
from sklearn.linear_model import LinearRegression
from sklearn.ensemble import RandomForestRegressor

BASE = Path(__file__).resolve().parents[1]  # project root
DATA = BASE / "data" / "housing_data.csv"
FIGS = BASE / "figures"
MODELS = BASE / "models"
FIGS.mkdir(parents=True, exist_ok=True)
MODELS.mkdir(parents=True, exist_ok=True)

def load_data():
    df = pd.read_csv(DATA)
    return df

def save_price_hist(df):
    plt.figure()
    df["price"].plot(kind="hist", bins=30, title="Price Distribution")
    plt.xlabel("Price (USD)")
    plt.tight_layout()
    plt.savefig(FIGS / "price_distribution.png")
    plt.close()

def save_corr_heatmap(df):
    num_df = df.select_dtypes(include=[np.number]).copy()
    corr = num_df.corr(numeric_only=True)
    fig = plt.figure()
    ax = fig.add_subplot(111)
    cax = ax.imshow(corr.values, interpolation="nearest")
    ax.set_xticks(range(len(corr.columns)))
    ax.set_yticks(range(len(corr.columns)))
    ax.set_xticklabels(corr.columns, rotation=90)
    ax.set_yticklabels(corr.columns)
    fig.colorbar(cax)
    ax.set_title("Correlation Heatmap (Numeric Features)")
    plt.tight_layout()
    plt.savefig(FIGS / "correlation_heatmap.png")
    plt.close()

def build_pipeline():
    numeric_features = ["bedrooms","bathrooms","sqft","lot_size","year_built",
                        "distance_to_city_center_miles","condition_score_1to10","has_garage"]
    categorical_features = ["neighborhood","property_type"]

    numeric_transformer = Pipeline(steps=[("scaler", StandardScaler())])
    categorical_transformer = Pipeline(steps=[("onehot", OneHotEncoder(handle_unknown="ignore"))])

    preprocessor = ColumnTransformer(
        transformers=[
            ("num", numeric_transformer, numeric_features),
            ("cat", categorical_transformer, categorical_features),
        ]
    )

    linreg = Pipeline(steps=[("prep", preprocessor),
                             ("model", LinearRegression())])
    rf = Pipeline(steps=[("prep", preprocessor),
                         ("model", RandomForestRegressor(n_estimators=400, random_state=42))])
    return linreg, rf

def evaluate(y_true, y_pred):
    mae = mean_absolute_error(y_true, y_pred)
    rmse = mean_squared_error(y_true, y_pred, squared=False)
    r2 = r2_score(y_true, y_pred)
    return {"MAE": mae, "RMSE": rmse, "R2": r2}

def plot_predictions(y_true, y_pred):
    plt.figure()
    plt.scatter(y_true, y_pred, alpha=0.6)
    max_val = max(y_true.max(), y_pred.max())
    min_val = min(y_true.min(), y_pred.min())
    plt.plot([min_val, max_val], [min_val, max_val])
    plt.xlabel("Actual Price")
    plt.ylabel("Predicted Price")
    plt.title("Predicted vs Actual")
    plt.tight_layout()
    plt.savefig(FIGS / "predictions_vs_actual.png")
    plt.close()

def main():
    df = load_data()
    save_price_hist(df)
    save_corr_heatmap(df)

    X = df.drop(columns=["price"])
    y = df["price"]

    X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=42)

    linreg, rf = build_pipeline()

    linreg.fit(X_train, y_train)
    rf.fit(X_train, y_train)

    preds_lin = linreg.predict(X_test)
    preds_rf = rf.predict(X_test)

    metrics_lin = evaluate(y_test, preds_lin)
    metrics_rf = evaluate(y_test, preds_rf)

    best_name, best_model, best_preds, best_metrics = ("LinearRegression", linreg, preds_lin, metrics_lin)
    if metrics_rf["RMSE"] < metrics_lin["RMSE"]:
        best_name, best_model, best_preds, best_metrics = ("RandomForestRegressor", rf, preds_rf, metrics_rf)

    joblib.dump(best_model, MODELS / "best_model.pkl")

    plot_predictions(y_test, best_preds)

    report = pd.DataFrame([
        {"model":"LinearRegression", **metrics_lin},
        {"model":"RandomForestRegressor", **metrics_rf},
        {"model":"BEST:"+best_name, **best_metrics},
    ])
    report.to_csv(MODELS / "metrics.csv", index=False)

    print("Training complete.")
    print(report.to_string(index=False))

if __name__ == "__main__":
    main()
