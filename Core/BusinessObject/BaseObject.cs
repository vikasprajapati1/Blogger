using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessObject
{
    [Serializable]
    public abstract class BaseObject
    {
        #region Properties

        public int Id { get; set; }

        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public string CreatedIp { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
        public string IPAddress { get; set; }
        public string UpdatedIp { get; set; }
        public DateTime RowVersion { get; set; }


        #endregion Properties


        public BaseObject()
        {

        }
        public BaseObject(int id)
        {
            Id = id;
        }


        public BaseObject(int id, string createdBy, DateTime createdOnUtc, string createdIp, string updatedBy, DateTime updatedOnUtc, string updatedIp, DateTime rowVersion)
        {
            Id = id;
            CreatedBy = createdBy;
            CreatedOnUtc = createdOnUtc;
            CreatedIp = createdIp;
            UpdatedBy = updatedBy;
            UpdatedOnUtc = updatedOnUtc;
            UpdatedIp = updatedIp;
            RowVersion = rowVersion;


        }


        #region BaseReader
        public BaseObject(IDataReader reader)
        {
            Id = DBNull.Value != reader["Id"] ? (int)reader["Id"] : default(int);
            CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
            CreatedOnUtc = DBNull.Value != reader["CreatedOnUtc"] ? (DateTime)reader["CreatedOnUtc"] : default(DateTime);
            CreatedIp = DBNull.Value != reader["CreatedIp"] ? (string)reader["CreatedIp"] : default(string);
            UpdatedBy = DBNull.Value != reader["UpdatedBy"] ? (string)reader["UpdatedBy"] : default(string);
            UpdatedOnUtc = DBNull.Value != reader["UpdatedOnUtc"] ? (DateTime)reader["UpdatedOnUtc"] : default(DateTime);
            UpdatedIp = DBNull.Value != reader["UpdatedIp"] ? (string)reader["UpdatedIp"] : default(string);

            if (DBNull.Value != reader["RowVersion"]) RowVersion = (DateTime)reader["RowVersion"];
        }
        #endregion

        public BaseObject(DataRow row)
        {
            Id = DBNull.Value != row["Id"] ? (int)row["Id"] : 0;
            CreatedBy = DBNull.Value != row["CreatedBy"] ? (string)row["CreatedBy"] : default(string);
            CreatedOnUtc = DBNull.Value != row["CreatedOnUtc"] ? (DateTime)row["CreatedOnUtc"] : default(DateTime);
            CreatedIp = DBNull.Value != row["CreatedIp"] ? (string)row["CreatedIp"] : default(string);
            UpdatedBy = DBNull.Value != row["UpdatedBy"] ? (string)row["UpdatedBy"] : default(string);
            UpdatedOnUtc = DBNull.Value != row["UpdatedOnUtc"] ? (DateTime)row["UpdatedOnUtc"] : default(DateTime);
            UpdatedIp = DBNull.Value != row["UpdatedIp"] ? (string)row["UpdatedIp"] : default(string);
            if (DBNull.Value != row["RowVersion"]) RowVersion = (DateTime)row["RowVersion"];
        }
        public BaseObject(BaseObject obj)
        {
            Id = obj.Id;
            CreatedBy = obj.CreatedBy;
            CreatedOnUtc = obj.CreatedOnUtc;
            CreatedIp = obj.CreatedIp;
            UpdatedBy = obj.UpdatedBy;
            UpdatedOnUtc = obj.UpdatedOnUtc;
            UpdatedIp = obj.UpdatedIp;
            RowVersion = obj.RowVersion;

        }

        public BaseObject(DataColumnCollection columns, DataRow row)
        {
            Id = (columns["Id"] != null && DBNull.Value != row["Id"]) ? (int)row["Id"] : 0;
            CreatedBy = (columns["CreatedBy"] != null && DBNull.Value != row["CreatedBy"]) ? (string)row["CreatedBy"] : default(string);
            CreatedOnUtc = (columns["CreatedOnUtc"] != null && DBNull.Value != row["CreatedOnUtc"]) ? row.ToDateTime("CreatedOnUtc") : default(DateTime);
            CreatedIp = (columns["CreatedIp"] != null && DBNull.Value != row["CreatedIp"]) ? (string)row["CreatedIp"] : default(string);
            UpdatedBy = (columns["UpdatedBy"] != null && DBNull.Value != row["UpdatedBy"]) ? (string)row["UpdatedBy"] : default(string);
            UpdatedOnUtc = (columns["UpdatedOnUtc"] != null && DBNull.Value != row["UpdatedOnUtc"]) ? row.ToDateTime("UpdatedOnUtc") : default(DateTime);
            UpdatedIp = (columns["UpdatedIp"] != null && DBNull.Value != row["UpdatedIp"]) ? (string)row["UpdatedIp"] : default(string);
            RowVersion = (columns["RowVersion"] != null && DBNull.Value != row["RowVersion"]) ? row.ToDateTime("RowVersion") : default(DateTime);
        }

        public BaseObject(int id, string createdBy, DateTime createdOnUtc, string updatedBy, DateTime updatedOnUtc, DateTime rowVersion) : this(id)
        {
        }

        protected BaseObject(string createdBy, DateTime createdOnUtc, string createdIp, string updatedBy, DateTime updatedOnUtc, string updatedIp, DateTime rowVersion)
        {
            CreatedBy = createdBy;
            CreatedOnUtc = createdOnUtc;
            CreatedIp = createdIp;
            UpdatedBy = updatedBy;
            UpdatedOnUtc = updatedOnUtc;
            UpdatedIp = updatedIp;
            RowVersion = rowVersion;
        }
    }
}
