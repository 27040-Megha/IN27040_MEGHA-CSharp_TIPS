namespace EmployeeHierarchy.Models
{
    public class Developer : Employee
    {
        public Developer(string name, decimal salary) 
            : base(name, salary)
        {
        }

        public override decimal CalculateBonus()
        {
            return Salary * 0.10m;
        }

        public override string GetDetails()
        {
            return $"Employee Type : Developer \n{base.GetDetails()} \nBonus : {Bonus:F2}";
        }
    }
}