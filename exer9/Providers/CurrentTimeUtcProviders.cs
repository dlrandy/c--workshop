namespace exer9.Providers;
public interface ICurrentTimeProvider{
    DateTime GetTime(string timezoneId);
}

public class CurrentTimeUtcProvider:ICurrentTimeProvider
{
    public DateTime GetTime(string timezoneId){
        var timezoneInfo = TimeZoneInfo.FindSystemTimeZoneById(timezoneId);
        var time = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timezoneInfo);
        return time;
    }
}