using webApi.Models;

namespace webApi.Services
{
    /// <summary>
    /// 用户管理类
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="info"></param>
        void Add(UserInfo info);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="info"></param>
        void Update(UserInfo info);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userId"></param>
        void Delete(int userId);

        /// <summary>
        /// 查询全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserInfo> GetAll();


    }
}
