namespace EmployeeHierarchy.Models
{
    public class Manager : Employee
    {
        public Manager(string name, decimal salary) 
            : base(name, salary)
        {
        }

        public override decimal CalculateBonus()
        {
            return Salary * 0.20m;
        }

        public override string GetDetails()
        {
            return $"Employee Type : Manager \n{base.GetDetails()} \nBonus : {Bonus:F2}";
        }
    }
}