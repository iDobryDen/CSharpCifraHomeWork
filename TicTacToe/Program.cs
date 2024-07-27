/// create game TicTacToe

namespace TicTacToe;

class Program
{
    const char XSymbol = 'X';
    const char OSymbol = 'V';

    static void Main(string[] args)
    {
        char[] gamingField = new char[9];
        PlayingField(gamingField);


        PlayerStep(gamingField, XSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, OSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, XSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, OSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, XSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, OSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, XSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, OSymbol);
        PlayingField(gamingField);

        PlayerStep(gamingField, XSymbol);
        PlayingField(gamingField);

        Console.WriteLine("больше нет ходов");

    }

    private static void PlayingField(char[] ValueField)
    {
        Console.Clear();
        for (int i = 0; i < ValueField.Length; i++)
        {
            if (ValueField[i] == '\0')
                Console.Write($"|{i + 1}");
            else
            {
                Console.Write('|');
                Console.Write(ValueField[i]);
            }

            if ((i + 1) % 3 == 0)
            {
                Console.WriteLine("|");
                if (i != ValueField.Length - 1)
                    Console.WriteLine("-------");
            }
        }
    }

    private static void PlayerStep(char[] ValueField, char playerSymbol)
    {
        while (true)
        {
            var playerStepNumber = Console.ReadKey().KeyChar;
            if (char.IsNumber(playerStepNumber))
            {
                var returnRealNumber = playerStepNumber - 48; //Преобразует символ цифры в соответствующее числовое значение.
                                                              //В ASCII кодировка символ '0' имеет значение 48, следовательно,
                                                              //вычитание 48 позволяет получить значение от 0 до 9.

                if (returnRealNumber == 0 || ValueField[returnRealNumber - 1] != '\0') //`ValueField[returnRealNumber - 1] != '\0'`: Проверяет, занята ли ячейка в игровом поле
                                                                                       //(то есть, если ячейка не пустая). Если элемент массива не равен `\0`, это означает,
                                                                                       //что в этой ячейке уже стоит символ (например, 'X' или 'O').

                {
                    Console.WriteLine("нельзя поставить символ в занятую ячейку и нельзя выбрать 0");
                    continue;
                }
                ValueField[returnRealNumber - 1] = playerSymbol;

                return;
            }

            Console.WriteLine("next player step");
        }
    }
}

