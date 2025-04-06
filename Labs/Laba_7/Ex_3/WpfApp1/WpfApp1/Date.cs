namespace WpfApp1;

public class Date : IComparable
{
    private int year;
    private int month;
    private int day;

    public Date()
    {
        year = 0;
        month = 0;
        day = 0;
    }

    public int Year
    {
        get { return year; }
        set { year = value; }
    }

    public int Month
    {
        get { return month; }
        set { month = value; }
    }

    public int Day
    {
        get { return day; }
        set { day = value; }
    }
    
    public void ConvertToDate(string date)
    {
        if (date.Length != 8)
        {
            throw new FormatException("Невірний формат введеного рядка");
        }
        
        day = int.Parse(date.Substring(0, 2));
        month = int.Parse(date.Substring(2, 2));
        year = int.Parse(date.Substring(4, 4));
    }
    
    public int CompareTo(object? obj)
    {
        if (obj == null)
            return 1;

        if (!(obj is Date otherDate))
            throw new ArgumentException("Object is not a Date");
        
        int yearComparison = year.CompareTo(otherDate.year);
        if (yearComparison != 0)
            return yearComparison;
        
        int monthComparison = month.CompareTo(otherDate.month);
        if (monthComparison != 0)
            return monthComparison;
        
        return day.CompareTo(otherDate.day);
    }

    public int GetInDays()
    {
        return this.day + this.month * 30 + this.year * 365;
    }

    public string ShowDate()
    {
        return $"{this.day}.{this.month}.{this.day}";
    }
}