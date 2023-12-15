namespace challenge.domain.layer.api.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string UserPrincipalName { get; set; }

        public UserDto()
        {
            Id = 
            DisplayName = 
            UserPrincipalName = string.Empty;
        }
    }
}
