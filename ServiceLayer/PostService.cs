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
        /// <summary>
        /// Create Post 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public OperationResult Add(POST obj, OperationContext context)
        {
            _postRepository.Add(obj);
            if (obj.Id == default(int))
            {
                
                return new OperationResult(OperationStatus.Failed, SLConstants.Messages.BASE_USER_ADD_FAILED, obj);

            }
            
            return new OperationResult(OperationStatus.Success, SLConstants.Messages.BASE_USER_ADD, obj);
        }
        /// <summary>
        /// get all post
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<POST> GetAll(OperationContext context)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// get post by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public POST GetById(int id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// delete post
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public OperationResult Remove(POST obj, OperationContext context)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
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
