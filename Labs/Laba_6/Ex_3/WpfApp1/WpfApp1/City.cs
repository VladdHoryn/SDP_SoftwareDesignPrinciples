using System.Collections;
using System.Threading.Tasks.Dataflow;

namespace WpfApp1;

public class City: IComparable, IComparer
{
    private string name;
    private double area;
    private int population;
    
    private List<City> cities = new List<City>();
    
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public double Area
    {
        get { return area; }
        set { area = value; }
    }
    
    public int Population
    {
        get { return population; }
        set { population = value; }
    }
    
    public City(string name, double area, int population)
    {
        this.name = name;
        this.area = area;
        this.population = population;
    }

    public int CompareTo(object? obj)
    {
        if (obj == null)
            return 1;

        if (!(obj is City otherCity))
            throw new ArgumentException("Object is not a City");

        if (this.area > otherCity.area)
            return 1;
        else if (this.area < otherCity.area)
            return -1;
        else
            return 0;
    }

    public int Compare(object? x, object? y)
    {
        if (!(x is City firstCity) || !(y is City secondCity))
            throw new ArgumentException("Object is not a City");

        if (firstCity.area > secondCity.area)
            return 1;
        else if (firstCity.area < secondCity.area)
            return -1;
        else
        {
            if (firstCity.population > secondCity.population)
                return 1;
            else if (firstCity.population < secondCity.population)
                return -1;
            else
                return 0;
        }
    }
    
    public void AddCity(City city)
    {
        cities.Add(city);
    }
    
    public IEnumerator GetEnumerator()
    {
        cities.Sort((city1, city2) => city1.Population.CompareTo(city2.Population));
        
        foreach (var city in cities)
        {
            yield return city;
        }
    }

    public string GetCities()
    {
        string result = "";
        foreach (var i in cities)
        {
            result += $"Name: {i.name}, Area: {i.area}, Population: {i.population}\n";
        }

        return result;
    }
}
