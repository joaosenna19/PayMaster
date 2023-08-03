// Base class of the whole project
// Responsible for storing all the information regarding the employee

using SQLite;

namespace PayMaster.Data;

public class HourlyEmployee
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Position { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateHired { get; set; }
    public DateTime? DateFired { get; set; }
    public double HourlyRate { get; set; }
    
}
