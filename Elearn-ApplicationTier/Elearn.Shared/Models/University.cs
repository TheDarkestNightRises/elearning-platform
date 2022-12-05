namespace Elearn.Shared.Models;

public class University
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public string Description { get; set; }
    public University()
    {
        
    }
    public University(long id, string name)
    {
        Id = id;
        Name = name;
    }

    
}