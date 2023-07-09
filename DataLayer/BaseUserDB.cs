using Core.BusinessObject;
using Core.Repositories;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BaseUserDB : IBaseUserRepository
    {
        private readonly IConfiguration _configuration;

        public BaseUserDB(IConfiguration configuration)
        {
            _configuration = configuration;
            if (string.IsNullOrWhiteSpace(_configuration.GetConnectionString("DefaultConnection")))
            {
               // _logger.LogError("Connection string is missing. Cannot initialize the database");
                throw new ArgumentException("Connection string [DefaultConnection] is missing. Set it up in appsettings.json");

            }

        }

        public void Add(BaseUser user)
        {
          //  _logger.LogInformation("start Adding tenantSettings to DB");
            DbConnection con = ConnectionFactory.CreateConnection(_configuration);
            DbCommand cmd = con.GetSqlStringComamnd(SQLCommands.usp_User_Insert);
            con.Open();
           
            cmd.AddInParameterString("@FirstName", user.FirstName);
            cmd.AddInParameterString("@LastName", user.LastName);
           
            cmd.AddInParameterInt("@Status", user.Status);
            cmd.AddInParameterString("@Email", user.Email);
            cmd.AddInParameterString("@Password", user.Password);
            cmd.AddInParameterBool("@IsSuperAdmin", user.IsSuperAdmin);
  
            cmd.AddInParameterDateTime("@LastLogin", user.LastLogin);
            cmd.AddInParameterString("@Permissions", user.Permissions.ToString());
            user.AddCreateParams(cmd);
            user.Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            //_logger.LogInformation("Added User To DataBase Successfull");
        }

      
     
        public BaseUser GetById(int id)
        {
            throw new NotImplementedException();
        }

       
        public void Remove(BaseUser entity)
        {
            throw new NotImplementedException();
        }


        public void Update(BaseUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
