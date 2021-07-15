using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectClass
{
    // All classes are the child to object class that hase useful mothods we can ovveride
    // this will be the same as public class Dimm : Object
    public class Dimm
    {
        public int x;
        public int y;

        public Dimm(int inX, int inY)
        {
            x = inX;
            y = inY;
        }

        // Overriding ToString() method:
        public override string ToString()
        {
            return "[" + x + ";" + y + "]";
        }

        // Overriding Equals() method to use for comparing vars of this class
        public override bool Equals(object obj)
        {
            Dimm p = (Dimm)obj;
            if (x == p.x && y == p.y)
            {
                return true;
            } else
            {
                return false;
            }

        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }
}
