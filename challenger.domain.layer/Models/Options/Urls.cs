namespace challenge.domain.layer.Models.Options
{
    public class Urls
    {
        public string CreateEvents { get; set; }
        public string DeleteEvents { get; set; }
        public string EditEvents { get; set; }
        public string GetEvents { get; set; }
        public string GetToken { get; set; }
        public string GetCode { get; set; }
        public string GetUsers { get; set; }

        public Urls()
        {
            CreateEvents =
            DeleteEvents =
            EditEvents =
            GetEvents =
            GetToken =
            GetCode =
            GetUsers = string.Empty;
        }
    }
}
