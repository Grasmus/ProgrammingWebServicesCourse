namespace TrainStation.Services.Configurations
{
    public class EmailConfiguration
    {
        public string From { get; set; }
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string DefaultSubject { get; set; }
        public string DefaultContent { get; set; }
        public string DefaultName { get; set; }
    }
}
