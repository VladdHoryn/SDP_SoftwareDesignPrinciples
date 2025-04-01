namespace WpfApp2;

public class Book : EducationalMaterial, Test
{
    private int pages;
    private string subject;
    private List<string> topics;

    public int Pages
    {
        get { return pages; }
        set { pages = value; }
    }

    public string Subject
    {
        get { return subject; }
        set { subject = value; }
    }

    public List<string> Topics
    {
        get { return topics; }
        set { topics = value; }
    }

    public string GetAllTopics()
    {
        string result = "";
        foreach (var i in topics)
        {
            result += i + " ";
        }

        return result;
    }

    public int GetAmountOfTopics()
    {
        return topics.Count;
    }

    public string ShowInfoAboutTest()
    {
        string result = "";
        result += $"Subject: {this.subject}\nAmount of topics: {this.GetAmountOfTopics()}\nTopics: {this.GetAllTopics()}";

        return result;
    }

    public int ShowPassScore()
    {
        return 60;
    }
}