namespace EmployeeHierarchy.Models
{
    /// <summary>
    /// Inherits from Employee and calculates salary bonus for Developers
    /// </summary>
    public class Developer : Employee
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Developer"/> class.
        /// </summary>
        /// <param name="name">name of the developer</param>
        /// <param name="salary">salary of the developer</param>
        public Developer(string name, decimal salary) 
            : base(name, salary)
        {
        }

       /// <summary>
       /// Caclulates and returns bonus of developer
       /// </summary>
       /// <returns>Bonus of developer</returns>
        public override decimal CalculateBonus()
        {
            return Salary * 0.10m;
        }

        /// <summary>
        /// Returns developer details that needed to be printed
        /// </summary>
        /// <returns>Developer details as string</returns>
        public override string GetDetails()
        {
            return $"Employee Type : Developer \n{base.GetDetails()} \nBonus : {Bonus:F2}";
        }
    }
}