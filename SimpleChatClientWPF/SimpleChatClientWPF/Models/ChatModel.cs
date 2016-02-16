using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SimpleChatClientWPF.Models
{
    class ChatModel
    {
        public int ChatId { get; set; }
        public string ChatText { get; set; }
        public string ChatTitle { get; set; }
        public string ChatLog { get; set; }
        public List<Views.FriendListEntry> Participants { get; set; }
    }
}
