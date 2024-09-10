using System;
using System.Collections.Generic;
using System.Text;

namespace ADONET4ConApp
{
    public class Program
    {

        static void Main(string[] args)
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();
            int choice;

            while (true)
            {
                Console.WriteLine("*****************************");
                Console.WriteLine("..::MENU::..");
                Console.WriteLine("1 Get Employees");
                Console.WriteLine("2 Get Employee");
                Console.WriteLine("3 Add Employee");
                Console.WriteLine("4 Update Employee");
                Console.WriteLine("5 Delete Employee");
                Console.WriteLine("0 Exit");

                Console.Write("Enter Your Choice : ");
                choice = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                        employeeRepository.ReadEmployees();
                        break;
                    case 2:
                        employeeRepository.ReadEmployee();
                        break;
                    case 3:
                        employeeRepository.CreateEmployee();
                        break;
                    case 4:
                        employeeRepository.UpdateEmployee();
                        break;
                    case 5:
                        employeeRepository.DeleteEmployee();
                        break;
                    case 0:
                        return;
                }
            }
        }
    }
}

