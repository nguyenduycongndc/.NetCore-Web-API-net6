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
    //public class UserRsModel
    //{
    //    public List<UserModel> Data { get; set; }
    //    public int Count { get; set; }
    //}
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
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public int IsActive { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
    }
    public class CreateModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public int RoleId { get; set; }
    }
    public class LoginModel
    {
        //public string UserName { get; set; }

        public string Token { get; set; }
        public string Message { get; set; }
        public int Code { get; set; }
    }
    public class InputLoginModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
    public class UserCreateModel
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string SaltKey { get; set; }
        public int RoleId { get; set; }
        public int? CreatedBy { get; set; }
    }

    public class OutModel
    {
        public string UserName { get; set; }

        public string PassWord { get; set; }
    }
    public class UpdateModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public string FullName { get; set; }
    }
    public class UserUpdateModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int IsActive { get; set; }
        public string FullName { get; set; }
        public int ModifiedBy { get; set; }

    }
    public class UserUpdateOTPModel
    {
        public string Email { get; set; }
        public string OTP { get; set; }
        public DateTime Expdate { get; set; }
    }
    public class checkOTPModel
    {
        public string Email { get; set; }
        public string OTP { get; set; }
    }
    public class ForgotPassWordModel
    {
        public string Email { get; set; }
        public string OTP { get; set; }
        public string PassWordNew { get; set; }
        public string ConfirmPassWord { get; set; }
    }
    public class ChangePassWordModel
    {
        public string Email { get; set; }
        public string PassWordNew { get; set; }
        public string SaltKey { get; set; }
    }
    public class EmailModel
    {
        public string? Email { get; set; }
    }

    public class ExportUserModel
    {
        public List<UserModel> Data { get; set; }
        public int Count { get; set; }
        public string? Message { get; set; }
        public int Code { get; set; }
    }

    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }

    public class RegisterSaltModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string SaltKey { get; set; }
    }
    public class ChangePassWordLoginModel
    {
        public int? Id { get; set; }
        public string PassWordOld { get; set; }
        public string PassWordNew { get; set; }
        public string ConfirmPassWordNew { get; set; }
    }
    public class ChangePassWordLoginSuccessModel
    {
        public int Id { get; set; }
        public string PassWordNew { get; set; }
        public string SaltKey { get; set; }
    }
    public class GetDataDetailUserModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public int IsActive { get; set; }
        public string? Email { get; set; }
        public int? RoleId { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }
    public class RsDetailUserModel
    {
        public int Id { get; set; }
        public string? full_name { get; set; }
        public string? user_name { get; set; }
        public DateTime? date_of_joining { get; set; }
        public int roles_id { get; set; }
        public int is_active { get; set; }
        public string? email { get; set; }
        public DateTime? created_at { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
    }
}
