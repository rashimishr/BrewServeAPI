using BrewServe.Core.Payloads;
using BrewServe.Data.Models;

namespace BrewServe.Core.Interfaces;
public interface IBeerSearchStrategy
{
    Task<IEnumerable<Beer>> FilterAsync(IEnumerable<Beer> beers, BeerFilterCriteria filter);
}