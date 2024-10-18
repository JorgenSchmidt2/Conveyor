using ConveyorUtility.Bunker.Core.Configuration;
using ConveyorUtility.Bunker.Core.Enitites;
using ConveyorUtility.Bunker.Core.Responses;
using ConveyorUtility.Bunker.Service.ConsoleOutputService;
using ConveyorUtility.Bunker.Service.FileService;
using ConveyorUtility.Bunker.Service.ValidateService;

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
    
    Console.Write("\nВведите название папки с файлами данных в директории Inputs: ");
    var PathName = Console.ReadLine();
    var ActuallyPathName = DirectoryNames.InputsDirName + "\\" + PathName;

    if (String.IsNullOrEmpty(ActuallyPathName))
    {
        Console.WriteLine("Нужно было ввести название директории.");
        Console.WriteLine("Продолжить ввод? 1 - Да; любое другое число - Нет.");
        Choise = Convert.ToInt32( Console.ReadLine() );
        IterationNumber += 1;
        continue;
    }

    var DirectoryInfo = DirectoryInfoGetter.GetInfo(ActuallyPathName);

    if (!DirectoryInfo.Status)
    {
        Console.WriteLine(DirectoryInfo.Message);
        Console.WriteLine("Продолжить ввод? 1 - Да; любое другое число - Нет.");
        Choise = Convert.ToInt32(Console.ReadLine());
        IterationNumber += 1;
        continue;
    }

    Console.Write("Задайте конфигурацию файлов через пробелы (0 - незначащий столбец, 1 - бункерные весы, - 2 - конвеерные): ");
    var FilesConfig = Console.ReadLine();

    if (String.IsNullOrEmpty(FilesConfig) || !OtherValidators.CheckFilesConfig(FilesConfig).Status)
    {
        Console.Write("Прервано. ");
        Console.WriteLine(DirectoryInfo.Message);
        Console.WriteLine("Продолжить ввод? 1 - Да; любое другое число - Нет.");
        Choise = Convert.ToInt32(Console.ReadLine());
        IterationNumber += 1;
        continue;
    }

    ListResponse<RegularData> RegularDatas = FileInfoGetter.GetRegularInfoFromFiles(DirectoryInfo.ObjectList, FilesConfig);

    IterationNumber += 1;
}

Console.WriteLine("\nРабота программы - окончена.");