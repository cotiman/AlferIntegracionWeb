namespace MySqlWooSyncApp
{
    public class Config
    {
        public string MySqlHost { get; set; }
        public int MySqlPort { get; set; } = 3306;
        public string MySqlDatabase { get; set; }
        public string MySqlUser { get; set; }
        public string MySqlPassword { get; set; }
        public string MySqlQuery { get; set; }
        public int SyncIntervalMinutes { get; set; } = 10;
        public string WooUrl { get; set; }
        public string WooKey { get; set; }
        public string WooSecret { get; set; }
        public int RequestTimeoutSeconds { get; set; } = 120;
    }
}
