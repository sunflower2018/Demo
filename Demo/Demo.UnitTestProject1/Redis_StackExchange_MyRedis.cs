using Demo.Redis.StackExchange;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;

namespace Demo.UnitTestProject1
{
    [TestClass]
    public class Redis_StackExchange_MyRedis
    {
        MyRedis myRedis = new MyRedis();
        public Redis_StackExchange_MyRedis()
        {          
            myRedis.ConnectDb();
            myRedis.OpenDb();
        }

        [TestMethod]
        public void GetVal()
        {
          
            myRedis.SetVal("id", "000001");
            string val = myRedis.GetVal("id");
            Assert.AreEqual("000001", val);

        }

        [TestMethod]
        public void Publish()
        {
            //可以开启一个redis客户端，使其订阅msg频道，测试redis客户端及时接受到消息
            myRedis.publish("msg", "hi world  dd ");          
        }
        [TestMethod]
        public void subscrib()
        {
            //可以开启一个redis客户端，使其订阅msg频道，测试redis客户端及时接受到消息
            myRedis.subscrib("msg",null);
        }

    }
}
