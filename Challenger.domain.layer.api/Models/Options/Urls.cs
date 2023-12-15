namespace challenge.domain.layer.api.Models.Options
{
    public class Urls
    {
        public string CreateEvents { get; set; }
        public string DeleteEvents { get; set; }
        public string EditEvents { get; set; }
        public string GetEvents { get; set; }
        public string GetCalendars { get; set; }
        public string GetToken { get; set; }
        public string GetCode { get; set; }
        public string GetUsers { get; set; }

        public Urls()
        {
            CreateEvents =
            DeleteEvents =
            EditEvents =
            GetEvents =
            GetCalendars =
            GetToken =
            GetCode =
            GetUsers = string.Empty;
        }
    }
}
