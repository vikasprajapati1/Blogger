using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IService<T> where T : class
    {
        public OperationResult Add(T obj, OperationContext context);
        public OperationResult Remove(T obj, OperationContext context);
        public OperationResult Update(T obj, OperationContext context);
        public T GetById(int id);
        public IEnumerable<T> GetAll(OperationContext context);

       
    }
}
