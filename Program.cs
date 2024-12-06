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
                new Employee { EmployeeID = 116, FullName = "Olivia Scott", DateOfBirth = new DateTime(1990, 6, 14), DepartmentID = 7, PositionID = 16, Address = "666 Rose St", Email = "olivia.scott@example.com", Identifier = "ID116", PhoneNumber = "123-890-9876", SalaryBase = 51000 }
                        //new Employee { EmployeeID = 123, FullName = "Ethan Foster", DateOfBirth = new DateTime(1985, 11, 8), DepartmentID = 11, PositionID = 1, Address = "333 Spring Rd", Email = "ethan.foster@example.com", Identifier = "ID123", PhoneNumber = "567-890-1234", SalaryBase = 56000 },
            //new Employee { EmployeeID = 124, FullName = "Victoria Hughes", DateOfBirth = new DateTime(1993, 7, 18), DepartmentID = 11, PositionID = 2, Address = "444 Summer Ln", Email = "victoria.hughes@example.com", Identifier = "ID124", PhoneNumber = "678-901-2345", SalaryBase = 47000 },
            //new Employee { EmployeeID = 125, FullName = "Daniel Turner", DateOfBirth = new DateTime(1992, 9, 14), DepartmentID = 12, PositionID = 3, Address = "555 Winter Dr", Email = "daniel.turner@example.com", Identifier = "ID125", PhoneNumber = "789-012-3456", SalaryBase = 45000 }
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
                new Contract { ContractID = 20, EmployeeID = 121, ContractTypeID = 3, StartDate = new DateTime(2024, 2, 1), EndDate = new DateTime(2027, 2, 1) }

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
            }
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
            Console.WriteLine("Danh sách nhân viên trong phòng ban IT:");
            employeesInIT.ForEach(e => Console.WriteLine($"- {e.FullName}, Lương: {e.SalaryBase}"));

            // 2. Lấy danh sách các nhân viên có lương cơ bản trên 50,000
            var highSalaryEmployees = employees.Where(e => e.SalaryBase > 50000).ToList();
            Console.WriteLine("\nDanh sách nhân viên có lương cơ bản trên 50,000:");
            highSalaryEmployees.ForEach(e => Console.WriteLine($"- {e.FullName}, Lương: {e.SalaryBase}"));

            // 3. Lấy danh sách hợp đồng có thời hạn dưới 3 năm
            var shortTermContracts = contracts.Where(c => (c.EndDate - c.StartDate).Days / 365 < 3).ToList();
            Console.WriteLine("\nDanh sách hợp đồng có thời hạn dưới 3 năm:");
            shortTermContracts.ForEach(c => Console.WriteLine($"- Hợp đồng ID: {c.ContractID}, Thời hạn: {(c.EndDate - c.StartDate).Days / 365} năm"));

            // 4. Lấy danh sách nhân viên và thông tin phòng ban của họ
            var employeesWithDepartments = employees.Select(e => new
            {
                e.FullName,
                DepartmentName = e.Department.DepartmentName,
                e.SalaryBase
            }).ToList();
            Console.WriteLine("\nDanh sách nhân viên và phòng ban của họ:");
            employeesWithDepartments.ForEach(e => Console.WriteLine($"- {e.FullName}, Phòng ban: {e.DepartmentName}, Lương: {e.SalaryBase}"));

            // 5. Đếm số lượng nhân viên trong từng phòng ban
            var employeeCountByDepartment = departments.Select(d => new
            {
                d.DepartmentName,
                EmployeeCount = d.Employees.Count
            }).ToList();
            Console.WriteLine("\nSố lượng nhân viên trong từng phòng ban:");
            employeeCountByDepartment.ForEach(d => Console.WriteLine($"- {d.DepartmentName}: {d.EmployeeCount} nhân viên"));

            // 6. Lấy danh sách các nhân viên đã từng được tăng lương (có log lương)
            var employeesWithSalaryLogs = employees.Where(e => e.EmployeeLogs.Any()).ToList();
            Console.WriteLine("\nDanh sách nhân viên đã từng được tăng lương:");
            employeesWithSalaryLogs.ForEach(e => Console.WriteLine($"- {e.FullName}"));

            // 7. Lấy danh sách các nhân viên làm việc dưới quyền của Mark Lee (ID 104)
            var employeesUnderMark = employees
                .Where(e => e.Department.HeadId == 104 || e.Department.ListDeputyId.Contains(104))
                .ToList();
            Console.WriteLine("\nDanh sách nhân viên làm việc dưới quyền Mark Lee:");
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

            Console.WriteLine("\nDanh sách nhân viên có hợp đồng hiện tại còn hiệu lực:");
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
            Console.WriteLine($"\nTổng lương của phòng ban Finance: {totalSalaryFinance}");

            // 10. Lấy danh sách các nhân viên và thông tin hợp đồng gần nhất của họ
            var employeesWithLatestContract = employees.Select(e => new
            {
                e.FullName,
                LatestContract = e.Contracts.OrderByDescending(c => c.StartDate).FirstOrDefault()
            }).ToList();
            Console.WriteLine("\nDanh sách nhân viên và hợp đồng gần nhất của họ:");
            employeesWithLatestContract.ForEach(e =>
            {
                var contractInfo = e.LatestContract != null ? $"Hợp đồng ID: {e.LatestContract.ContractID}, Bắt đầu: {e.LatestContract.StartDate}, Kết thúc: {e.LatestContract.EndDate}" : "Không có hợp đồng";
                Console.WriteLine($"- {e.FullName}, {contractInfo}");
            });




        }
    }
}