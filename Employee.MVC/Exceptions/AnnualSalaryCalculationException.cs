namespace Employee.MVC.Exceptions
{
    public class AnnualSalaryCalculationException : Exception
    {
        public AnnualSalaryCalculationException() : base("Failed to calculate annual salary.")
        {
        }

        public AnnualSalaryCalculationException(string message) : base(message)
        {
        }

        public AnnualSalaryCalculationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
