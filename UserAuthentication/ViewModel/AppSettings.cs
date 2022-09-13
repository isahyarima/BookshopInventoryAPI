namespace Authentication.ViewModel
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string Environment { get; set; }
        public string SupportEmail { get; set; }
        public string SendGridApi { get; set; }
        public int tokenExpiryTime { get; set; }
    }
}
