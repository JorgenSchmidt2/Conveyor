using ConveyorUtility.Bunker.Core.Enitites;
using ConveyorUtility.Bunker.Core.Responses;
using ConveyorUtility.Bunker.Service.ErrorService;
using ConveyorUtility.Bunker.Service.ValidateService;

namespace ConveyorUtility.Bunker.Service.FileService
{
    public class FileInfoGetter
    {
        public static ListResponse<RegularData> GetRegularInfoFromFiles(List<LocFileInfo> FileList, string FilesConfig)
        {
            ListResponse<RegularData> Result = new ListResponse<RegularData>();
            Result.ObjectList = new List<RegularData>();
            Result.Status = true;

            try
            {
                var BeginColumn = 0;
                foreach (var symbol in FilesConfig)
                {
                    BeginColumn++;
                    if (!symbol.Equals('0')) break;
                }

                foreach (LocFileInfo file in FileList)
                {
                    var fileContent = ContentReaders.GetContentFromFile(file.DirName, file.FileName);

                    var fileContentValidator = FileContentValidators.GetContentFromGeneralFile_CSV(fileContent.Result, file.FileName, FilesConfig);
                    if (!fileContentValidator.Status)
                    {
                        ErrorConsoleShowers.ShowForFileValidate(file.FileName, fileContentValidator.Message);
                        continue;
                    }

                    

                }

                return Result;
            }
            catch (Exception e)
            {
                Result.Message = e.Message;
                Result.Status = false;
                return Result;
            }
        }
    }
}