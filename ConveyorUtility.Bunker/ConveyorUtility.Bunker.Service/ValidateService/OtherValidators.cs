using ConveyorUtility.Bunker.Core.Responses;

namespace ConveyorUtility.Bunker.Service.ValidateService
{
    public class OtherValidators
    {
        public static SimpleResponse CheckFilesConfig (string FilesConfig)
        {
            SimpleResponse Result = new SimpleResponse ();
            Result.Status = true;

            var AllowedChars = new string[] { "0", "1", "2" };

            var ConfigSplits = FilesConfig.Split(' ');

            foreach (var Symbol in ConfigSplits)
            {
                var truelist = new List<bool>();
                foreach (var Charsym in AllowedChars)
                {
                    var curresult = Symbol.Equals(Charsym);
                    truelist.Add(curresult);
                }
                if (truelist.Where(x => x == true).Select(x => x).Count() == 0)
                {
                    Result.Message = "Строка содержала запрещённые символы.";
                    Result.Status = false;
                    return Result;
                }
            }

            return Result;
        }
    }
}
