using Core.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IBaseUserService:IService<BaseUser>
    {
     public  BaseUser GetByEmail(string email);
    }
}
