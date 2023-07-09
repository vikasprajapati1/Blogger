using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class SQLCommands
    {

        #region user
        public const string usp_User_Insert = @"INSERT INTO `User`(
                                                            FirstName ,
                                                            LastName ,
                                                            Status ,   
                                                            Email ,
                                                            Password ,
                                                            IsSuperAdmin ,
                                                            LastLogin,
                                                            Permissions,
                                                            CreatedBy,
                                                            CreatedOnUtc ,
                                                            CreatedIp,
                                                            UpdatedBy,
                                                            UpdatedOnUtc,
                                                            UpdatedIp     
                                                            ) VALUES (
                                                            @FirstName, 
                                                            @LastName, 
                                                            @Status,   
                                                            @Email, 
                                                            @Password, 
                                                            @IsSuperAdmin,
                                                            @LastLogin,
                                                            @Permissions,
                                                             @CreatedBy, 
                                                            @CreatedOnUtc,
                                                             @CreatedIp,
                                                            @UpdatedBy,
                                                            @UpdatedOnUtc,
                                                            @UpdatedIp 
                                                            );SELECT LAST_INSERT_ID();";

        #endregion

        #region Post
        public const string usp_Post_Add = @"INSERT INTO `Post`(
                                                            Title ,
                                                            Description ,
                                                            Content ,   
                                                            Status ,
                                                            CreatedBy,
                                                            CreatedOnUtc ,
                                                            CreatedIp,
                                                            UpdatedBy,
                                                            UpdatedOnUtc,
                                                            UpdatedIp     
                                                            ) VALUES (
                                                            @Title ,
                                                            @Description ,
                                                            @Content ,   
                                                            @Status ,
                                                            @CreatedBy, 
                                                            @CreatedOnUtc,
                                                            @CreatedIp,
                                                            @UpdatedBy,
                                                            @UpdatedOnUtc,
                                                            @UpdatedIp 
                                                            );SELECT LAST_INSERT_ID();";



        public const string usp_Post_GetById = @"Select * from `Post` where id=@Iid";
        public const string usp_Post_Delete= @"DELETE FROM Post WHERE Id = @Iid;";
        public const string usp_Post_Update = @"UPDATE  Post SET
                                                            Title = @Title ,
                                                            Description = @Description , 
                                                           Content = @Content,
Status=@Status,
                                                            CreatedBy = @CreatedBy ,
                                                            CreatedOnUtc = @CreatedOnUtc,
                                                            CreatedIp=@CreatedIp,
                                                            UpdatedBy = @UpdatedBy,
                                                            UpdatedOnUtc = @UpdatedOnUtc,
                                                            UpdatedIp = @UpdatedIp
                                                            WHERE
                                                            Id = @Iid";
        #endregion

    }
}
