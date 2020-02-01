using BlockChainWeb.Models.HellperClasses;

namespace BlockChainWeb.Models.Person
{
    public class Admin : User
    {
        public Admin(string id, string email, string fullname) : base(id,email,fullname,Role.Admin)
        {

        }
    }
}
