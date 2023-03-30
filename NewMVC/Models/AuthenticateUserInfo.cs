namespace NewMVC.Models
{
    public class AuthenticateUserInfo
    {
        public AccessRights accessRights { get; set; }
        public ADAttributes adAttributes { get; set; }
        public OktaAttributes oktaAttributes { get; set; }
        public bool IsPublic { get; set; }
        public int AuthenticateType { get; set; }
    }
}
