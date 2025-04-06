namespace WpfApp1;

public enum ConstructioState
{
    InProgress,
    Done,
    Freezed
}
public class Construction: IComparable
{
    private string nameConstructionCompany;
    private string constructionName;
    private int area;
    private Date dateConstructionStart;
    private Date dateConstructionEnd;
    private ConstructioState state;
    
    public Construction()
    {
        nameConstructionCompany = "Unknown";
        constructionName = "Unnamed";
        area = 0;
        dateConstructionStart = new Date();
        dateConstructionEnd = new Date();
        state = ConstructioState.InProgress;
    }
    
    public string NameConstructionCompany
    {
        get { return nameConstructionCompany; }
        set { nameConstructionCompany = value; }
    }

    public string ConstructionName
    {
        get { return constructionName; }
        set { constructionName = value; }
    }

    public int Area
    {
        get { return area; }
        set { area = value; }
    }

    public Date DateConstructionStart
    {
        get { return this.dateConstructionStart; }
        set { dateConstructionStart = value; }
    }

    public Date DateConstructionEnd
    {
        get { return dateConstructionEnd; }
        set { dateConstructionEnd = value; }
    }

    public ConstructioState State
    {
        get { return state; }
        set { state = value; }
    }

    public int CompareTo(object? obj)
    {
        if (obj == null)
            return 1;
        if(!(obj is Construction otherConstruction))
            throw new ArgumentException("Object is not a SKLAD");

        return this.dateConstructionEnd.CompareTo(otherConstruction.dateConstructionEnd);
    }

    public int CalculateDayRest()
    {
        return this.dateConstructionEnd.GetInDays() - this.dateConstructionStart.GetInDays();
    }

    public string ShowInfo()
    {
        return $"Name Construction Company: {this.nameConstructionCompany}\n" +
               $"Construction Name: {this.constructionName}\nArea: {this.area}" +
               $"Date Construction Start: {this.dateConstructionStart.ShowDate()}" +
               $"Date Construction End: {this.dateConstructionEnd.ShowDate()}" +
               $"State: {this.state}\n";
    }
}