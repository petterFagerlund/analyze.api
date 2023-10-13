using System.Net;
using Analyze.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Polly;
using Polly.Extensions.Http;
using Polly.Retry;

namespace Analyze.Application.Services;

public class StockService : IStockService
{
    private readonly HttpClient _httpClient;
    private readonly string? _key;
    private readonly string? _host;
    private const int MaxRetryCount = 2;
    private const double DurationBetweenRetries = 50;
    private readonly AsyncRetryPolicy<HttpResponseMessage> _policy; 

    public StockService(IConfiguration configuration, HttpClient httpClient)
    {
        _httpClient = httpClient;
        _key = configuration["Yahoo:Key"];
        _host = configuration["Yahoo:Host"];
        _policy = GetHttpPolicy();
    }
    
    public async Task<StockFinancialDataResponse?> GetFinancialDataAsync(StockRequest stockRequest)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _host);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-key", _key);
            var response = await _policy.ExecuteAsync(() =>
                _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, _httpClient.BaseAddress)));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<StockFinancialDataResponse>(responseBody);
            return dto;
        }
        catch (Exception e)
        {
            return default;
        }
    }

    private AsyncRetryPolicy<HttpResponseMessage> GetHttpPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.Unauthorized)
            .WaitAndRetryAsync(
                MaxRetryCount,
                retryCount => TimeSpan.FromMilliseconds(DurationBetweenRetries * Math.Pow(2, retryCount - 1)
                ), (msg, _, retries, _) =>
                {
                    if (retries != MaxRetryCount)
                    {
                        //Todo: add logging
                        return Task.CompletedTask;
                    }
                    return Task.CompletedTask;
                });
    }
}