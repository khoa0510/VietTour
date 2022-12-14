using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using VietTour.Areas.Admin.Models;
using VietTour.Areas.Public.Models;
using VietTour.Areas.Shared.Models;
using VietTour.Data.Entities;

namespace VietTour.Data.Repositories
{
    public class UserRepository
    {
        private readonly ViettourContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ViettourContext viettourContext, IMapper mapper)
        {
            _context = viettourContext;
            _mapper = mapper;
        }

        public List<UserComponent> GetAll(int pageNumber, int pageSize, string? sortBy, string? search)
        {
            var users = _context.Users.AsNoTracking();
            if (!string.IsNullOrEmpty(search))
            {
                users = users.Where(u => u.Username.Contains(search));
            }
            List<User> userList;
            userList = users.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            List<UserComponent> userComponents = new();
            foreach (var user in userList)
            {
                var userComponent = _mapper.Map<UserComponent>(user);
                userComponents.Add(userComponent);
            }
            return userComponents;
        }

        public bool SignUp(SignUpViewModel signUpViewModel)
        {
            var user = _mapper.Map<User>(signUpViewModel);
            var users = _context.Users.SingleOrDefault(u => u.Phone == user.Phone);
            if (users != null) return false;

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            user.Admin = false;
            do
            {
                user.CookieId = RandomCookie();
            }
            while (_context.Users.SingleOrDefault(u => u.CookieId == user.CookieId) != null);

            _context.Add(user);
            _context.SaveChanges();
            return true;
        }

        public UserDetailViewModel? GetUserDetail(string cookieId)
        {
            var user = _context.Users.SingleOrDefault(u => u.CookieId == cookieId);
            if (user == null) return null;

            var userDetailViewModel = _mapper.Map<UserDetailViewModel>(user);
            userDetailViewModel.Password = "********************";
            return userDetailViewModel;
        }

        public bool EditUser(UserDetailViewModel userDetailViewModel, string cookieId)
        {
            var user = _context.Users.SingleOrDefault(u => u.CookieId == cookieId);
            if (user == null) return false;
            if (user.Username != userDetailViewModel.Username)
                user.Username = userDetailViewModel.Username;
            if (user.Email != userDetailViewModel.Email)
                user.Email = userDetailViewModel.Email;
            if (user.Phone != userDetailViewModel.Phone)
                user.Phone = userDetailViewModel.Phone;
            if (user.Address != userDetailViewModel.Address)
                user.Address = userDetailViewModel.Address;
            if (BCrypt.Net.BCrypt.Verify(userDetailViewModel.Password, user.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(userDetailViewModel.Password);
            _context.SaveChanges();
            return true;
        }

        public EditUserViewModel? GetUserDetail(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == id);
            if (user == null) return null;

            var editUserViewModel = _mapper.Map<EditUserViewModel>(user);
            editUserViewModel.Password = "********************";
            return editUserViewModel;
        }

        public bool EditUser(int userId, EditUserViewModel userDetailViewModel)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == userId);
            if (user == null) return false;
            if (user.Username != userDetailViewModel.Username)
                user.Username = userDetailViewModel.Username;
            if (user.Email != userDetailViewModel.Email)
                user.Email = userDetailViewModel.Email;
            if (user.Phone != userDetailViewModel.Phone)
                user.Phone = userDetailViewModel.Phone;
            if (user.Address != userDetailViewModel.Address)
                user.Address = userDetailViewModel.Address;
            if (!userDetailViewModel.Password.IsNullOrEmpty() && !BCrypt.Net.BCrypt.Verify(userDetailViewModel.Password, user.Password))
                user.Password = BCrypt.Net.BCrypt.HashPassword(userDetailViewModel.Password);
            _context.SaveChanges();
            return true;
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserId == id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public string RandomCookie()
        {
            Random random = new();

            String str = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int size = 20;
            String cookieId = "";

            for (int i = 0; i < size; i++)
            {
                int x = random.Next(62);
                cookieId += str[x];
            }
            return cookieId;
        }

        public User? VerifyPassword(LogInViewModel logInViewModel)
        {
            var user = _context.Users.SingleOrDefault(u => u.Phone == logInViewModel.Phone);
            if (user == null) return null;
            if (BCrypt.Net.BCrypt.Verify(logInViewModel.Password, user.Password))
                return user;
            return null;

        }
    }
}
