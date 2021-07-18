using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettersSetters
{
    // setting setters and getters in class
    public class Staff
    {
        private int age;

        // Getter function
        public int GetAge()
        {
            return this.age;
        }

        // Setter function
        public void SetAge(int inAge)
        {
            if (inAge > 0 && inAge < 120)
            {
                this.age = inAge;
            }
        }
    }

    // instead of using "classic" set and get we can use properties
    public class StaffMem
    {
        // our age var
        private int age;
        // public var that will be used as propertie
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                // value - referes to value we assign to var Age in program
                if (value > 0 && value < 120)
                {
                    this.age = value;
                }
            }
        }

        // Also properties can be used for some custom get-set
        // notice: never use properties if set or get can fail, as there is now
        // way to notify "user" about error other than via exception
        public int AgeInMonths
        {
            get
            {
                return this.age * 12;
            }
        }
    }

    // Properties could be described in Interface
    public interface IStaff
    {
        int Age
        {
            get;
            set;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // using getters and setters
            Staff sf = new Staff();
            sf.SetAge(25);
            Console.WriteLine($"Age via set-get: {sf.GetAge()}");


            // using properties
            StaffMem sm = new StaffMem();
            //assign new val to age via property
            sm.Age = 21;
            Console.WriteLine($"Age via property: {sm.Age}");
            Console.WriteLine($"Age in months: {sm.AgeInMonths}");

            Console.ReadKey();
        }
    }
}
