using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//test

namespace DesignPatterns.Adapter
{
    class Adapter
    {
        public static void TestAdapterDP()
        {
            string[,] employeesArray = new string[5, 4]
             {
                {"101","John","SE","10000"},
                {"102","Smith","SE","20000"},
                {"103","Dev","SSE","30000"},
                {"104","Pam","SE","40000"},
                {"105","Sara","SSE","50000"}
             };
            //The EmployeeAdapter Makes it possible to work with Two Incompatible Interfaces
            Console.WriteLine("HR system passes employee string array to Adapter\n");
            ITarget target = new EmployeeAdapter();
            target.ProcessCompanySalary(employeesArray);
        }
    }

    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public decimal Salary { get; set; }
        public Employee(int id, string name, string designation, decimal salary)
        {
            ID = id;
            Name = name;
            Designation = designation;
            Salary = salary;
        }
    }

    public class ThirdPartyBillingSystem
    {
        public void ProcessSalary(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                Console.WriteLine("Rs." + employee.Salary + " Salary Credited to " + employee.Name + " Account");
            }
        }
    }

    public interface ITarget
    {
        void ProcessCompanySalary(string[,] employeesArray);
    }

    public class EmployeeAdapter : ITarget
    {
        private ThirdPartyBillingSystem _TPBS;

        public EmployeeAdapter()
        {
            _TPBS = new ThirdPartyBillingSystem();
        }

        public void ProcessCompanySalary(string[,] employeesArray)
        {
            int Id = 0;
            string Name = null;
            string Designation = null;
            decimal Salary = 0;

            List<Employee> employees = new List<Employee>();

            for (int i = 0; i < employeesArray.GetLength(0); i++)
            {
                for (int j = 0; j < employeesArray.GetLength(1); j++)
                {
                    if (j == 0)
                    {
                        Id = Convert.ToInt32(employeesArray[i, j]);
                    }
                    else if (j == 1)
                    {
                        Name = employeesArray[i, j];
                    }
                    else if (j == 2)
                    {
                        Designation = employeesArray[i, j];
                    }
                    else
                    {
                        Salary = Convert.ToDecimal(employeesArray[i, j]);
                    }
                }
                employees.Add(new Employee(Id, Name, Designation, Salary));
            }

            _TPBS.ProcessSalary(employees);
        }
    }
}
