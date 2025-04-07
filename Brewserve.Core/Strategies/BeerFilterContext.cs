using BrewServe.Core.Interfaces;
using BrewServe.Core.Payloads;
using BrewServe.Data.Models;

namespace BrewServe.Core.Strategies
{
    public class BeerFilterContext
    {
        private readonly IEnumerable<IBeerSearchStrategy> _strategies;

        public BeerFilterContext(IEnumerable<IBeerSearchStrategy> strategies)
        {
            _strategies = strategies;
        }

        public async Task<IEnumerable<Beer>> FilterBeersAsync(IEnumerable<Beer> beers, BeerFilterCriteria filter)
        {
            foreach (var strategy in _strategies)
            {
                beers = await strategy.FilterAsync(beers, filter);
            }
            return beers;
        }
    }
}
