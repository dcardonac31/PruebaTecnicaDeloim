using System;

namespace PruebaTecnicaDeloimBackend.Common.Dtos
{
    public class RegisterUser : UserInfo
    {
        public string Email { get; set; }
        public Guid Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string NickName { get; set; }

    }
}
