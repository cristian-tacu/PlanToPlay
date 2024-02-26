using DomainApi.Common.Repositories;
using DomainApi.Players.Models;

namespace DomainApi.Players.Repositories;

public interface IGradeRepository : IRepository<GradeModel>
{
    Task<List<GradeModel>> GetGradesByDate();
}