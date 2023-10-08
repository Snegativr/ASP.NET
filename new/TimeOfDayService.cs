  interface ITimeOfDayService {
    string GetTimeOfDay();

  }

public class TimeOfDayService: ITimeOfDayService
{
    public string GetTimeOfDay()
    {
        DateTime currentTime = DateTime.Now;
        int hour = currentTime.Hour;

        if (hour >= 12 && hour < 18)
        {
            return "it's daytime";
        }
        else if (hour >= 18 && hour < 24)
        {
            return "it is evening";
        }
        else if (hour >= 0 && hour < 6)
        {
            return "it's night now";
        }
        else
        {
            return "it's morning";
        }
    }
}
