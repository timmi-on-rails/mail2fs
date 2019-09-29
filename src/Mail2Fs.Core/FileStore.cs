using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MailSync
{
    public class FileStore : IStore<string>
    {
        private readonly string directory;

        public FileStore(string directory)
        {
            this.directory = directory;
            Directory.CreateDirectory(directory);
        }
        public void Delete(string id)
        {
            string trash = Path.Combine(directory, "trash");
            Directory.CreateDirectory(trash);
            File.Move(Path.Combine(directory, id), Path.Combine(trash, id));
        }

        public TextReader Get(string id)
        {
            return new StreamReader(Path.Combine(directory, id));
        }

        public IEnumerable<string> List()
        {
            var files = Directory.GetFiles(directory, "*.eml")
                                 .Select(f => Path.GetFileName(f))
                                 .ToArray();
            return files;
        }

        public string Store(TextReader reader)
        {
            string mail = reader.ReadToEnd();
            string subject = Regex.Match(mail, @"^Subject: (.*)$", RegexOptions.Multiline).Groups[1].Value.TrimEnd();
            string date = Regex.Match(mail, @"^Date: (.*)$", RegexOptions.Multiline).Groups[1].Value.TrimEnd();

            DateTime dateTime = DateTime.Now;
            if (!DateTime.TryParse(date, out dateTime))
            {
                dateTime = DateTime.Now;
            }

            string filename = dateTime.ToString() + " " + subject + ".eml";

            var invalids = System.IO.Path.GetInvalidFileNameChars();
            filename = String.Join("_", filename.Split(invalids, StringSplitOptions.RemoveEmptyEntries)).TrimEnd('.');

            File.WriteAllText(Path.Combine(directory, filename), mail);
            return filename;
        }
    }
}
