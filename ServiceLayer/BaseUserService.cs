using Core.BusinessObject;
using Core;
using Core.Repositories;
using Core.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class BaseUserService :IBaseUserService
    {
        private readonly IBaseUserRepository _baseUserRepository;

        public BaseUserService(IBaseUserRepository baseUserRepository)
        {
            
            _baseUserRepository = baseUserRepository;
        }

        /// <summary>
        /// Adding a base user object through Add method
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public OperationResult Add(BaseUser obj, OperationContext context)
        {
            //_logger.LogInformation("Adding BaseUser from ServiceLayer");
            _baseUserRepository.Add(obj);
            if (obj.Id == default(int))
            {
               // _logger.LogInformation($"Failed to Add BaseUser from ServiceLayer{obj.Id}");
                return new OperationResult(OperationStatus.Failed, SLConstants.Messages.BASE_USER_ADD_FAILED, obj);

            }
           // _logger.LogInformation("Added BaseUser from ServiceLayer successfully");
            return new OperationResult(OperationStatus.Success, SLConstants.Messages.BASE_USER_ADD, obj);
        }
        /// <summary>
        /// Fetching all base users through GetAll method
        /// </summary>
        /// <returns></returns>
        public IEnumerable<BaseUser> GetAll(OperationContext context)
        {
            //_logger.LogInformation("Getting All BaseUser from ServiceLayer");
            // _logger.LogInformation("Got All BaseUsers from ServiceLayer");
            throw new NotImplementedException();
        }

        public BaseUser GetByEmail(string email)
        {
            return _baseUserRepository.GetByEmail(email);
        }

        /// <summary>
        /// Fetching a base user by Id through GetById method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BaseUser GetById(int id)
        {
           // _logger.LogInformation("Fetching BaseUser from ServiceLayer ById");
           // _logger.LogInformation("Fetched BaseUser from ServiceLayer ById");
            return _baseUserRepository.GetById(id);
        }

        /// <summary>
        /// Remove a base user by Remove method
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public OperationResult Remove(BaseUser obj, OperationContext context)
        {
           // _logger.LogInformation("Removing BaseUser from ServiceLayer");
            if (obj.Id != default(int))
            {
                //_logger.LogInformation($"Failed to remove BaseUser from ServiceLayer{obj.Id}");
                return new OperationResult(OperationStatus.Failed, SLConstants.Messages.BASE_USER_DELETE_FAILED, obj);
            }
            _baseUserRepository.Remove(obj);
           // _logger.LogInformation("Removed BaseUser from ServiceLayer successfully");
            return new OperationResult(OperationStatus.Success, SLConstants.Messages.BASE_USER_DELETE_SUCCESS, obj);
        }
        /// <summary>
        /// Update a base user through Update method
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public OperationResult Update(BaseUser obj, OperationContext context)
        {
           // _logger.LogInformation("Updating BaseUser from ServiceLayer");
            if (obj == null)
            {
               // _logger.LogInformation($"Failed to update BaseUser from ServiceLayer");
                return new OperationResult(OperationStatus.Failed, SLConstants.Messages.BASE_USER_UPDATE_FAILED, obj);
            }
            _baseUserRepository.Update(obj);
          //  _logger.LogInformation("Updated BaseUser from ServiceLayer successfully");
            return new OperationResult(OperationStatus.Success, SLConstants.Messages.BASE_USER_UPDATE_SUCCESS, obj);
        }



      
    }
}
