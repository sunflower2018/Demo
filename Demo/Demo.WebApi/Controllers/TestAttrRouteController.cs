/*
 *  1、WebApi 只匹配到Controller，不匹配Action 
 *  2、Action 默认 识别 Get、Post、Put、Delete
 *  3、方法名Get、Post可以不用添加[HttpGet]或[HttpPost] 默认为Get或Post
 *  4、不可以有方法名、入参相同的方法 【用[HttpGet]或[HttpPost]是不能区分的】
 *  5、Controller中可以定义非标准的方法，例如【test方法】，如果不加特性标签，将无法正确匹配【调用会提示一个错误】
 *  6、配置路由中可选参数id或其他，Controller中有参方法形参必须一致, 类似 localhost:44387/api/TestWebApiroute/a 才能找到
 *  7、还可以：localhost:44387/api/TestWebApiroute?id=1&name=2，以调用有两个参数的Get方法
 *  8、如果请求 localhost:44387/api/TestWebApiroute/a 是post过来的，也能顺利进入 有参Post方法【形参参数名必须匹配路由配置】
 *  9、Fiddler模拟Post请求调用方法时，请求头要加上“Content-Type: application/json”【只能设置json?测试text不可以】
 *  10、Put方法：修改数据；
 *  11、Delete方法：删除数据
 *  12、可以自定义路由到action，但webapi中不提倡，最好启用特性路由。
 *  13、启用特性路由后，http请求，就会匹配特性路由方法，如果方法有参数，则请求也必须有参数
 *  14、Post方法中形参前面必须定义[FromBody]
 *  15、路由前缀只能作用类上
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.WebApi.Controllers
{
    public class TestAttrRouteController : ApiController
    {
        //【localhost:44387/api/TestWebApiroute】调用【localhost:44387/api1/TestWebApiroute】也可以，因为配置了两个路由
        public string Get()
        {
            return  "调用无惨Get方法";
        }
        //【localhost:44387/api/TestWebApiroute/a】  入参必须是是id，如果其他参数名，则还会走无参的Get方法
        public string Get(string id)
        {
            return string.Format("调用有参Get方法，参数是：{0}",id);
        }              
        public string Get(string id,string name)
        {
            return string.Format("调用有两个参数的Get重载方法，参数是：{0}   {1}",id,name);
        }
       
        public string Post([FromBody] string str)
        {
            return string.Format("调用有参Post方法，参数是：{0}", str);
        }      
        public void Put(int id, [FromBody]string value)
        {

        }
        public void Delete(int id)
        {
           
        }
        [Route("aaa")]
        [HttpPost]
        public string Test1([FromBody] string str)
        {
            return string.Format("启用了无参特性理由");
        }
        [Route("aaa/bbb")]
        [HttpGet]
        public string Test2(string id)
        {
            return string.Format("启用了有参特性理由");
        }     
    }
}
