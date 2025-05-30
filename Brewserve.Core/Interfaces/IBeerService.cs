﻿using BrewServe.Core.Payloads;
namespace BrewServe.Core.Interfaces;
public interface IBeerService
{
    Task<IEnumerable<BeerResponse>> GetBeersAsync();
    Task<BeerResponse> GetBeerByIdAsync(int id);
    Task<BeerResponse> AddBeerAsync(BeerRequest beer);
    Task<BeerResponse> UpdateBeerAsync(BeerRequest beer, int id);
    Task<IEnumerable<BeerResponse>> GetBeersByAlcoholContentAsync(BeerFilterCriteria filter);
}