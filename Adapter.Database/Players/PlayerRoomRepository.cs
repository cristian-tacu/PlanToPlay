using Adapter.Database.Common.Repositories;
using DomainApi.Players.Models;
using DomainApi.Players.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database.Players;

public class PlayerRoomRepository(DatabaseContext context)
    : Repository<PlayerRoomModel>(context), IPlayerRoomRepository
{
    public async Task<PlayerRoomModel?> GetPlayerRoomEntry(string playerId, string roomId)
    {
        return await context.PlayerRooms.FirstOrDefaultAsync(pl => pl.RoomId == roomId && pl.PlayerId == playerId);
    }
}