using DomainApi.Players.Repositories;

namespace DomainApi.Common.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IPlayersRepository Players { get; }
    public IRoomRepository Rooms { get; }
    public IStatsRepository Stats { get; }
    public IPlayerRoomRepository PlayerRooms { get; }
    public IGradeRepository Grades { get; }
    public Task<int> Complete();

}