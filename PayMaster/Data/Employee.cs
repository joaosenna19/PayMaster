namespace PayMaster.Data;

public abstract class Employee
{
    private int Id { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Position { get; set; }
    private bool isActive { get; set; }
    private DateTime DateHired { get; set; }
    
    private DateTime DateFired { get; set; }

    protected Employee(int id, string firstName, string lastName, string position, bool isActive, DateTime dateHired)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Position = position;
        this.isActive = isActive;
        DateHired = dateHired;
    }
}