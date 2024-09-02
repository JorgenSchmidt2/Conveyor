using ConveyorUtility.Bunker.Service.ConsoleOutputService;
using ConveyorUtility.Bunker.Service.FileService;

string ProgrammInstruction = "";

ProgrammInstruction = OutputOptimizator.DoOptimization(
    ProgrammInstruction,
    10
);

Console.WriteLine(ProgrammInstruction);

int IterationNumber = 1;
int Choise = 1;

while (Choise == 1)
{
    Console.WriteLine("Номер итерации: " + IterationNumber.ToString());
    Console.Write("\nВведите название папки с файлами: ");
    var PathName = Console.ReadLine();

    if (String.IsNullOrEmpty(PathName))
    {
        Console.WriteLine("Нужно было ввести название файла.");
        Console.WriteLine("Продолжить ввод? 1 - Да; любое другое число - Нет.");
        Choise = Convert.ToInt32( Console.ReadLine() );
        IterationNumber += 1;
        continue;
    }

    var DirectoryInfo = DirectoryInfoGetter.GetInfo(PathName);

    if (!DirectoryInfo.Status)
    {
        Console.WriteLine(DirectoryInfo.Message);
        Console.WriteLine("Продолжить ввод? 1 - Да; любое другое число - Нет.");
        Choise = Convert.ToInt32(Console.ReadLine());
        IterationNumber += 1;
        continue;
    }

    IterationNumber += 1;
}