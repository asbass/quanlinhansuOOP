using System.Text;

namespace DatabaseModels
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int ParentDepartmentId { get; set; }
        public int HeadId { get; set; }
        public List<int> ListDeputyId { get; set; }
        public List<Employee> Employees { get; set; } = new List<Employee>();

        public Employee Head { get; set; }
        public List<Employee> Deputies { get; set; } = new List<Employee>();
    }

    public class Position
    {
        public int PositionID { get; set; }
        public string PositionName { get; set; }
    }

    public class ContractType
    {
        public int ContractTypeID { get; set; }
        public string TypeName { get; set; }
    }

    public class Employee
    {
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Identifier { get; set; }
        public string PhoneNumber { get; set; }
        public double SalaryBase { get; set; }

        // Foreign Key Relationships
        public Department Department { get; set; }
        public Position Position { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();
        public List<EmployeeLog> EmployeeLogs { get; set; } = new List<EmployeeLog>();
    }

    public class Contract
    {
        public int ContractID { get; set; }
        public int EmployeeID { get; set; }
        public int ContractTypeID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // Foreign Key Relationships
        public Employee Employee { get; set; }
        public ContractType ContractType { get; set; }
    }

    public class EmployeeLog
    {
        public int LogID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime ChangeDate { get; set; }
        public string Reason { get; set; }
        public double NewSalary { get; set; }
        public int ChangeBy { get; set; }
        public Position Position { get; set; }
        public Department Department { get; set; }
        // Mối quan hệ với Employee
        public Employee Employee { get; set; }

        // Mối quan hệ với người thay đổi
        public Employee ChangedBy { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            // Dữ liệu mẫu cho các phòng ban
            // Sample Data for Department
            var departments = new List<Department>
        {
            new Department { DepartmentID = 1, DepartmentName = "HR", ParentDepartmentId = 0, HeadId = 101, ListDeputyId = new List<int> { 102, 103 } },
            new Department { DepartmentID = 2, DepartmentName = "IT", ParentDepartmentId = 0, HeadId = 104, ListDeputyId = new List<int> { 105, 106 } },
            new Department { DepartmentID = 3, DepartmentName = "Finance", ParentDepartmentId = 0, HeadId = 107, ListDeputyId = new List<int> { 108 } },
            new Department { DepartmentID = 4, DepartmentName = "Sales", ParentDepartmentId = 3, HeadId = 109, ListDeputyId = new List<int> { 110 } },
            new Department { DepartmentID = 5, DepartmentName = "Marketing", ParentDepartmentId = 4, HeadId = 111, ListDeputyId = new List<int> { 112 } },
            new Department { DepartmentID = 6, DepartmentName = "Legal", ParentDepartmentId = 1, HeadId = 113, ListDeputyId = new List<int> { 114, 115 } },
            new Department { DepartmentID = 7, DepartmentName = "Operations", ParentDepartmentId = 2, HeadId = 116, ListDeputyId = new List<int> { 117, 118 } },
            new Department { DepartmentID = 8, DepartmentName = "Customer Support", ParentDepartmentId = 5, HeadId = 119, ListDeputyId = new List<int>() },
            new Department { DepartmentID = 9, DepartmentName = "R&D", ParentDepartmentId = 2, HeadId = 120, ListDeputyId = new List<int> { 121 } },
            new Department { DepartmentID = 10, DepartmentName = "Procurement", ParentDepartmentId = 7, HeadId = 122, ListDeputyId = new List<int>() }
        };

            // Sample Data for Position
            var positions = new List<Position>
            {
                new Position { PositionID = 1, PositionName = "Manager" },
                new Position { PositionID = 2, PositionName = "Team Leader" },
                new Position { PositionID = 3, PositionName = "Staff" },
                new Position { PositionID = 4, PositionName = "Senior Developer" },
                new Position { PositionID = 5, PositionName = "Junior Developer" },
                new Position { PositionID = 6, PositionName = "Intern" },
                new Position { PositionID = 7, PositionName = "HR Specialist" },
                new Position { PositionID = 8, PositionName = "Marketing Executive" },
                new Position { PositionID = 9, PositionName = "Sales Representative" },
                new Position { PositionID = 10, PositionName = "Accountant" },
                new Position { PositionID = 11, PositionName = "Customer Support" },
                new Position { PositionID = 12, PositionName = "Business Analyst" },
                new Position { PositionID = 13, PositionName = "IT Support Specialist" }
            };

            // Sample Data for ContractType
            var contractTypes = new List<ContractType>
            {
                new ContractType { ContractTypeID = 1, TypeName = "Full-Time" },
                new ContractType { ContractTypeID = 2, TypeName = "Part-Time" },
                new ContractType { ContractTypeID = 3, TypeName = "Contractor" },
                new ContractType { ContractTypeID = 4, TypeName = "Freelancer" },
                new ContractType { ContractTypeID = 5, TypeName = "Temporary" },
                new ContractType { ContractTypeID = 6, TypeName = "Internship" },
                new ContractType { ContractTypeID = 7, TypeName = "Seasonal" },
                new ContractType { ContractTypeID = 8, TypeName = "Consultant" },
                new ContractType { ContractTypeID = 9, TypeName = "Volunteer" },
                new ContractType { ContractTypeID = 10, TypeName = "Probation" },
                new ContractType { ContractTypeID = 11, TypeName = "Apprenticeship" },
                new ContractType { ContractTypeID = 12, TypeName = "Fixed-Term" },
                new ContractType { ContractTypeID = 13, TypeName = "On-Call" }
            };

            // Sample Data for Employees
            var employees = new List<Employee>
        {
            // Department 1 (e.g., Sales)
                new Employee { EmployeeID = 101, FullName = "John Smith", DateOfBirth = new DateTime(1980, 5, 15), DepartmentID = 1, PositionID = 1, Address = "123 Main St", Email = "john.smith@example.com", Identifier = "ID101", PhoneNumber = "123-456-7890", SalaryBase = 50000 },
                new Employee { EmployeeID = 102, FullName = "Jane Doe", DateOfBirth = new DateTime(1985, 8, 20), DepartmentID = 1, PositionID = 2, Address = "456 Elm St", Email = "jane.doe@example.com", Identifier = "ID102", PhoneNumber = "123-555-7890", SalaryBase = 45000 },
                new Employee { EmployeeID = 103, FullName = "Alice Johnson", DateOfBirth = new DateTime(1987, 12, 12), DepartmentID = 1, PositionID = 3, Address = "789 Maple Ave", Email = "alice.johnson@example.com", Identifier = "ID103", PhoneNumber = "123-789-1234", SalaryBase = 42000 },
                new Employee { EmployeeID = 117, FullName = "Nancy Brown", DateOfBirth = new DateTime(1991, 11, 15), DepartmentID = 1, PositionID = 2, Address = "1234 Broadway St", Email = "nancy.brown@example.com", Identifier = "ID117", PhoneNumber = "345-678-9012", SalaryBase = 47000 },

                // Department 2 (e.g., IT)
                new Employee { EmployeeID = 104, FullName = "Mark Lee", DateOfBirth = new DateTime(1990, 1, 10), DepartmentID = 2, PositionID = 4, Address = "789 Oak St", Email = "mark.lee@example.com", Identifier = "ID104", PhoneNumber = "321-654-0987", SalaryBase = 55000 },
                new Employee { EmployeeID = 105, FullName = "Emily Davis", DateOfBirth = new DateTime(1995, 3, 25), DepartmentID = 2, PositionID = 5, Address = "321 Pine Rd", Email = "emily.davis@example.com", Identifier = "ID105", PhoneNumber = "321-555-2345", SalaryBase = 46000 },
                new Employee { EmployeeID = 106, FullName = "Michael Brown", DateOfBirth = new DateTime(1992, 6, 30), DepartmentID = 2, PositionID = 6, Address = "654 Birch Ln", Email = "michael.brown@example.com", Identifier = "ID106", PhoneNumber = "987-321-6543", SalaryBase = 48000 },
                new Employee { EmployeeID = 118, FullName = "George Harris", DateOfBirth = new DateTime(1988, 3, 5), DepartmentID = 2, PositionID = 4, Address = "5678 Tech Blvd", Email = "george.harris@example.com", Identifier = "ID118", PhoneNumber = "987-654-3210", SalaryBase = 56000 },

                // Department 3 (e.g., HR)
                new Employee { EmployeeID = 107, FullName = "Chris Taylor", DateOfBirth = new DateTime(1985, 9, 5), DepartmentID = 3, PositionID = 7, Address = "432 Cedar St", Email = "chris.taylor@example.com", Identifier = "ID107", PhoneNumber = "789-123-4567", SalaryBase = 53000 },
                new Employee { EmployeeID = 108, FullName = "Sarah Wilson", DateOfBirth = new DateTime(1988, 7, 10), DepartmentID = 3, PositionID = 8, Address = "567 Walnut Dr", Email = "sarah.wilson@example.com", Identifier = "ID108", PhoneNumber = "567-890-1234", SalaryBase = 47000 },
                new Employee { EmployeeID = 119, FullName = "Rachel Adams", DateOfBirth = new DateTime(1993, 9, 28), DepartmentID = 3, PositionID = 8, Address = "9101 Office Park", Email = "rachel.adams@example.com", Identifier = "ID119", PhoneNumber = "123-456-7891", SalaryBase = 49000 },

                // Department 4 (e.g., Finance)
                new Employee { EmployeeID = 109, FullName = "David Martinez", DateOfBirth = new DateTime(1990, 11, 1), DepartmentID = 4, PositionID = 9, Address = "890 Spruce Ln", Email = "david.martinez@example.com", Identifier = "ID109", PhoneNumber = "123-890-4567", SalaryBase = 52000 },
                new Employee { EmployeeID = 110, FullName = "Laura Garcia", DateOfBirth = new DateTime(1995, 4, 18), DepartmentID = 4, PositionID = 10, Address = "321 Cherry St", Email = "laura.garcia@example.com", Identifier = "ID110", PhoneNumber = "234-567-8901", SalaryBase = 48000 },
                new Employee { EmployeeID = 120, FullName = "Tom Wilson", DateOfBirth = new DateTime(1992, 5, 19), DepartmentID = 4, PositionID = 10, Address = "1213 Investment St", Email = "tom.wilson@example.com", Identifier = "ID120", PhoneNumber = "432-567-8901", SalaryBase = 51000 },

                // Department 5 (e.g., Operations)
                new Employee { EmployeeID = 111, FullName = "Anthony Green", DateOfBirth = new DateTime(1984, 2, 11), DepartmentID = 5, PositionID = 11, Address = "111 Meadow Ln", Email = "anthony.green@example.com", Identifier = "ID111", PhoneNumber = "456-789-0123", SalaryBase = 54000 },
                new Employee { EmployeeID = 112, FullName = "Jessica White", DateOfBirth = new DateTime(1992, 5, 3), DepartmentID = 5, PositionID = 12, Address = "222 Blossom St", Email = "jessica.white@example.com", Identifier = "ID112", PhoneNumber = "123-567-7890", SalaryBase = 46000 },
                new Employee { EmployeeID = 121, FullName = "Sophia Martinez", DateOfBirth = new DateTime(1994, 2, 14), DepartmentID = 5, PositionID = 11, Address = "1415 Business Ave", Email = "sophia.martinez@example.com", Identifier = "ID121", PhoneNumber = "321-654-0987", SalaryBase = 55000 },

                // Department 6 (e.g., Marketing)
                new Employee { EmployeeID = 113, FullName = "Paul Walker", DateOfBirth = new DateTime(1989, 7, 25), DepartmentID = 6, PositionID = 13, Address = "333 Sycamore Ave", Email = "paul.walker@example.com", Identifier = "ID113", PhoneNumber = "789-012-3456", SalaryBase = 47000 },
                new Employee { EmployeeID = 114, FullName = "Angela Evans", DateOfBirth = new DateTime(1993, 10, 19), DepartmentID = 6, PositionID = 14, Address = "444 Magnolia Rd", Email = "angela.evans@example.com", Identifier = "ID114", PhoneNumber = "234-678-9012", SalaryBase = 53000 },
                new Employee { EmployeeID = 122, FullName = "Daniel Lee", DateOfBirth = new DateTime(1996, 4, 22), DepartmentID = 6, PositionID = 13, Address = "1617 Creative Rd", Email = "daniel.lee@example.com", Identifier = "ID122", PhoneNumber = "234-567-8902", SalaryBase = 48000 },

                // Department 7 (e.g., Customer Service)
                new Employee { EmployeeID = 115, FullName = "Kevin Parker", DateOfBirth = new DateTime(1986, 1, 8), DepartmentID = 7, PositionID = 15, Address = "555 Palm Dr", Email = "kevin.parker@example.com", Identifier = "ID115", PhoneNumber = "345-789-2345", SalaryBase = 50000 },
                new Employee { EmployeeID = 116, FullName = "Olivia Scott", DateOfBirth = new DateTime(1990, 6, 14), DepartmentID = 7, PositionID = 16, Address = "666 Rose St", Email = "olivia.scott@example.com", Identifier = "ID116", PhoneNumber = "123-890-9876", SalaryBase = 51000 },
                        //new Employee { EmployeeID = 123, FullName = "Ethan Foster", DateOfBirth = new DateTime(1985, 11, 8), DepartmentID = 11, PositionID = 1, Address = "333 Spring Rd", Email = "ethan.foster@example.com", Identifier = "ID123", PhoneNumber = "567-890-1234", SalaryBase = 56000 },
            //new Employee { EmployeeID = 124, FullName = "Victoria Hughes", DateOfBirth = new DateTime(1993, 7, 18), DepartmentID = 11, PositionID = 2, Address = "444 Summer Ln", Email = "victoria.hughes@example.com", Identifier = "ID124", PhoneNumber = "678-901-2345", SalaryBase = 47000 },
            //new Employee { EmployeeID = 125, FullName = "Daniel Turner", DateOfBirth = new DateTime(1992, 9, 14), DepartmentID = 12, PositionID = 3, Address = "555 Winter Dr", Email = "daniel.turner@example.com", Identifier = "ID125", PhoneNumber = "789-012-3456", SalaryBase = 45000 }
        new Employee
            {
                EmployeeID = 123,
                FullName = "Ethan Foster",
                DateOfBirth = new DateTime(1990, 11, 15),
                DepartmentID = 8, // Customer Support
                PositionID = 11, // Customer Support
                Address = "333 Customer Ave",
                Email = "ethan.foster@example.com",
                PhoneNumber = "987-654-3210",
                SalaryBase = 45000
            }
        };

            var contracts = new List<Contract>
            {
                new Contract { ContractID = 1, EmployeeID = 101, ContractTypeID = 1, StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2025, 1, 1) },
                new Contract { ContractID = 2, EmployeeID = 102, ContractTypeID = 2, StartDate = new DateTime(2021, 6, 1), EndDate = new DateTime(2024, 6, 1) },
                new Contract { ContractID = 3, EmployeeID = 104, ContractTypeID = 1, StartDate = new DateTime(2019, 3, 15), EndDate = new DateTime(2024, 3, 15) },
                new Contract { ContractID = 4, EmployeeID = 105, ContractTypeID = 3, StartDate = new DateTime(2022, 5, 10), EndDate = new DateTime(2026, 5, 10) },
                new Contract { ContractID = 5, EmployeeID = 106, ContractTypeID = 2, StartDate = new DateTime(2020, 8, 1), EndDate = new DateTime(2023, 8, 1) },
                new Contract { ContractID = 6, EmployeeID = 107, ContractTypeID = 1, StartDate = new DateTime(2018, 4, 5), EndDate = new DateTime(2023, 4, 5) },
                new Contract { ContractID = 7, EmployeeID = 108, ContractTypeID = 3, StartDate = new DateTime(2023, 9, 12), EndDate = new DateTime(2025, 9, 12) },
                new Contract { ContractID = 8, EmployeeID = 109, ContractTypeID = 1, StartDate = new DateTime(2017, 2, 15), EndDate = new DateTime(2022, 2, 15) },
                new Contract { ContractID = 9, EmployeeID = 110, ContractTypeID = 2, StartDate = new DateTime(2022, 10, 1), EndDate = new DateTime(2025, 10, 1) },
                new Contract { ContractID = 10, EmployeeID = 111, ContractTypeID = 3, StartDate = new DateTime(2019, 11, 20), EndDate = new DateTime(2024, 11, 20) },
                new Contract { ContractID = 11, EmployeeID = 112, ContractTypeID = 1, StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2026, 1, 1) },
                new Contract { ContractID = 12, EmployeeID = 113, ContractTypeID = 2, StartDate = new DateTime(2021, 7, 15), EndDate = new DateTime(2024, 7, 15) },
                new Contract { ContractID = 13, EmployeeID = 114, ContractTypeID = 1, StartDate = new DateTime(2020, 5, 10), EndDate = new DateTime(2023, 5, 10) },
                new Contract { ContractID = 14, EmployeeID = 115, ContractTypeID = 3, StartDate = new DateTime(2022, 3, 5), EndDate = new DateTime(2025, 3, 5) },
                new Contract { ContractID = 15, EmployeeID = 116, ContractTypeID = 2, StartDate = new DateTime(2022, 9, 1), EndDate = new DateTime(2025, 9, 1) },
                new Contract { ContractID = 16, EmployeeID = 117, ContractTypeID = 1, StartDate = new DateTime(2019, 8, 20), EndDate = new DateTime(2024, 8, 20) },
                new Contract { ContractID = 17, EmployeeID = 118, ContractTypeID = 3, StartDate = new DateTime(2023, 6, 10), EndDate = new DateTime(2026, 6, 10) },
                new Contract { ContractID = 18, EmployeeID = 119, ContractTypeID = 2, StartDate = new DateTime(2021, 4, 15), EndDate = new DateTime(2024, 4, 15) },
                new Contract { ContractID = 19, EmployeeID = 120, ContractTypeID = 1, StartDate = new DateTime(2018, 12, 5), EndDate = new DateTime(2023, 12, 5) },
                new Contract { ContractID = 20, EmployeeID = 121, ContractTypeID = 3, StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2027, 2, 1) },

                new Contract
                {
                    ContractID = 21,
                    EmployeeID = 102, // Jane Doe
                    ContractTypeID = 1, // Full-Time
                    StartDate = new DateTime(2023, 1, 1),
                    EndDate = new DateTime(2025, 1, 1)
                },
                new Contract
                {
                    ContractID = 22,
                    EmployeeID = 102, // Jane Doe
                    ContractTypeID = 3, // Contractor
                    StartDate = new DateTime(2024, 1, 1),
                    EndDate = new DateTime(2024, 12, 31)
                }
            };

            // Sample Data for EmployeeLogs
            var employeeLogs = new List<EmployeeLog>
        {
            new EmployeeLog
            {
                LogID = 1,
                EmployeeID = 101,
                ChangeDate = new DateTime(2022, 7, 1),
                Reason = "Promotion",
                NewSalary = 55000,
                ChangeBy = 104,
                Position = positions.First(p => p.PositionID == 1),
                Department = departments.First(d => d.DepartmentID == 1)
            },
            new EmployeeLog
            {
                LogID = 2,
                EmployeeID = 102,
                ChangeDate = new DateTime(2023, 1, 1),
                Reason = "Performance Bonus",
                NewSalary = 47000,
                ChangeBy = 101,
                Position = positions.First(p => p.PositionID == 2),
                Department = departments.First(d => d.DepartmentID == 1)
            },
            new EmployeeLog
            {
                LogID = 3,
                EmployeeID = 105,
                ChangeDate = new DateTime(2023, 6, 10),
                Reason = "Salary Adjustment",
                NewSalary = 60000,
                ChangeBy = 102,
                Position = positions.First(p => p.PositionID == 3),
                Department = departments.First(d => d.DepartmentID == 2)
            },
            new EmployeeLog
            {
                LogID = 4,
                EmployeeID = 106,
                ChangeDate = new DateTime(2022, 11, 15),
                Reason = "Promotion",
                NewSalary = 52000,
                ChangeBy = 105,
                Position = positions.First(p => p.PositionID == 2),
                Department = departments.First(d => d.DepartmentID == 1)
            },
            new EmployeeLog
            {
                LogID = 5,
                EmployeeID = 107,
                ChangeDate = new DateTime(2022, 8, 25),
                Reason = "Contract Renewal",
                NewSalary = 48000,
                ChangeBy = 104,
                Position = positions.First(p => p.PositionID == 4),
                Department = departments.First(d => d.DepartmentID == 3)
            },
            new EmployeeLog
            {
                LogID = 6,
                EmployeeID = 108,
                ChangeDate = new DateTime(2023, 4, 10),
                Reason = "Transfer",
                NewSalary = 59000,
                ChangeBy = 103,
                Position = positions.First(p => p.PositionID == 5),
                Department = departments.First(d => d.DepartmentID == 2)
            },
            new EmployeeLog
            {
                LogID = 7,
                EmployeeID = 109,
                ChangeDate = new DateTime(2022, 12, 5),
                Reason = "Promotion",
                NewSalary = 51000,
                ChangeBy = 107,
                Position = positions.First(p => p.PositionID == 1),
                Department = departments.First(d => d.DepartmentID == 1)
            },
            new EmployeeLog
            {
                LogID = 8,
                EmployeeID = 110,
                ChangeDate = new DateTime(2023, 3, 22),
                Reason = "Performance Review",
                NewSalary = 55000,
                ChangeBy = 108,
                Position = positions.First(p => p.PositionID == 2),
                Department = departments.First(d => d.DepartmentID == 3)
            },
            new EmployeeLog
            {
                LogID = 9,
                EmployeeID = 111,
                ChangeDate = new DateTime(2022, 10, 30),
                Reason = "New Contract",
                NewSalary = 60000,
                ChangeBy = 109,
                Position = positions.First(p => p.PositionID == 3),
                Department = departments.First(d => d.DepartmentID == 4)
            },
            new EmployeeLog
            {
                LogID = 10,
                EmployeeID = 112,
                ChangeDate = new DateTime(2023, 7, 12),
                Reason = "Salary Increase",
                NewSalary = 62000,
                ChangeBy = 110,
                Position = positions.First(p => p.PositionID == 4),
                Department = departments.First(d => d.DepartmentID == 5)
            },
            new EmployeeLog
            {
                LogID = 11,
                EmployeeID = 113,
                ChangeDate = new DateTime(2023, 5, 5),
                Reason = "Promotion",
                NewSalary = 63000,
                ChangeBy = 111,
                Position = positions.First(p => p.PositionID == 5),
                Department = departments.First(d => d.DepartmentID == 6)
            },
            new EmployeeLog
            {
                LogID = 12,
                EmployeeID = 101, // John Smith
                ChangeDate = new DateTime(2021, 5, 1),
                Reason = "Promoted to Manager",
                NewSalary = 60000,
                ChangeBy = 104, // Mark Lee
                Position = positions.First(p => p.PositionID == 1), // Manager
                Department = departments.First(d => d.DepartmentID == 1) // HR
            },
            new EmployeeLog
            {
                LogID = 13,
                EmployeeID = 101, // John Smith
                ChangeDate = new DateTime(2023, 3, 1),
                Reason = "Moved to IT as Team Leader",
                NewSalary = 65000,
                ChangeBy = 104, // Mark Lee
                Position = positions.First(p => p.PositionID == 2), // Team Leader
                Department = departments.First(d => d.DepartmentID == 2) // IT
            },

        };

            // Linking Data
            foreach (var department in departments)
            {
                department.Employees = employees.Where(e => e.DepartmentID == department.DepartmentID).ToList();
                department.Head = employees.FirstOrDefault(e => e.EmployeeID == department.HeadId);
                department.Deputies = employees.Where(e => department.ListDeputyId.Contains(e.EmployeeID)).ToList();
            }

            foreach (var employee in employees)
            {
                employee.Department = departments.FirstOrDefault(d => d.DepartmentID == employee.DepartmentID);
                employee.Position = positions.FirstOrDefault(p => p.PositionID == employee.PositionID);
                employee.Contracts = contracts.Where(c => c.EmployeeID == employee.EmployeeID).ToList();
                employee.EmployeeLogs = employeeLogs.Where(el => el.EmployeeID == employee.EmployeeID).ToList();
            }
            // 1. Lấy danh sách tất cả các nhân viên trong phòng ban IT
            var employeesInIT = employees.Where(e => e.Department.DepartmentName == "IT").ToList();
            Console.WriteLine("1 Danh sách nhân viên trong phòng ban IT:");
            employeesInIT.ForEach(e => Console.WriteLine($"- {e.FullName}, Lương: {e.SalaryBase}"));

            // 2. Lấy danh sách các nhân viên có lương cơ bản trên 50,000
            var highSalaryEmployees = employees.Where(e => e.SalaryBase > 50000).ToList();
            Console.WriteLine("\n2 Danh sách nhân viên có lương cơ bản trên 50,000:");
            highSalaryEmployees.ForEach(e => Console.WriteLine($"- {e.FullName}, Lương: {e.SalaryBase}"));

            // 3. Lấy danh sách hợp đồng có thời hạn dưới 3 năm
            var shortTermContracts = contracts.Where(c => (c.EndDate - c.StartDate).Days / 365 < 3).ToList();
            Console.WriteLine("\n3 Danh sách hợp đồng có thời hạn dưới 3 năm:");
            shortTermContracts.ForEach(c => Console.WriteLine($"- Hợp đồng ID: {c.ContractID}, Thời hạn: {(c.EndDate - c.StartDate).Days / 365} năm"));

            // 4. Lấy danh sách nhân viên và thông tin phòng ban của họ
            var employeesWithDepartments = employees.Select(e => new
            {
                e.FullName,
                DepartmentName = e.Department.DepartmentName,
                e.SalaryBase
            }).ToList();
            Console.WriteLine("\n4 Danh sách nhân viên và phòng ban của họ:");
            employeesWithDepartments.ForEach(e => Console.WriteLine($"- {e.FullName}, Phòng ban: {e.DepartmentName}, Lương: {e.SalaryBase}"));

            // 5. Đếm số lượng nhân viên trong từng phòng ban
            var employeeCountByDepartment = departments.Select(d => new
            {
                d.DepartmentName,
                EmployeeCount = d.Employees.Count
            }).ToList();
            Console.WriteLine("\n5 Số lượng nhân viên trong từng phòng ban:");
            employeeCountByDepartment.ForEach(d => Console.WriteLine($"- {d.DepartmentName}: {d.EmployeeCount} nhân viên"));

            // 6. Lấy danh sách các nhân viên đã từng được tăng lương (có log lương)
            var employeesWithSalaryLogs = employees.Where(e => e.EmployeeLogs.Any()).ToList();
            Console.WriteLine("\n6 Danh sách nhân viên đã từng được tăng lương:");
            employeesWithSalaryLogs.ForEach(e => Console.WriteLine($"- {e.FullName}"));

            // 7. Lấy danh sách các nhân viên làm việc dưới quyền của Mark Lee (ID 104)
            var employeesUnderMark = employees
                .Where(e => e.Department.HeadId == 104 || e.Department.ListDeputyId.Contains(104))
                .ToList();
            Console.WriteLine("\n7 Danh sách nhân viên làm việc dưới quyền Mark Lee:");
            employeesUnderMark.ForEach(e => Console.WriteLine($"- {e.FullName}"));

            // 8. Danh sách nhân viên có ít nhất một hợp đồng hiện tại còn hiệu lực
            var currentDate = DateTime.Now;
            var employeesWithActiveContracts = employees
                .Where(e => e.Contracts.Any(c => c.StartDate <= currentDate && c.EndDate >= currentDate))
                .Select(e => new
                {
                    e.EmployeeID,
                    e.FullName,
                    ActiveContracts = e.Contracts.Where(c => c.StartDate <= currentDate && c.EndDate >= currentDate).ToList()
                });

            Console.WriteLine("\n8 Danh sách nhân viên có hợp đồng hiện tại còn hiệu lực:");
            foreach (var emp in employeesWithActiveContracts)
            {
                Console.WriteLine($"Nhân viên ID: {emp.EmployeeID}, Tên: {emp.FullName}");
                Console.WriteLine("Hợp đồng hiện tại:");
                foreach (var contract in emp.ActiveContracts)
                {
                    Console.WriteLine($"  - Hợp đồng ID: {contract.ContractID}, Bắt đầu: {contract.StartDate:d}, Kết thúc: {contract.EndDate:d}");
                }
            }

            // 9. Tính tổng lương cơ bản của tất cả các nhân viên trong phòng ban Finance
            var totalSalaryFinance = employees
                .Where(e => e.Department.DepartmentName == "Finance")
                .Sum(e => e.SalaryBase);
            Console.WriteLine($"\n9 Tổng lương của phòng ban Finance: {totalSalaryFinance}");

            // 10. Lấy danh sách các nhân viên và thông tin hợp đồng gần nhất của họ
            var employeesWithLatestContract = employees.Select(e => new
            {
                e.FullName,
                LatestContract = e.Contracts.OrderByDescending(c => c.StartDate).FirstOrDefault()
            }).ToList();
            Console.WriteLine("\n10 Danh sách nhân viên và hợp đồng gần nhất của họ:");
            employeesWithLatestContract.ForEach(e =>
            {
                var contractInfo = e.LatestContract != null ? $"Hợp đồng ID: {e.LatestContract.ContractID}, Bắt đầu: {e.LatestContract.StartDate}, Kết thúc: {e.LatestContract.EndDate}" : "Không có hợp đồng";
                Console.WriteLine($"- {e.FullName}, {contractInfo}");
            });
            //11. Liệt kê các nhân viên có hợp đồng kết thúc vào năm 2024 và chưa có nhật ký công việc
            var employeesWithContractsEnding2024 = employees
    .Where(e => e.Contracts.Any(c => c.EndDate.Year == 2024)) // Lọc nhân viên có hợp đồng kết thúc vào năm 2024
    .Where(e => e.EmployeeLogs == null || !e.EmployeeLogs.Any()) // Kiểm tra chưa có nhật ký công việc
    .Select(e => new
    {
        EmployeeID = e.EmployeeID,
        FullName = e.FullName,
        DepartmentName = e.Department?.DepartmentName ?? "Unknown",
        PositionName = e.Position?.PositionName ?? "Unknown",
        Contracts = e.Contracts.Where(c => c.EndDate.Year == 2024).ToList()
    })
    .ToList();
            Console.WriteLine("\n11 các nhân viên có hợp đồng kết thúc vào năm 2024 và chưa có nhật ký công việc:");
            // Hiển thị kết quả
            foreach (var employee in employeesWithContractsEnding2024)
            {
                Console.WriteLine($"Mã nhân viên: {employee.EmployeeID}, Tên đầy đủ: {employee.FullName}, Phòng ban: {employee.DepartmentName}, Vị trí: {employee.PositionName}");
                foreach (var contract in employee.Contracts)
                {
                    Console.WriteLine($"\tMã hợp đồng: {contract.ContractID}, Ngày bắt đầu: {contract.StartDate}, Ngày kết thúc: {contract.EndDate}");
                }
            }

            //12. Liệt kê các nhân viên có hợp đồng trong phòng ban 'IT' với thời hạn hợp đồng dài nhất
            var query12 = from e in employees
                          join c in contracts on e.EmployeeID equals c.EmployeeID
                          where e.Department.DepartmentName == "IT"
                          orderby (c.EndDate - c.StartDate).TotalDays descending
                          select new { e.FullName, ContractDuration = (c.EndDate - c.StartDate).TotalDays };

            var longestContract = query12.FirstOrDefault();
            Console.WriteLine("\n12 Nhân viên trong phòng ban IT có hợp đồng dài nhất:");
            if (longestContract != null)
            {
                Console.WriteLine($"{longestContract.FullName} - {longestContract.ContractDuration} ngày");
            }
            //13. Liệt kê các nhân viên chưa có hợp đồng và phòng ban của họ
            var query13 = from e in employees
                          join c in contracts on e.EmployeeID equals c.EmployeeID into contractGroup
                          where !contractGroup.Any()
                          select new { e.FullName, e.Department.DepartmentName };

            Console.WriteLine("\n13 Nhân viên chưa có hợp đồng:");
            foreach (var item in query13)
            {
                Console.WriteLine($"{item.FullName} - {item.DepartmentName}");
            }
            //14 Liệt kê nhân viên với số lượng hợp đồng nhiều nhất trong công ty
            var query14 = from c in contracts
                          group c by c.EmployeeID into g
                          orderby g.Count() descending
                          select new { EmployeeID = g.Key, ContractCount = g.Count(), EmployeeName = employees.First(e => e.EmployeeID == g.Key).FullName };

            var topContract = query14.FirstOrDefault();
            Console.WriteLine("\n14 Nhân viên có số hợp đồng nhiều nhất:");
            if (topContract != null)
            {
                Console.WriteLine($"{topContract.EmployeeName} - {topContract.ContractCount} hợp đồng");
            }
            //15 Liệt kê các nhân viên có ngày sinh gần nhất
            var query15 = employees.OrderBy(e => Math.Abs((e.DateOfBirth - DateTime.Now).Days))
                       .Select(e => new { e.FullName, e.DateOfBirth })
                       .Take(5);

            Console.WriteLine("\n15 Nhân viên có ngày sinh gần nhất:");
            foreach (var item in query15)
            {
                Console.WriteLine($"{item.FullName} - {item.DateOfBirth.ToShortDateString()}");
            }
            //16 Liệt kê những nhân viên lương cao nhất theo mỗi phòng ban
            var highestPaidEmployees = employees
         .GroupBy(e => e.DepartmentID) // Nhóm nhân viên theo DepartmentID
         .Select(g => g.OrderByDescending(e => e.SalaryBase) // Sắp xếp theo lương giảm dần
                        .First()) // Lấy nhân viên có lương cao nhất trong mỗi nhóm
         .Select(e => new
         {
             MaPhongBan = e.DepartmentID,
             TenPhongBan = e.Department?.DepartmentName ?? "Không xác định",
             MaNhanVien = e.EmployeeID,
             HoTen = e.FullName,
             Luong = e.SalaryBase
         })
         .ToList();
            Console.WriteLine("\n16 nhân viên lương cao nhất theo mỗi phòng ban");
            // Hiển thị kết quả
            foreach (var employee in highestPaidEmployees)
            {
                Console.WriteLine($"Mã Phòng Ban: {employee.MaPhongBan}, Tên Phòng Ban: {employee.TenPhongBan}, Mã Nhân Viên: {employee.MaNhanVien}, Họ Tên: {employee.HoTen}, Lương: {employee.Luong}");
            }
            //17. Liệt kê những nhân viên có thâm niên làm việc trên dưới 3 năm
            var underThreeYears = employees
    .Where(e => e.Contracts.Any() && (DateTime.Now - e.Contracts.First().StartDate).TotalDays < 3 * 365) // Lọc nhân viên làm việc dưới 3 năm
    .Select(e => new
    {
        EmployeeID = e.EmployeeID,
        FullName = e.FullName,
        StartDate = e.Contracts.First().StartDate, // Lấy ngày bắt đầu hợp đồng đầu tiên
        TotalDaysWorked = (DateTime.Now - e.Contracts.First().StartDate).TotalDays, // Tổng số ngày làm việc
    })
    .ToList();

            var overThreeYears = employees
                .Where(e => e.Contracts.Any() && (DateTime.Now - e.Contracts.First().StartDate).TotalDays >= 3 * 365) // Lọc nhân viên làm việc trên 3 năm
                .Select(e => new
                {
                    EmployeeID = e.EmployeeID,
                    FullName = e.FullName,
                    StartDate = e.Contracts.First().StartDate, // Lấy ngày bắt đầu hợp đồng đầu tiên
                    TotalDaysWorked = (DateTime.Now - e.Contracts.First().StartDate).TotalDays, // Tổng số ngày làm việc
                })
                .ToList();

            // Hàm để chuyển tổng số ngày làm việc thành năm và ngày
            Func<double, (int years, int days)> convertToYearsAndDays = totalDays =>
            {
                int years = (int)(totalDays / 365); // Số năm
                int days = (int)(totalDays % 365);  // Số ngày dư
                return (years, days);
            };
            Console.WriteLine("\n17 Những nhân viên làm việc trên và dưới 3 năm:");
            // Hiển thị kết quả
            Console.WriteLine("Nhân viên làm việc dưới 3 năm:");
            foreach (var employee in underThreeYears)
            {
                var (years, days) = convertToYearsAndDays(employee.TotalDaysWorked);
                Console.WriteLine($"Mã Nhân Viên: {employee.EmployeeID}, Họ Tên: {employee.FullName}, Ngày Bắt Đầu: {employee.StartDate}, Thời Gian Làm Việc: {years} năm {days} ngày");
            }

            Console.WriteLine("\nNhân viên làm việc trên 3 năm:");
            foreach (var employee in overThreeYears)
            {
                var (years, days) = convertToYearsAndDays(employee.TotalDaysWorked);
                Console.WriteLine($"Mã Nhân Viên: {employee.EmployeeID}, Họ Tên: {employee.FullName}, Ngày Bắt Đầu: {employee.StartDate}, Thời Gian Làm Việc: {years} năm {days} ngày");
            }
            // 18. Liệt kê các nhân viên có hợp đồng dài nhất
            var employeesWithLongestContracts = employees
                .Select(e => new
                {
                    e.FullName,
                    LongestContract = e.Contracts.OrderByDescending(c => (c.EndDate - c.StartDate).TotalDays).FirstOrDefault()
                })
                .Where(e => e.LongestContract != null)
                .ToList();
            Console.WriteLine("\n18. Nhân viên có hợp đồng dài nhất:");
            employeesWithLongestContracts.ForEach(e => Console.WriteLine($"- {e.FullName}, Hợp đồng ID: {e.LongestContract.ContractID}, Thời gian: {(e.LongestContract.EndDate - e.LongestContract.StartDate).TotalDays} ngày"));

            // 19. Nhân viên lớn tuổi nhất theo từng phòng ban
            var oldestEmployeeByDept = departments
                .Select(d => new
                {
                    d.DepartmentName,
                    OldestEmployee = d.Employees.OrderBy(e => e.DateOfBirth).FirstOrDefault()
                })
                .Where(d => d.OldestEmployee != null)
                .ToList();
            Console.WriteLine("\n19. Nhân viên lớn tuổi nhất theo từng phòng ban:");
            oldestEmployeeByDept.ForEach(d =>
            {
                Console.WriteLine($"- {d.DepartmentName}: {d.OldestEmployee.FullName}, Ngày sinh: {d.OldestEmployee.DateOfBirth.ToShortDateString()}");
            });

            // 20. Tính tổng lương cơ bản của tất cả các phòng ban
            var totalSalaryByDept = departments
                .Select(d => new
                {
                    d.DepartmentName,
                    TotalSalary = d.Employees.Sum(e => e.SalaryBase)
                })
                .ToList();
            Console.WriteLine("\n20. Tổng lương cơ bản của tất cả các phòng ban:");
            totalSalaryByDept.ForEach(d => Console.WriteLine($"- {d.DepartmentName}: {d.TotalSalary}"));

            //21. liệt kê các trưởng phòng và phó phòng của các phòng ban
            Console.WriteLine("Liệt kê các trưởng phòng và phó phòng của các phòng ban");
                var departmentHeadsAndDeputies = departments
                    .Select(d => new
                    {
                        DepartmentName = d.DepartmentName,
                        Head = employees.FirstOrDefault(e => e.EmployeeID == d.HeadId)?.FullName ?? "Chưa có trưởng phòng",
                        Deputies = employees.Where(e => d.ListDeputyId.Contains(e.EmployeeID))
                                            .Select(e => e.FullName)
                                            .ToList()
                    })
                    .ToList();

                foreach (var dept in departmentHeadsAndDeputies)
                {
                    Console.WriteLine($"Phòng ban: {dept.DepartmentName}");
                    Console.WriteLine($"  Trưởng phòng: {dept.Head}");
                    Console.WriteLine($"  Phó phòng: {string.Join(", ", dept.Deputies)}");
                }
                //22. Liết kê phòng ban có nhiều hơn 1 phó phòng
                Console.WriteLine(" Liết kê phòng ban có nhiều hơn 1 phó phòng");
                var departmentsWithMultipleDeputies = departments
                .Where(d => d.ListDeputyId.Count > 1) // Lọc các phòng ban có hơn 1 phó phòng
                .Select(d => new
                {
                    DepartmentName = d.DepartmentName,
                    DeputyCount = d.ListDeputyId.Count,
                    Deputies = employees.Where(e => d.ListDeputyId.Contains(e.EmployeeID))
                                        .Select(e => e.FullName)
                                        .ToList()
                })
                .ToList();

                foreach (var dept in departmentsWithMultipleDeputies)
                {
                    Console.WriteLine($"Phòng ban: {dept.DepartmentName}");
                    Console.WriteLine($"  Số lượng phó phòng: {dept.DeputyCount}");
                    Console.WriteLine($"  Danh sách phó phòng: {string.Join(", ", dept.Deputies)}");
                }
                //23. Liệt kê tất cả các phòng ban có phòng ban con
                Console.WriteLine("Liệt kê tất cả các phòng ban có phòng ban con");
                List<Department> GetAllSubDepartments(List<Department> departments, int parentId)
                {
                    var result = new List<Department>();
                    var subDepartments = departments.Where(d => d.ParentDepartmentId == parentId).ToList();

                    foreach (var subDept in subDepartments)
                    {
                        result.Add(subDept);
                        result.AddRange(GetAllSubDepartments(departments, subDept.DepartmentID)); // Đệ quy tìm cấp con
                    }

                    return result;
                }

                // Truy vấn tất cả các phòng ban có cấp con
                var departmentsWithSubDepartments = departments
                    .Where(parent => departments.Any(child => child.ParentDepartmentId == parent.DepartmentID))
                    .Select(parent => new
                    {
                        DepartmentName = parent.DepartmentName,
                        SubDepartments = GetAllSubDepartments(departments, parent.DepartmentID)
                    })

                    .ToList();

                foreach (var dept in departmentsWithSubDepartments)
                {
                    Console.WriteLine($"Phòng ban: {dept.DepartmentName}");
                    Console.WriteLine($"  Phòng ban con: {string.Join(", ", dept.SubDepartments.Select(sub => sub.DepartmentName))}");
                }
                //24 Tìm lịch sử thay đổi của 1 nhân viên theo tên
                string employeeName = "John Smith"; // Tên nhân viên cần tìm

                Console.WriteLine("Tìm lịch sử thay đổi của 1 nhân viên theo tên");
                var employeeHistory = employeeLogs
                    .Where(log => employees.Any(emp => emp.EmployeeID == log.EmployeeID && emp.FullName == employeeName))
                    .Select(log => new
                    {
                        log.LogID,
                        log.EmployeeID,
                        log.ChangeDate,
                        log.Reason,
                        log.NewSalary,
                        log.ChangeBy,
                        PositionName = log.Position.PositionName, // Giả sử thuộc tính PositionName tồn tại
                        DepartmentName = log.Department.DepartmentName // Giả sử thuộc tính DepartmentName tồn tại
                    })
                    .ToList();
                foreach (var log in employeeHistory)
                {
                    Console.WriteLine($"LogID: {log.LogID}");
                    Console.WriteLine($"EmployeeID: {log.EmployeeID}");
                    Console.WriteLine($"ChangeDate: {log.ChangeDate}");
                    Console.WriteLine($"Reason: {log.Reason}");
                    Console.WriteLine($"NewSalary: {log.NewSalary}");
                    Console.WriteLine($"ChangeBy: {log.ChangeBy}");
                    Console.WriteLine($"Position: {log.PositionName}");
                    Console.WriteLine($"Department: {log.DepartmentName}");
                    Console.WriteLine("------------------------------");
                }
                //25 Đếm số lượng nhân viên của mỗi phòng ban
                Console.WriteLine("Đếm số lượng nhân viên của mỗi phòng ban");

                var departmentEmployeeCount = from d in departments
                                              join e in employees on d.DepartmentID equals e.DepartmentID into deptEmployees
                                              select new
                                              {
                                                  DepartmentName = d.DepartmentName,
                                                  EmployeeCount = deptEmployees.Count()
                                              };

                // In kết quả
                foreach (var item in departmentEmployeeCount)
                {
                    Console.WriteLine($"Phòng ban: {item.DepartmentName}, Số lượng nhân viên: {item.EmployeeCount}");
                }
                //26 Phòng ban có nhiều nhân viên nhất
                Console.WriteLine("Phòng ban có nhiều nhân viên nhất");
                var departmentWithMostEmployees = employees
                .GroupBy(e => e.DepartmentID)
                .Select(g => new
                {
                    DepartmentID = g.Key,
                    EmployeeCount = g.Count()
                })
                .Join(departments,
                      empGroup => empGroup.DepartmentID,
                      dept => dept.DepartmentID,
                      (empGroup, dept) => new
                      {
                          DepartmentName = dept.DepartmentName,
                          EmployeeCount = empGroup.EmployeeCount
                      })
                .OrderByDescending(result => result.EmployeeCount)
                .FirstOrDefault();

                Console.WriteLine($"Phòng ban có nhiếu nhân viên nhất: {departmentWithMostEmployees.DepartmentName}");
                Console.WriteLine($"Số nhân viên: {departmentWithMostEmployees.EmployeeCount}");

                //27 Phòng ban có nhiều nhân viên nhất
                Console.WriteLine("Phòng ban có nhiều nhân viên nhất");
                var departmentWithLeastEmployees = employees
                .GroupBy(e => e.DepartmentID)
                .Select(g => new
                {
                    DepartmentID = g.Key,
                    EmployeeCount = g.Count()
                })
                .Join(departments,
                      empGroup => empGroup.DepartmentID,
                      dept => dept.DepartmentID,
                      (empGroup, dept) => new
                      {
                          DepartmentName = dept.DepartmentName,
                          EmployeeCount = empGroup.EmployeeCount
                      })
                .OrderBy(result => result.EmployeeCount)
                .FirstOrDefault();

                Console.WriteLine($"Phòng ban có ít nhân viên nhất: {departmentWithLeastEmployees.DepartmentName}");
                Console.WriteLine($"Số nhân viên: {departmentWithLeastEmployees.EmployeeCount}");

                //28 Xáp xếp phòng ban theo số lượng nhân viên từ thấp đến cao
                Console.WriteLine("Xáp xếp phòng ban theo số lượng nhân viên từ cao đến thấp");
                var departmentsSortedByEmployeeCount = employees
                .GroupBy(e => e.DepartmentID)
                .Select(g => new
                {
                    DepartmentID = g.Key,
                    EmployeeCount = g.Count()
                })
                .Join(departments,
                      empGroup => empGroup.DepartmentID,
                      dept => dept.DepartmentID,
                      (empGroup, dept) => new
                      {
                          DepartmentName = dept.DepartmentName,
                          EmployeeCount = empGroup.EmployeeCount
                      })
                .OrderByDescending(result => result.EmployeeCount) // Sắp xếp theo số lượng nhân viên tăng dần
                .ToList();

                foreach (var department in departmentsSortedByEmployeeCount)
                {
                    Console.WriteLine($"Department: {department.DepartmentName}, Employees: {department.EmployeeCount}");
                }

                //29 Liệt kê trưởng phòng, phó phòng, nhân viên của phòng ban theo tên phòng ban
                Console.WriteLine("Liệt kê trưởng phòng, phó phòng, nhân viên của phòng ban theo tên phòng ban");
                string departmentName = "IT"; // Tên phòng ban cần truy vấn

                var result = departments
                .Where(dept => dept.DepartmentName == departmentName)
                .SelectMany(dept =>
                    employees
                        .Where(emp =>
                            emp.DepartmentID == dept.DepartmentID // Nhân viên trong phòng ban
                            || emp.EmployeeID == dept.HeadId      // Trưởng phòng
                            || dept.ListDeputyId.Contains(emp.EmployeeID)) // Phó phòng
                        .Select(emp => new
                        {
                            emp.FullName,
                            emp.EmployeeID,
                            emp.DepartmentID,
                            Role = emp.EmployeeID == dept.HeadId
                                ? "Trưởng phòng"
                                : dept.ListDeputyId.Contains(emp.EmployeeID)
                                    ? "Phó phòng"
                                    : "Nhân viên"
                        })
                )
                .ToList();

                foreach (var item in result)
                {
                    Console.WriteLine($"Name: {item.FullName}, EmployeeID: {item.EmployeeID}, DepartmentID: {item.DepartmentID}, Role: {item.Role}");
                }
                //30 Phòng ban có nhiều phó phòng nhất trả về kèm tên nhân viên
                Console.WriteLine("Phòng ban có nhiều phó phòng nhất trả về kèm tên nhân viên");
                var departmentsWithMostDeputy = departments
                .Where(d => d.ListDeputyId.Count == departments
                    .Max(dept => dept.ListDeputyId.Count))
                .Select(d => new
                {
                    DepartmentName = d.DepartmentName,
                    Deputies = d.ListDeputyId.Select(deputyId => employees
                        .FirstOrDefault(e => e.EmployeeID == deputyId)?.FullName)
                        .ToList()
                })
                .ToList();

                // In kết quả
                foreach (var department in departmentsWithMostDeputy)
                {
                    Console.WriteLine($"Department: {department.DepartmentName}");
                    Console.WriteLine("Deputies:");
                    foreach (var deputy in department.Deputies)
                    {
                        Console.WriteLine($"- {deputy}");
                    }
                    Console.WriteLine();
                }
                // 31. Nhân viên có hợp đồng hết hạn sớm nhất
                var contractEndingSoonest = contracts
                    .OrderBy(c => c.EndDate)
                    .FirstOrDefault();
                Console.WriteLine("\n31. Nhân viên có hợp đồng hết hạn sớm nhất:");
                if (contractEndingSoonest != null)
                {
                    var employea = employees.FirstOrDefault(e => e.EmployeeID == contractEndingSoonest.EmployeeID);
                    Console.WriteLine($"- {employea?.FullName}, Hợp đồng ID: {contractEndingSoonest.ContractID}, Ngày kết thúc: {contractEndingSoonest.EndDate}");
                }

                // 32. Danh sách các phòng ban và số nhân viên có lương trên 50.000
                var departmentHighSalaryCount = departments
                    .Select(d => new
                    {
                        d.DepartmentName,
                        HighSalaryCount = d.Employees.Count(e => e.SalaryBase > 50000)
                    })
                    .ToList();
                Console.WriteLine("\n32. Phòng ban và số nhân viên có lương trên 50.000:");
                departmentHighSalaryCount.ForEach(d => Console.WriteLine($"- {d.DepartmentName}: {d.HighSalaryCount} nhân viên"));

                // 33. Tìm nhân viên lớn tuổi nhất trong công ty
                var oldestEmployee = employees
                    .OrderBy(e => e.DateOfBirth)
                    .FirstOrDefault();
                Console.WriteLine("\n33. Nhân viên lớn tuổi nhất:");
                if (oldestEmployee != null)
                    Console.WriteLine($"- {oldestEmployee.FullName}, Ngày sinh: {oldestEmployee.DateOfBirth.ToShortDateString()}");

                // 34. Phòng ban có số nhân viên thấp nhất và chi tiết
                var departmentWithLeastEmployeess = departments
                    .OrderBy(d => d.Employees.Count)
                    .FirstOrDefault();
                Console.WriteLine("\n34. Phòng ban có số nhân viên ít nhất:");
                if (departmentWithLeastEmployeess != null)
                {
                    Console.WriteLine($"- {departmentWithLeastEmployeess.DepartmentName}, Số nhân viên: {departmentWithLeastEmployeess.Employees.Count}");
                    departmentWithLeastEmployeess.Employees.ForEach(e => Console.WriteLine($"  + {e.FullName}"));
                }

                // 35. Liệt kê tất cả các hợp đồng chưa kết thúc
                var ongoingContracts = contracts
                    .Where(c => c.EndDate > DateTime.Now)
                    .ToList();
                Console.WriteLine("\n35. Hợp đồng chưa kết thúc:");
                ongoingContracts.ForEach(c => Console.WriteLine($"- Hợp đồng ID: {c.ContractID}, Nhân viên ID: {c.EmployeeID}, Kết thúc: {c.EndDate}"));

                // 36. Tính tổng số lượng hợp đồng theo từng phòng ban
                var totalContractsByDepartment = departments
                    .Select(d => new
                    {
                        d.DepartmentName,
                        TotalContracts = d.Employees.Sum(e => e.Contracts.Count)
                    })
                    .ToList();
                Console.WriteLine("\n36. Tổng số lượng hợp đồng theo từng phòng ban:");
                totalContractsByDepartment.ForEach(d => Console.WriteLine($"- {d.DepartmentName}: {d.TotalContracts} hợp đồng"));

                // 37. Liệt kê các nhân viên chưa từng ký hợp đồng
                var employeesWithoutContracts = employees
                    .Where(e => !e.Contracts.Any())
                    .ToList();
                Console.WriteLine("\n37. Nhân viên chưa từng ký hợp đồng:");
                employeesWithoutContracts.ForEach(e => Console.WriteLine($"- {e.FullName}"));

                // 38. Nhân viên có lương cao nhất trong công ty
                var highestPaidEmployee = employees
                    .OrderByDescending(e => e.SalaryBase)
                    .FirstOrDefault();
                Console.WriteLine("\n38. Nhân viên có lương cao nhất:");
                if (highestPaidEmployee != null)
                    Console.WriteLine($"- {highestPaidEmployee.FullName}, Lương: {highestPaidEmployee.SalaryBase}");

                // 39. Liệt kê các phòng ban không có nhân viên đã từng được tăng lương
                var departmentsWithoutSalaryIncreases = departments
                    .Where(d => d.Employees.All(e => !e.EmployeeLogs.Any()))
                    .ToList();
                Console.WriteLine("\n39. Phòng ban không có nhân viên từng được tăng lương:");
                departmentsWithoutSalaryIncreases.ForEach(d => Console.WriteLine($"- {d.DepartmentName}"));

                // 40. Tìm các nhân viên đã làm việc ở nhiều vị trí khác nhau
                var employeesWithMultiplePositions = employees
                    .Where(e => e.EmployeeLogs.Select(log => log.Position.PositionID).Distinct().Count() > 1)
                    .ToList();
                Console.WriteLine("\n40. Nhân viên đã làm việc ở nhiều vị trí:");
                employeesWithMultiplePositions.ForEach(e => Console.WriteLine($"- {e.FullName}"));

                // 41. Liệt kê các nhân viên có hơn 1 hợp đồng đang hoạt động
                var employeesWithMultipleActiveContracts = employees
                    .Where(e => e.Contracts.Count(c => c.StartDate <= DateTime.Now && c.EndDate >= DateTime.Now) > 1)
                    .ToList();
                Console.WriteLine("\n41. Nhân viên có hơn 1 hợp đồng đang hoạt động:");
                employeesWithMultipleActiveContracts.ForEach(e => Console.WriteLine($"- {e.FullName}"));

                // 42. Liệt kê các nhân viên làm việc trong phòng ban không có phó phòng
                var employeesInDeptsWithoutDeputies = employees
                    .Where(e => departments.First(d => d.DepartmentID == e.DepartmentID).Deputies.Count == 0)
                    .ToList();
                Console.WriteLine("\n42. Nhân viên trong phòng ban không có phó phòng:");
                employeesInDeptsWithoutDeputies.ForEach(e => Console.WriteLine($"- {e.FullName}"));

                // 43. Liệt kê tất cả các nhân viên và số lần được thay đổi lương
                var employeesWithSalaryChangeCount = employees
                    .Select(e => new { e.FullName, SalaryChangeCount = e.EmployeeLogs.Count })
                    .ToList();
                Console.WriteLine("\n43. Nhân viên và số lần được thay đổi lương:");
                employeesWithSalaryChangeCount.ForEach(e => Console.WriteLine($"- {e.FullName}: {e.SalaryChangeCount} lần"));
              // 45. Nhóm nhân viên theo số lượng hợp đồng họ đã ký
                var employeesGroupedByContractCount = employees
                    .GroupBy(e => e.Contracts.Count)
                    .Select(g => new { ContractCount = g.Key, Employees = g.ToList() })
                    .ToList();
                Console.WriteLine("\n45. Nhân viên nhóm theo số lượng hợp đồng:");
                employeesGroupedByContractCount.ForEach(g =>
                {
                    Console.WriteLine($"- Số hợp đồng: {g.ContractCount}");
                    g.Employees.ForEach(e => Console.WriteLine($"  + {e.FullName}"));
                });

                // 46. Liệt kê các phòng ban không có nhân viên nào dưới 30 tuổi
                var departmentsNoYoungEmployees = departments
                    .Where(d => d.Employees.All(e => (DateTime.Now.Year - e.DateOfBirth.Year) >= 30))
                    .ToList();
                Console.WriteLine("\n46. Phòng ban không có nhân viên dưới 30 tuổi:");
                departmentsNoYoungEmployees.ForEach(d => Console.WriteLine($"- {d.DepartmentName}"));

      


        } 
    }
}