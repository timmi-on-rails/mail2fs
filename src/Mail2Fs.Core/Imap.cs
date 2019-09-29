using System.IO;
using System.Text;

namespace MailSync
{
    public static class Imap
    {
        public static string Send(Stream stream, string command)
        {
            StringBuilder stringBuilder = new StringBuilder();

            using (StreamWriter writer = new StreamWriter(stream, leaveOpen: true))
            {
                writer.WriteLine(command);
            }

            using (StreamReader reader = new StreamReader(stream, leaveOpen: true))
            {
                string response;

                do
                {
                    response = reader.ReadLine();
                    stringBuilder.AppendLine(response);
                } while (!response.EndsWith("completed")); /* careful, the check can fail, if message contains string -> check imap spec */
            }

            return stringBuilder.ToString();
        }

        public static void FetchMail(Stream stream, string directory, int number)
        {
            Directory.CreateDirectory(directory);
            string mail = Send(stream, $"$ FETCH {number} (RFC822)");

            using (var reader = new StringReader(mail))
            using (var fileWriter = new StreamWriter(Path.Combine(directory, $"mail{number}.eml")))
            {
                reader.ReadLine();

                string line;
                do
                {
                    line = reader.ReadLine();
                    if (reader.Peek() >= 0)
                    {
                        fileWriter.WriteLine(line);
                    }
                } while (line != null);
            }
        }
    }
}
