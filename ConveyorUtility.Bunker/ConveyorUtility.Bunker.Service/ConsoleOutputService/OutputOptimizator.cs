namespace ConveyorUtility.Bunker.Service.ConsoleOutputService
{
    public class OutputOptimizator
    {
        public static string DoOptimization (string Content, int WordsPerLine)
        {
            string Result = "";

            var words = Content.Split (' ');

            int words_counter = 1;
            foreach (var word in words)
            {
                Result += word + " ";
                if (words_counter >= WordsPerLine)
                {
                    words_counter = 0;
                    Result += "\n";
                }
                words_counter += 1;
            }

            return Result;
        }
    }
}