using Adapter.Database.Common.Repositories;
using DomainApi.Players.Models;
using DomainApi.Players.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database.Players;

public class GradeRepository(DatabaseContext context)
    : Repository<GradeModel>(context), IGradeRepository
{
    public async Task<List<GradeModel>> GetGradesByDate()
    {
        var grades = await context.Grades.Where(i => i.Date.AddDays(13) < DateTime.Now).ToListAsync();

        return grades;
    }
}