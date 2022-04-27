using webApi.Depots;
using webApi.Models;

namespace webApi.Services.impl
{
    /// <summary>
    /// 
    /// </summary>
    public class UserServiceImpl : IUserService
    {
        private readonly UserDepot userDepot;

        /// <summary>
        /// 
        /// </summary>
        public UserServiceImpl()
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "MyData.db");
            this.userDepot = new(dbPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void Add(UserInfo info)
        {
            userDepot.Add(info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void Delete(int userId)
        {
            userDepot.Delete(userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserInfo> GetAll()
        {
            return userDepot.GetAll();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void Update(UserInfo info)
        {
            userDepot.Update(info);
        }
    }
}
