using Adapter.Database.Players;
using DomainApi.Common.Repositories;
using DomainApi.Players.Repositories;

namespace Adapter.Database.Common.Repositories;

public class UnitOfWork : IUnitOfWork
{

    public IPlayersRepository Players { get; }
    public IRoomRepository Rooms { get; }
    public IStatsRepository Stats { get; }
    public IPlayerRoomRepository PlayerRooms { get; }
    public IGradeRepository Grades { get; }
    

    private readonly DatabaseContext _context;

    public UnitOfWork(DatabaseContext context)
    {
            _context = context;
            Players = new PlayersRepository(_context);
    }

    public Task<int> Complete()
    {
            return _context.SaveChangesAsync();
    }

    private bool _disposed;
    public void Dispose()
    {
            Dispose(true);
            GC.SuppressFinalize(this);
    }
        
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed) return;
        if (disposing)
        {
            _context.Dispose();
        }

        _disposed = true;
    }
        
    ~UnitOfWork()
    {
        Dispose(false);
    }
}