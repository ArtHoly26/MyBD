using System.Text.Json;


namespace MyBD.DBConfigLib
{
    public class DbConfig
    {
        public string? Host { get; set; }
        public string? DataBase { get; set; }
        

        public override string ToString()
        {
            return $"Server={Host};Database={DataBase};";
        }
        public static DbConfig ImportFromJsonConfig(string path="db_config.json")
        {
            var json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<DbConfig>(json);
        }
    }
}
