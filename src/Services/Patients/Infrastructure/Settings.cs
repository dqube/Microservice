namespace CompanyName.MyProjectName.Patients.Infrastructure;

public class Settings
{
    public string BackgroundColor { get; set; }

    public int FontSize { get; set; }

    public Logging Logging { get; set; }

    public DateTime ReleaseDate { get; set; }

    public List<int> RolloutPercentage { get; set; }

    public bool UseDefaultRouting { get; set; }
}

public class Logging
{
    public Test Test { get; set; }

    public Prod Prod { get; set; }
}

public class Prod
{
    public string Level { get; set; }
}

public class Test
{
    public string Level { get; set; }
}
