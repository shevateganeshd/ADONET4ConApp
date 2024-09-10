using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET4ConApp
{
    public class EmployeeRepository
    {
        readonly string connectionString = "Data Source=DESKTOP-S87FPOF\\SQLEXPRESS;Initial Catalog=CRM;UID=sa;Password=ABC@;TrustServerCertificate=True;MultipleActiveResultSets=True;Integrated Security=True;Trusted_Connection=True;";
        public void CreateEmployee()
        {
            Console.Write("Name : ");
            string Name = Console.ReadLine();

            Console.Write("Address : ");
            string Address = Console.ReadLine();

            Console.Write("Phone : ");
            string PhoneNo = Console.ReadLine();

            Console.Write("BirthDate yyyy-MM-dd: ");
            DateTime BirthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("IsActive true/false: ");
            bool IsActive = Boolean.Parse(Console.ReadLine());

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Employee (Name, Address, PhoneNo, BirthDate, IsActive) VALUES (@Name, @Address, @PhoneNo, @BirthDate, @IsActive)";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", Name);
                    cmd.Parameters.AddWithValue("@Address", Address);
                    cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                    cmd.Parameters.AddWithValue("@BirthDate", BirthDate);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);

                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Employee Added Successfully");
                }
            }
            Console.WriteLine();
        }

        public void ReadEmployees()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Employee";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Address: {reader["Address"]}, Phone: {reader["PhoneNo"]}, BirthDate: {reader["BirthDate"]}, IsActive: {reader["IsActive"]}");
                    }
                }
            }
            Console.WriteLine();
        }

        public void ReadEmployee()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Console.Write("Id : ");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine();
                con.Open();
                string query = "SELECT * FROM Employee WHERE Id="+Id;
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Id: {reader["Id"]}");
                            Console.WriteLine($"Name: {reader["Name"]}");
                            Console.WriteLine($"Address: {reader["Address"]}");
                            Console.WriteLine($"PhoneNo: {reader["PhoneNo"]}");
                            Console.WriteLine($"BirthDate: {reader["BirthDate"]}");
                            Console.WriteLine($"IsActive: {reader["IsActive"]}");
                        }
                    }
                    else
                        Console.WriteLine("No record found with Id : " + Id);
                }
            }
            Console.WriteLine();
        }

        public void UpdateEmployee()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Console.Write("Id : ");
                int Id = int.Parse(Console.ReadLine());

                con.Open();
                string getEmployee = "SELECT * FROM Employee WHERE Id=" + Id;
                using (SqlCommand cmdEmployee = new SqlCommand(getEmployee, con))
                {
                    SqlDataReader reader = cmdEmployee.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        Console.Write("Name : ");
                        string Name = Console.ReadLine();

                        Console.Write("Address : ");
                        string Address = Console.ReadLine();

                        Console.Write("Phone : ");
                        string PhoneNo = Console.ReadLine();

                        Console.Write("BirthDate yyyy-MM-dd: ");
                        DateTime BirthDate = DateTime.Parse(Console.ReadLine());

                        Console.Write("IsActive true/false: ");
                        bool IsActive = Boolean.Parse(Console.ReadLine());

                        string updateEmployee = "UPDATE Employee SET Name = @Name, Address = @Address, PhoneNo = @PhoneNo, BirthDate = @BirthDate, IsActive = @IsActive WHERE Id = @Id";
                        using (SqlCommand cmd = new SqlCommand(updateEmployee, con))
                        {
                            cmd.Parameters.AddWithValue("@Id", Id);
                            cmd.Parameters.AddWithValue("@Name", Name);
                            cmd.Parameters.AddWithValue("@Address", Address);
                            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                            cmd.Parameters.AddWithValue("@BirthDate", BirthDate);
                            cmd.Parameters.AddWithValue("@IsActive", IsActive);

                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Employee Updated Successfully");
                        }
                    }
                    else
                        Console.WriteLine("No record found with Id : " + Id);
                }
                Console.WriteLine();
            }
        }

        public void DeleteEmployee()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                Console.Write("Id: ");
                int Id = int.Parse(Console.ReadLine());
                Console.WriteLine();
                con.Open();
                string getEmployee = "SELECT * FROM Employee WHERE Id=" + Id;
                using (SqlCommand cmdEmployee = new SqlCommand(getEmployee, con))
                {
                    SqlDataReader reader = cmdEmployee.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        string query = "DELETE FROM Employee WHERE Id = @Id";
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Id", Id);
                            cmd.ExecuteNonQuery();
                            Console.WriteLine("Employee Deletted Successfully");
                        }

                    }
                    else
                        Console.WriteLine("No record found with Id : " + Id);
                }
                Console.WriteLine();
            }
        }
    }
}
