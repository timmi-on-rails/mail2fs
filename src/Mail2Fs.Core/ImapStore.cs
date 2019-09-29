using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace MailSync
{
    public class ImapStore : IStore<int>
    {
        private readonly SslStream ssl;
        private readonly string folder;
        public ImapStore(SslStream ssl, string folder)
        {
            this.ssl = ssl;
            this.folder = folder;

            Imap.Send(ssl, $"$ SELECT {folder}");
        }

        public void Delete(int id)
        {
            string response = Imap.Send(ssl, @$"$ uid store {id} +FLAGS (\Deleted)");
            response = Imap.Send(ssl, @$"$ EXPUNGE");
        }

        public TextReader Get(int id)
        {
            string mail = Imap.Send(ssl, $"$ UID FETCH {id} (RFC822)");

            return new StringReader(mail);
        }

        public IEnumerable<int> List()
        {
            string response = Imap.Send(ssl, "$ UID SEARCH ALL");
            var list = response.Split(Environment.NewLine)
                               .First()
                               .Split(' ')
                               .Skip(2)
                               .Select(i => Convert.ToInt32(i))
                               .ToArray();

            return list;
        }

        public int Store(TextReader reader)
        {
            string content = reader.ReadToEnd();
            string response = Imap.Send(ssl, $"$ APPEND {folder} {{{content.Length}}}\n" + content);
            string id = Regex.Match(response, @"\[APPENDUID \d+ (\d+)\]", RegexOptions.Multiline).Groups[1].Value;
            return Convert.ToInt32(id);
        }
    }
}
