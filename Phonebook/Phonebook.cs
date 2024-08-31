namespace Phonebook;

public class Phonebook : Repository
{
    public override void Add(Abonent abonent)
    {
        if (this.Get(abonent) == null)
        {
            this._abonents.Add(abonent);
            Console.WriteLine("Номер добавлен.");
        }
        else
        {
            Console.WriteLine("Абонент с таким номером уже существует.");
        }
    }

    public override Abonent? Get(Abonent abonent)
    {
        if (abonent is PhoneNumber)
        {
            return this._abonents.SingleOrDefault(p => ((PhoneNumber)p).Number == ((PhoneNumber)abonent).Number);
        }
        return null;
    }

    public override void Update(Abonent abonent)
    {
        var foundAbonent = this.Get(abonent);
        if (foundAbonent != null)
            foundAbonent = abonent;
    }
    
}

