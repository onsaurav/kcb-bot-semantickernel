using System.IO;

namespace KcbBotSemanticKernel.Bot.Helper
{
    public class JsonHelper
    {
        public static string ReadCardJson(string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Cards", fileName);
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{fileName}' was not found in the 'cards' directory.");
            }

            return File.ReadAllText(filePath);
        }
    }
}
