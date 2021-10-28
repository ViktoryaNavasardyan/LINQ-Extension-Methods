using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Extension_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Phone> phones = new List<Phone>
            {
                new Phone {Name="Lumia 430", Company="Microsoft" , Index = 25564},
                new Phone {Name="Mi 5", Company="Xiaomi", Index = 16565},
                new Phone {Name="LG G 3", Company="LG", Index = 35544 },
                new Phone {Name="iPhone 5", Company="Apple", Index = 47748 },
                new Phone {Name="Lumia 930", Company="Microsoft", Index = 55652 },
                new Phone {Name="iPhone 6", Company="Apple", Index = 60056 },
                new Phone {Name="Lumia 630", Company="Microsoft", Index = 78521 },
                new Phone {Name="LG G 4", Company="LG", Index = 80051 },
                new Phone {Name="Lumia 630", Company="Microsoft", Index = 98900 }
            };
            ExperementWithToListExt();
            printspace();

            ExperementWithSelectExt();
            printspace();

            ExperementWithWhereExt();
            printspace();

            ExperementWithToDictionaryExt(phones);
            printspace();

            ExperementWithGroupByExt(phones);
            printspace();

            ExperementWithOrderByExt( phones);
            printspace();

        }
        static void printspace()
        {
            Console.WriteLine();
            Console.WriteLine("========================================================================================");
            Console.WriteLine();
        }
        static void ExperementWithToListExt()
        {
            Console.WriteLine("returns a collection as a List");
            Console.WriteLine("------------------------------");
            int[] numbers = new int[6] { 0, 1, 2, 3, 4, 5 };
            Console.Write("type is => ");
            Console.WriteLine(numbers.GetType());

            var query = numbers.ToListExt();

            Console.Write("new type is => ");
            Console.WriteLine(query.GetType());
            Console.WriteLine();
        }
        static void ExperementWithSelectExt()
        {
            Console.WriteLine("projects the elements into a new form");
            Console.WriteLine("-------------------------------------");
            Console.Write("Degree 2 ranging from 1 to 10 => ");
            
            IEnumerable<double> gradeOf2 = Enumerable.Range(1, 10).SelectExt(x => Math.Pow(2, x));
            foreach (int num in gradeOf2)
            {
                Console.Write("{0} " , num);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void ExperementWithWhereExt()
        {
            Console.WriteLine("filters elements from fruits where fruit's length < 6");
            Console.WriteLine("-------------------------------------------------------");
            List<string> fruits = new List<string> { "apple", "passionfruit", "banana", 
                "mango", "orange", "blueberry", "grape", "strawberry" };
            
            Console.Write("Your fruits are => "); 
            foreach (string fruit in fruits)
            { 
                Console.Write("\"{0}\" ", fruit);
            }
            Console.WriteLine();
            IEnumerable<string> query = fruits.WhereExt(fruit => fruit.Length < 6);
            Console.Write("New collection is => ");
            foreach (string fruit in query)
            {
                Console.Write("{0} ", fruit);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        static void ExperementWithToDictionaryExt(List<Phone> phones)
        {

            Console.WriteLine("Create a Dictionary of Phone objects");
            Console.WriteLine("------------------------------------");
            // using Index as the key.
            Dictionary<int, Phone> dictionary = phones.ToDictionaryExt(p => p.Index);

            foreach (KeyValuePair<int, Phone> p in dictionary)
            {
                Console.WriteLine(
                    "Key {0}: Company => {1}, Name => {2} ",
                    p.Key,
                    p.Value.Company,
                    p.Value.Name);
            }
            Console.WriteLine();
        }
        static void ExperementWithGroupByExt(List<Phone> phones)
        {
            var groupByCompany = phones.GroupByExt(x => x.Company);
            foreach (var p in groupByCompany)
            {
                Console.WriteLine(p.Key);

                foreach (var ph in phones)
                {
                    if (ph.Company == p.Key)
                    {
                        Console.WriteLine(ph.Name);
                    }
                }

                Console.WriteLine("-------------------");
                Console.WriteLine();
            }
        }
        static void ExperementWithOrderByExt(List<Phone> phones)
        {
            Console.WriteLine("Order phones by index");
            Console.WriteLine("---------------------");
            var orderedByIndex = phones.OrderByExt(x => x.Index);
            foreach (var phone in orderedByIndex)
            {
                Console.WriteLine("Index:" + phone.Index + "    Name: " + phone.Name);
            }
            Console.WriteLine();
            Console.WriteLine("descending");
            Console.WriteLine("----------");
            var orderedByIndexDesc = phones.OrderByDescExt(x => x.Index);
            foreach (var phone in orderedByIndexDesc)
            {
                Console.WriteLine("Index:" + phone.Index + "    Name: " + phone.Name);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

}
