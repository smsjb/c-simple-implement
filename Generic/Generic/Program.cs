using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{

    class Generic<T>
    {
        private T[] g = new T[5];
        public void ShowMsg()
        {
            foreach (T item in g) Console.Write(item);
        }

        public void Store(T data)
        {
            g[0] = data;
        }


    }



   class Program
    {
        private static void ShowMsg1<T>(T[] s)
        {
            foreach (T item in s) Console.Write(item);
        }

        private static int DivedZero()
        {
            int numa = 100, numb = 0;
            return numa / numb;
        }

        static void Main(string[] args)
        {
            /*
            Generic<string> p = new Generic<string>();
            Generic<int> s = new Generic<int>();
            string[] str = { "t", "h" };
            int[] it = { 1, 2, 3 };

            ShowMsg1(str);
            ShowMsg1(it);
            p.Store("tttt");
            s.Store(1);
            p.ShowMsg();
            s.ShowMsg();
            Console.WriteLine("hi");
            Console.ReadKey();*/

           

            try { int res = DivedZero(); }
            catch (DivideByZeroException ex) { Console.WriteLine(ex.Message); } //ex.ToString()也可
            finally { Console.ReadKey();  }
        }

    }
}
