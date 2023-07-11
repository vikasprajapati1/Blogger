using Core.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IPostRepository:IRepository<POST>
    {
       List<POST> GetAll();
    }
}
