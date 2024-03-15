//варіант 2
using System;


public enum DaysOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public class CalendarEvent
{
    public string EventName { get; set; }
    public DaysOfWeek EventDay { get; set; }


    public CalendarEvent(string eventName, DaysOfWeek eventDay)
    {
        EventName = eventName;
        EventDay = eventDay;
    }

    public void PrintEventDetails()
    {
        Console.WriteLine($"Event {EventName} will take place on {EventDay}.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        CalendarEvent myEvent = new CalendarEvent("Birthday party", DaysOfWeek.Saturday);

        myEvent.PrintEventDetails();
    }
}
