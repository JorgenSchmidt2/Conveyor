using ConveyorUtility.Bunker.Core.Enitites;
using ConveyorUtility.Bunker.Core.Responses;

namespace ConveyorUtility.Bunker.Service.FileService
{
    public class DirectoryInfoGetter
    {
        public static ListResponse<LocFileInfo> GetInfo(string PathName)
        {
            ListResponse<LocFileInfo> Result = new ListResponse<LocFileInfo>();
            Result.ObjectList = new List<LocFileInfo>();
            Result.Status = true;

            string FullDirPath = Environment.CurrentDirectory + "\\" + PathName;

            if (!Directory.Exists(FullDirPath))
            {
                Result.Status = false;
                Result.Message = "Ошибка: директории " + PathName + " не существует.";
                return Result;
            }

            var FileList = Directory.GetFiles(FullDirPath);

            if (FileList.Length == 0)
            {
                Result.Status = false;
                Result.Message = "Ошибка: директория " + PathName + " оказалась пуста.";
                return Result;
            }

            foreach (var curFile in FileList)
            {
                var splits = curFile.Split('\\');
                Result.ObjectList.Add(
                    new LocFileInfo()
                    {
                        DirName = PathName,
                        FileName = splits[splits.Length - 1]
                    }    
                );
            }

            return Result;
        }
    }
}