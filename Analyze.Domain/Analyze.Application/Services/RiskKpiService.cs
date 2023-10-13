namespace Analyze.Application.Services;

public class RiskKpiService : IRiskKpiService
{
    public decimal SharpeRatio(double expectedReturn, double riskFreeRate, double standardDeviation)
    {
        // Beräkna Sharpekvoten: (Förväntad avkastning - Riskfri ränta) / Standardavvikelse av avkastningen
        var sharpeRatio = (expectedReturn - riskFreeRate) / standardDeviation;
        return Convert.ToDecimal(sharpeRatio);
    }

    public decimal Volatility(double[] closingPrices)
    {
        // Beräkna genomsnittet av stängningspriserna
        double average = closingPrices.Average();

        // Beräkna summan av kvadraten av skillnaden mellan varje pris och genomsnittet
        double sumOfSquares = closingPrices.Sum(price => Math.Pow(price - average, 2));

        // Beräkna standardavvikelsen
        double standardDeviation = Math.Sqrt(sumOfSquares / closingPrices.Length);

        // Volatilitet är standardavvikelsen
        return Convert.ToDecimal(standardDeviation);
    }

    public decimal Beta(double[] stockReturns, double[] marketReturns)
    {
        // Beräkna genomsnittet av aktiens dagliga avkastning
        var stockAverageReturn = AverageReturn(stockReturns);

        // Beräkna genomsnittet av marknadens dagliga avkastning
        var marketAverageReturn = AverageReturn(marketReturns);

        // Beräkna kovariansen mellan aktiens och marknadens avkastning
        var covariance = Covariance(stockReturns, marketReturns, stockAverageReturn, marketAverageReturn);

        // Beräkna variansen för marknadens avkastning
        var marketVariance = Variance(marketReturns, marketAverageReturn);

        // Beräkna beta genom att dividera kovariansen med variansen för marknadens avkastning
        var beta = covariance / marketVariance;

        return beta;
    }

    private decimal AverageReturn(IReadOnlyCollection<double> returns)
    {
        // Beräkna genomsnittet av avkastningen
        var sum = returns.Sum();
        return Convert.ToDecimal(sum / returns.Count);
    }

    private decimal Covariance(double[] stockReturns, double[] marketReturns, decimal stockAvgReturn,
        decimal marketAvgReturn)
    {
        // Beräkna kovariansen mellan aktiens och marknadens avkastning
        var sum = stockReturns.Select((t, i) =>
            (t - Convert.ToDouble(stockAvgReturn)) * (marketReturns[i] - Convert.ToDouble(marketAvgReturn))).Sum();
        return Convert.ToDecimal(sum / stockReturns.Length);
    }

    private decimal Variance(double[] returns, decimal averageReturn)
    {
        // Beräkna variansen för avkastningen
        var sum = returns.Sum(returnVal => Math.Pow(returnVal - Convert.ToDouble(averageReturn), 2));
        return Convert.ToDecimal(sum / returns.Length);
    }
}