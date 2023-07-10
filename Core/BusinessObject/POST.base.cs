using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BusinessObject
{
    public partial class POST:BaseObject
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public string Content { get; set; }
        public int Status { get; set; }    
        public int AuthorId { get; set; }
        public string Tags { get; set; }
        public POST() { }

        public POST(IDataReader reader) : base(reader)
        {
           
            Title = DBNull.Value != reader["Title"] ? (string)reader["Title"] : default(string);
            Description = DBNull.Value != reader["Description"] ? (string)reader["Description"] : default(string);
            Content = DBNull.Value != reader["Content"] ? (string)reader["Content"] : default(string);
            Status = DBNull.Value != reader["Status"] ? (int)reader["Status"] : default(int);
            Tags = DBNull.Value != reader["Tags"] ? (string)reader["Tags"] : default(string);
            AuthorId = DBNull.Value != reader["AuthorId"] ? (int)reader["AuthorId"] : default(int);
           
           
        }
    }
}
