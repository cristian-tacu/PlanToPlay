using DomainApi.Common.Repositories;
using Microsoft.Extensions.Logging;

namespace DomainImpl.Players.Services;

public class ClearGradesService(IUnitOfWork unitOfWork, ILogger<ClearGradesService> logger)
{
    public async Task Invoke()
    {
        logger.LogInformation("----------- Deleting Grades older than 1 week -----------");

        var jobs = await unitOfWork.Grades.GetGradesByDate();
        await unitOfWork.Grades.DeleteRange(jobs);
        await unitOfWork.Complete();
    }
}