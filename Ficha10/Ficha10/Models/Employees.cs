using Ficha7Saturday;

namespace Ficha10.Models
{
    public class Employees : IEmployees
    {
        private List<Employee> employeesList;

        public Employees()
        {
            employeesList = JsonLoader.DeserializeEmployees();
        }

        public List<Employee> EmployeesList { get { return employeesList; } set { employeesList = value; } }

    }
}
