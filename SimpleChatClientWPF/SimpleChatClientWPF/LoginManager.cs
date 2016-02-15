using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        [XmlElement("RemmeberPassword")]
        public bool RemmeberPassword;
    }

    class LoginManager
    {
        private AccountInfo _accountInfo;

        static string accountXmlFilename = "account.xml";
        private LoginManager()
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

        ~LoginManager()
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

        private static LoginManager _loginManager = null;
        public static LoginManager GetInstance()
        {
            if(_loginManager == null)
            {
                _loginManager = new LoginManager();
            }

            return _loginManager;
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
                return _accountInfo.RemmeberPassword;
            }
            set
            {
                _accountInfo.RemmeberPassword = value;
            }
        }

        public static bool LoginUser(string username, string password)
        {
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");

            LoginManager lm = LoginManager.GetInstance();
            lm.Token = api.LoginUser(username, password);
            lm.Username = username;
            lm.Password = password;

            return true;
        }

        public static bool RegisterUser(string username, string password, string email)
        {
            DefaultApi api = new DefaultApi("http://localhost:8080/api/");
            var result = api.RegisterUserWithHttpInfo(username, password, email);
            return result.Data == "true";
        }

        public static List<IO.Swagger.Model.Friend> GetFriendList()
        {
            List<IO.Swagger.Model.Friend> friends = new List<IO.Swagger.Model.Friend>();

            try
            {
                LoginManager lm = LoginManager.GetInstance();
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
            try
            {
                LoginManager lm = LoginManager.GetInstance();
                DefaultApi api = new DefaultApi("http://localhost:8080/api/");
                return api.AddFriend(username, lm.Token);
            }
            catch (ApiException e)
            {
            }

            return null;
        }

        public static bool DeleteFriend(int id)
        {
            try
            {
                LoginManager lm = LoginManager.GetInstance();
                DefaultApi api = new DefaultApi("http://localhost:8080/api/");
                return api.DeleteFriend(id, lm.Token).Value;
            }
            catch (ApiException e)
            {
            }

            return false;
        }
    }
}
