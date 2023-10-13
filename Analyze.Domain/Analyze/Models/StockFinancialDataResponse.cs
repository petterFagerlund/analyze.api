using Newtonsoft.Json;

public class StockFinancialDataResponse
{
    [JsonProperty("financialData")]
    public FinancialData FinancialData { get; set; }
}

public class FinancialData
{
    [JsonProperty("maxAge")]
    public int MaxAge { get; set; }

    [JsonProperty("currentPrice")]
    public Price CurrentPrice { get; set; }

    [JsonProperty("targetHighPrice")]
    public Price TargetHighPrice { get; set; }

    [JsonProperty("targetLowPrice")]
    public Price TargetLowPrice { get; set; }

    [JsonProperty("targetMeanPrice")]
    public Price TargetMeanPrice { get; set; }

    [JsonProperty("targetMedianPrice")]
    public Price TargetMedianPrice { get; set; }

    [JsonProperty("recommendationMean")]
    public Recommendation RecommendationMean { get; set; }

    [JsonProperty("recommendationKey")]
    public string RecommendationKey { get; set; }

    [JsonProperty("numberOfAnalystOpinions")]
    public AnalystOpinions NumberOfAnalystOpinions { get; set; }

    [JsonProperty("totalCash")]
    public Amount TotalCash { get; set; }

    [JsonProperty("totalCashPerShare")]
    public Amount TotalCashPerShare { get; set; }

    [JsonProperty("ebitda")]
    public Amount Ebitda { get; set; }

    [JsonProperty("totalDebt")]
    public Amount TotalDebt { get; set; }

    [JsonProperty("quickRatio")]
    public QuickRatio QuickRatio { get; set; }

    [JsonProperty("currentRatio")]
    public CurrentRatio CurrentRatio { get; set; }

    [JsonProperty("totalRevenue")]
    public Amount TotalRevenue { get; set; }

    [JsonProperty("debtToEquity")]
    public DebtToEquity DebtToEquity { get; set; }

    [JsonProperty("revenuePerShare")]
    public RevenuePerShare RevenuePerShare { get; set; }

    [JsonProperty("returnOnAssets")]
    public ReturnOnAssets ReturnOnAssets { get; set; }

    [JsonProperty("returnOnEquity")]
    public ReturnOnEquity ReturnOnEquity { get; set; }

    [JsonProperty("grossProfits")]
    public Amount GrossProfits { get; set; }

    [JsonProperty("freeCashflow")]
    public Amount FreeCashflow { get; set; }

    [JsonProperty("operatingCashflow")]
    public Amount OperatingCashflow { get; set; }

    [JsonProperty("earningsGrowth")]
    public EarningsGrowth EarningsGrowth { get; set; }

    [JsonProperty("revenueGrowth")]
    public RevenueGrowth RevenueGrowth { get; set; }

    [JsonProperty("grossMargins")]
    public GrossMargins GrossMargins { get; set; }

    [JsonProperty("ebitdaMargins")]
    public EbitdaMargins EbitdaMargins { get; set; }

    [JsonProperty("operatingMargins")]
    public OperatingMargins OperatingMargins { get; set; }

    [JsonProperty("profitMargins")]
    public ProfitMargins ProfitMargins { get; set; }

    [JsonProperty("financialCurrency")]
    public string FinancialCurrency { get; set; }
}

public class RevenuePerShare
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class ReturnOnAssets
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class ReturnOnEquity
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class EarningsGrowth
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class RevenueGrowth
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class GrossMargins
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}
public class EbitdaMargins
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}
public class OperatingMargins
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class ProfitMargins
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class Price
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class Recommendation
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class AnalystOpinions
{
    [JsonProperty("raw")]
    public int Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }

    [JsonProperty("longFmt")]
    public string LongFormatted { get; set; }
}

public class Amount
{
    [JsonProperty("raw")]
    public long Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }

    [JsonProperty("longFmt")]
    public string LongFormatted { get; set; }
}

public class QuickRatio
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class CurrentRatio
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}

public class DebtToEquity
{
    [JsonProperty("raw")]
    public double Raw { get; set; }

    [JsonProperty("fmt")]
    public string Formatted { get; set; }
}