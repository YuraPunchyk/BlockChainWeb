using BlockChainWeb.Models.HellperClasses;

namespace BlockChainWeb.Models.Person
{
    public class Admin : User
    {
        public Admin(string login, string password, string email, string fullname) : base(login,password,email,fullname,Role.Admin)
        {

        }
    }
}
