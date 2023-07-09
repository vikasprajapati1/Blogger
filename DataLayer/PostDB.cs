using Core.BusinessObject;
using Core.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class PostDB:IPostRepository
    {
        private readonly IConfiguration _configuration;

        public PostDB(IConfiguration configuration)
        {
            _configuration = configuration;
            if (string.IsNullOrWhiteSpace(_configuration.GetConnectionString("DefaultConnection")))
            {
                // _logger.LogError("Connection string is missing. Cannot initialize the database");
                throw new ArgumentException("Connection string [DefaultConnection] is missing. Set it up in appsettings.json");

            }

        }

        public void Add(POST post)
        {
            //  _logger.LogInformation("start Adding tenantSettings to DB");
            DbConnection con = ConnectionFactory.CreateConnection(_configuration);
            DbCommand cmd = con.GetSqlStringComamnd(SQLCommands.usp_Post_Add);
            con.Open();

            cmd.AddInParameterString("@Title", post.Title);
            cmd.AddInParameterString("@Description", post.Description);
            cmd.AddInParameterString("@Content", post.Content);
            cmd.AddInParameterInt("@Status", post.Status);
        
            post.AddCreateParams(cmd);
            post.Id = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            //_logger.LogInformation("Added User To DataBase Successfull");
        }


        public POST GetById(int id)
        {
            //_logger.LogInformation($"BrandDB.cs - GetById method - Populating brand details from database {id}");
            DbConnection con = ConnectionFactory.CreateConnection(_configuration);
            DbCommand db = con.GetSqlStringComamnd(SQLCommands.usp_Post_GetById);
            con.Open();
            db.AddInParameterInt("@Iid", id);
            IDataReader reader = db.ExecuteReader();
            POST post = null;
            while (reader.Read())
            {
                post = new POST(reader);
               
            }
            reader.Close();
            con.Close();
           // _logger.LogInformation($"BrandDB.cs - GetById method - Populated details for Brands from database {id}");
            return post;
        }

        public void Remove(POST entity)
        {
           // _logger.LogInformation($"BrandDB.cs - Remove method - Deleting Brand from database {brand}");
            DbConnection con = ConnectionFactory.CreateConnection(_configuration);
            con.Open();
            DbCommand db = con.GetSqlStringComamnd(SQLCommands.usp_Post_Delete);
            db.AddInParameterInt("@Iid", entity.Id);
            db.ExecuteNonQuery();
            con.Close();
           // _logger.LogInformation($"BrandDB.cs - Remove method - Delete Brand from database {brand}");
        }

        public void Update(POST post)
        {
           // logger.LogInformation($"BrandDB.cs - Update method - Updating Brand in database {Brand}");
            DbConnection con = ConnectionFactory.CreateConnection(_configuration);
            DbCommand db = con.GetSqlStringComamnd(SQLCommands.usp_Brand_Update);
            con.Open();
            db.AddInParameterString("@Title", post.Title);
            db.AddInParameterString("@Description", post.Description);
            db.AddInParameterString("@Content", post.Content);
            db.AddInParameterString("@Tags", post.Tags);
            db.AddInParameterInt("@AuthorId",post.AuthorId);    
            db.AddInParameterInt("@Status", post.Status);
            db.AddInParameterInt("@Iid", post.Id);
            post.AddUpdateParams(db);
            db.ExecuteNonQuery();
            con.Close();
           // _logger.LogInformation($"BrandDB.cs - Update method - Updated Brand in database{Brand}");
        }
    }
}
