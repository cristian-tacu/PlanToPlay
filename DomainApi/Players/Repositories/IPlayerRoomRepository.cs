using DomainApi.Common.Repositories;
using DomainApi.Players.Models;

namespace DomainApi.Players.Repositories;

public interface IPlayerRoomRepository : IRepository<PlayerRoomModel>
{
    Task<PlayerRoomModel?> GetPlayerRoomEntry(string playerId, string roomId);
}