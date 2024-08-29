namespace Phonebook;

public static class Program
{
    public static void Main(string[] args)
    {
        Repository phonebookRepository = new Phonebook();
        phonebookRepository.Add(new PhoneNumber("Denis", "Perev", 89999199119));
        var a = phonebookRepository.Get(new PhoneNumber("Denis", "Perev", 8999919911));
    }
}