using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITFLIX.Models
{
    public class ChatModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string EmailPassword { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string AttachmentPath { get; set; }
    }
}
