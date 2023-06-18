using Microsoft.AspNetCore.Mvc;

namespace exer9.Exceptions;
public class NoSuchWeekdayException:Exception

{
    public NoSuchWeekdayException(int day):base($"{day} is not a valid dat of week"){}
}
