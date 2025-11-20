using System.Globalization;
using System.Reflection.Metadata;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

static int getNumFromUser(string message) {
    Console.Write(message);
    var userInput = Console.ReadLine();

    if (int.TryParse(userInput, out int number)) {
        return number;
    } else {
        Console.WriteLine("Not a number!");
    }
    return 0;
}

static int main() {
    var availableOpers = new Dictionary<string, Func<int, int, int>> {
        { "+" , (x , y) => x + y },
        { "-" , (x , y) => x - y },
        { "/" , (x , y) => x / y },
        { "*" , (x , y) => x * y }
    };

    int x = getNumFromUser("number 1: ");
    int y = getNumFromUser("number 2: ");

    Console.Write("operation: ");
    var oper = Console.ReadLine();

    if (oper is null) {
        Console.WriteLine("No operation specified!");
        return 1;
    }

    if (oper == "/" && y == 0) {
        Console.WriteLine("Cant divide by 0!");
        return 1;
    }
    
    if (availableOpers.TryGetValue(oper , out var func)) {
        Console.WriteLine($"Result: {func(x, y)}");
    } else {
        Console.WriteLine("Unknown Operation!");
    }

    return 0;
}

main();