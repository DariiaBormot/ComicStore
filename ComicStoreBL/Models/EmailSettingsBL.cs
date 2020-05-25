using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComicStoreBL.Models
{
    public class EmailSettingsBL
    {
        public string MailToAddress { get; set; }
        public string MailFromAddress { get; set; } = "dariiabormot@outlook.com";
        public bool UseSsl { get; set; } = true;
        public string Username { get; set; } = "dariiabormot@outlook.com";
        public string Password { get; set; } // set valid
        public string Host { get; set; } = "smtp-mail.outlook.com";  
        public int ServerPort { get; set; } = 587;
        public bool WriteAsFile { get; set; } = true;
        public string FileLocation { get; set; } = @"F:\.Net C#\temp";
    }
}
