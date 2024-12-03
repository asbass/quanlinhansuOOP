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
            var departments = new List<Department>
            {
                new Department { DepartmentID = 1, DepartmentName = "Sales", ParentDepartmentId = 0 },
                new Department { DepartmentID = 2, DepartmentName = "Marketing", ParentDepartmentId = 0 },
                new Department { DepartmentID = 3, DepartmentName = "Human Resources", ParentDepartmentId = 0 },
                new Department { DepartmentID = 4, DepartmentName = "Finance", ParentDepartmentId = 0 },
                new Department { DepartmentID = 5, DepartmentName = "IT", ParentDepartmentId = 0 },
                new Department { DepartmentID = 6, DepartmentName = "Operations", ParentDepartmentId = 0 },
                new Department { DepartmentID = 7, DepartmentName = "Research & Development", ParentDepartmentId = 0 },
                new Department { DepartmentID = 8, DepartmentName = "Customer Service", ParentDepartmentId = 0 },
                new Department { DepartmentID = 9, DepartmentName = "Legal", ParentDepartmentId = 0 },
                new Department { DepartmentID = 10, DepartmentName = "Product Management", ParentDepartmentId = 0 }
            };

            // Dữ liệu mẫu cho các chức vụ
            var positions = new List<Position>
        {
            new Position { PositionID = 1, PositionName = "Manager" },
            new Position { PositionID = 2, PositionName = "Director" },
            new Position { PositionID = 3, PositionName = "Software Engineer" },
            new Position { PositionID = 4, PositionName = "HR Specialist" },
            new Position { PositionID = 5, PositionName = "Financial Analyst" },
            new Position { PositionID = 6, PositionName = "Sales Associate" },
            new Position { PositionID = 7, PositionName = "Marketing Coordinator" },
            new Position { PositionID = 8, PositionName = "Product Owner" },
            new Position { PositionID = 9, PositionName = "Customer Support Representative" },
            new Position { PositionID = 10, PositionName = "Legal Advisor" }
        };

            var employees = new List<Employee>
        {
            new Employee { EmployeeID = 1, FullName = "John Doe", DateOfBirth = new DateTime(1985, 5, 15), DepartmentID = 1, PositionID = 1, Address = "123 Main St", Email = "john.doe@example.com", Identifier = "ID001", PhoneNumber = "1234567890", SalaryBase = 5000 },
            new Employee { EmployeeID = 2, FullName = "Jane Smith", DateOfBirth = new DateTime(1990, 8, 20), DepartmentID = 2, PositionID = 2, Address = "456 Elm St", Email = "jane.smith@example.com", Identifier = "ID002", PhoneNumber = "0987654321", SalaryBase = 4500 },
            new Employee { EmployeeID = 3, FullName = "Robert Brown", DateOfBirth = new DateTime(1992, 3, 12), DepartmentID = 3, PositionID = 3, Address = "789 Oak St", Email = "robert.brown@example.com", Identifier = "ID003", PhoneNumber = "1122334455", SalaryBase = 4000 },
            new Employee { EmployeeID = 4, FullName = "Emily Davis", DateOfBirth = new DateTime(1988, 11, 5), DepartmentID = 4, PositionID = 4, Address = "321 Pine St", Email = "emily.davis@example.com", Identifier = "ID004", PhoneNumber = "6677889900", SalaryBase = 6000 },
            new Employee { EmployeeID = 5, FullName = "Michael Johnson", DateOfBirth = new DateTime(1985, 4, 10), DepartmentID = 5, PositionID = 5, Address = "654 Cedar St", Email = "michael.johnson@example.com", Identifier = "ID005", PhoneNumber = "4455667788", SalaryBase = 7000 },
            new Employee { EmployeeID = 6, FullName = "Sarah Wilson", DateOfBirth = new DateTime(1994, 9, 22), DepartmentID = 6, PositionID = 6, Address = "987 Birch St", Email = "sarah.wilson@example.com", Identifier = "ID006", PhoneNumber = "2233445566", SalaryBase = 4700 },
            new Employee { EmployeeID = 7, FullName = "Daniel Martinez", DateOfBirth = new DateTime(1983, 7, 18), DepartmentID = 7, PositionID = 7, Address = "432 Maple St", Email = "daniel.martinez@example.com", Identifier = "ID007", PhoneNumber = "5566778899", SalaryBase = 5300 },
            new Employee { EmployeeID = 8, FullName = "Laura Clark", DateOfBirth = new DateTime(1991, 1, 25), DepartmentID = 8, PositionID = 8, Address = "654 Spruce St", Email = "laura.clark@example.com", Identifier = "ID008", PhoneNumber = "6677889900", SalaryBase = 4900 },
            new Employee { EmployeeID = 9, FullName = "David Lopez", DateOfBirth = new DateTime(1987, 6, 30), DepartmentID = 9, PositionID = 9, Address = "123 Cherry St", Email = "david.lopez@example.com", Identifier = "ID009", PhoneNumber = "7788990011", SalaryBase = 5100 },
            new Employee { EmployeeID = 10, FullName = "Sophia Hernandez", DateOfBirth = new DateTime(1989, 2, 14), DepartmentID = 10, PositionID = 10, Address = "456 Walnut St", Email = "sophia.hernandez@example.com", Identifier = "ID010", PhoneNumber = "8899001122", SalaryBase = 5200 }
        };

            var random = new Random();

            foreach (var department in departments)
            {
                // Lấy nhân viên từ danh sách employees theo DepartmentID
                department.Employees = employees.Where(e => e.DepartmentID == department.DepartmentID).ToList();

                // Random quyết định có Head và Deputies hay không
                bool hasHeadAndDeputies = random.Next(0, 2) == 1; // 50% cơ hội có Head và Deputies

                if (hasHeadAndDeputies && department.Employees.Count > 0)
                {
                    // Cập nhật HeadId (lấy ngẫu nhiên một nhân viên làm trưởng phòng)
                    department.HeadId = department.Employees[random.Next(department.Employees.Count)].EmployeeID;

                    // Cập nhật ListDeputyId (lấy tối đa 2 nhân viên khác ngẫu nhiên làm phó phòng)
                    department.ListDeputyId = department.Employees
                        .Where(e => e.EmployeeID != department.HeadId)
                        .OrderBy(_ => random.Next())
                        .Take(2)
                        .Select(e => e.EmployeeID)
                        .ToList();

                    // Cập nhật Head và Deputies
                    department.Head = employees.FirstOrDefault(e => e.EmployeeID == department.HeadId);
                    department.Deputies = employees.Where(e => department.ListDeputyId.Contains(e.EmployeeID)).ToList();
                }
                else
                {
                    // Không có Head và Deputies
                    department.HeadId = 0;
                    department.ListDeputyId = new List<int>();
                    department.Head = null;
                    department.Deputies = new List<Employee>();
                }
            }

            // Dữ liệu mẫu cho các loại hợp đồng
            var contractTypes = new List<ContractType>
        {
            new ContractType { ContractTypeID = 1, TypeName = "Full-Time" },
            new ContractType { ContractTypeID = 2, TypeName = "Part-Time" },
            new ContractType { ContractTypeID = 3, TypeName = "Internship" },
            new ContractType { ContractTypeID = 4, TypeName = "Freelance" },
            new ContractType { ContractTypeID = 5, TypeName = "Temporary" },
        };

            // Dữ liệu mẫu cho các hợp đồng của nhân viên
            var contracts = new List<Contract>
        {
            new Contract { ContractID = 1, EmployeeID = 1, ContractTypeID = 1, StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2025, 1, 1) },
            new Contract { ContractID = 2, EmployeeID = 2, ContractTypeID = 2, StartDate = new DateTime(2021, 6, 1), EndDate = new DateTime(2023, 6, 1) },
            new Contract { ContractID = 3, EmployeeID = 3, ContractTypeID = 3, StartDate = new DateTime(2022, 1, 15), EndDate = new DateTime(2023, 1, 15) },
            new Contract { ContractID = 4, EmployeeID = 4, ContractTypeID = 4, StartDate = new DateTime(2019, 3, 1), EndDate = new DateTime(2024, 3, 1) },
            new Contract { ContractID = 5, EmployeeID = 5, ContractTypeID = 5, StartDate = new DateTime(2023, 7, 1), EndDate = new DateTime(2024, 7, 1) },
            new Contract { ContractID = 6, EmployeeID = 6, ContractTypeID = 1, StartDate = new DateTime(2020, 9, 1), EndDate = new DateTime(2025, 9, 1) },
            new Contract { ContractID = 7, EmployeeID = 7, ContractTypeID = 2, StartDate = new DateTime(2021, 5, 1), EndDate = new DateTime(2023, 5, 1) },
            new Contract { ContractID = 8, EmployeeID = 8, ContractTypeID = 3, StartDate = new DateTime(2022, 10, 1), EndDate = new DateTime(2023, 10, 1) },
            new Contract { ContractID = 9, EmployeeID = 9, ContractTypeID = 4, StartDate = new DateTime(2018, 11, 1), EndDate = new DateTime(2023, 11, 1) },
            new Contract { ContractID = 10, EmployeeID = 10, ContractTypeID = 5, StartDate = new DateTime(2023, 8, 1), EndDate = new DateTime(2024, 8, 1) }
        };

            // Dữ liệu mẫu cho các nhật ký nhân viên
            var employeeLogs = new List<EmployeeLog>
        {
            new EmployeeLog { LogID = 1, EmployeeID = 1, LogDate = new DateTime(2023, 1, 15), Description = "Completed first project.", Employee = employees[0] },
            new EmployeeLog { LogID = 2, EmployeeID = 2, LogDate = new DateTime(2023, 6, 5), Description = "Attended team meeting.", Employee = employees[1] },
            new EmployeeLog { LogID = 3, EmployeeID = 3, LogDate = new DateTime(2023, 3, 10), Description = "Started new role as manager.", Employee = employees[2] },
            new EmployeeLog { LogID = 4, EmployeeID = 4, LogDate = new DateTime(2023, 5, 7), Description = "Completed training course.", Employee = employees[3] },
            new EmployeeLog { LogID = 5, EmployeeID = 5, LogDate = new DateTime(2023, 7, 12), Description = "Received employee of the month award.", Employee = employees[4] },
            new EmployeeLog { LogID = 6, EmployeeID = 6, LogDate = new DateTime(2023, 2, 18), Description = "Lead project meeting.", Employee = employees[5] },
            new EmployeeLog { LogID = 7, EmployeeID = 7, LogDate = new DateTime(2023, 8, 21), Description = "Introduced new software tool.", Employee = employees[6] },
            new EmployeeLog { LogID = 8, EmployeeID = 8, LogDate = new DateTime(2023, 4, 13), Description = "Completed product launch.", Employee = employees[7] },
            new EmployeeLog { LogID = 9, EmployeeID = 9, LogDate = new DateTime(2023, 9, 3), Description = "Resolved customer issue.", Employee = employees[8] },
            new EmployeeLog { LogID = 10, EmployeeID = 10, LogDate = new DateTime(2023, 10, 5), Description = "Presented quarterly report.", Employee = employees[9] }
        };

            // Query 1: Liệt kê các nhân viên đã có hợp đồng hơn 2 năm
            var query1 = from c in contracts
                         where (c.EndDate - c.StartDate).TotalDays > 730 // 2 năm
                         select c.Employee.FullName;
            Console.WriteLine("\n1. Nhân viên có hợp đồng hơn 2 năm:");
            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }

            // Query 2: Liệt kê tên nhân viên cùng với mô tả công việc gần nhất
            var query2 = from log in employeeLogs
                         join e in employees on log.EmployeeID equals e.EmployeeID
                         orderby log.LogDate descending
                         group log by e.FullName into g
                         select new { Employee = g.Key, LastLog = g.FirstOrDefault().Description };
            Console.WriteLine("\n2. Nhân viên cùng với mô tả công việc gần nhất:");
            foreach (var item in query2)
            {
                Console.WriteLine($"{item.Employee} - {item.LastLog}");
            }

            // Query 3: Liệt kê các nhân viên làm việc trong các phòng ban có tên chứa 'IT'
            var query3 = from e in employees
                         where e.Department.DepartmentName.Contains("IT")
                         select e.FullName;
            Console.WriteLine("\n3. Nhân viên làm việc trong phòng ban có tên chứa 'IT':");
            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }

            // Query 4: Liệt kê các nhân viên có hợp đồng đã ký từ tháng 1 năm 2023
            var query4 = from c in contracts
                         where c.StartDate >= new DateTime(2023, 1, 1)
                         select c.Employee.FullName;
            Console.WriteLine("\n4. Nhân viên có hợp đồng đã ký từ tháng 1 năm 2023:");
            foreach (var item in query4)
            {
                Console.WriteLine(item);
            }

            // Query 5: Liệt kê các hợp đồng có loại 'Part-time' và kết thúc sau tháng 6 năm 2024
            var query5 = from c in contracts
                         where c.ContractType.TypeName == "Part-time" && c.EndDate > new DateTime(2024, 6, 1)
                         select new { c.Employee.FullName, c.StartDate, c.EndDate };
            Console.WriteLine("\n5. Hợp đồng Part-time kết thúc sau tháng 6 năm 2024:");
            foreach (var item in query5)
            {
                Console.WriteLine($"{item.FullName} - Start: {item.StartDate.ToShortDateString()}, End: {item.EndDate.ToShortDateString()}");
            }

            // Query 6: Liệt kê các nhân viên có ngày sinh trong tháng 6
            var query6 = from e in employees
                         where e.DateOfBirth.Month == 6
                         select e.FullName;
            Console.WriteLine("\n6. Nhân viên sinh trong tháng 6:");
            foreach (var item in query6)
            {
                Console.WriteLine(item);
            }

            // Query 7: Liệt kê các nhân viên có hợp đồng loại 'Part-time' và có ngày sinh từ năm 1990 trở đi
            var query7 = from c in contracts
                         where c.ContractType.TypeName == "Part-time" && c.Employee.DateOfBirth.Year >= 1990
                         select c.Employee.FullName;
            Console.WriteLine("\n7. Nhân viên Part-time sinh từ năm 1990:");
            foreach (var item in query7)
            {
                Console.WriteLine(item);
            }

            // Query 8: Liệt kê tên nhân viên và phòng ban của những người có chức vụ 'Senior' hoặc 'Manager'
            var query8 = from e in employees
                         where e.Position.PositionName == "Senior" || e.Position.PositionName == "Manager"
                         select new { e.FullName, e.Department.DepartmentName };
            Console.WriteLine("\n8. Nhân viên có chức vụ 'Senior' hoặc 'Manager':");
            foreach (var item in query8)
            {
                Console.WriteLine($"{item.FullName} - {item.DepartmentName}");
            }

            // Query 9: Liệt kê các nhân viên làm việc tại các phòng ban có tên bắt đầu bằng 'Sales'
            var query9 = from e in employees
                         where e.Department.DepartmentName.StartsWith("Sales")
                         select e.FullName;
            Console.WriteLine("\n9. Nhân viên làm việc tại các phòng ban có tên bắt đầu bằng 'Sales':");
            foreach (var item in query9)
            {
                Console.WriteLine(item);
            }

            // Query 10: Liệt kê các nhân viên có hợp đồng từ 1 năm đến 3 năm
            var query10 = from c in contracts
                          where (c.EndDate - c.StartDate).TotalDays >= 365 && (c.EndDate - c.StartDate).TotalDays <= 1095 // 1 đến 3 năm
                          select c.Employee.FullName;
            Console.WriteLine("\n10. Nhân viên có hợp đồng từ 1 đến 3 năm:");
            foreach (var item in query10)
            {
                Console.WriteLine(item);
            }

            // Query 11: Liệt kê tên nhân viên và ngày ký hợp đồng cho những người có ngày sinh trong khoảng từ 1985 đến 1995
            var query11 = from c in contracts
                          where c.Employee.DateOfBirth.Year >= 1985 && c.Employee.DateOfBirth.Year <= 1995
                          select new { c.Employee.FullName, c.StartDate };
            Console.WriteLine("\n11. Nhân viên có ngày sinh từ 1985 đến 1995:");
            foreach (var item in query11)
            {
                Console.WriteLine($"{item.FullName} - Start Date: {item.StartDate.ToShortDateString()}");
            }

            // Query 12: Liệt kê các phòng ban và số lượng nhân viên trong mỗi phòng ban
            var query12 = from e in employees
                          group e by e.Department.DepartmentName into g
                          select new { Department = g.Key, EmployeeCount = g.Count() };
            Console.WriteLine("\n12. Số lượng nhân viên trong mỗi phòng ban:");
            foreach (var item in query12)
            {
                Console.WriteLine($"{item.Department}: {item.EmployeeCount} nhân viên");
            }

            // Query 13: Liệt kê các nhân viên có tên chứa chữ 'John' hoặc 'Jane'
            var query13 = from e in employees
                          where e.FullName.Contains("John") || e.FullName.Contains("Jane")
                          select e.FullName;
            Console.WriteLine("\n13. Nhân viên có tên chứa 'John' hoặc 'Jane':");
            foreach (var item in query13)
            {
                Console.WriteLine(item);
            }

            // Query 14: Liệt kê tên các nhân viên và thời gian làm việc trong phòng ban của họ
            var query14 = from e in employees
                          join log in employeeLogs on e.EmployeeID equals log.EmployeeID
                          group log by new { e.FullName, e.Department.DepartmentName } into g
                          select new { g.Key.FullName, g.Key.DepartmentName, WorkingDuration = g.Count() };
            Console.WriteLine("\n14. Nhân viên và thời gian làm việc trong phòng ban:");
            foreach (var item in query14)
            {
                Console.WriteLine($"{item.FullName} - {item.DepartmentName}: {item.WorkingDuration} ngày");
            }

            // Query 15: Liệt kê các nhân viên có ngày sinh vào năm 1992
            var query15 = from e in employees
                          where e.DateOfBirth.Year == 1992
                          select e.FullName;
            Console.WriteLine("\n15. Nhân viên sinh năm 1992:");
            foreach (var item in query15)
            {
                Console.WriteLine(item);
            }
        }
    }
}