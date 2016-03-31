using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TxtOperate
{
    //定义委托，它定义了可以代表的方法的类型
    public delegate void GreetingDelegate(string name);

    //新建的GreetingManager类
    public class GreetingManager
    {
        ////在GreetingManager类的内部声明delegate1变量
        //public GreetingDelegate delegate1;        
        //public void GreetPeople(string name)
        //{
        //    if (delegate1 != null)
        //    {     //如果有方法注册委托变量
        //        delegate1(name);      //通过委托调用方法
        //    }
        //}

        //这一次我们在这里声明一个事件
        public event GreetingDelegate MakeGreet;

        public void GreetPeople(string name)
        {
            MakeGreet(name);
        }
    }



    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        /// 

        [DllImport("kernel32.dll")]
        public static extern bool AllocConsole();


        private static void EnglishGreeting(string name)
        {
            Console.WriteLine("Morning, " + name);
        }

        private static void ChineseGreeting(string name)
        {
            Console.WriteLine("早上好, " + name);
        }



        [STAThread]
        static void Main()
        {
            //AllocConsole();

            //GreetingManager gm = new GreetingManager();

            ////gm.delegate1 = EnglishGreeting;
            ////gm.delegate1 += ChineseGreeting;
            //////            gm.GreetPeople("Jimmy Zhang", gm.delegate1);
            ////gm.GreetPeople("Jimmy Zhang");

            ////gm.MakeGreet = EnglishGreeting;         // 编译错误1
            //gm.MakeGreet += ChineseGreeting;

            //gm.GreetPeople("Jimmy Zhang");


            ////   Console.ReadLine();



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
