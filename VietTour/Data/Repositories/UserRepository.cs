using Microsoft.AspNetCore.Identity;
using VietTour.Models.Entities;

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
			string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
			user.Password = passwordHash;
			_context.Add(user);
			_context.SaveChanges();
			return true;
		}

		public int VerifyPassword(User user)
		{
			var users = _context.Users.SingleOrDefault(u => u.Email == user.Email);
			if (users != null)
			{
				if( BCrypt.Net.BCrypt.Verify(user.Password, users.Password))
					return users.UserId;
			}
			return 0;
		}
	}
}
