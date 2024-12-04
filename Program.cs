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
                new Department { DepartmentID = 2, DepartmentName = "IT", ParentDepartmentId = 0, HeadId = 104, ListDeputyId = new List<int> { 105 } },
                new Department { DepartmentID = 3, DepartmentName = "Finance", ParentDepartmentId = 0, HeadId = 106, ListDeputyId = new List<int>() }
            };

                        // Sample Data for Position
                        var positions = new List<Position>
            {
                new Position { PositionID = 1, PositionName = "Manager" },
                new Position { PositionID = 2, PositionName = "Team Leader" },
                new Position { PositionID = 3, PositionName = "Staff" }
            };

                        // Sample Data for ContractType
                        var contractTypes = new List<ContractType>
            {
                new ContractType { ContractTypeID = 1, TypeName = "Full-Time" },
                new ContractType { ContractTypeID = 2, TypeName = "Part-Time" },
                new ContractType { ContractTypeID = 3, TypeName = "Contractor" }
            };

                        // Sample Data for Employees
                        var employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeID = 101,
                    FullName = "John Smith",
                    DateOfBirth = new DateTime(1980, 5, 15),
                    DepartmentID = 1,
                    PositionID = 1,
                    Address = "123 Main St",
                    Email = "john.smith@example.com",
                    Identifier = "ID101",
                    PhoneNumber = "123-456-7890",
                    SalaryBase = 50000
                },
                new Employee
                {
                    EmployeeID = 102,
                    FullName = "Jane Doe",
                    DateOfBirth = new DateTime(1985, 8, 20),
                    DepartmentID = 1,
                    PositionID = 2,
                    Address = "456 Elm St",
                    Email = "jane.doe@example.com",
                    Identifier = "ID102",
                    PhoneNumber = "123-555-7890",
                    SalaryBase = 45000
                },
                new Employee
                {
                    EmployeeID = 104,
                    FullName = "Mark Lee",
                    DateOfBirth = new DateTime(1990, 1, 10),
                    DepartmentID = 2,
                    PositionID = 1,
                    Address = "789 Oak St",
                    Email = "mark.lee@example.com",
                    Identifier = "ID104",
                    PhoneNumber = "321-654-0987",
                    SalaryBase = 55000
                }
            };

                        // Sample Data for Contracts
                        var contracts = new List<Contract>
            {
                new Contract { ContractID = 1, EmployeeID = 101, ContractTypeID = 1, StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2025, 1, 1) },
                new Contract { ContractID = 2, EmployeeID = 102, ContractTypeID = 2, StartDate = new DateTime(2021, 6, 1), EndDate = new DateTime(2024, 6, 1) },
                new Contract { ContractID = 3, EmployeeID = 104, ContractTypeID = 1, StartDate = new DateTime(2019, 3, 15), EndDate = new DateTime(2024, 3, 15) }
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