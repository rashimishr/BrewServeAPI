using Brewserve.Data.Interfaces;
using BrewServe.Data.Models;
using BrewServe.Data.Repositories;
using BrewServeData.EF_Core;
namespace Brewserve.Data.Repositories;
public class BreweryRepository : Repository<Brewery>, IBreweryRepository
{
    public BreweryRepository(BrewServeDbContext context) : base(context){}
}