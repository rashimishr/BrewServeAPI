using BrewServe.Core.Interfaces;
using BrewServe.Core.Payloads;
using BrewServe.Data.Models;

namespace BrewServe.Core.Strategies;
public class BeerByAlcoholContentStrategy : IBeerSearchStrategy
{
   public BeerByAlcoholContentStrategy(){}
    public async Task<IEnumerable<Beer>> FilterAsync(IEnumerable<Beer> beers, BeerFilterCriteria filter)
    {
       return beers.Where(b =>
           (!filter.gtAlcoholByVolume.HasValue || b.PercentageAlcoholByVolume > filter.gtAlcoholByVolume) &&
           (!filter.ltAlcoholByVolume.HasValue || b.PercentageAlcoholByVolume < filter.ltAlcoholByVolume));
    }
}