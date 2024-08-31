namespace Phonebook;

//Должна быть реализована CRUD функциональность:
//      Должен уметь принимать от пользователя номер и имя телефона.
//      Сохранять номер в файле phonebook.txt. (При завершении программы либо при добавлении).
//      Вычитывать из файла сохранённые номера. (При старте программы).
//      Удалять номера.
//      Получать абонента по номеру телефона.
//      Получать номер телефона по имени абонента.
// Обращение к Phonebook должно быть как к классу-одиночке.
// Внутри должна быть коллекция с абонентами.
// Для обращения с абонентами нужно завести класс Abonent. С полями «номер телефона», «имя».
// Не дать заносить уже записанного абонента.

public static class Program
{
    public static void Main(string[] args)
    {
        Repository phonebookRepository = new Phonebook();
        
        phonebookRepository.LoadPhonebook(); // Загружаем телефонную книгу при запуске

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Добавить номер");
            Console.WriteLine("2. Удалить номер");
            Console.WriteLine("3. Получить абонента по номеру");
            Console.WriteLine("4. Получить номер телефона по имени");
            Console.WriteLine("5. Вывести всех абонентов");
            Console.WriteLine("0. Выход");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Получение данных от пользователя
                    Console.WriteLine("Введите имя:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию:");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Введите номер телефона:");
                    long number;
                    while (!long.TryParse(Console.ReadLine(), out number))
                    {
                        Console.WriteLine("Неверный формат номера. Попробуйте снова.");
                    }

                    // Создание объекта PhoneNumber
                    PhoneNumber newPhone = new PhoneNumber(name, lastName, number);

                    // Вызов метода Add с объектом PhoneNumber
                    phonebookRepository.Add(newPhone); 
                    break;

                case 2:
                    phonebookRepository.Delete(); 
                    break;
                case 3:
                    phonebookRepository.GetByNumber();
                    break;
                //case 4:
                    //phonebookRepository.GetByName();
                    //break;
                case 5:
                    phonebookRepository.PrintAll();
                    break;
                case 0:
                    phonebookRepository.SavePhonebook(); // Сохраняем телефонную книгу при выходе
                    return;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}