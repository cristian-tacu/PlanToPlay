using Adapter.Database.Common.Repositories;
using DomainApi.Players.Models;
using DomainApi.Players.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database.Players;

public class PlayersRepository(DatabaseContext context)
    : Repository<PlayerModel>(context), IPlayersRepository
{
    public async Task<PlayerModel?> GetPlayerByEmail(string email)
    {
        return await context.Players.FirstOrDefaultAsync(pl => pl.Email == email);
    }

    public Task<PlayerModel?> GetPlayerByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<PlayerModel> AddJob(PlayerModel player)
    {
        throw new NotImplementedException();
    }
}
