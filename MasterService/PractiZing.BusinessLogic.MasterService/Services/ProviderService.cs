using PractiZing.Base.Common;
using PractiZing.Base.Entities.MasterService;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.MasterService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.Base.Service.MasterService;
using PractiZing.DataAccess.SecurityService;
using System;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.MasterService.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProviderRepository _providerRepository;
        private readonly ITransactionProvider _transactionProvider;

        public ProviderService(IUserRepository userRepository, IProviderRepository providerRepository, ITransactionProvider transactionProvider)
        {
            this._userRepository = userRepository;
            this._providerRepository = providerRepository;
            this._transactionProvider = transactionProvider;
        }

        public async Task<IProvider> AddProvider(IProvider entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                // when provider wants to be a user 
                if (entity.IsProviderAUser)
                    entity = await CreateUser(entity);

                var result = await this._providerRepository.AddNew(entity);
                this._transactionProvider.CommitTransaction(transactionId);
                return result;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        public async Task<int> Update(IProvider entity)
        {
            string transactionId = this._transactionProvider.StartTransaction(true);
            try
            {
                // when provider wants to be a user 
                if (entity.IsProviderAUser && !string.IsNullOrEmpty(entity.UserName) && !string.IsNullOrEmpty(entity.Password))
                    entity = await CreateUser(entity);

                var result = await this._providerRepository.Update(entity);
                this._transactionProvider.CommitTransaction(transactionId);
                return result;
            }
            catch
            {
                this._transactionProvider.RollbackTransaction(transactionId);
                throw;
            }
        }

        /// <summary>
        /// Create User when provider needs to be user it self.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private async Task<IProvider> CreateUser(IProvider entity)
        {
            IUser user = new User();
            user.UserName = entity.UserName;
            //user.UserPassword = (UTF8Encoding.UTF8.GetBytes(entity.Password));
            user.Password = entity.Password;
            user.FirstName = entity.FirstName;
            user.LastName = entity.LastName;
            user.Active = entity.IsActive;
            user.CanBill = true;
            user.DefaultBillFacilityId = entity.FacilityId;
            user.PositionId = 1;
            user = await this._userRepository.AddNew(user);

            entity.PUserId = Convert.ToInt16(user.Id);
            return entity;
        }
    }
}
