using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBD
{
    public class Teacher
    {
        public int ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public decimal Salary { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ID {ID} Имя {FirstName} Зарплата {Salary} Фамилия {LastName}");
        }
    }
}

