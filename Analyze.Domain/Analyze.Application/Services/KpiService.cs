namespace Analyze.Application.Services;

public class KpiService : IKpiService
{
    private readonly IStockService _stockService;

    public KpiService(IStockService stockService)
    {
        _stockService = stockService;
    }

    public decimal PriceEarningRatio(double stockPrice, double profitPerStock)
    {
        if (stockPrice == 0 || profitPerStock == 0) return default;
        return Convert.ToDecimal(stockPrice / profitPerStock);
    }

    public decimal PriceBookRatio(double stockPrice, double equityCapital)
    {
        if (stockPrice == 0 || equityCapital == 0) return default;
        return Convert.ToDecimal(stockPrice / equityCapital);
    }

    public decimal PriceSalesRatio(double stockPrice, double revenue, double totalNumberOfStocksAvailable)
    {
        if (stockPrice == 0 || revenue == 0 || totalNumberOfStocksAvailable == 0) return default;
        return Convert.ToDecimal(stockPrice / (revenue / totalNumberOfStocksAvailable));
    }

    public decimal CompoundAnnualGrowthRatio(double stockPriceAtAcquisition, double stockPriceAtSale, double yearsOwned)
    {
        if (stockPriceAtAcquisition == 0 || stockPriceAtSale == 0 ||
            yearsOwned == 0) return default;
        return Convert.ToDecimal(Math.Pow((stockPriceAtSale / stockPriceAtAcquisition), 1 / yearsOwned) - 1) * 100;
    }

    public decimal ReturnOnEquityRatio(double grossProfit, double assets, double liabilities)
    {
        if (grossProfit == 0 || liabilities == 0 || assets == 0) return default;
        return Convert.ToDecimal(grossProfit / (assets - liabilities));
    }

    public decimal Ebidta(double earnings, double manufacturingCosts, double totalCosts)
    {
        if (earnings == 0 || earnings == 0 || manufacturingCosts == 0 || totalCosts == 0) return default;

        var grossProfit = earnings - manufacturingCosts;
        var otherCosts = totalCosts - manufacturingCosts;
        var ebidta = grossProfit - otherCosts;
        return Convert.ToDecimal(ebidta);
    }

    public decimal Ebit(double ebidta, double amortization, double depreciation)
    {
        if (ebidta == 0 || amortization == 0 || depreciation == 0) return default;
        return Convert.ToDecimal(ebidta - amortization - depreciation);
    }

    public decimal DuPont(double netIncome, double revenue, double sales, double averageTotalAssets,
        double averageSharHolderEquity)
    {
        if (netIncome == 0 || revenue == 0 || sales == 0 || averageTotalAssets == 0 ||
            averageSharHolderEquity == 0) return default;

        var assetTurnover = sales / averageTotalAssets;
        var equityMultiplier = averageTotalAssets / averageSharHolderEquity;
        var netProfitMargin = netIncome / revenue;
        return Convert.ToDecimal(netProfitMargin * assetTurnover * equityMultiplier);
    }

    public decimal CashFlow(double currentAssets, double inventoryAndOnGoingWork, double shortTermLiabilities)
    {
        if (currentAssets == 0 || inventoryAndOnGoingWork == 0 || shortTermLiabilities == 0) return default;
        return Convert.ToDecimal((currentAssets - inventoryAndOnGoingWork) / shortTermLiabilities);
    }

    public decimal OperatingMargin(double ebit, double revenue)
    {
        if (ebit == 0 || ebit == 0 || revenue == 0) return default;
        return Convert.ToDecimal(ebit / revenue);
    }

    public decimal ProfitMargin(double netRevenue, double resultBeforeFinancialCosts)
    {
        if (netRevenue == 0 || resultBeforeFinancialCosts == 0) return default;
        return Convert.ToDecimal(resultBeforeFinancialCosts / netRevenue);
    }
    
    public decimal Solidity(double equityCapital, double totalCapital, double taxRate, double unTaxedReserves)
    {
        if (equityCapital == 0 || totalCapital == 0 || taxRate == 0 || unTaxedReserves == 0) return default;
        var adjustedEquityCapital = equityCapital + ((1 - taxRate) * unTaxedReserves);
        var solidity = adjustedEquityCapital / totalCapital; 
        return Convert.ToDecimal(solidity);
    }
    

}