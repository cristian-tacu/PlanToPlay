using Adapter.Database.Common.Repositories;
using DomainApi.Players.Models;
using DomainApi.Players.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database.Players;

public class RoomRepository(DatabaseContext context)
    : Repository<RoomModel>(context), IRoomRepository
{
    public Task<RoomModel?> GetRoomWithPlayers(string roomId)
    {
        return context.Rooms.Include(rm => rm.PlayerRooms).FirstOrDefaultAsync(rm => rm.Id == roomId);
    }
}