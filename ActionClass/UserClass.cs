using LibraryAPI.ActionClass.Account;
using LibraryAPI.ActionClass.HelperClass.DTO;
using LibraryAPI.Contecst;
using LibraryAPI.Interfes;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.ActionClass
{
    public class UserClass : IUserRepository
    {
        private readonly LibraryContext _context;
        public UserClass(LibraryContext context) => _context = context;

        public List<string> AddAccount(AccountCreate account)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(account.FirstName))
                {
                    return new List<string> { "поле FirstName не заполнено" };
                }
                else if (account.FirstName.Length < 3)
                {
                    return new List<string> { "в поле FirstName не может быть меньше трёх символов" };
                }
                else if (account.FirstName == "string")
                {
                    return new List<string> { "не может быть string" };
                }

                if (string.IsNullOrWhiteSpace(account.LastName))
                {
                    return new List<string> { "поле LastName не заполнено" };
                }
                else if (account.LastName.Length < 3)
                {
                    return new List<string> { "в поле LastName не может быть меньше трёх символов" };
                }
                else if (account.LastName == "string")
                {
                    return new List<string> { "не может быть string" };
                }

                if (string.IsNullOrWhiteSpace(account.Login))
                {
                    return new List<string> { "поле Login не заполнено" };
                }
                else if (account.Login.Length < 3)
                {
                    return new List<string> { "в поле Login не может быть меньше трёх символов" };
                }
                else if (account.Login == "string")
                {
                    return new List<string> { "не может быть string" };
                }

                if (string.IsNullOrWhiteSpace(account.Password))
                {
                    return new List<string> { "поле Password не заполнено" };
                }
                else if (account.Password.Length < 8)
                {
                    return new List<string> { "в поле Password не может быть меньше восьми символов" };
                }
                else if (account.Password == "string")
                {
                    return new List<string> { "не может быть string" };
                }

                if (string.IsNullOrWhiteSpace(account.PhoneNumber))
                {
                    return new List<string> { "поле PhoneNumber не заполнено" };
                }
                else if (account.PhoneNumber == "string")
                {
                    return new List<string> { "не может быть string" };
                }

                if (string.IsNullOrWhiteSpace(account.Email))
                {
                    return new List<string> { "поле Email не заполнено" };
                }
                else if (account.Email == "string")
                {
                    return new List<string> { "не может быть string" };
                }

                if (string.IsNullOrWhiteSpace(account.PositionName))
                {
                    return new List<string> { "поле PositionName не заполнено" };
                }
                else if (account.PositionName == "string")
                {
                    return new List<string> { "не может быть string" };
                }

                User createUser = new User()
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,                    
                    DateOfBirth = account.DateOfBirth,
                    Login = account.Login,
                    Password = account.Password,
                    PhoneNumber = account.PhoneNumber,
                    Email = account.Email,
                    PositionName = account.PositionName,
                };

                _context.Users.Add(createUser);
                _context.SaveChanges();

                long userId = createUser.Id;
                return [$"Пользователь успешно создан Id - {userId}"];
            }
            catch
            {
                Results.BadRequest(new List<string> { "Ощибка в выполнении запроса"});
                throw;
            }
        }

        public List<string> DeleteUser(long id)
        {
            try
            {
                var uers = _context.Users.Find(id);

                if (uers == null)
                {
                    return new List<string> { "Пользователь не найден" };
                }

                var Loanssions = _context.Loans.Where(us => us.UserId == id).ToList();

                if (Loanssions.Any())
                {
                    _context.RemoveRange(Loanssions);
                    _context.SaveChanges();
                }
                if (uers != null)
                {
                    _context.Users.Remove(uers);
                    _context.SaveChanges();

                    return new List<string> { "Пользователь успешно удален" };
                }
                Results.NoContent();

                return new List<string> { "Операция завершена" };
            }
            catch
            {
                Results.BadRequest(new List<string> { "Ошибка в выполнении запроса" });
                throw;
            }

        }

        public List<AccountDTO> GetUser()
        {
            try
            {
                var data = _context.Users.Select(x => new AccountDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Login = x.Login,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    PositionName = x.PositionName,
                }
                ).ToList();
                return (List<AccountDTO>) data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<AccountDTO> GetUser(string login)
        {
            try
            {
                var data = _context.Users.Where(e => e.Login == login).Select(x => new AccountDTO
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Login = x.Login,
                    Password = x.Password,
                    PhoneNumber = x.PhoneNumber,
                    Email = x.Email,
                    PositionName = x.PositionName,
                }
                ).ToList();
                return (List<AccountDTO>)data;
            }
            catch
            {
                Results.BadRequest();
                throw;
            }
        }

        public List<string> UpdateUser(string login, AccountDTO user)
        {
            try
            {
                var userData = _context.Users.FirstOrDefault(x => x.Login == login);

                if(userData == null)
                {
                    Results.NoContent();
                    return [];
                }

                userData.FirstName = user.FirstName;
                userData.LastName = user.LastName;
                userData.Login = user.Login;
                userData.Password = user.Password;
                userData.PhoneNumber = user.PhoneNumber;
                userData.Email = user.Email;
                userData.PositionName = user.PositionName;

                _context.Users.Update(userData);
                _context.SaveChanges();

                Results.Ok();
                return ["Данные пользователя успешно обновлены"];
            }
            catch { Results.BadRequest(); throw; }
        }

        
    }
}
