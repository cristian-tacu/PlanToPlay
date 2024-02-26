using DomainApi.Common.Repositories;
using DomainApi.Players.Models;

namespace DomainApi.Players.Repositories;

public interface IPlayersRepository : IRepository<PlayerModel>
{
    Task<PlayerModel?> GetPlayerByEmail(string email);

    Task<PlayerModel?> GetPlayerByName(string name);
    Task<PlayerModel> AddJob(PlayerModel player);
}