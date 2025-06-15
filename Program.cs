using System;
public class SettingsManager
{
    private static SettingsManager _instance;
    private static readonly object _lock = new object();
    public string Theme { get; set; }
    public string Language { get; set; }
    private SettingsManager()
    {
        Theme = "Light";
        Language = "Ukrainian";
    }
    public static SettingsManager Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new SettingsManager();
                return _instance;
            }
        }
    }
    public void PrintSettings()
    {
        Console.WriteLine($"Theme: {Theme}, Language: {Language}");
    }
}
class Program
{
    static void Main()
    {
        var settings1 = SettingsManager.Instance;
        settings1.PrintSettings();
        settings1.Theme = "Dark";
        settings1.Language = "English";

        var settings2 = SettingsManager.Instance;
        settings2.PrintSettings();
    }
}