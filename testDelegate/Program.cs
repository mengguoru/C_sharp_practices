using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public delegate void greeting(String name);
    class Program
    {
        private static void greetingPeople(greeting func, String name)
        {
            func(name);
        }
        private static void ChineseGreeting(String name)
        {
            Console.WriteLine("早上好" + name);
        }
        private static void EnglishGreeting(String name)
        {
            Console.WriteLine("Good morning" + name);
        }
        static void Main(string[] args)
        {
            greetingPeople(ChineseGreeting, "中文名字");
            greetingPeople(EnglishGreeting, "English name");
        }
    }
}
