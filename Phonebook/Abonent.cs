namespace Phonebook;

public class Abonent
{
    public string Name { get; set; }
    public string LastName { get; set; }

    #region Сonstructors
    /// <summary>
    /// Сonstructor.
    /// </summary>
    public Abonent() : this(string.Empty, string.Empty) { }
    
    /// <summary>
    /// Сonstructor.
    /// </summary>
    /// <param name="name">Name</param>
    /// <param name="lastName">Last name</param>
    public Abonent(string name, string lastName)
    {
        this.Name = name;
        this.LastName = lastName;
    }
    #endregion
}

