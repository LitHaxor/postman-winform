﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Postman.DataAccess;
using Postman.Models;
using Postman.Repository;
namespace Postman.Repository
{
    public class UserRepository
    {
        // Login
        AccountRepository acc = new AccountRepository();
        public bool VerifyUser (string email, string password)
        {
            var result = ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE email=@email and password=@password;", new { email, password });
            if(result.Count ==1) return true;
            return false;
        }

        public User GetUserInfo(string email)
        {
            return ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE email=@email ;", new { email }).SingleOrDefault();
        }

        public List<User> GetAll()
        {
            return ConnectionDB.SelectQuery<User>("SELECT * FROM users;").ToList();
        }

        public string RegisterUser (User user)
        {
            var result = ConnectionDB.SelectQuery<User>("SELECT * FROM users WHERE email=@email;", new { user.email });
            if (result.Count == 1) return "duplicate";
            var query = ConnectionDB.ExecuteQuery("INSERT INTO users VALUES (@name, @email,@password,@userRole, @phone, @pickupLocation);", new { user.name, user.email, user.password, user.userRole, user.phone, user.pickupLocation });
            if (query > 0)
            {
                acc.CreateOne(this.GetUserInfo(user.email).id);
                return "success";
            }
            return "failed";
        }

        public int? UpdateUser(User user, int id)
        {
            if (user.password != null)
            {
                return ConnectionDB.ExecuteQuery(@"UPDATE users
			                                            SET  
				                                            name = @name,
				                                            email = @email,
				                                            password=@password,
				                                            pickupLocation = @pickupLocation
			                                            WHERE id=@id;",
                                                        new {user.name, user.email, user.password, user.pickupLocation, id });
            }
            return ConnectionDB.ExecuteQuery(@"UPDATE users
			                                            SET  
				                                            name = @name,
				                                            email = @email,
				                                            pickupLocation = @pickupLocation
			                                            WHERE id=@id;",
                                                       new { user.name, user.email,user.pickupLocation, id });
        }
    }
}
