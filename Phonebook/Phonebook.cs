namespace Phonebook;

public class Phonebook : Repository
{
    public override void Add(Abonent abonent)
    {
        var foundAbonent = this.Get(abonent); 
        if (foundAbonent == null)
            this._abonents.Add(abonent);
        throw new InvalidOperationException($"There is already a phone book with name {abonent.Name}");
    }
    
    public override Abonent? Get(Abonent abonent)
    {
        return this._abonents.SingleOrDefault(p => p.Name == abonent.Name);
    }
    
    public override void Update(Abonent abonent)
    {
        var foundAbonent = this.Get(abonent);
        if (foundAbonent != null)
            foundAbonent = abonent;

    }
    
    public override void Delete(Abonent abonent)
    {
        this._abonents.Remove(abonent);
    }
}

