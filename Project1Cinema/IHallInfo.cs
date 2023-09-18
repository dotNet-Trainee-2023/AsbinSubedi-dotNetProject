public interface IHallInfo
{

    string HallName { get; }
    string? HallType { get; }


    int Capacity { get; }


    void DisplayMovieSchedule();

}