namespace Phonebook;
public abstract class Repository
{
    #region Fields and properties

    protected IList<Abonent> _abonents;

    #endregion

    public abstract void Add(Abonent abonent);
    public abstract Abonent? Get(Abonent abonent);
    public abstract void Update(Abonent abonent);
    public void Delete()
    {
        Console.WriteLine("Введите номер телефона:");
        long number;
        while (!long.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Неверный формат номера. Попробуйте снова.");
        }

        PhoneNumber phoneToRemove = _abonents.FirstOrDefault(p => ((PhoneNumber)p).Number == number) as PhoneNumber;
        if (phoneToRemove != null)
        {
            _abonents.Remove(phoneToRemove);
            Console.WriteLine("Номер удален.");
        }
        else
        {
            Console.WriteLine("Номер не найден.");
        }
    }
    public Repository()
    {
        this._abonents = new List<Abonent>();
    }

    public void PrintAll()
    {
        if (_abonents.Count == 0)
        {
            Console.WriteLine("Телефонная книга пуста.");
            return;
        }
        Console.WriteLine("Абоненты телефонной книги:");
        foreach (PhoneNumber abonent in _abonents)
        {
            Console.WriteLine($"Имя: {abonent.Name}, Фамилия: {abonent.LastName}, Номер: {abonent.Number}");
        }
    }

    public void SavePhonebook()
    {
        using (StreamWriter writer = new StreamWriter("phonebook.txt"))
        {
            foreach (PhoneNumber phone in _abonents)
            {
                writer.WriteLine($"{phone.Name},{phone.LastName},{phone.Number}");
            }
        }
        Console.WriteLine("Телефонная книга сохранена.");
    }

    public void LoadPhonebook()
    {
        if (!File.Exists("phonebook.txt"))
        {
            Console.WriteLine("Файл phonebook.txt не найден. Создается новый файл.");
            return;
        }
        using (StreamReader reader = new StreamReader("phonebook.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                _abonents.Add(new PhoneNumber(parts[0], parts[1], long.Parse(parts[2])));
            }
        }
        Console.WriteLine("Телефонная книга загружена.");
    }

    public void GetByNumber()
    {
        Console.WriteLine("Введите номер телефона:");
        long number;
        while (!long.TryParse(Console.ReadLine(), out number))
        {
            Console.WriteLine("Неверный формат номера. Попробуйте снова.");
        }

        PhoneNumber foundPhone = _abonents.FirstOrDefault(p => ((PhoneNumber)p).Number == number) as PhoneNumber;
        if (foundPhone != null)
        {
            Console.WriteLine($"Имя: {foundPhone.Name}, Фамилия: {foundPhone.LastName}");
        }
        else
        {
            Console.WriteLine("Номер не найден.");
        }
    }
    
    public void GetByName()
    {
        Console.WriteLine("Введите имя для поиска:");
        string name = Console.ReadLine();
        PhoneNumber foundName = _abonents.FirstOrDefault(p => ((PhoneNumber)p).Name == name) as PhoneNumber;
        if (foundName != null)
        {
            Console.WriteLine($"Номер: {foundName.Number}, Фамилия: {foundName.LastName}");
        }
        else
        {
            Console.WriteLine("Номер не найден.");
        }
    }
}