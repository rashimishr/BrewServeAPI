using BrewServe.Data.Interfaces;
using BrewServe.Data.Models;
using BrewServe.Data.Repositories;
using BrewServeData.EF_Core;
namespace Brewserve.Data.Repositories;
public class BarRepository : Repository<Bar>, IBarRepository
{
    public BarRepository(BrewServeDbContext context) : base(context){}
}