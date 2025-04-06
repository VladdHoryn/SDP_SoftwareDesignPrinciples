using System.Collections;

namespace WpfApp2;

public class SKLAD: IComparable
{
    private string name;
    private string type;
    private int quantity;
    private int cost;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public string Type
    {
        get { return this.type; }
        set { this.type = value; }
    }
    public int Quantity
    {
        get { return this.quantity; }
        set { this.quantity = value; }
    }
    public int Cost
    {
        get { return this.cost; }
        set { this.cost = value; }
    }

    public int CompareTo(object? obj)
    {
        if (obj == null)
            return 1;

        if (!(obj is SKLAD otherSKLAD))
            throw new ArgumentException("Object is not a SKLAD");

        return String.Compare(this.name, otherSKLAD.name);
    }

    public string GetInfo()
    {
        string result = $"Product name: {this.name}, Type: {this.type}\n" +
                        $"Quantity: {this.quantity}\nCost: {this.cost}\n" +
                        $"Total cost: {this.quantity * this.cost}\n";

        return result;
    }
}