using ConveyorUtility.Bunker.Core.Responses;

namespace ConveyorUtility.Bunker.Service.FileService
{
    public class ContentReaders
    {
        public static ObjectResponse<string> GetContentFromFile(string DirectoryName, string FileName)
        {
            ObjectResponse<string> Result = new ObjectResponse<string>();

            string ActuallyFilePath = Environment.CurrentDirectory + @"\" + DirectoryName + @"\" + FileName;

            var file = new FileInfo(ActuallyFilePath);
            if (!file.Exists || file.Length == 0)
            {
                Result.Status = false;
                Result.Message = "Ошибка, файл не существует, либо его содержимое пустое.";
                return Result;
            }

            try
            {
                Result.Result = File.ReadAllText(ActuallyFilePath);
            }
            catch (Exception e)
            {
                Result.Status = false;
                Result.Message = "Ошибка при чтении файла " + FileName + ":\n" + e.Message;
                return Result;
            }

            return Result;
        }
    }
}