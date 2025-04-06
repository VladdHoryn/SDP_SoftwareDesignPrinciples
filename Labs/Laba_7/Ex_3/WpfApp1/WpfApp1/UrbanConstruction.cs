using System.Runtime.InteropServices.JavaScript;

namespace WpfApp1;

public class UrbanConstruction
{
    private List<Construction> constructions;

    public UrbanConstruction()
    {
        this.constructions = new List<Construction>();
    }

    public List<Construction> Constructions
    {
        get { return this.constructions; }
        set { this.constructions = value; }
    }

    public string GetInfoByDate(int amountDays)
    {
        string result = "";

        foreach (var i in constructions)
        {
            if (amountDays == i.CalculateDayRest())
                result += i.ShowInfo();
        }

        return result;
    }

    public string GetInfoFor4thquarter(Date date)
    {
        string result = "";
        foreach (var i in constructions)
        {
            if (i.State == ConstructioState.InProgress && i.DateConstructionEnd.Year == date.Year
                && i.DateConstructionEnd.Month >= 10 && i.DateConstructionEnd.Month <= 12)
            {
                result += i.ShowInfo();
            }
        }
        
        return result;
    }

    public string GetDoneThisYear(Date date)
    {
        string result = "";
        int amount = 0;
        int sumArea = 0;
        foreach (var i in constructions)
        {
            amount++;
            sumArea += i.Area;
            if (i.State != ConstructioState.Done && i.DateConstructionEnd.Year == date.Year)
            {
                result += i.ShowInfo();
            }
        }

        result = $"Amount of Constructions: {amount}\n Sum of all their area: {sumArea}\n" + result;
        
        return result;
    }

    public string GetWithMinTerm()
    {
        Construction result = new Construction();
        Date date = new Date();
        if (constructions.Count > 0)
            date = constructions[0].DateConstructionEnd;
        foreach (var i in constructions)
        {
            if (i.State != ConstructioState.Done && (i.DateConstructionEnd.CompareTo(date) == -1 ||
                                                     i.DateConstructionEnd.CompareTo(date) == 0))
            {
                date = i.DateConstructionEnd;
                Console.Out.WriteLine(date.ShowDate());
                result = i;
                Console.Out.WriteLine(result.ShowInfo());
            }
        }
        
        return result.ShowInfo();
    }

    public string GetOverdueDeadLine(Date date)
    {
        string result = "";
        
        foreach (var i in constructions)
        {
            if (i.State == ConstructioState.InProgress && date.GetInDays() - i.DateConstructionEnd.GetInDays() > 547)
                result += i.ShowInfo();
        }
        
        return result;
    }
}