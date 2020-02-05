using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace ConsoleApp5
{
    class Program
    {
        private static Person[] people = new Person[10000];
        private static List<Person> listpeople = new List<Person>();
        private static string path = @"C:\\Users\\valik\\source\\repos\\ConsoleApp5\\ConsoleApp5\\name.txt";





        static void Main(string[] args)
        {
            Random random = new Random();
            readOnFile(path);
            Console.WriteLine(listpeople.Count);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            int i = 0;
            foreach (var item in listpeople)
            {
                if (item.Name.Equals("Valik")) {

                    Console.WriteLine(i);
                    break;
                }
                i++;
            }



            //Console.WriteLine(listpeople[listpeople.Count-1]);
            //sortOnAge();
            //bublesort(listpeople);
            //selectSort(listpeople);
            //listpeople.Sort();
            //shellSort(listpeople, listpeople.Count);
            stopwatch.Stop();
            time(stopwatch);
            Console.ReadLine();
        }






        public static void shellSort(List<Person> arr, int size) {
            int increment = 50;
            while (increment > 0)
            {
                for (int i = 0; i < size; i++)
                {
                    int j = i;
                    Person temp = arr[i];
                    while ((j>=increment) && (arr[j-increment].Age > temp.Age))
                    {
                        arr[i] = arr[j - increment];
                        j = j - increment;
                    }
                    arr[j] = temp;
                }
                if (increment > 1) increment = increment / 2;
                else if (increment == 1) break;
            }
        }






        public static void time(Stopwatch stopwatch) {
            TimeSpan timeSpan = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }






        public static void write(Person [] arr) {

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }










        public static void selectSort(List<Person> person) {
            Person temp;
            int Ind_min = 0, i, j;
            for (i = 0; i < person.Count; i++)
            {
                Ind_min = i;
                for ( j = 0; j < person.Count; j++)
                {
                    if (person[i].Age < person[Ind_min].Age) Ind_min = j;
                }
                temp = person[i];
                person[i] = person[Ind_min];
                person[Ind_min] = temp;
            }
        }








        public static void bublesort(List<Person> people) {
            Person person = people[0];
            for (int i = 0; i < people.Count; i++)
            {
                for (int j = i+1; j < people.Count; j++)
                {
                    if(people[i].Age> people[j].Age) {
                        person = people[i];
                        people[i] = people[j];
                        people[j] = person;
                    }
                }
            }
        }







        public static void sortOnAge() {
            for (int i = 0; i < listpeople.Count; i++)
            {
                Person cur = listpeople[i];
                int j = i;
                while (j>0 && (cur.Age <  listpeople[j-1].Age))
                {
                    listpeople[j] = listpeople[j - 1];
                    j--;
                }
                listpeople[j] = cur;
            }
        }








        public static void readOnFile(string path) {
            try {
                using (StreamReader stream = new StreamReader(path))
                {
                    string text;
                    int i = 0;
                    Random random = new Random();
                    while (i <= people.Length-1 & ((text = stream.ReadLine()) != null))
                    {
                        
                        masAdd(text.Split(' ')[0], text.Split(' ')[1], i, random.Next(16, 30), text.Split(' ')[2], i);
                        i++;
                    }
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
        }
        public static void masAdd(string name, string surname , int number , int age, string otchestvo , int index){
            
            Person person = new Person(name, surname, number, age, otchestvo);
            listpeople.Add(person);
            //people[index] = person;
        }
    }
}
