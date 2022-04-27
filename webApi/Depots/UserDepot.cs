using LiteDB;
using LiteDB.Engine;
using webApi.Models;

namespace webApi.Depots
{
    public class UserDepot
    {
        String dbPath;

        public UserDepot(String dbPath)
        {
            this.dbPath = dbPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void Add(UserInfo info)
        {
            using (var db = new LiteDatabase(dbPath))
            {
                var users = db.GetCollection<UserInfo>();
                users.Insert(info);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        public void Delete(int userId)
        {
            using (var db = new LiteDatabase(dbPath))
            {
                var users = db.GetCollection<UserInfo>();
                users.Delete(userId);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserInfo> GetAll()
        {
            using (var db = new LiteDatabase(dbPath))
            {
                var users = db.GetCollection<UserInfo>();
                return users.FindAll().ToList();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void Update(UserInfo info)
        {
            using (var db = new LiteDatabase(dbPath))
            {
                var users = db.GetCollection<UserInfo>();
                users.Update(info);
            }
        }
    }
}
