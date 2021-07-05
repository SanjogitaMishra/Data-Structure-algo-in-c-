using System;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int, string> HashtableDemoObject = new HashTable<int, string>();


            // demo of Insert Method which add key-value in Hashtable
            Console.WriteLine("\n***** Calling Insert Method and Adding Below ELements *****");
            HashtableDemoObject.Insert(2, "M S Dhoni");
            HashtableDemoObject.Insert(3, "Hardik Pandya");
            HashtableDemoObject.Insert(4, "Virat Kohli");
            HashtableDemoObject.Insert(5, "KL Rahul");
            HashtableDemoObject.Insert(6, "Shikhar Dhawan");
            HashtableDemoObject.Insert(6, "Rohit Sharma"); // previous value of key=6 is updated
            HashtableDemoObject.Traverse();

            // demo of size method which returns the size of Hashtable
            Console.WriteLine("\n***** Calling Size Method *****");
            Console.WriteLine("\tSize of HashTable is = " + HashtableDemoObject.Size());

            // demo of Delete method which remove key-value pair with given key and returns the value
            Console.WriteLine("\n***** Calling Delete Method *****");
            Console.WriteLine("\tElement Deleted for Given Key \"3\" = " + HashtableDemoObject.Delete(3));

            // checking Hashtable after obove changes made
            AfterOperation(" Delete Method");


            // demo of GetValue method which returns the value for given key
            Console.WriteLine("\n***** Calling GetValue Method for Given Key ******");
            Console.WriteLine("\tVaue for Key \"2\" = " + HashtableDemoObject.GetValue(2));


            // demo of contains method which finds wheter given element is present or not
            Console.WriteLine("\n***** Calling Contains Method ******");
            Console.WriteLine("\tDoes Hashtable Contains \"KL Rahul\" = " + HashtableDemoObject.Contains("KL Rahul"));
            Console.WriteLine("\tDoes Hashtable Contains \"Kapil Dev\" = " + HashtableDemoObject.Contains("Kapil Dev"));



            // demo of Traverse method and Iterator Method 
            Console.WriteLine("\n***** Calling Traverse method and Iterator Method withing Traverse Method *****");
            Console.WriteLine(" ---- ELements In the Queue are ---- ");
            HashtableDemoObject.Traverse();


            void AfterOperation(string message)
            {
                // checking list data after obove changes made in list
                Console.WriteLine("---- Data After Calling" + message);
                HashtableDemoObject.Traverse();
            }

        }
  }
}

