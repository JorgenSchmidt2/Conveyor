using ConveyorUtility.Bunker.Service.ValidateService;

namespace ConveyorUtility.Bunker.Service.ErrorService
{
    public class ErrorConsoleShowers
    {
        public static void ShowForFileValidate (string FileName, string Error)
        {
            var Message = "Обнаружен нечитаемый файл " + FileName + ". Описание ошибки: " + Error +
                ".\n Содержимое файла при расчётах учитываться не будет! \n";
            Console.Write(Message);
        }
    }
}