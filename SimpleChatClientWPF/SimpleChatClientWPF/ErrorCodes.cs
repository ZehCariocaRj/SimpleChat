using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SimpleChatClientWPF
{
    class ErrorCodes
    {
        static public IO.Swagger.Model.Error TranslateError(string data)
        {
            IO.Swagger.Model.Error error = null;
            error = JsonConvert.DeserializeObject<IO.Swagger.Model.Error>(data);
            return error;
        }

        static public string TranslateErrorCode(int errorCode)
        {
            string message = "";

            switch (errorCode)
            {
                // User-related error codes
                case 100:
                    message = "Username already exists";
                    break;

                // Account-related error codes
                case 200:
                    message = "Invalid username/password combination";
                    break;
                case 201:
                    message = "Could not verify account";
                    break;
                case 202:
                    message = "Invalid account";
                    break;
                case 203:
                    message = "Could not delete account";
                    break;

                // Friend-related error codes
                case 400:
                    message = "Could not add friend";
                    break;
                case 401:
                    message = "Could not delete friend";
                    break;

                // Chat-related error codes
                case 600:
                    message = "Could not create chat group";
                    break;
                case 601:
                    message = "Could not send message to group";
                    break;
                case 603:
                    message = "Could not get messages";
                    break;

                // Authentication-related error codes
                case 800:
                    message = "Invalid token";
                    break;

                default:
                    message = "";
                    break;
            }

            return message;
        }
    }
}
