using Core;
using Core.BusinessObject;
using Core.Repositories;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public OperationResult Add(POST obj, OperationContext context)
        {
            _postRepository.Add(obj);
            if (obj.Id == default(int))
            {
                
                return new OperationResult(OperationStatus.Failed, SLConstants.Messages.BASE_USER_ADD_FAILED, obj);

            }
            
            return new OperationResult(OperationStatus.Success, SLConstants.Messages.BASE_USER_ADD, obj);
        }

        public IEnumerable<POST> GetAll(OperationContext context)
        {
            throw new NotImplementedException();
        }

        public POST GetById(int id)
        {
            throw new NotImplementedException();
        }

        public OperationResult Remove(POST obj, OperationContext context)
        {
            throw new NotImplementedException();
        }

        public OperationResult Update(POST obj, OperationContext context)
        {
            throw new NotImplementedException();
        }
        public List<POST> GetAll()
        {
            List<POST> posts = new List<POST>();

            posts = _postRepository.GetAll();
            return posts;
        }
    }
}
