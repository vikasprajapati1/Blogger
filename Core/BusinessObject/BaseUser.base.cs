using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessObject
{
    public partial class BaseUser : BaseObject
    {
        #region Properties

        [StringLength(50, ErrorMessage = "Max 50 characters allowed.")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Max 100 characters allowed.")]
        public string LastName { get; set; }

        /// <summary>
        /// Holds the value of email of user
        /// </summary>
        [Required(ErrorMessage = "Please enter email id.")]
        [EmailAddress(ErrorMessage = "Please enter valid email id")]
        [StringLength(50, ErrorMessage = "Max 50 characters are allowed.")]
        public string Email { get; set; }

        /// <summary>
        /// Holds the value of password of user phone
        /// </summary>
        public string Password { get; set; }
      

        /// <summary>
        /// Holds the Permissions of User
        /// </summary>
        public int Permissions { get; set; }

        /// <summary>
        /// Holds the status of User
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Holds the value of User SuperAdmin or not
        /// </summary>
        public bool IsSuperAdmin { get; set; }

        /// <summary>
        /// Store the value of user last logged in
        /// </summary>
        public DateTime LastLogin { get; set; }

        #endregion Properties

        #region Methods

        public string ToJSON()
        {
            return JsonConvert.SerializeObject(this);
        }
        public override string ToString()
        {
            return Id.ToString();
        }

        public BaseUser()
        {
        }

        public BaseUser(int id, int tenantId)
            : base(id)
        {
        }

        public BaseUser(int id, string firstName, string lastName, string email, string password, int permissions, int status, bool isSuperAdmin, DateTime lastLogin, string createdBy, DateTime createdOnUtc, string CreatedIp, string updatedBy, DateTime updatedOnUtc, string UpdatedIp, DateTime rowVersion)
            : base(id, createdBy, createdOnUtc, CreatedIp, updatedBy, updatedOnUtc, UpdatedIp, rowVersion)
        {
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
         
            Permissions = permissions;
            IsSuperAdmin = isSuperAdmin;
            LastLogin = lastLogin;
            Status = status;
        }

        public BaseUser(IDataReader reader)
            : base(reader)
        {
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            FirstName = DBNull.Value != reader["FirstName"] ? (string)reader["FirstName"] : default(string);
            LastName = DBNull.Value != reader["LastName"] ? (string)reader["LastName"] : default(string);
            Email = DBNull.Value != reader["Email"] ? (string)reader["Email"] : default(string);
            Password = DBNull.Value != reader["Password"] ? (string)reader["Password"] : default(string);
           
            Permissions = DBNull.Value != reader["Permissions"] ? (int)reader["Permissions"] : default(int);
            Status = DBNull.Value != reader["Status"] ? (int)reader["Status"] : default(int);
            IsSuperAdmin = DBNull.Value != reader["IsSuperAdmin"] ? reader.GetBoolean(reader.GetOrdinal("IsSuperAdmin")) : default(bool);
            LastLogin = DBNull.Value != reader["LastLogin"] ? (DateTime)reader["LastLogin"] : default(DateTime);
        }

        public BaseUser(DataRow row)
            : base(row)
        {
            Email = DBNull.Value != row["Email"] ? (string)row["Email"] : default(string);
            FirstName = DBNull.Value != row["FirstName"] ? (string)row["FirstName"] : default(string);
            LastName = DBNull.Value != row["LastName"] ? (string)row["LastName"] : default(string);
            Password = DBNull.Value != row["Password"] ? (string)row["Password"] : default(string);
           
            Permissions = DBNull.Value != row["Permissions"] ? (int)row["Permissions"] : default(int);
            Status = DBNull.Value != row["Status"] ? (int)row["Status"] : default(int);
            IsSuperAdmin = DBNull.Value != row["IsSuperAdmin"] ? (bool)row["IsSuperAdmin"] : default(bool);
            LastLogin = DBNull.Value != row["LastLogin"] ? (DateTime)row["LastLogin"] : default(DateTime);
        }

        public BaseUser(DataColumnCollection columns, DataRow row)
            : base(columns, row)
        {
            Email = (columns["Email"] != null && DBNull.Value != row["Email"]) ? (string)row["Email"] : default(string);
            FirstName = (columns["FirstName"] != null && DBNull.Value != row["FirstName"]) ? (string)row["FirstName"] : default(string);
            LastName = (columns["LastName"] != null && DBNull.Value != row["LastName"]) ? (string)row["LastName"] : default(string);
            Password = (columns["Password"] != null && DBNull.Value != row["Password"]) ? (string)row["Password"] : default(string);
           
            Permissions = (columns["Permissions"] != null && DBNull.Value != row["Permissions"]) ? row.ToInt32("Permissions") : default(int);
            Status = (columns["Status"] != null && DBNull.Value != row["Status"]) ? row.ToInt32("Status") : default(int);
            IsSuperAdmin = (columns["IsSuperAdmin"] != null && DBNull.Value != row["IsSuperAdmin"]) ? row.ToBoolean("IsSuperAdmin") : default(bool);
            LastLogin = (columns["LastLogin"] != null && DBNull.Value != row["LastLogin"]) ? row.ToDateTime("LastLogin") : default(DateTime);
        }

        public BaseUser(BaseUser user)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Password = user.Password;
           
            Permissions = user.Permissions;
            Status = user.Status;
            IsSuperAdmin = user.IsSuperAdmin;
            LastLogin = user.LastLogin;
        }

        public BaseUser Clone()
        {
            return (BaseUser)this.MemberwiseClone();
        }

        #endregion Methods
    }
}
