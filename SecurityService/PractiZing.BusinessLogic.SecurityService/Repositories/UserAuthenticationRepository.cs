using PractiZing.Api.Common.Authorize;
using PractiZing.Base.Entities.SecurityService;
using PractiZing.Base.Repositories.SecurityService;
using PractiZing.DataAccess.Common;
using PractiZing.DataAccess.SecurityService;
using PractiZing.DataAccess.SecurityService.Tables;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PractiZing.BusinessLogic.SecurityService.Repositories
{
    public class UserAuthenticationRepository
        : ModuleBaseRepository<UserAuthentication>, IUserAuthenticationRepository
    {
        public UserAuthenticationRepository(ValidationErrorCodes validationErrorCodes,
                                            DataBaseContext dbContext,
                                            ILoginUser loggedUser)
            : base(validationErrorCodes, dbContext, loggedUser)
        {
        }
        /// <summary>
        /// get logged data using unique small token
        /// </summary>
        /// <param name="smallToken">This smallToken is bearer token which is used for
        /// communicating front-end and back-end</param>
        /// <returns>this method will return UserAuthentication object which will have logged user detail
        /// like smallToken, real token, and request finger print</returns>
        public async Task<IUserAuthentication> Get(string smallToken)
        {
            var userAuth = await this.Connection.SingleAsync<UserAuthentication>(i => i.SmallToken == smallToken);

            return userAuth;
        }
        /// <summary>
        /// when application will be restarted then all the memory cache data will be reset
        /// using this method we will get all logget user data from db and set in memory cache
        /// this method will be called once when the application will be started
        /// </summary>
        /// <param name="practices">these are PracticeCentral Practices which are master practices</param>
        /// <returns>this method will retuen nothing but get all logged user deatils from each practices
        /// at start of the application and set to memory cache</returns>
        public async Task SetAllInCache(IEnumerable<IPracticeCentralPractice> practices)
        {
            try
            {
                await RemoveAllExpiredTokenFromCache(practices);

                foreach (var practice in practices)
                {
                    base.SetPracticeCode(practice.PracticeCode);
                    var userAuths = await this.Connection.SelectAsync<UserAuthentication>(i => i.CreatedDateTime> DateTime.Now.AddDays(-1));                    
                    foreach (var userAuth in userAuths)
                    {
                        MemoryCache.Set(userAuth.SmallToken, userAuth);
                    }

                    this.Connection.Close();
                }
            }
            catch(Exception ex)
            {

                throw;
            }
            finally
            {
                //base.DbContext?.Dispose();
                GC.Collect();
            }
           

        }
        /// <summary>
        /// this method will delete all the expried token from all practice databases as well as 
        /// memory chache
        /// </summary>
        /// <returns>this method will return coutnt of how many expired tokens are there and has been deleted</returns>
        public async Task<int> RemoveAllExpiredTokenFromCache(IEnumerable<IPracticeCentralPractice> practices)
        {
            try
            {
                var count = 0;
                foreach (var practice in practices)
                {
                    
                    base.SetPracticeCode(practice.PracticeCode);
                    var userAuths = await this.Connection.SelectAsync<UserAuthentication>(i => i.ExpiryDateTime < DateTime.Now);
                    var expiredSmallTokens = userAuths.Select(j => j.SmallToken).ToList();

                    if (expiredSmallTokens.Count > 0)
                    {
                        //base.SetPracticeCode(practice.PracticeCode);
                        count += await this.Connection.DeleteAsync<UserAuthentication>(i => expiredSmallTokens.Contains(i.SmallToken));
                        foreach (var smallToken in expiredSmallTokens)
                        {
                            MemoryCache.Remove(smallToken);
                        }                     
                    }

                    this.Connection.Close();

                }

                return count;
            }
            catch(Exception ex)
            {

                throw;
            }
            finally
            {
                //base.DbContext?.Dispose();
                GC.Collect();
            }
            
        }
        /// <summary>
        /// this method is called when roles and permissions of a user is modified
        /// </summary>
        /// <param name="userId">this is userId whom logged user changing the roles and permissions</param>
        /// <returns>this will return how many records are deleted. when roles and permissins of
        /// logged user changed then it will return 0 ,that means no record will be deleted.
        /// when userId is not as same as logged userId then it will return some count. that means will
        /// delete all logged user details by userId, as well as memory cache.</returns>
        public async Task<int> Delete(int userId)
        {
            int count = 0;
            if (userId == LoggedUser.Id)
                return count;

            var userAuths = await this.Connection.SelectAsync<UserAuthentication>(i => i.UserId == userId);
            if (userAuths.Count() > 0)
            {
                count = await this.Connection.DeleteAsync<UserAuthentication>(i => i.UserId == userId);
                foreach (var userAuth in userAuths)
                {
                    MemoryCache.Remove(userAuth.SmallToken);
                }
            }

            return count;
        }

        /// <summary>
        /// this method will be called when user will successfully logged in 
        /// and token generated
        /// </summary>
        /// <param name="userId">logged userId</param>
        /// <param name="token">this is real token which will be validated and claims will be gotten </param>
        /// <param name="expiryDateTime">this is the time when a token will be expired</param>
        /// <param name="fingerPrint">this is request finger print, will be same for same browser,
        /// same pc, and same mode</param>
        /// <param name="smallToken">this is token which will be used for communicating front-end and 
        /// back-end</param>
        /// <returns>this method will save logged user detail in database as well as memory cache
        /// when an user login.</returns>
        public async Task<IUserAuthentication> AddNew(int userId, string token, DateTime expiryDateTime, string fingerPrint, string smallToken)
        {
            try
            {
                UserAuthentication tEntity = new UserAuthentication();
                tEntity.UserId = userId;
                tEntity.Token = token;
                tEntity.ExpiryDateTime = expiryDateTime;
                tEntity.FingerPrint = fingerPrint;
                tEntity.CreatedDateTime = DateTime.Now;
                tEntity.SmallToken = smallToken;
                var result = await base.AddNewAsync(tEntity);
                MemoryCache.Set(result.SmallToken, result);
                return result;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// update expiryDateTime using unique smallToken this method will be called when
        /// token expiry datetime has been changed
        /// </summary>
        /// <param name="smallToken">this is token which will be used for communicating front-end and 
        /// back-end</param>
        /// <param name="expiryDateTime">this is the time when a token will be expired</param>
        /// <param name="token">this is real token which will be validated and claims will be gotten </param>
        /// <returns>This method will update Token and expiryDateTime by unique small token</returns>
        public async Task<int> Update(string smallToken, DateTime expiryDateTime, string token)
        {
            try
            {
                var tEntity = await this.Get(smallToken) as UserAuthentication;
                tEntity.SmallToken = smallToken;
                tEntity.Token = token;
                tEntity.ExpiryDateTime = expiryDateTime;
                var updateOnlyFields = this.Connection
                                           .From<UserAuthentication>()
                                           .Update(x => new
                                           {
                                               x.ExpiryDateTime,
                                               x.Token
                                           })
                                           .Where(i => i.SmallToken == smallToken);

                var result = await this.Connection.UpdateOnlyAsync(tEntity, updateOnlyFields);
                MemoryCache.Remove(smallToken);
                MemoryCache.Set(tEntity.SmallToken, tEntity);
                return result;
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// delete logged user data by using qnique small token
        /// first we will delete data from database and then we will delete from 
        /// local cache because, we get original token from memory cache on basis of this 
        /// unique small token
        /// </summary>
        /// <param name="smallToken">this is token which will be used for communicating front-end and 
        /// <returns>this will delete logged user detail from databse and memory cache by unique smalltoken</returns>
        public async Task<int> Delete(string smallToken)
        {
            try
            {
                var result = await this.Connection.DeleteAsync<UserAuthentication>(i => i.SmallToken == smallToken);
                MemoryCache.Remove(smallToken);
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
