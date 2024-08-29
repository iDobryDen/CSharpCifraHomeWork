namespace Phonebook;

public abstract class Repository
{
    #region Fields and properties
 
    protected IList<Abonent> _abonents;

    #endregion

    #region Metods

    public abstract void Add(Abonent abonent);
    public abstract Abonent? Get(Abonent abonent);
    public abstract void Update(Abonent abonent);
    public abstract void Delete(Abonent abonent);

    #endregion

    #region Constructors

    public Repository()
    {
        this._abonents = new List<Abonent>();
    }

    #endregion
}