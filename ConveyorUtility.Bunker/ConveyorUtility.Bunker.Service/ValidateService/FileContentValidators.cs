using ConveyorUtility.Bunker.Core.Responses;

namespace ConveyorUtility.Bunker.Service.ValidateService
{
    public class FileContentValidators
    {
        public static SimpleResponse GetContentFromGeneralFile_CSV (string Content, string FileName, string FilesConfig) 
        { 
            SimpleResponse Result = new SimpleResponse ();
            Result.Status = true;

            var Lines = Content.Split ('\n').ToList();

            // Если последняя строка файла оказалась пуста - удаляем её
            if (String.IsNullOrEmpty(Lines[Lines.Count - 1]))
            {
                Lines.RemoveAt (Lines.Count - 1);
            }
            
            // Определяет на какой строке 
            int LineCounter = 1;

            // Определение начального столбца данных
            var BeginColumn = 0;
            foreach (var symbol in FilesConfig)
            {
                BeginColumn++;
                if (!symbol.Equals('0')) break;
            }

            var FileNameSplits = FileName.Split (' ', '.');
            bool FileNameIsCorrect = false;

            // Проверка на имя файла (д.б хоть одна цифра)
            foreach (var Item in FileNameSplits)
            {
                if (Double.TryParse(Item, out double res))
                {
                    FileNameIsCorrect = true;
                    break;
                }
            }

            if (!FileNameIsCorrect)
            {
                Result.Status = false;
                Result.Message = "Ошибка: имя файла должно содержать хотя бы одну цифру.";
                return Result;
            }

            var ConfigSplits = FilesConfig.Split(" ");

            // Проверка контента
            foreach (var Line in Lines)
            {
                var splits = Line.Split (';');

                // Проверка на кол-во элементов
                if (splits.Length + BeginColumn < 6 + BeginColumn )
                {
                    Result.Status = false;
                    Result.Message = "В строке №" + LineCounter + " файла \"" + FileName + "\" ошибка, количество элементов не равно 6";
                    return Result;
                }

                // Проверка содержат ли колонки цифры
                for (int i = BeginColumn - 1; i < BeginColumn + ConfigSplits.Length - 2; i += 1)
                {
                    if (!Double.TryParse(splits[i], out double res))
                    {
                        Result.Status = false;
                        Result.Message = "В строке №" + i + "файла" + FileName + "ошибка. Одна из целевых строк не содержала число.";
                        return Result;
                    }
                }

                LineCounter += 1;
            }


            return Result;
        }
    }
}