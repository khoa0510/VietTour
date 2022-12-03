using VietTour.Data.Entities;

namespace VietTour.Data.Repositories
{
    public class UserRepository
	{
		private readonly ViettourContext _context;

		public UserRepository(ViettourContext viettourContext)
		{
			_context = viettourContext;
		}

		public bool SignUp(User user)
		{
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

		public User VerifyPassword(User user)
		{
			var users = _context.Users.SingleOrDefault(u => u.Phone == user.Phone);
			if (users != null)
			{
				if( BCrypt.Net.BCrypt.Verify(user.Password, users.Password))
					return users;
			}
			return null;
		}
        public User GetUserDetail(string cookieId)
        {
            var users = _context.Users.SingleOrDefault(u => u.CookieId == cookieId);
            if (users != null)
            {
				users.Password = "********************";
				return users;
            } else
            return null;
        }

		public bool EditUser(User user)
		{
            var users = _context.Users.SingleOrDefault(u => u.CookieId == user.CookieId);
			if (users == null)
			{
				return false;
			} else
			{
				if (users.Username != user.Username)
					users.Username = user.Username;
				if (users.Email != user.Email)
					users.Email = user.Email;
				if (users.Phone != user.Phone)
                    users.Phone = user.Phone;
				if (users.Address != user.Address)
                    users.Address = user.Address;
                if (BCrypt.Net.BCrypt.Verify(user.Password, users.Password))
                    users.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
                _context.SaveChanges();
                return true;
            }
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
                cookieId = cookieId + str[x];
            }
			return cookieId;
        }
	}
}
