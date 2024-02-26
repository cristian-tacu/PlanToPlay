using DomainApi.Common.Repositories;
using DomainApi.Players.Models;

namespace DomainApi.Players.Repositories;

public interface IRoomRepository : IRepository<RoomModel>
{
    Task<RoomModel?> GetRoomWithPlayers(string roomId);
}