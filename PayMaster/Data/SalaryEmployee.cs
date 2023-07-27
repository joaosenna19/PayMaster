namespace PayMaster.Data;

public class SalaryEmployee : Employee
{
    
    private double Salary { get; set; }
    
    public SalaryEmployee(int id, string firstName, string lastName, string position, bool isActive, DateTime dateHired, double salary) 
        : base(id, firstName, lastName, position, isActive, dateHired)
    {
        Salary = salary;
    }
}