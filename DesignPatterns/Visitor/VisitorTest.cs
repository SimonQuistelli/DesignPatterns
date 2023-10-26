using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    class VisitorTest
    {
        public static void TestVisitorDP()
        {
            Employees employees = new Employees();

            employees.AddEmployee(new Director());
            employees.AddEmployee(new SalesManager());
            employees.AddEmployee(new SalesPerson());

            IncomeVisitor incomeVisitor = new IncomeVisitor();
            employees.Accept(incomeVisitor);

            VacationVisitor vacationVisitor = new VacationVisitor();
            employees.Accept(vacationVisitor);
        }

        public interface IVisitor
        {
            void Visit(Element element);
        }

        public abstract class Element
        {
            public abstract void Accept(IVisitor visitor); 
        }

        public class IncomeVisitor : IVisitor
        {
            public void Visit(Element element)
            {
                Employee employee = element as Employee;

                employee.Income *= 1.05;

                switch (employee)
                {
                    case Director:
                        Console.WriteLine("Director {0} new Income {1:C}", employee.Name, employee.Income);
                        break;
                    case SalesManager:
                        Console.WriteLine("SalesManager {0} new Income {1:C}", employee.Name, employee.Income);
                        break;
                    case SalesPerson:
                        Console.WriteLine("SalesPerson {0} new Income {1:C}", employee.Name, employee.Income);
                        break;

                }
            }
        }

        public class VacationVisitor : IVisitor
        {
            public void Visit(Element element)
            {
                Employee employee = element as Employee;

                employee.VacationDays += 3;

                switch (employee)
                {
                    case Director:
                        Console.WriteLine("Director {0} new vacation days {1}", employee.Name, employee.VacationDays);
                        break;
                    case SalesManager:
                        Console.WriteLine("SalesManager {0} new vacation days {1}", employee.Name, employee.VacationDays);
                        break;
                    case SalesPerson:
                        Console.WriteLine("SalesPerson {0} new vacation days {1}", employee.Name, employee.VacationDays);
                        break;
                }
            }
        }

        public class Employee : Element
        {
            public string Name { get; set; }
            public double Income { get; set; }
            public int VacationDays { get; set; }

            public Employee(string name, double income, int vacationDays)
            {
                this.Name = name;
                this.Income = income;
                this.VacationDays = vacationDays;
            }
 
            public override void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Employees
        {
            private List<Employee> _employess;

            public Employees()
            {
                _employess = new List<Employee>();
            }

            public void AddEmployee(Employee employee)
            {
                _employess.Add(employee);
            }

            public void Accept(IVisitor visitor)
            {
                foreach (Employee emplyee in _employess)
                {
                    emplyee.Accept(visitor);
                }
            }
        }

        public class Director : Employee
        {
            public Director() : base("John", 5000.0, 26)
            {
            }
        }

        public class  SalesManager : Employee
        {
            public SalesManager() : base("Steve", 40000.0, 23)
            {
            }
        }

        public class SalesPerson : Employee
        {
            public SalesPerson() : base("Mary", 30000.0, 20)
            {
            }
        }
    }
}
