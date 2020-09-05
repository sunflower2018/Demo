using System;
using System.IO;
using System.Runtime.CompilerServices;
using StackExchange.Redis;

namespace Demo.Redis.StackExchange
{
    public class MyRedis
    {
        private ConnectionMultiplexer redis;
        private IDatabase db;
        public MyRedis()
        { 
        
        }
        public  void ConnectDb()
        {
            this.redis= ConnectionMultiplexer.Connect("localhost");
            
        }
        public void OpenDb()
        {
            this.db= this.redis.GetDatabase();
        }
        public void SetVal(string key, string val)
        {           
            this.db.StringSet(key,val);
        }
        public RedisValue GetVal(string key)
        {
            return this.db.StringGet(key);
        }
        /// <summary>
        /// 向某频道发布消息
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="msg"></param>
        public void publish(string channel,string msg)
        {
            ISubscriber sub = redis.GetSubscriber();
            sub.Publish(channel, msg);  
           
        }
        /// <summary>
        /// 客户端订阅某频道 调用示例：在winform中（redis.subscrib("msg", (rc, rv) => { MessageBox.Show((string)rv); });）
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="handler">调用需要提供的回调方法</param>
        public void subscrib(string channel, Action<RedisChannel,RedisValue> handler)
        {
            ISubscriber sub = redis.GetSubscriber();            
            sub.Subscribe(channel,handler);
        }
        public IServer GetServer(string host,int port)
        {
            IServer server= redis.GetServer(host, port);
           
            return server;

        }
    }
}
