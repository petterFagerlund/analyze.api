using Analyze.Models;

namespace Analyze.Application.Services;

public interface IStockService
{
    Task<StockFinancialDataResponse?> GetFinancialDataAsync(StockRequest stockRequest);
}