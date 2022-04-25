using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using webApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webApi.Controllers
{
    //struct根据内容大小占用内存,IO小,GC小
    struct Record {
        public int Id;
        public string Name;
        public DateTime dt;

        public Record(int id, string name, DateTime dt)
        {
            Id = id;
            Name = name;
            this.dt = dt;
        }
    }    /// <summary>
         /// 用户controller
         /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static Dictionary<int, Record> data = new ();
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns>用户信息列表</returns>
        [HttpGet]
        public IEnumerable<UserInfo> Get()
        {
            UserInfo[] ua = new UserInfo[data.Count];
            int i = 0;
            foreach (Record user in data.Values) {
                ua[i++]=new UserInfo { UserId = user.Id,UserName=user.Name};
            }
            return ua;
        }

        /// <summary>
        /// 根据id查询用户
        /// </summary>
        /// <param name="id">用户ID</param>
        /// <returns>用户信息</returns>
        [HttpGet("{id}")]
        public UserInfo Get(int id)
        {
            if (data.ContainsKey(id))
            {
                return new UserInfo() { UserId = data[id].Id, UserName = data[id].Name + data[id].dt };
            }
            else {
                return null;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="user"></param>
        [HttpPost]
        public void Post([FromBody]UserInfo user)
        {
            if(!data.ContainsKey(user.UserId))
                data.Add(user.UserId, new Record(user.UserId, user.UserName, DateTime.Now));
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string name)
        {
            if (data.ContainsKey(id))
            {
                data[id] = new Record(id, name, DateTime.Now);
            }
        }

        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (data.ContainsKey(id))
            {
                data.Remove(id);
            }
        }
    }
}
