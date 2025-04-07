using AutoMapper;
using BrewServe.Core.Interfaces;
using BrewServe.Core.Payloads;
using BrewServe.Core.Strategies;
using BrewServe.Data.Interfaces;
using BrewServe.Data.Models;
namespace BrewServe.Core.Services;
public class BeerService(IUnitOfWork unitOfWork, IMapper mapper, BeerFilterContext beerFilterContext) : IBeerService
{
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly BeerFilterContext _beerFilterContext = beerFilterContext;
    public async Task<IEnumerable<BeerResponse>> GetBeersAsync()
    {
        var beers = await _unitOfWork.Beers.GetAllAsync();
        return _mapper.Map<IEnumerable<BeerResponse>>(beers);
    }
    public async Task<BeerResponse> GetBeerByIdAsync(int id)
    {
        var beer = await _unitOfWork.Beers.GetByIdAsync(id);
        return _mapper.Map<BeerResponse>(beer);
    }
    public async Task<BeerResponse> AddBeerAsync(BeerRequest beer)
    {
        var beerEntity = _mapper.Map<Beer>(beer);
        await _unitOfWork.Beers.AddAsync(beerEntity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<BeerResponse>(beerEntity);
    }
    public async Task<BeerResponse> UpdateBeerAsync(BeerRequest beer, int id)
    {
        var beerEntity = _mapper.Map<Beer>(beer);
        beerEntity.Id = id;
        await _unitOfWork.Beers.UpdateAsync(beerEntity);
        await _unitOfWork.SaveAsync();
        return _mapper.Map<BeerResponse>(beerEntity);
    }
    public async Task<IEnumerable<BeerResponse>> GetBeersByAlcoholContentAsync(BeerFilterCriteria filter)
    {
       var beers = await _unitOfWork.Beers.GetAllAsync();
        var filteredBeers = await _beerFilterContext.FilterBeersAsync(beers, filter);
        return _mapper.Map<IEnumerable<BeerResponse>>(filteredBeers);
    }
}