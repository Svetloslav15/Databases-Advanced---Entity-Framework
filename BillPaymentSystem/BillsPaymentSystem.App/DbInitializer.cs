using BillsPaymentSystem.Data;
using BillsSystem.Models;
using System.Collections;
using System.Collections.Generic;

namespace BillsPaymentSystem.App
{
    public class DbInitializer
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            SeedUsers(context);
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            string[] firstNames = { "Gosho", "Pesho", "Ivan", "Kiro" };
            string[] lastNames = { "Goshov", "Peshov", "Ivanov", "Kirov" };
            string[] emails = { "gosho@abv.bg", "pesho@abv.bg", "ivan@abv.bg", "kiro@abv.bg" };
            string[] passwords = { "gosho@abv.bg123", "pesho@abv.bg123", "ivan@abv.bg123", "kiro@abv.bg123" };

            IList<User> users = new List<User>();
            for (int i = 0; i < firstNames.Length; i++)
            {
                User user = new User
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = passwords[i]
                };
                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }
    }
}
