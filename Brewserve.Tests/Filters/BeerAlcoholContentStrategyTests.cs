using BrewServe.Core.Payloads;
using BrewServe.Core.Strategies;
using BrewServe.Data.Models;

namespace BrewServe.Tests.Filters
{
    [TestFixture]
    public class BeerAlcoholContentStrategyTests
    {
        private BeerByAlcoholContentStrategy _strategy;
        private List<Beer> _testBeers;

        [SetUp]
        public void Setup()
        {
            _strategy = new BeerByAlcoholContentStrategy();
            _testBeers = new List<Beer>
            {
                new Beer { Id = 1, Name = "Beer1", PercentageAlcoholByVolume = 5.0m },
                new Beer { Id = 2, Name = "Beer2", PercentageAlcoholByVolume = 6.4m },
                new Beer { Id = 3, Name = "Beer3", PercentageAlcoholByVolume = 7.2m }
            };
        }

        [Test]
        public async Task Filter_WhenGreaterAndLessPercentageProvided_ReturnsMatchingBeers()
        {
            var filter = new BeerFilterCriteria
            {
                gtAlcoholByVolume = 5.0m,
                ltAlcoholByVolume = 7.0m
            };

            var result = await _strategy.FilterAsync(_testBeers, filter);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Beer>>(result);
            var filteredBeers = result.ToList();
            Assert.AreEqual(1, filteredBeers.Count);
            Assert.AreEqual("Beer2", filteredBeers[0].Name);
        }

        [Test]
        public async Task Filter_WhenOnlyGreaterThanAlcoholPercentageProvided_ReturnsBeersAboveGivenFilter()
        {
            var filter = new BeerFilterCriteria{gtAlcoholByVolume = 5.3m};

            var result = await _strategy.FilterAsync(_testBeers, filter);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Beer>>(result);
            var filteredBeers = result.ToList();
            Assert.AreEqual(2, filteredBeers.Count);
            Assert.AreEqual("Beer2", filteredBeers[0].Name);
            Assert.AreEqual("Beer3", filteredBeers[1].Name);
        }

        [Test]
        public async Task Filter_WhenOnlyLessThanAlcoholPercentageProvided_ReturnsBeersBelowGivenFilter()
        {
            var filter = new BeerFilterCriteria{ltAlcoholByVolume = 5.0m
            };

            var result = await _strategy.FilterAsync(_testBeers, filter);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Beer>>(result);
            var filteredBeers = result.ToList();
            Assert.AreEqual(0, filteredBeers.Count);
        }

        [Test]
        public async Task Filter_WhenNoAlcoholPercentageFilterProvided_ReturnsAllBeers()
        {
            var filter = new BeerFilterCriteria();

            var result = await _strategy.FilterAsync(_testBeers, filter);

            Assert.IsNotNull(result);
            Assert.IsInstanceOf<IEnumerable<Beer>>(result);
            var filteredBeers = result.ToList();
            Assert.AreEqual(3, filteredBeers.Count);
            Assert.AreEqual("Beer1", filteredBeers[0].Name);
            Assert.AreEqual("Beer3", filteredBeers[2].Name);
        }

        [Test]
        public async Task Filter_WhenNoBeers_ReturnsEmpty()
        {
            var filter = new BeerFilterCriteria{gtAlcoholByVolume = 5.3m};

            var result = await _strategy.FilterAsync(new List<Beer>(), filter);

            Assert.IsEmpty(result);
        }
    }
}
