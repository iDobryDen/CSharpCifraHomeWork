namespace Phonebook;

public class PhoneNumber : Abonent
{
  public long Number { get; private set; }

  public void ChangeNumber(long newNumber)
  {
    if (newNumber != Number)
      this.Number = newNumber;
  }

  public PhoneNumber(string name, string lastName, long number) : base(name, lastName)
  {
    this.Number = number;
  }
}