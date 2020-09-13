using Demo.Redis.StackExchange;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            MyRedis redis = new MyRedis();
            redis.ConnectDb();
            redis.OpenDb();
            redis.subscrib("msg", (rc, rv) => { MessageBox.Show((string)rv); });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //如果Person没有定义隐式类型转换，这里的实参就不能传字符串。编译时会报错
            TestPerson("张三");
        }
        public void TestPerson(Person p)
        {
            MessageBox.Show(p.name);
        }
    }
    public class Person
    { 
        public string name { get; set; }
        public static implicit operator string(Person p)
        {
            return p.name;
        }
        //隐式类型转换
        public static implicit operator Person(string name)
        {
            return new Person() { name = name };
        }
    }

    
}
