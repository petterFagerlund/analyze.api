namespace Analyze.Application.Services;

public interface IRiskKpiService
{
    decimal SharpeRatio(double expectedReturn, double riskFreeRate, double standardDeviation);
    decimal Volatility(double[] closingPrices);
    decimal Beta(double[] stockReturns, double[] marketReturns);
}