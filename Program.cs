//Створити суперклас Співробітник підкласи Керівник, Менеджер, Інженер, Механік, Інженер-архітектор.
//За допомогою конструктора задати кількість досвіду співробітника в роках.
//Вивести зарплату кожного співробітника та кількість вихідних в році у інженерів.
//Реалізувати функцію підрахунку кількості підлеглих у менеджера.


using System.Collections.Generic;
using System.Linq;

namespace laba4
{
    class Program
    {
        class Company
        {
            public List<Employee> allEmployee = new List<Employee>();
            public void Addpeople(Employee employee)
            {
                allEmployee.Add(employee);
            }
            public void PrintWorkers()
            {
                Console.WriteLine("Працівники компанії");
                foreach (Employee workers in allEmployee)
                    Console.WriteLine($"Посада:{workers.name}   Стаж роботи:{workers.experience} років");
                Console.WriteLine();
            }
            public void CountOfSubordinates()
            {
                int managerSB = 0;
                foreach (Employee employee in allEmployee)
                    if (employee.experience < 5)
                        managerSB += employee.count;
                Console.WriteLine($"Менеджер має {managerSB} підлеглих");
                Console.WriteLine();
            }

        }
        abstract class Employee
        {
            public string name { get; set; }
            public int count { get; set; }
            public int salary { get; set; }
            public int experience { get; set; }
            public abstract void Salary();
        }
        class Head : Employee
        {
            public Head (string Name,int Count, int Salary, int Experience)
            {
                name = Name;
                count = Count;
                salary = Salary;
                experience = Experience;
            }
            public override void Salary()
            {
                Console.WriteLine($"{name} заробляє {salary}$ в місяць");
            }
        }
        class Manager:Employee
        {
            public Manager(string Name, int Count, int Salary, int Experience)
            {
                name = Name;
                count = Count;
                salary = Salary;
                experience = Experience;
            }
            public override void Salary()
            {
                Console.WriteLine($"{name} заробляє {salary}$ в місяць");
            }
        }
        class Engeneer : Employee
        {
            public virtual void Weekend() { }
            public override void Salary()
            {
                Console.WriteLine($"{name} заробляє {salary}$ в місяць");
            }
        }
        class EngineerArchitect : Engeneer
        {
            public int workday { get; set; }
            public EngineerArchitect(string Name, int Count, int Salary, int Experience)
            {
                name = Name;
                count = Count;
                salary = Salary;
                experience = Experience;
            }
            public EngineerArchitect(int Workday)
            {
                workday = Workday;
            }
            public override void Weekend()
            {
                int holiday = 365 - workday;

                Console.WriteLine($"Інженер працює {workday} днів у році та має {holiday} вихідних");
            }
        }
        class Mehanik:Employee
        {
            public Mehanik(string Name, int Count, int Salary, int Experience)
            {
                name = Name;
                count = Count;
                salary = Salary;
                experience = Experience;
            }

            public override void Salary()
            {
                Console.WriteLine($"{name} заробляє {salary}$ в місяць");
            }
        }
        static void Main(string[] args)
        {
            var company = new Company();

            var head = new Head("Керівник", 1, 1000, 10);
            company.Addpeople(head);

            var manager = new Manager("Менеджер", 1, 700, 5);
            company.Addpeople(manager);

            var engineerarchitect = new EngineerArchitect("Інженер-архітектор", 10, 600, 3);
            company.Addpeople(engineerarchitect);
            var engineerarchitect2 = new EngineerArchitect(250);

            var mehanik = new Mehanik("Механік", 15, 500, 1);
            company.Addpeople(mehanik);

            company.PrintWorkers(); 
            head.Salary();
            manager.Salary();
            company.CountOfSubordinates();
            engineerarchitect.Salary();
            engineerarchitect2.Weekend();
            mehanik.Salary();

            Console.ReadKey();
        }
    }
}