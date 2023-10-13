namespace Analyze.Application.Services;

public interface IKpiService
{
    decimal PriceEarningRatio(double stockPrice, double profitPerStock);
    decimal PriceBookRatio(double stockPrice, double equityCapital);
    decimal PriceSalesRatio(double stockPrice, double revenue, double totalNumberOfStocksAvailable);
    decimal CompoundAnnualGrowthRatio(double stockPriceAtAcquisition, double stockPriceAtSale, double yearsOwned);
    decimal ReturnOnEquityRatio(double grossProfit, double assets, double liabilities);
    decimal Ebidta(double earnings, double manufacturingCosts, double totalCosts);
    decimal Ebit(double ebidta, double amortization, double depreciation);
    decimal DuPont(double netIncome, double revenue, double sales, double averageTotalAssets,
        double averageSharHolderEquity);
    decimal CashFlow(double currentAssets, double inventoryAndOnGoingWork, double shortTermLiabilities);
    decimal OperatingMargin(double ebit, double revenue);
    decimal ProfitMargin(double netRevenue, double resultBeforeFinancialCosts);
    decimal Solidity(double equityCapital, double totalCapital, double taxRate, double unTaxedReserves);
}