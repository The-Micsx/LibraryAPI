using LibraryAPI.Models;
using Microsoft.Identity.Client;
using LibraryAPI.ActionClass.HelperClass.DTO;
using LibraryAPI.ActionClass.Account;

namespace LibraryAPI.Interfes
{
    public interface IUserRepository
    {
        public List<AccountDTO> GetUser();
        public List<AccountDTO> GetUser(string login);
        public List<string> AddAccount(AccountCreate account);
        public List<string> UpdateUser(string login, AccountDTO user);
        public List<string> DeleteUser(long id);
    }
}

