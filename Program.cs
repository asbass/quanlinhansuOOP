namespace DatabaseModels
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
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

        // Foreign Key Relationships
        public Department Department { get; set; }
        public Position Position { get; set; }
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
        public DateTime LogDate { get; set; }
        public string Description { get; set; }

        // Foreign Key Relationships
        public Employee Employee { get; set; }
    }
    public class Program
    {
        public static void Main()
        {
            // Dữ liệu mẫu cho các phòng ban
            var departments = new List<Department>
        {
            new Department { DepartmentID = 1, DepartmentName = "Sales" },
            new Department { DepartmentID = 2, DepartmentName = "Marketing" },
            new Department { DepartmentID = 3, DepartmentName = "Human Resources" },
            new Department { DepartmentID = 4, DepartmentName = "Finance" },
            new Department { DepartmentID = 5, DepartmentName = "IT" },
            new Department { DepartmentID = 6, DepartmentName = "Operations" },
            new Department { DepartmentID = 7, DepartmentName = "Research & Development" },
            new Department { DepartmentID = 8, DepartmentName = "Customer Service" },
            new Department { DepartmentID = 9, DepartmentName = "Legal" },
            new Department { DepartmentID = 10, DepartmentName = "Product Management" }
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
            new Employee { EmployeeID = 1, FullName = "John Doe", DateOfBirth = new DateTime(1990, 5, 10), Position = positions[0], Department = departments[0] },
            new Employee { EmployeeID = 2, FullName = "Jane Smith", DateOfBirth = new DateTime(1985, 3, 22), Position = positions[1], Department = departments[1] },
            new Employee { EmployeeID = 3, FullName = "Michael Johnson", DateOfBirth = new DateTime(1982, 7, 18), Position = positions[2], Department = departments[2] },
            new Employee { EmployeeID = 4, FullName = "Emily Davis", DateOfBirth = new DateTime(1993, 12, 15), Position = positions[3], Department = departments[3] },
            new Employee { EmployeeID = 5, FullName = "David Brown", DateOfBirth = new DateTime(1991, 6, 5), Position = positions[4], Department = departments[4] },
            new Employee { EmployeeID = 6, FullName = "Laura Wilson", DateOfBirth = new DateTime(1994, 11, 23), Position = positions[5], Department = departments[5] },
            new Employee { EmployeeID = 7, FullName = "James Taylor", DateOfBirth = new DateTime(1988, 9, 14), Position = positions[6], Department = departments[6] },
            new Employee { EmployeeID = 8, FullName = "Olivia Thomas", DateOfBirth = new DateTime(1998, 1, 30), Position = positions[7], Department = departments[7] },
            new Employee { EmployeeID = 9, FullName = "Daniel Lee", DateOfBirth = new DateTime(1987, 4, 2), Position = positions[8], Department = departments[8] },
            new Employee { EmployeeID = 10, FullName = "Sophia Martinez", DateOfBirth = new DateTime(1992, 8, 12), Position = positions[9], Department = departments[9] }
        };

            // Dữ liệu mẫu cho các loại hợp đồng
            var contractTypes = new List<ContractType>
        {
            new ContractType { ContractTypeID = 1, TypeName = "Full-time" },
            new ContractType { ContractTypeID = 2, TypeName = "Part-time" },
            new ContractType { ContractTypeID = 3, TypeName = "Freelance" }
        };

            // Dữ liệu mẫu cho các hợp đồng của nhân viên
            var contracts = new List<Contract>
        {
            new Contract { ContractID = 1, EmployeeID = 1, ContractTypeID = 1, StartDate = new DateTime(2023, 1, 1), EndDate = new DateTime(2025, 1, 1), Employee = employees[0], ContractType = contractTypes[0] },
            new Contract { ContractID = 2, EmployeeID = 2, ContractTypeID = 2, StartDate = new DateTime(2023, 6, 1), EndDate = new DateTime(2023, 6, 1), Employee = employees[1], ContractType = contractTypes[1] },
            new Contract { ContractID = 3, EmployeeID = 3, ContractTypeID = 1, StartDate = new DateTime(2023, 3, 1), EndDate = new DateTime(2025, 3, 1), Employee = employees[2], ContractType = contractTypes[0] },
            new Contract { ContractID = 4, EmployeeID = 4, ContractTypeID = 3, StartDate = new DateTime(2023, 5, 1), EndDate = new DateTime(2024, 5, 1), Employee = employees[3], ContractType = contractTypes[2] },
            new Contract { ContractID = 5, EmployeeID = 5, ContractTypeID = 2, StartDate = new DateTime(2023, 7, 1), EndDate = new DateTime(2024, 12, 1), Employee = employees[4], ContractType = contractTypes[1] },
            new Contract { ContractID = 6, EmployeeID = 6, ContractTypeID = 1, StartDate = new DateTime(2023, 2, 1), EndDate = new DateTime(2025, 2, 1), Employee = employees[5], ContractType = contractTypes[0] },
            new Contract { ContractID = 7, EmployeeID = 7, ContractTypeID = 3, StartDate = new DateTime(2023, 8, 1), EndDate = new DateTime(2024, 8, 1), Employee = employees[6], ContractType = contractTypes[2] },
            new Contract { ContractID = 8, EmployeeID = 8, ContractTypeID = 1, StartDate = new DateTime(2023, 4, 1), EndDate = new DateTime(2025, 4, 1), Employee = employees[7], ContractType = contractTypes[0] },
            new Contract { ContractID = 9, EmployeeID = 9, ContractTypeID = 2, StartDate = new DateTime(2023, 9, 1), EndDate = new DateTime(2024, 9, 1), Employee = employees[8], ContractType = contractTypes[1] },
            new Contract { ContractID = 10, EmployeeID = 10, ContractTypeID = 3, StartDate = new DateTime(2023, 10, 1), EndDate = new DateTime(2024, 10, 1), Employee = employees[9], ContractType = contractTypes[2] }
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