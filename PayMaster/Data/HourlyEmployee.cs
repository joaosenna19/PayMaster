namespace PayMaster.Data;

public class HourlyEmployee : Employee
{
    private double HourlyRate { get; set; }
    
    public HourlyEmployee(int id, string firstName, string lastName, string position, bool isActive, DateTime dateHired, double hourlyRate) 
        : base(id, firstName, lastName, position, isActive, dateHired)
    {
        HourlyRate = hourlyRate;
    }
    
}