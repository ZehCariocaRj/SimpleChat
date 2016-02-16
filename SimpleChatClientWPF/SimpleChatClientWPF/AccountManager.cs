using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Serialization;
using IO.Swagger.Api;
using IO.Swagger.Client;

namespace SimpleChatClientWPF
{
    public class AccountInfo
    {
        [XmlElement("Username")]
        public string Username;

        [XmlElement("Password")]
        public string Password;

        [XmlElement("Token")]
        public string Token;

        [XmlElement("AutomaticSignIn")]
        public bool AutomaticSignIn;

        [XmlElement("RememberPassword")]
        public bool RememberPassword;
    }

    class AccountManager
    {
        private AccountInfo _accountInfo;

        static string accountXmlFilename = "account.xml";
        private AccountManager()
        {
            _accountInfo = new AccountInfo();

            if (File.Exists(accountXmlFilename))
            {
                using (XmlTextReader reader = new XmlTextReader(accountXmlFilename))
                {
                    reader.WhitespaceHandling = WhitespaceHandling.All;
                    XmlSerializer serializer = new XmlSerializer(typeof(AccountInfo));
                    _accountInfo = (AccountInfo)serializer.Deserialize(reader);
                }
            }
        }

        ~AccountManager()
        {
            if(!RememberPassword)
            {
                Password = "";
            }

            using (TextWriter writer = new StreamWriter(accountXmlFilename))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AccountInfo));
                serializer.Serialize(writer, _accountInfo);
            }
        }

        private static AccountManager _loginManager = null;
        public static AccountManager GetInstance()
        {
            if(_loginManager == null)
            {
                _loginManager = new AccountManager();
            }

            return _loginManager;
        }

        private int _userId;
        public int UserId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        public String Username
        {
            get
            {
                return _accountInfo.Username;
            }
            set
            {
                _accountInfo.Username = value;
            }
        }

        public string Password
        {
            get
            {
                return _accountInfo.Password;
            }
            set
            {
                _accountInfo.Password = value;
            }
        }

        public String Token
        {
            get
            {
                return _accountInfo.Token;
            }
            set
            {
                _accountInfo.Token = value;
            }
        }

        public bool AutomaticSignIn
        {
            get
            {
                return _accountInfo.AutomaticSignIn;
            }
            set
            {
                _accountInfo.AutomaticSignIn = value;
            }
        }

        public bool RememberPassword
        {
            get
            {
                return _accountInfo.RememberPassword;
            }
            set
            {
                _accountInfo.RememberPassword = value;
            }
        }

        private string _displayName;
        public string DisplayName
        {
            get
            {
                return _displayName;
            }
            set
            {
                _displayName = value;
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        public static IO.Swagger.Model.UserProfile UpdateProfile()
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");

            IO.Swagger.Model.UserProfile profile = new IO.Swagger.Model.UserProfile();
            profile = api.GetMyProfile(lm.Token);
            lm.UserId = profile.UserId.Value;
            lm.Username = profile.Username;
            lm.DisplayName = profile.DisplayName;
            lm.Email = profile.Email;

            return profile;
        }

        internal static bool SetChatTitle(int chatId, string chatTitle)
        {
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            AccountManager lm = AccountManager.GetInstance();
            return api.UpdateChat(lm.Token, chatId, chatTitle).Value;
        }

        internal static void Signout()
        {
            AccountManager lm = AccountManager.GetInstance();
            lm.Token = "";
            lm.AutomaticSignIn = false;
        }

        public static bool UpdateUser(string token, string username, string password, string email, string displayName)
        {
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            AccountManager lm = AccountManager.GetInstance();
            var ret = api.UpdateUser(lm.Token, username, password, email, displayName).Value;
            UpdateProfile();
            return ret;
        }

        public static bool LoginUser(string username, string password)
        {
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");

            AccountManager lm = AccountManager.GetInstance();
            lm.Token = api.LoginUser(username, password);
            lm.Password = password;

            UpdateProfile();

            return true;
        }

        public static bool RegisterUser(string username, string password, string email, string displayName)
        {
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            var result = api.RegisterUserWithHttpInfo(displayName, username, password, email);
            return result.Data == "true";
        }

        public static List<IO.Swagger.Model.Friend> GetFriendList()
        {
            List<IO.Swagger.Model.Friend> friends = new List<IO.Swagger.Model.Friend>();

            try
            {
                AccountManager lm = AccountManager.GetInstance();
                DefaultApi api = new DefaultApi("http://localhost:8080/api/");
                friends = api.GetMyFriends(lm.Token);
            }
            catch (ApiException e)
            {

            }

            return friends;
        }

        public static IO.Swagger.Model.Friend AddFriend(string username)
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.AddFriend(username, lm.Token);
        }

        public static bool DeleteFriend(int id)
        {
            try
            {
                AccountManager lm = AccountManager.GetInstance();
                DefaultApi api = new DefaultApi("http://localhost:8080/api/");
                return api.DeleteFriend(id, lm.Token).Value;
            }
            catch (ApiException e)
            {
            }

            return false;
        }

        public static int CreateChatGroup(string chatName)
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.CreateChatGroup(new List<int?>() { lm.UserId }, chatName, lm.Token).Value;
        }

        public static IO.Swagger.Model.UserProfile GetProfileById(int userId)
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.GetProfileById(userId, lm.Token);
        }

        public static List<IO.Swagger.Model.Chat> GetChatList()
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.GetChats(lm.Token);
        }

        public static IO.Swagger.Model.Chat GetChatInfo(int chatId)
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.GetChat(chatId, lm.Token);
        }

        public static List<IO.Swagger.Model.Message> GetChatMessages(int chatId)
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.GetChatMessages(chatId, lm.Token);
        }

        public static IO.Swagger.Model.Message SendChatMessage(int chatId, string message)
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.SendChatMessage(chatId, message, lm.Token);
        }

        public static bool InviteUserToChat(int chatId, string username)
        {
            AccountManager lm = AccountManager.GetInstance();
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            return api.InviteUserToChat(chatId, username, lm.Token).Value;
        }
    }
}
