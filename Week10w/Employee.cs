using System.Collections.Generic;

namespace Week10w
{
    public class EmployeeSortByName : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            var res = x.Name.CompareTo(y.Name);
            if (res == 0)
                res = x.Name.CompareTo(y.Name);

            return res;
        }
    }

    public class Employee
    {
        public int idEmployee { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public double WageHourly { get; set; }
        public bool IsChanged { get; set; }
        public bool IsDeleted { get; set; }
    }
}
