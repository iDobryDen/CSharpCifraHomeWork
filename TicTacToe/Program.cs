/// create game TicTacToe

namespace TicTacToe;

class Program
{
    const char XSymbol = 'X';
    const char OSymbol = '0';
    
    private static readonly List<int[]> WinningCombinations = new List<int[]>()
    {
        new int[]{0, 1, 2},
        new int[]{3, 4, 5},
        new int[]{6, 7, 8},
        new int[]{0, 3, 6},
        new int[]{1, 4, 7},
        new int[]{2, 5, 8},
        new int[]{0, 4, 8},
        new int[]{2, 4, 6},
    };
    
    static void Main(string[] args)
    {
        char[] gamingField = new char[9];
        PlayingField(gamingField);

        while (true)
        {
            PlayerStep(gamingField, XSymbol);
            PlayingField(gamingField);
            if (CheckWin(gamingField, XSymbol, out var winningCombination))
            {
                Console.WriteLine($"Player with char '{XSymbol}' winner!!!");
                return;
            }
            
            if (CheckDraw(gamingField))
            {
                Console.WriteLine("Draw in the game...");
                return;
            }
            PlayingField(gamingField);
            
            PlayerStep(gamingField, OSymbol);
            if (CheckWin(gamingField, OSymbol, out winningCombination))
            {
                Console.WriteLine($"Player with char '{OSymbol}' winner!!!");
                return;
            }
            PlayingField(gamingField);
        }
    }

    private static void PlayingField(char[] ValueField)
    {
        Console.Clear();
        for (int i = 0; i < ValueField.Length; i++)
        {
            if (ValueField[i] == '\0') //проверяем конец строки
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
    
    private static bool CheckWin(char[] field, char playerSymbol, out int[] _combination)
    {
        _combination = Array.Empty<int>();

        var winFlag = 0;
        foreach (var combination in WinningCombinations)   
        {
            foreach (var index in combination)
            {
                if (field[index] == playerSymbol)
                    winFlag++;
            }

            if (winFlag == 3)
            {
                _combination = combination;
                return true;
            }
            winFlag = 0;
        }

        return false;
    }
    
    private static bool CheckDraw(char[] field)
    {
        foreach (var empty in field)
        {
            if (empty == '\0')
                return false;
        }

        return true;
    }
}

