using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenAndCal
{
    class SimpleClass
    {
        private int num;
        private string name;

        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }

        public void SetName(string inName)
        {
            name = inName;
        }

        public string GetName()
        {
            return name;
        }

        public void AddNum(int n)
        {
            num += n;
        }

        public SimpleClass(int inNum, string inName)
        {
            num = inNum;
            name = inName;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // === ARRAY LIST ====
            // is kind of array withought preset size
            // also it can store items of different types
            ArrayList store = new ArrayList();

            // It is possible to init ArrayList with size, but it could be extended
            ArrayList storeFifty = new ArrayList(50);

            // adding to arraylist
            store.Add(5);
            store.Add("Apple");

            SimpleClass sc = new SimpleClass(5, "Jon");
            store.Add(sc);
            // note: when item is added to array list, the array list stores reference to the object, but not item itself

            // retrieving object from array list
            SimpleClass a = (SimpleClass) store[2];
            Console.WriteLine($"{a.GetName()} : {a.Num}");
            a.AddNum(10);
            Console.WriteLine($"after add 10: {a.GetName()} : {a.Num}");
            a = (SimpleClass)store[2];
            Console.WriteLine($"Retrieve item again: {a.GetName()} : {a.Num}");
            // changes to retrieved item will be "stored" in array list as list contains references to object

            // note: ArrayList is not type safe, that leads to exception when type casting wrong type

            //Finding the size of an ArrayList
            Console.WriteLine($"Size: {store.Count}");

            // removing item from ArrayList:
            store.Remove("Apple");
            // This removes the first occurrence of the reference. If it's not found non is changed and no error

            Console.WriteLine($"Size after remove: {store.Count}");

            // Checking to see if an ArrayList contains an item
            if (store.Contains(5))
            {
                Console.WriteLine("5 is in array list");
            }

            // ==== LIST CLASS ====
            // everything that an arraylist gives you, with the advantage that it is also typesafe
            List<SimpleClass> scList = new List<SimpleClass>();
            // because List contains items of particular type we can reference to them withought casting:
            scList.Add(sc);
            scList[0].Num = 100;
            Console.WriteLine($"Item from list: {scList[0].GetName()} : {scList[0].Num}");

            // ==== Dictionary ====
            // more powerful cousin of Hashtable
            Dictionary<string, SimpleClass> dic = new Dictionary<string, SimpleClass>();
            dic.Add(sc.GetName(), sc);

            // accesing the item in Dictionary:
            dic["Jon"].AddNum(10);

            // check key
            if(dic.ContainsKey("Jon"))
            {
                Console.WriteLine($"Jon is in dictionary: {dic["Jon"].Num}");
            }

            Console.ReadKey();
        }
    }
}
