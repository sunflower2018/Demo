using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.AspNetCoreApiTestFilter
{
    public class MyCity
    {
        public int cid { get; set; }   //必须是属性，否则无法解析
        public string cname { get; set; }
    }
}
