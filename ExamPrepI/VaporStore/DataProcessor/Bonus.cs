namespace VaporStore.DataProcessor
{
	using System;
    using System.Linq;
    using Data;
    using VaporStore.Data.Models;

    public static class Bonus
	{
		public static string UpdateEmail(VaporStoreDbContext context, string username, string newEmail)
		{
            User user = context.Users.FirstOrDefault(x => x.Username == username);

            if (user == null)
            {
                return $"User {username} not found";
            }
            user = context.Users.FirstOrDefault(x => x.Email == newEmail);

            if (user != null)
            {
                return $"Email {newEmail} is already taken";
            }
            user.Email = newEmail;
            context.SaveChanges();

            return $"Changed {username}'s email successfully";
        }
	}
}
