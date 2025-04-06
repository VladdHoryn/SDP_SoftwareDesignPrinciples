namespace WpfApp2;

public class SHOP
{
    private List<SKLAD> sklads;
    
    public SHOP()
    {
        this.sklads = new List<SKLAD>();
    }

    public List<SKLAD> Sklads
    {
        get { return this.sklads; }
        set { this.sklads = value; }
    }

    public void Add(SKLAD sklad)
    {
        this.sklads.Add(sklad);
    }

    public string GetInfo()
    {
        sklads.Sort();
        string result = "";

        foreach (var i in this.sklads)
        {
            result += i.GetInfo();
        }

        return result;
    }

    public string GetByName(string name)
    {
        sklads.Sort();
        foreach (var i in this.sklads)
        {
            if (name == i.Name)
            {
                return i.GetInfo();
            }
        }

        return "There is no product with such name!";
    }
}