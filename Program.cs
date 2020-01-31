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
        private static string path = @"C:\\Users\\valik\\source\\repos\\ConsoleApp3\\ConsoleApp3\\name.txt";
        

        static void Main(string[] args)
        {
            readOnFile(path);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //sortOnAge();
            //bublesort(people);
            selectSort(people);
            stopwatch.Stop();
            time(stopwatch);
            Console.ReadLine();
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

        public static void selectSort(Person[] person) {
            Person temp;
            int Ind_min = 0, i, j;
            for (i = 0; i < person.Length; i++)
            {
                Ind_min = i;
                for ( j = 0; j < person.Length; j++)
                {
                    if (person[i].Age < person[Ind_min].Age) Ind_min = j;
                }
                temp = person[i];
                person[i] = person[Ind_min];
                person[Ind_min] = temp;
            }
        }

        public static void bublesort(Person [] people) {
            Person person = people[0];
            for (int i = 0; i < people.Length; i++)
            {
                for (int j = i+1; j < people.Length; j++)
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

            for (int i = 0; i < people.Length; i++)
            {
                Person cur = people[i];
                int j = i;
                while (j>0 && (cur.Age <  people[j-1].Age))
                {
                    people[j] = people[j - 1];
                    j--;
                }
                people[j] = cur;
            }
        }
        public static void readOnFile(string path) {
            try {
                using (StreamReader stream = new StreamReader(path))
                {
                    string text;
                    int i = 0;
                    Random random = new Random();
                    while (i <= 9999 & ((text = stream.ReadLine()) != null))
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
            people[index] = person;
           
        }
    }
}
