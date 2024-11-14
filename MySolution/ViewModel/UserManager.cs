using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Model;

namespace ViewModel
{
    public class UserManager : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;
            if (user == null) return null;

            user.Username = reader["Username"].ToString();
            user.Email = reader["Email"].ToString();
            user.PasswordHash = reader["PasswordHash"].ToString();
            user.IsAdvanced = Convert.ToBoolean(reader["IsAdvanced"]);  
            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM Users"; // Sample SQL query
            List<BaseEntity> result = ExecuteCommand();
            return new UserList(result.Cast<User>());
        }

        public int Insert(User user)
        {
            command.CommandText = "INSERT INTO Users (Username, Email, PasswordHash, IsAdvanced) VALUES (@Username, @Email, @PasswordHash, @IsAdvanced)";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@IsAdvanced", user.IsAdvanced);

            return ExecuteNonQuery();
        }

        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM Users WHERE Id = @Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", id);
            UserList list = new UserList(ExecuteCommand());
            return list.Count > 0 ? list[0] : null;
        }

        public bool IsUsernameAvailable(string username)
        {
            command.CommandText = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Username", username);

            int count = Convert.ToInt32(ExecuteScalar());
            return count == 0;
        }
        
        public int Update(User user)
        {
            command.CommandText = "UPDATE Users SET Username = @Username, Email = @Email, PasswordHash = @PasswordHash, IsAdvanced = @IsAdvanced WHERE Id = @Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", user.Id);
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@PasswordHash", user.PasswordHash);
            command.Parameters.AddWithValue("@IsAdvanced", user.IsAdvanced); 

            return ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            command.CommandText = "DELETE FROM Users WHERE Id = @Id";
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@Id", id);
            return ExecuteNonQuery();
        }
    }
}
