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
    }
}
