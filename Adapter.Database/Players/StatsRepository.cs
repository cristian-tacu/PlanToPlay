using Adapter.Database.Common.Repositories;
using DomainApi.Players.Models;
using DomainApi.Players.Repositories;

namespace Adapter.Database.Players;

public class StatsRepository(DatabaseContext context)
    : Repository<StatsModel>(context), IStatsRepository
{
    
}