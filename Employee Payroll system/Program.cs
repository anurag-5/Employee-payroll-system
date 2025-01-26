using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_system
{
    public class BaseEmployee
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double BasicPay { get; set; }
        public double Allowances { get; set; }
        public double Deductions { get; set; }

        public BaseEmployee(string name, int id, double basicPay, double allowances, double deductions)
        {
            Name = name;
            ID = id;
            BasicPay = basicPay;
            Allowances = allowances;
            Deductions = deductions;
        }

        public virtual double CalculateSalary()
        {
            return BasicPay + Allowances - Deductions;
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"ID: {ID}, Name: {Name}, Basic Pay: {BasicPay}, Allowances: {Allowances}, Deductions: {Deductions}");
        }
    }

    public class Manager : BaseEmployee
    {
        public double Bonus { get; set; }

        public Manager(string name, int id, double basicPay, double allowances, double deductions, double bonus)
            : base(name, id, basicPay, allowances, deductions)
        {
            Bonus = bonus;
        }

        public override double CalculateSalary()
        {
            return base.CalculateSalary() + Bonus;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Bonus: {Bonus}");
        }
    }
    public class Developer : BaseEmployee
    {
        public double PerformanceBonus { get; set; }

        public Developer(string name, int id, double basicPay, double allowances, double deductions, double performanceBonus)
            : base(name, id, basicPay, allowances, deductions)
        {
            PerformanceBonus = performanceBonus;
        }

        public override double CalculateSalary()
        {
            return base.CalculateSalary() + PerformanceBonus;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Performance Bonus: {PerformanceBonus}");
        }
    }
    public class Intern : BaseEmployee
    {
        public double Stipend { get; set; }

        public Intern(string name, int id, double basicPay, double allowances, double deductions, double stipend)
            : base(name, id, basicPay, allowances, deductions)
        {
            Stipend = stipend;
        }

        public override double CalculateSalary()
        {
            return base.CalculateSalary() + Stipend;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"Stipend: {Stipend}");
        }
    }
    class Program
    {
        static List<BaseEmployee> employees = new List<BaseEmployee>();

        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.Clear();
                Console.WriteLine("Employee Payroll System");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Calculate and Display Individual Salary");
                Console.WriteLine("4. Display Total Payroll");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        DisplayEmployees();
                        break;
                    case 3:
                        DisplayIndividualSalary();
                        break;
                    case 4:
                        DisplayTotalPayroll();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            } while (choice != 5);
        }

        static void AddEmployee()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Basic Pay: ");
            double basicPay = double.Parse(Console.ReadLine());

            Console.Write("Enter Allowances: ");
            double allowances = double.Parse(Console.ReadLine());

            Console.Write("Enter Deductions: ");
            double deductions = double.Parse(Console.ReadLine());

            Console.WriteLine("Select Role (1. Manager, 2. Developer, 3. Intern): ");
            int roleChoice = int.Parse(Console.ReadLine());

            BaseEmployee employee = null;

            switch (roleChoice)
            {
                case 1:
                    Console.Write("Enter Bonus: ");
                    double bonus = double.Parse(Console.ReadLine());
                    employee = new Manager(name, id, basicPay, allowances, deductions, bonus);
                    break;
                case 2:
                    Console.Write("Enter Performance Bonus: ");
                    double performanceBonus = double.Parse(Console.ReadLine());
                    employee = new Developer(name, id, basicPay, allowances, deductions, performanceBonus);
                    break;
                case 3:
                    Console.Write("Enter Stipend: ");
                    double stipend = double.Parse(Console.ReadLine());
                    employee = new Intern(name, id, basicPay, allowances, deductions, stipend);
                    break;
                default:
                    Console.WriteLine("Invalid role selected.");
                    return;
            }

            employees.Add(employee);
            Console.WriteLine("Employee added successfully!");
        }

        static void DisplayEmployees()
        {
            foreach (var employee in employees)
            {
                employee.DisplayDetails();
                Console.WriteLine($"Salary: {employee.CalculateSalary()}");
                Console.WriteLine();
            }
        }

        static void DisplayIndividualSalary()
        {
            Console.Write("Enter Employee ID: ");
            int id = int.Parse(Console.ReadLine());

            var employee = employees.Find(e => e.ID == id);
            if (employee != null)
            {
                Console.WriteLine($"Employee Salary: {employee.CalculateSalary()}");
            }
            else
            {
                Console.WriteLine("Employee not found.");
            }
        }

        static void DisplayTotalPayroll()
        {
            double totalPayroll = 0;
            foreach (var employee in employees)
            {
                totalPayroll += employee.CalculateSalary();
            }
            Console.WriteLine($"Total Payroll: {totalPayroll}");
        }
    }
}
