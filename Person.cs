using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Person
    {
        private string _name;
        private string _surname;
        private int _number;
        private int _age;
        private string _otchestvo;


        public Person(string name, string surname, int number, int age, string otchestvo)
        {
            _name = name;
            _surname = surname;
            _number = number;
            _age = age;
            _otchestvo = otchestvo;
        }

        public string Name { get => _name; set => _name = value; }
        public string Surname { get => _surname; set => _surname = value; }
        public int Number { get => _number; set => _number = value; }
        public int Age { get => _age; set => _age = value; }
        public string Otchestvo { get => _otchestvo; set => _otchestvo = value; }

        
        public override string ToString()
        {
            return $"{Name} {Surname} {Number+1} {Age} {Otchestvo}";
        }
    }
}
