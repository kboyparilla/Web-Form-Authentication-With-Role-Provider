using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Evolantis.Data;
using Evolantis.Data.OleDb;
using Evolantis.Lib.Extensions;

namespace Application.BusinessLogic
{
    public class UsersProcessor
    {
        public UsersModel Read(int id)
        {
            Database db = new Database(new Connection());
            UsersModel users = null;

            try
            {
                string sql = "SELECT * FROM Users WHERE UserID = @userid";
                db.Command.Parameters.AddWithValue("@userid", id);
                db.ExecuteReader(sql);

                while (db.Reader.Read()) {
                    users = new UsersModel()
                    {
                        ID = db.Reader.GetValue<int>("UserID"),
                        FirstName = db.Reader.GetValue("UserFirstName"),
                        LastName = db.Reader.GetValue("UserLastName"),
                        Email = db.Reader.GetValue("UserEmail"),
                        Username = db.Reader.GetValue("UserUserName"),
                        Password = db.Reader.GetValue("UserPassword"),
                        Status = db.Reader.GetValue<int>("UserStatus"),
                        Role = db.Reader.GetValue("UserType")                       
                    };
                }
            }
            catch { }
            finally
            {
                db.Close();
            }

            return users;
        }

        public UsersModel Login(string username)
        {
            Database db = new Database(new Connection());
            UsersModel users = null;

            try
            {
                string sql = "SELECT * FROM Users WHERE UserUserName = @user";
                db.Command.Parameters.AddWithValue("@user", username);
                db.ExecuteReader(sql);

                while (db.Reader.Read())
                {
                    users = new UsersModel()
                    {
                        ID = db.Reader.GetValue<int>("UserID"),
                        FirstName = db.Reader.GetValue("UserFirstName"),
                        LastName = db.Reader.GetValue("UserLastName"),
                        Email = db.Reader.GetValue("UserEmail"),
                        Username = db.Reader.GetValue("UserUserName"),
                        Password = db.Reader.GetValue("UserPassword"),
                        Status = db.Reader.GetValue<int>("UserStatus"),
                        Role = db.Reader.GetValue("UserType")
                    };
                }
            }
            catch { }
            finally
            {
                db.Close();
            }

            return users;
        }

        public int Add(UsersModel user)
        {
            Database db = new Database(new Connection());
            int retval = 0;

            try
            {
                string sql = "INSERT INTO Users(UserFirstName, UserLastName, UserEmail , UserUserName, UserPassword, UserType) VALUES (@UserFirstName, @UserLastName, @UserEmail , @UserUserName, @UserPassword, 'User')";
                db.Command.Parameters.AddWithValue("@UserFirstName", user.FirstName);
                db.Command.Parameters.AddWithValue("@UserLastName", user.LastName);
                db.Command.Parameters.AddWithValue("@UserEmail", user.Email);
                db.Command.Parameters.AddWithValue("@UserUserName", user.Username);
                db.Command.Parameters.AddWithValue("@UserPassword", user.Password);

                retval = (int)db.ExecuteScopeIdentity(sql);               
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Close();
            }

            return retval;
        }
    }
}
