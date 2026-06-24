namespace TimeTrackingApp.Services.Interfaces;

using TimeTrackingApp.Services.StatisticsModels;
public interface IStatisticsService
{
    ReadingStatistics GetReadingStats(int userId);
    ExerciseStatistics GetExerciseStats(int userId);
    WorkingStatistics GetWorkingStats(int userId);
    HobbyStatistics GetHobbyStats(int userId);
    GlobalStatistics GetGlobalStats(int userId);
}
