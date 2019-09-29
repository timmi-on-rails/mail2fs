using MailSync;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace ImapTest
{
    class Program
    {
        private const string Host = "imap.web.de";
        private const string CfgFile = "config.json";

        static void Main(string[] args)
        {
            using (TcpClient tcpc = new TcpClient(Host, 993))
            using (SslStream ssl = new SslStream(tcpc.GetStream()))
            {
                ssl.AuthenticateAsClient(Host);
                Console.Write("user: ");
                string user = Console.ReadLine();
                Console.Write("password: ");
                string password = Console.ReadLine();
                Imap.Send(ssl, $"$ LOGIN {user} {password}");

                string folder = "Test2";
                string cfg = File.ReadAllText(Program.CfgFile);
                Dictionary<int, string> map = JsonConvert.DeserializeObject<Dictionary<int, string>>(cfg);

                IdMap<int, string> idMap = new IdMap<int, string>(map);

                var imapStore = new ImapStore(ssl, folder);
                var fileStore = new FileStore(folder);
                Util.Integrate(imapStore, fileStore, idMap);
                var idMap2 = idMap.Invert();
                Util.Integrate(fileStore, imapStore, idMap2);

                cfg = JsonConvert.SerializeObject(idMap2.Invert().Map);
                File.WriteAllText(Program.CfgFile, cfg);

                // check uivalidity
                // TODO skip invalid filenames (subject not content)
                // TODO check if folder is empty, dangerous actions
                // TODO MS Outlook Plugin

                var messages = Imap.Send(ssl, $"$ STATUS {folder} (MESSAGES)");
                int count = Convert.ToInt32(Regex.Match(messages, @".*MESSAGES (\d+).*").Groups[1].Value);
                
                Imap.Send(ssl, "$ LOGOUT");
            }
        }
    }
}
