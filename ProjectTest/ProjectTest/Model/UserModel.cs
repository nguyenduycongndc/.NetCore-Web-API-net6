using System.Text.Json.Serialization;

namespace ProjectTest.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public int IsActive { get; set; }
    }
    public class UserRsModel
    {
        public List<UserModel> Data { get; set; }
        public int Count { get; set; }
    }
    public class SearchUserModel
    {
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
        [JsonPropertyName("is_active")]
        public int IsActive { get; set; }
        [JsonPropertyName("start_number")]
        public int StartNumber { get; set; }
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }
    }
    public class CurrentUserModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public int IsActive { get; set; }
        public string Email { get; set; }
        public int? RoleId { get; set; }
    }
}
