using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IDefaultApi
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Send a chat message.
        /// </remarks>
        /// <param name="targetId">ID of target group</param>
        /// <param name="message">Message to send</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Message</returns>
        Message SendChatMessage (int? targetId, string message, string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Send a chat message.
        /// </remarks>
        /// <param name="targetId">ID of target group</param>
        /// <param name="message">Message to send</param>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of Message</returns>
        ApiResponse<Message> SendChatMessageWithHttpInfo (int? targetId, string message, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Send a chat message.
        /// </remarks>
        /// <param name="targetId">ID of target group</param>
        /// <param name="message">Message to send</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of Message</returns>
        System.Threading.Tasks.Task<Message> SendChatMessageAsync (int? targetId, string message, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Send a chat message.
        /// </remarks>
        /// <param name="targetId">ID of target group</param>
        /// <param name="message">Message to send</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (Message)</returns>
        System.Threading.Tasks.Task<ApiResponse<Message>> SendChatMessageAsyncWithHttpInfo (int? targetId, string message, string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create a chat group.
        /// </remarks>
        /// <param name="userIds">IDs of users to be added to chat group</param>
        /// <param name="chatTitle">Name of chat group to be created</param>
        /// <param name="token">Authentication token</param>
        /// <returns>int?</returns>
        int? CreateChatGroup (List<int?> userIds, string chatTitle, string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create a chat group.
        /// </remarks>
        /// <param name="userIds">IDs of users to be added to chat group</param>
        /// <param name="chatTitle">Name of chat group to be created</param>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of int?</returns>
        ApiResponse<int?> CreateChatGroupWithHttpInfo (List<int?> userIds, string chatTitle, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create a chat group.
        /// </remarks>
        /// <param name="userIds">IDs of users to be added to chat group</param>
        /// <param name="chatTitle">Name of chat group to be created</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of int?</returns>
        System.Threading.Tasks.Task<int?> CreateChatGroupAsync (List<int?> userIds, string chatTitle, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Create a chat group.
        /// </remarks>
        /// <param name="userIds">IDs of users to be added to chat group</param>
        /// <param name="chatTitle">Name of chat group to be created</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (int?)</returns>
        System.Threading.Tasks.Task<ApiResponse<int?>> CreateChatGroupAsyncWithHttpInfo (List<int?> userIds, string chatTitle, string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get all chat messages from target group chat.
        /// </remarks>
        /// <param name="targetGroupId">ID of target group</param>
        /// <param name="lastMessageId">ID of last message received</param>
        /// <param name="token">Authentication token</param>
        /// <returns>List&lt;Message&gt;</returns>
        List<Message> GetChatMessages (int? targetGroupId, int? lastMessageId, string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get all chat messages from target group chat.
        /// </remarks>
        /// <param name="targetGroupId">ID of target group</param>
        /// <param name="lastMessageId">ID of last message received</param>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of List&lt;Message&gt;</returns>
        ApiResponse<List<Message>> GetChatMessagesWithHttpInfo (int? targetGroupId, int? lastMessageId, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get all chat messages from target group chat.
        /// </remarks>
        /// <param name="targetGroupId">ID of target group</param>
        /// <param name="lastMessageId">ID of last message received</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of List&lt;Message&gt;</returns>
        System.Threading.Tasks.Task<List<Message>> GetChatMessagesAsync (int? targetGroupId, int? lastMessageId, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get all chat messages from target group chat.
        /// </remarks>
        /// <param name="targetGroupId">ID of target group</param>
        /// <param name="lastMessageId">ID of last message received</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (List&lt;Message&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Message>>> GetChatMessagesAsyncWithHttpInfo (int? targetGroupId, int? lastMessageId, string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a list of all friends for the currently logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>List&lt;Friend&gt;</returns>
        List<Friend> GetMyFriends (string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a list of all friends for the currently logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of List&lt;Friend&gt;</returns>
        ApiResponse<List<Friend>> GetMyFriendsWithHttpInfo (string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a list of all friends for the currently logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of List&lt;Friend&gt;</returns>
        System.Threading.Tasks.Task<List<Friend>> GetMyFriendsAsync (string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a list of all friends for the currently logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (List&lt;Friend&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Friend>>> GetMyFriendsAsyncWithHttpInfo (string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Add friend to friend list of currently logged in user.
        /// </remarks>
        /// <param name="username">Username of person to friend</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Friend</returns>
        Friend AddFriend (string username, string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Add friend to friend list of currently logged in user.
        /// </remarks>
        /// <param name="username">Username of person to friend</param>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of Friend</returns>
        ApiResponse<Friend> AddFriendWithHttpInfo (string username, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Add friend to friend list of currently logged in user.
        /// </remarks>
        /// <param name="username">Username of person to friend</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of Friend</returns>
        System.Threading.Tasks.Task<Friend> AddFriendAsync (string username, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Add friend to friend list of currently logged in user.
        /// </remarks>
        /// <param name="username">Username of person to friend</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (Friend)</returns>
        System.Threading.Tasks.Task<ApiResponse<Friend>> AddFriendAsyncWithHttpInfo (string username, string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete friend from friend list.
        /// </remarks>
        /// <param name="targetId">User ID of friend to delete</param>
        /// <param name="token">Authentication token</param>
        /// <returns>bool?</returns>
        bool? DeleteFriend (int? targetId, string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete friend from friend list.
        /// </remarks>
        /// <param name="targetId">User ID of friend to delete</param>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of bool?</returns>
        ApiResponse<bool?> DeleteFriendWithHttpInfo (int? targetId, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete friend from friend list.
        /// </remarks>
        /// <param name="targetId">User ID of friend to delete</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of bool?</returns>
        System.Threading.Tasks.Task<bool?> DeleteFriendAsync (int? targetId, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete friend from friend list.
        /// </remarks>
        /// <param name="targetId">User ID of friend to delete</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool?>> DeleteFriendAsyncWithHttpInfo (int? targetId, string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of current logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>UserProfile</returns>
        UserProfile GetMyProfile (string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of current logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of UserProfile</returns>
        ApiResponse<UserProfile> GetMyProfileWithHttpInfo (string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of current logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of UserProfile</returns>
        System.Threading.Tasks.Task<UserProfile> GetMyProfileAsync (string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of current logged in user.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (UserProfile)</returns>
        System.Threading.Tasks.Task<ApiResponse<UserProfile>> GetMyProfileAsyncWithHttpInfo (string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update account and profile information.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <param name="username">Account&#39;s username</param>
        /// <param name="password">Account&#39;s password</param>
        /// <param name="email">Account&#39;s email</param>
        /// <param name="displayName">Account&#39;s display name</param>
        /// <returns>bool?</returns>
        bool? UpdateUser (string token, string username = null, string password = null, string email = null, string displayName = null);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update account and profile information.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <param name="username">Account&#39;s username</param>
        /// <param name="password">Account&#39;s password</param>
        /// <param name="email">Account&#39;s email</param>
        /// <param name="displayName">Account&#39;s display name</param>
        /// <returns>ApiResponse of bool?</returns>
        ApiResponse<bool?> UpdateUserWithHttpInfo (string token, string username = null, string password = null, string email = null, string displayName = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update account and profile information.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <param name="username">Account&#39;s username</param>
        /// <param name="password">Account&#39;s password</param>
        /// <param name="email">Account&#39;s email</param>
        /// <param name="displayName">Account&#39;s display name</param>
        /// <returns>Task of bool?</returns>
        System.Threading.Tasks.Task<bool?> UpdateUserAsync (string token, string username = null, string password = null, string email = null, string displayName = null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Update account and profile information.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <param name="username">Account&#39;s username</param>
        /// <param name="password">Account&#39;s password</param>
        /// <param name="email">Account&#39;s email</param>
        /// <param name="displayName">Account&#39;s display name</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool?>> UpdateUserAsyncWithHttpInfo (string token, string username = null, string password = null, string email = null, string displayName = null);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Register new account.
        /// </remarks>
        /// <param name="username">New account&#39;s username</param>
        /// <param name="password">New account&#39;s password</param>
        /// <param name="email">New account&#39;s email</param>
        /// <returns>string</returns>
        string RegisterUser (string username, string password, string email);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Register new account.
        /// </remarks>
        /// <param name="username">New account&#39;s username</param>
        /// <param name="password">New account&#39;s password</param>
        /// <param name="email">New account&#39;s email</param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> RegisterUserWithHttpInfo (string username, string password, string email);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Register new account.
        /// </remarks>
        /// <param name="username">New account&#39;s username</param>
        /// <param name="password">New account&#39;s password</param>
        /// <param name="email">New account&#39;s email</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> RegisterUserAsync (string username, string password, string email);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Register new account.
        /// </remarks>
        /// <param name="username">New account&#39;s username</param>
        /// <param name="password">New account&#39;s password</param>
        /// <param name="email">New account&#39;s email</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> RegisterUserAsyncWithHttpInfo (string username, string password, string email);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete account.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>bool?</returns>
        bool? DeleteUser (string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete account.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of bool?</returns>
        ApiResponse<bool?> DeleteUserWithHttpInfo (string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete account.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of bool?</returns>
        System.Threading.Tasks.Task<bool?> DeleteUserAsync (string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Delete account.
        /// </remarks>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool?>> DeleteUserAsyncWithHttpInfo (string token);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a login token.
        /// </remarks>
        /// <param name="username">User&#39;s username</param>
        /// <param name="password">User&#39;s password</param>
        /// <returns>string</returns>
        string LoginUser (string username, string password);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a login token.
        /// </remarks>
        /// <param name="username">User&#39;s username</param>
        /// <param name="password">User&#39;s password</param>
        /// <returns>ApiResponse of string</returns>
        ApiResponse<string> LoginUserWithHttpInfo (string username, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a login token.
        /// </remarks>
        /// <param name="username">User&#39;s username</param>
        /// <param name="password">User&#39;s password</param>
        /// <returns>Task of string</returns>
        System.Threading.Tasks.Task<string> LoginUserAsync (string username, string password);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get a login token.
        /// </remarks>
        /// <param name="username">User&#39;s username</param>
        /// <param name="password">User&#39;s password</param>
        /// <returns>Task of ApiResponse (string)</returns>
        System.Threading.Tasks.Task<ApiResponse<string>> LoginUserAsyncWithHttpInfo (string username, string password);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Verify a user&#39;s account.
        /// </remarks>
        /// <param name="verificationHash">Verification hash of account</param>
        /// <returns>bool?</returns>
        bool? VerifyUser (string verificationHash);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Verify a user&#39;s account.
        /// </remarks>
        /// <param name="verificationHash">Verification hash of account</param>
        /// <returns>ApiResponse of bool?</returns>
        ApiResponse<bool?> VerifyUserWithHttpInfo (string verificationHash);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Verify a user&#39;s account.
        /// </remarks>
        /// <param name="verificationHash">Verification hash of account</param>
        /// <returns>Task of bool?</returns>
        System.Threading.Tasks.Task<bool?> VerifyUserAsync (string verificationHash);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Verify a user&#39;s account.
        /// </remarks>
        /// <param name="verificationHash">Verification hash of account</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        System.Threading.Tasks.Task<ApiResponse<bool?>> VerifyUserAsyncWithHttpInfo (string verificationHash);
        
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of target user.
        /// </remarks>
        /// <param name="targetUserId">ID of target user</param>
        /// <param name="token">Authentication token</param>
        /// <returns>List&lt;UserProfile&gt;</returns>
        List<UserProfile> GetProfileById (int? targetUserId, string token);
  
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of target user.
        /// </remarks>
        /// <param name="targetUserId">ID of target user</param>
        /// <param name="token">Authentication token</param>
        /// <returns>ApiResponse of List&lt;UserProfile&gt;</returns>
        ApiResponse<List<UserProfile>> GetProfileByIdWithHttpInfo (int? targetUserId, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of target user.
        /// </remarks>
        /// <param name="targetUserId">ID of target user</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of List&lt;UserProfile&gt;</returns>
        System.Threading.Tasks.Task<List<UserProfile>> GetProfileByIdAsync (int? targetUserId, string token);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Get profile of target user.
        /// </remarks>
        /// <param name="targetUserId">ID of target user</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (List&lt;UserProfile&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<UserProfile>>> GetProfileByIdAsyncWithHttpInfo (int? targetUserId, string token);
        
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class DefaultApi : IDefaultApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class.
        /// </summary>
        /// <returns></returns>
        public DefaultApi(String basePath)
        {
            this.Configuration = new Configuration(new ApiClient(basePath));
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public DefaultApi(Configuration configuration = null)
        {
            if (configuration == null) // use the default one in Configuration
                this.Configuration = Configuration.Default; 
            else
                this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public String GetBasePath()
        {
            return this.Configuration.ApiClient.RestClient.BaseUrl.ToString();
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        [Obsolete("SetBasePath is deprecated, please do 'Configuraiton.ApiClient = new ApiClient(\"http://new-path\")' instead.")]
        public void SetBasePath(String basePath)
        {
            // do nothing
        }
    
        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Configuration Configuration {get; set;}

        /// <summary>
        /// Gets the default header.
        /// </summary>
        /// <returns>Dictionary of HTTP header</returns>
        [Obsolete("DefaultHeader is deprecated, please use Configuration.DefaultHeader instead.")]
        public Dictionary<String, String> DefaultHeader()
        {
            return this.Configuration.DefaultHeader;
        }

        /// <summary>
        /// Add default header.
        /// </summary>
        /// <param name="key">Header field name.</param>
        /// <param name="value">Header field value.</param>
        /// <returns></returns>
        [Obsolete("AddDefaultHeader is deprecated, please use Configuration.AddDefaultHeader instead.")]
        public void AddDefaultHeader(string key, string value)
        {
            this.Configuration.AddDefaultHeader(key, value);
        }
   
        
        /// <summary>
        ///  Send a chat message.
        /// </summary>
        /// <param name="targetId">ID of target group</param> 
        /// <param name="message">Message to send</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>Message</returns>
        public Message SendChatMessage (int? targetId, string message, string token)
        {
             ApiResponse<Message> response = SendChatMessageWithHttpInfo(targetId, message, token);
             return response.Data;
        }

        /// <summary>
        ///  Send a chat message.
        /// </summary>
        /// <param name="targetId">ID of target group</param> 
        /// <param name="message">Message to send</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of Message</returns>
        public ApiResponse< Message > SendChatMessageWithHttpInfo (int? targetId, string message, string token)
        {
            
            // verify the required parameter 'targetId' is set
            if (targetId == null)
                throw new ApiException(400, "Missing required parameter 'targetId' when calling DefaultApi->SendChatMessage");
            
            // verify the required parameter 'message' is set
            if (message == null)
                throw new ApiException(400, "Missing required parameter 'message' when calling DefaultApi->SendChatMessage");
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->SendChatMessage");
            
    
            var path_ = "/chat";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (targetId != null) queryParams.Add("targetId", Configuration.ApiClient.ParameterToString(targetId)); // query parameter
            if (message != null) queryParams.Add("message", Configuration.ApiClient.ParameterToString(message)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling SendChatMessage: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling SendChatMessage: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<Message>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Message) Configuration.ApiClient.Deserialize(response, typeof(Message)));
            
        }
    
        /// <summary>
        ///  Send a chat message.
        /// </summary>
        /// <param name="targetId">ID of target group</param>
        /// <param name="message">Message to send</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of Message</returns>
        public async System.Threading.Tasks.Task<Message> SendChatMessageAsync (int? targetId, string message, string token)
        {
             ApiResponse<Message> response = await SendChatMessageAsyncWithHttpInfo(targetId, message, token);
             return response.Data;

        }

        /// <summary>
        ///  Send a chat message.
        /// </summary>
        /// <param name="targetId">ID of target group</param>
        /// <param name="message">Message to send</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (Message)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Message>> SendChatMessageAsyncWithHttpInfo (int? targetId, string message, string token)
        {
            // verify the required parameter 'targetId' is set
            if (targetId == null) throw new ApiException(400, "Missing required parameter 'targetId' when calling SendChatMessage");
            // verify the required parameter 'message' is set
            if (message == null) throw new ApiException(400, "Missing required parameter 'message' when calling SendChatMessage");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling SendChatMessage");
            
    
            var path_ = "/chat";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (targetId != null) queryParams.Add("targetId", Configuration.ApiClient.ParameterToString(targetId)); // query parameter
            if (message != null) queryParams.Add("message", Configuration.ApiClient.ParameterToString(message)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling SendChatMessage: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling SendChatMessage: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<Message>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Message) Configuration.ApiClient.Deserialize(response, typeof(Message)));
            
        }
        
        /// <summary>
        ///  Create a chat group.
        /// </summary>
        /// <param name="userIds">IDs of users to be added to chat group</param> 
        /// <param name="chatTitle">Name of chat group to be created</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>int?</returns>
        public int? CreateChatGroup (List<int?> userIds, string chatTitle, string token)
        {
             ApiResponse<int?> response = CreateChatGroupWithHttpInfo(userIds, chatTitle, token);
             return response.Data;
        }

        /// <summary>
        ///  Create a chat group.
        /// </summary>
        /// <param name="userIds">IDs of users to be added to chat group</param> 
        /// <param name="chatTitle">Name of chat group to be created</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of int?</returns>
        public ApiResponse< int? > CreateChatGroupWithHttpInfo (List<int?> userIds, string chatTitle, string token)
        {
            
            // verify the required parameter 'userIds' is set
            if (userIds == null)
                throw new ApiException(400, "Missing required parameter 'userIds' when calling DefaultApi->CreateChatGroup");
            
            // verify the required parameter 'chatTitle' is set
            if (chatTitle == null)
                throw new ApiException(400, "Missing required parameter 'chatTitle' when calling DefaultApi->CreateChatGroup");
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->CreateChatGroup");
            
    
            var path_ = "/chat/manage";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (userIds != null) queryParams.Add("userIds", Configuration.ApiClient.ParameterToString(userIds)); // query parameter
            if (chatTitle != null) queryParams.Add("chatTitle", Configuration.ApiClient.ParameterToString(chatTitle)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling CreateChatGroup: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling CreateChatGroup: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<int?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (int?) Configuration.ApiClient.Deserialize(response, typeof(int?)));
            
        }
    
        /// <summary>
        ///  Create a chat group.
        /// </summary>
        /// <param name="userIds">IDs of users to be added to chat group</param>
        /// <param name="chatTitle">Name of chat group to be created</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of int?</returns>
        public async System.Threading.Tasks.Task<int?> CreateChatGroupAsync (List<int?> userIds, string chatTitle, string token)
        {
             ApiResponse<int?> response = await CreateChatGroupAsyncWithHttpInfo(userIds, chatTitle, token);
             return response.Data;

        }

        /// <summary>
        ///  Create a chat group.
        /// </summary>
        /// <param name="userIds">IDs of users to be added to chat group</param>
        /// <param name="chatTitle">Name of chat group to be created</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (int?)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<int?>> CreateChatGroupAsyncWithHttpInfo (List<int?> userIds, string chatTitle, string token)
        {
            // verify the required parameter 'userIds' is set
            if (userIds == null) throw new ApiException(400, "Missing required parameter 'userIds' when calling CreateChatGroup");
            // verify the required parameter 'chatTitle' is set
            if (chatTitle == null) throw new ApiException(400, "Missing required parameter 'chatTitle' when calling CreateChatGroup");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling CreateChatGroup");
            
    
            var path_ = "/chat/manage";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (userIds != null) queryParams.Add("userIds", Configuration.ApiClient.ParameterToString(userIds)); // query parameter
            if (chatTitle != null) queryParams.Add("chatTitle", Configuration.ApiClient.ParameterToString(chatTitle)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling CreateChatGroup: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling CreateChatGroup: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<int?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (int?) Configuration.ApiClient.Deserialize(response, typeof(int?)));
            
        }
        
        /// <summary>
        ///  Get all chat messages from target group chat.
        /// </summary>
        /// <param name="targetGroupId">ID of target group</param> 
        /// <param name="lastMessageId">ID of last message received</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>List&lt;Message&gt;</returns>
        public List<Message> GetChatMessages (int? targetGroupId, int? lastMessageId, string token)
        {
             ApiResponse<List<Message>> response = GetChatMessagesWithHttpInfo(targetGroupId, lastMessageId, token);
             return response.Data;
        }

        /// <summary>
        ///  Get all chat messages from target group chat.
        /// </summary>
        /// <param name="targetGroupId">ID of target group</param> 
        /// <param name="lastMessageId">ID of last message received</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of List&lt;Message&gt;</returns>
        public ApiResponse< List<Message> > GetChatMessagesWithHttpInfo (int? targetGroupId, int? lastMessageId, string token)
        {
            
            // verify the required parameter 'targetGroupId' is set
            if (targetGroupId == null)
                throw new ApiException(400, "Missing required parameter 'targetGroupId' when calling DefaultApi->GetChatMessages");
            
            // verify the required parameter 'lastMessageId' is set
            if (lastMessageId == null)
                throw new ApiException(400, "Missing required parameter 'lastMessageId' when calling DefaultApi->GetChatMessages");
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->GetChatMessages");
            
    
            var path_ = "/chat/{targetGroupId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (targetGroupId != null) pathParams.Add("targetGroupId", Configuration.ApiClient.ParameterToString(targetGroupId)); // path parameter
            
            if (lastMessageId != null) queryParams.Add("lastMessageId", Configuration.ApiClient.ParameterToString(lastMessageId)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetChatMessages: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetChatMessages: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<List<Message>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Message>) Configuration.ApiClient.Deserialize(response, typeof(List<Message>)));
            
        }
    
        /// <summary>
        ///  Get all chat messages from target group chat.
        /// </summary>
        /// <param name="targetGroupId">ID of target group</param>
        /// <param name="lastMessageId">ID of last message received</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of List&lt;Message&gt;</returns>
        public async System.Threading.Tasks.Task<List<Message>> GetChatMessagesAsync (int? targetGroupId, int? lastMessageId, string token)
        {
             ApiResponse<List<Message>> response = await GetChatMessagesAsyncWithHttpInfo(targetGroupId, lastMessageId, token);
             return response.Data;

        }

        /// <summary>
        ///  Get all chat messages from target group chat.
        /// </summary>
        /// <param name="targetGroupId">ID of target group</param>
        /// <param name="lastMessageId">ID of last message received</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (List&lt;Message&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Message>>> GetChatMessagesAsyncWithHttpInfo (int? targetGroupId, int? lastMessageId, string token)
        {
            // verify the required parameter 'targetGroupId' is set
            if (targetGroupId == null) throw new ApiException(400, "Missing required parameter 'targetGroupId' when calling GetChatMessages");
            // verify the required parameter 'lastMessageId' is set
            if (lastMessageId == null) throw new ApiException(400, "Missing required parameter 'lastMessageId' when calling GetChatMessages");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling GetChatMessages");
            
    
            var path_ = "/chat/{targetGroupId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (targetGroupId != null) pathParams.Add("targetGroupId", Configuration.ApiClient.ParameterToString(targetGroupId)); // path parameter
            
            if (lastMessageId != null) queryParams.Add("lastMessageId", Configuration.ApiClient.ParameterToString(lastMessageId)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetChatMessages: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetChatMessages: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<List<Message>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Message>) Configuration.ApiClient.Deserialize(response, typeof(List<Message>)));
            
        }
        
        /// <summary>
        ///  Get a list of all friends for the currently logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <returns>List&lt;Friend&gt;</returns>
        public List<Friend> GetMyFriends (string token)
        {
             ApiResponse<List<Friend>> response = GetMyFriendsWithHttpInfo(token);
             return response.Data;
        }

        /// <summary>
        ///  Get a list of all friends for the currently logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of List&lt;Friend&gt;</returns>
        public ApiResponse< List<Friend> > GetMyFriendsWithHttpInfo (string token)
        {
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->GetMyFriends");
            
    
            var path_ = "/friends";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetMyFriends: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetMyFriends: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<List<Friend>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Friend>) Configuration.ApiClient.Deserialize(response, typeof(List<Friend>)));
            
        }
    
        /// <summary>
        ///  Get a list of all friends for the currently logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of List&lt;Friend&gt;</returns>
        public async System.Threading.Tasks.Task<List<Friend>> GetMyFriendsAsync (string token)
        {
             ApiResponse<List<Friend>> response = await GetMyFriendsAsyncWithHttpInfo(token);
             return response.Data;

        }

        /// <summary>
        ///  Get a list of all friends for the currently logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (List&lt;Friend&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<Friend>>> GetMyFriendsAsyncWithHttpInfo (string token)
        {
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling GetMyFriends");
            
    
            var path_ = "/friends";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetMyFriends: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetMyFriends: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<List<Friend>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<Friend>) Configuration.ApiClient.Deserialize(response, typeof(List<Friend>)));
            
        }
        
        /// <summary>
        ///  Add friend to friend list of currently logged in user.
        /// </summary>
        /// <param name="username">Username of person to friend</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>Friend</returns>
        public Friend AddFriend (string username, string token)
        {
             ApiResponse<Friend> response = AddFriendWithHttpInfo(username, token);
             return response.Data;
        }

        /// <summary>
        ///  Add friend to friend list of currently logged in user.
        /// </summary>
        /// <param name="username">Username of person to friend</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of Friend</returns>
        public ApiResponse< Friend > AddFriendWithHttpInfo (string username, string token)
        {
            
            // verify the required parameter 'username' is set
            if (username == null)
                throw new ApiException(400, "Missing required parameter 'username' when calling DefaultApi->AddFriend");
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->AddFriend");
            
    
            var path_ = "/friends";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling AddFriend: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling AddFriend: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<Friend>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Friend) Configuration.ApiClient.Deserialize(response, typeof(Friend)));
            
        }
    
        /// <summary>
        ///  Add friend to friend list of currently logged in user.
        /// </summary>
        /// <param name="username">Username of person to friend</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of Friend</returns>
        public async System.Threading.Tasks.Task<Friend> AddFriendAsync (string username, string token)
        {
             ApiResponse<Friend> response = await AddFriendAsyncWithHttpInfo(username, token);
             return response.Data;

        }

        /// <summary>
        ///  Add friend to friend list of currently logged in user.
        /// </summary>
        /// <param name="username">Username of person to friend</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (Friend)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<Friend>> AddFriendAsyncWithHttpInfo (string username, string token)
        {
            // verify the required parameter 'username' is set
            if (username == null) throw new ApiException(400, "Missing required parameter 'username' when calling AddFriend");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling AddFriend");
            
    
            var path_ = "/friends";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling AddFriend: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling AddFriend: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<Friend>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (Friend) Configuration.ApiClient.Deserialize(response, typeof(Friend)));
            
        }
        
        /// <summary>
        ///  Delete friend from friend list.
        /// </summary>
        /// <param name="targetId">User ID of friend to delete</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>bool?</returns>
        public bool? DeleteFriend (int? targetId, string token)
        {
             ApiResponse<bool?> response = DeleteFriendWithHttpInfo(targetId, token);
             return response.Data;
        }

        /// <summary>
        ///  Delete friend from friend list.
        /// </summary>
        /// <param name="targetId">User ID of friend to delete</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of bool?</returns>
        public ApiResponse< bool? > DeleteFriendWithHttpInfo (int? targetId, string token)
        {
            
            // verify the required parameter 'targetId' is set
            if (targetId == null)
                throw new ApiException(400, "Missing required parameter 'targetId' when calling DefaultApi->DeleteFriend");
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->DeleteFriend");
            
    
            var path_ = "/friends";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (targetId != null) queryParams.Add("targetId", Configuration.ApiClient.ParameterToString(targetId)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling DeleteFriend: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling DeleteFriend: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
    
        /// <summary>
        ///  Delete friend from friend list.
        /// </summary>
        /// <param name="targetId">User ID of friend to delete</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of bool?</returns>
        public async System.Threading.Tasks.Task<bool?> DeleteFriendAsync (int? targetId, string token)
        {
             ApiResponse<bool?> response = await DeleteFriendAsyncWithHttpInfo(targetId, token);
             return response.Data;

        }

        /// <summary>
        ///  Delete friend from friend list.
        /// </summary>
        /// <param name="targetId">User ID of friend to delete</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<bool?>> DeleteFriendAsyncWithHttpInfo (int? targetId, string token)
        {
            // verify the required parameter 'targetId' is set
            if (targetId == null) throw new ApiException(400, "Missing required parameter 'targetId' when calling DeleteFriend");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling DeleteFriend");
            
    
            var path_ = "/friends";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (targetId != null) queryParams.Add("targetId", Configuration.ApiClient.ParameterToString(targetId)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling DeleteFriend: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling DeleteFriend: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
        
        /// <summary>
        ///  Get profile of current logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <returns>UserProfile</returns>
        public UserProfile GetMyProfile (string token)
        {
             ApiResponse<UserProfile> response = GetMyProfileWithHttpInfo(token);
             return response.Data;
        }

        /// <summary>
        ///  Get profile of current logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of UserProfile</returns>
        public ApiResponse< UserProfile > GetMyProfileWithHttpInfo (string token)
        {
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->GetMyProfile");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetMyProfile: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetMyProfile: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<UserProfile>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserProfile) Configuration.ApiClient.Deserialize(response, typeof(UserProfile)));
            
        }
    
        /// <summary>
        ///  Get profile of current logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of UserProfile</returns>
        public async System.Threading.Tasks.Task<UserProfile> GetMyProfileAsync (string token)
        {
             ApiResponse<UserProfile> response = await GetMyProfileAsyncWithHttpInfo(token);
             return response.Data;

        }

        /// <summary>
        ///  Get profile of current logged in user.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (UserProfile)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<UserProfile>> GetMyProfileAsyncWithHttpInfo (string token)
        {
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling GetMyProfile");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetMyProfile: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetMyProfile: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<UserProfile>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (UserProfile) Configuration.ApiClient.Deserialize(response, typeof(UserProfile)));
            
        }
        
        /// <summary>
        ///  Update account and profile information.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <param name="username">Account&#39;s username</param> 
        /// <param name="password">Account&#39;s password</param> 
        /// <param name="email">Account&#39;s email</param> 
        /// <param name="displayName">Account&#39;s display name</param> 
        /// <returns>bool?</returns>
        public bool? UpdateUser (string token, string username = null, string password = null, string email = null, string displayName = null)
        {
             ApiResponse<bool?> response = UpdateUserWithHttpInfo(token, username, password, email, displayName);
             return response.Data;
        }

        /// <summary>
        ///  Update account and profile information.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <param name="username">Account&#39;s username</param> 
        /// <param name="password">Account&#39;s password</param> 
        /// <param name="email">Account&#39;s email</param> 
        /// <param name="displayName">Account&#39;s display name</param> 
        /// <returns>ApiResponse of bool?</returns>
        public ApiResponse< bool? > UpdateUserWithHttpInfo (string token, string username = null, string password = null, string email = null, string displayName = null)
        {
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->UpdateUser");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            if (password != null) queryParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // query parameter
            if (email != null) queryParams.Add("email", Configuration.ApiClient.ParameterToString(email)); // query parameter
            if (displayName != null) queryParams.Add("displayName", Configuration.ApiClient.ParameterToString(displayName)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.PUT, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling UpdateUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling UpdateUser: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
    
        /// <summary>
        ///  Update account and profile information.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <param name="username">Account&#39;s username</param>
        /// <param name="password">Account&#39;s password</param>
        /// <param name="email">Account&#39;s email</param>
        /// <param name="displayName">Account&#39;s display name</param>
        /// <returns>Task of bool?</returns>
        public async System.Threading.Tasks.Task<bool?> UpdateUserAsync (string token, string username = null, string password = null, string email = null, string displayName = null)
        {
             ApiResponse<bool?> response = await UpdateUserAsyncWithHttpInfo(token, username, password, email, displayName);
             return response.Data;

        }

        /// <summary>
        ///  Update account and profile information.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <param name="username">Account&#39;s username</param>
        /// <param name="password">Account&#39;s password</param>
        /// <param name="email">Account&#39;s email</param>
        /// <param name="displayName">Account&#39;s display name</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<bool?>> UpdateUserAsyncWithHttpInfo (string token, string username = null, string password = null, string email = null, string displayName = null)
        {
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling UpdateUser");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            if (password != null) queryParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // query parameter
            if (email != null) queryParams.Add("email", Configuration.ApiClient.ParameterToString(email)); // query parameter
            if (displayName != null) queryParams.Add("displayName", Configuration.ApiClient.ParameterToString(displayName)); // query parameter
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.PUT, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling UpdateUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling UpdateUser: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
        
        /// <summary>
        ///  Register new account.
        /// </summary>
        /// <param name="username">New account&#39;s username</param> 
        /// <param name="password">New account&#39;s password</param> 
        /// <param name="email">New account&#39;s email</param> 
        /// <returns>string</returns>
        public string RegisterUser (string username, string password, string email)
        {
             ApiResponse<string> response = RegisterUserWithHttpInfo(username, password, email);
             return response.Data;
        }

        /// <summary>
        ///  Register new account.
        /// </summary>
        /// <param name="username">New account&#39;s username</param> 
        /// <param name="password">New account&#39;s password</param> 
        /// <param name="email">New account&#39;s email</param> 
        /// <returns>ApiResponse of string</returns>
        public ApiResponse< string > RegisterUserWithHttpInfo (string username, string password, string email)
        {
            
            // verify the required parameter 'username' is set
            if (username == null)
                throw new ApiException(400, "Missing required parameter 'username' when calling DefaultApi->RegisterUser");
            
            // verify the required parameter 'password' is set
            if (password == null)
                throw new ApiException(400, "Missing required parameter 'password' when calling DefaultApi->RegisterUser");
            
            // verify the required parameter 'email' is set
            if (email == null)
                throw new ApiException(400, "Missing required parameter 'email' when calling DefaultApi->RegisterUser");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            if (password != null) queryParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // query parameter
            if (email != null) queryParams.Add("email", Configuration.ApiClient.ParameterToString(email)); // query parameter
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling RegisterUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling RegisterUser: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<string>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(response, typeof(string)));
            
        }
    
        /// <summary>
        ///  Register new account.
        /// </summary>
        /// <param name="username">New account&#39;s username</param>
        /// <param name="password">New account&#39;s password</param>
        /// <param name="email">New account&#39;s email</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> RegisterUserAsync (string username, string password, string email)
        {
             ApiResponse<string> response = await RegisterUserAsyncWithHttpInfo(username, password, email);
             return response.Data;

        }

        /// <summary>
        ///  Register new account.
        /// </summary>
        /// <param name="username">New account&#39;s username</param>
        /// <param name="password">New account&#39;s password</param>
        /// <param name="email">New account&#39;s email</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<string>> RegisterUserAsyncWithHttpInfo (string username, string password, string email)
        {
            // verify the required parameter 'username' is set
            if (username == null) throw new ApiException(400, "Missing required parameter 'username' when calling RegisterUser");
            // verify the required parameter 'password' is set
            if (password == null) throw new ApiException(400, "Missing required parameter 'password' when calling RegisterUser");
            // verify the required parameter 'email' is set
            if (email == null) throw new ApiException(400, "Missing required parameter 'email' when calling RegisterUser");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            if (password != null) queryParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // query parameter
            if (email != null) queryParams.Add("email", Configuration.ApiClient.ParameterToString(email)); // query parameter
            
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling RegisterUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling RegisterUser: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<string>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(response, typeof(string)));
            
        }
        
        /// <summary>
        ///  Delete account.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <returns>bool?</returns>
        public bool? DeleteUser (string token)
        {
             ApiResponse<bool?> response = DeleteUserWithHttpInfo(token);
             return response.Data;
        }

        /// <summary>
        ///  Delete account.
        /// </summary>
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of bool?</returns>
        public ApiResponse< bool? > DeleteUserWithHttpInfo (string token)
        {
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->DeleteUser");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling DeleteUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling DeleteUser: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
    
        /// <summary>
        ///  Delete account.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of bool?</returns>
        public async System.Threading.Tasks.Task<bool?> DeleteUserAsync (string token)
        {
             ApiResponse<bool?> response = await DeleteUserAsyncWithHttpInfo(token);
             return response.Data;

        }

        /// <summary>
        ///  Delete account.
        /// </summary>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<bool?>> DeleteUserAsyncWithHttpInfo (string token)
        {
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling DeleteUser");
            
    
            var path_ = "/user";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.DELETE, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling DeleteUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling DeleteUser: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
        
        /// <summary>
        ///  Get a login token.
        /// </summary>
        /// <param name="username">User&#39;s username</param> 
        /// <param name="password">User&#39;s password</param> 
        /// <returns>string</returns>
        public string LoginUser (string username, string password)
        {
             ApiResponse<string> response = LoginUserWithHttpInfo(username, password);
             return response.Data;
        }

        /// <summary>
        ///  Get a login token.
        /// </summary>
        /// <param name="username">User&#39;s username</param> 
        /// <param name="password">User&#39;s password</param> 
        /// <returns>ApiResponse of string</returns>
        public ApiResponse< string > LoginUserWithHttpInfo (string username, string password)
        {
            
            // verify the required parameter 'username' is set
            if (username == null)
                throw new ApiException(400, "Missing required parameter 'username' when calling DefaultApi->LoginUser");
            
            // verify the required parameter 'password' is set
            if (password == null)
                throw new ApiException(400, "Missing required parameter 'password' when calling DefaultApi->LoginUser");
            
    
            var path_ = "/user/login";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            if (password != null) queryParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // query parameter
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling LoginUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling LoginUser: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<string>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(response, typeof(string)));
            
        }
    
        /// <summary>
        ///  Get a login token.
        /// </summary>
        /// <param name="username">User&#39;s username</param>
        /// <param name="password">User&#39;s password</param>
        /// <returns>Task of string</returns>
        public async System.Threading.Tasks.Task<string> LoginUserAsync (string username, string password)
        {
             ApiResponse<string> response = await LoginUserAsyncWithHttpInfo(username, password);
             return response.Data;

        }

        /// <summary>
        ///  Get a login token.
        /// </summary>
        /// <param name="username">User&#39;s username</param>
        /// <param name="password">User&#39;s password</param>
        /// <returns>Task of ApiResponse (string)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<string>> LoginUserAsyncWithHttpInfo (string username, string password)
        {
            // verify the required parameter 'username' is set
            if (username == null) throw new ApiException(400, "Missing required parameter 'username' when calling LoginUser");
            // verify the required parameter 'password' is set
            if (password == null) throw new ApiException(400, "Missing required parameter 'password' when calling LoginUser");
            
    
            var path_ = "/user/login";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            
            if (username != null) queryParams.Add("username", Configuration.ApiClient.ParameterToString(username)); // query parameter
            if (password != null) queryParams.Add("password", Configuration.ApiClient.ParameterToString(password)); // query parameter
            
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.POST, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling LoginUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling LoginUser: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<string>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (string) Configuration.ApiClient.Deserialize(response, typeof(string)));
            
        }
        
        /// <summary>
        ///  Verify a user&#39;s account.
        /// </summary>
        /// <param name="verificationHash">Verification hash of account</param> 
        /// <returns>bool?</returns>
        public bool? VerifyUser (string verificationHash)
        {
             ApiResponse<bool?> response = VerifyUserWithHttpInfo(verificationHash);
             return response.Data;
        }

        /// <summary>
        ///  Verify a user&#39;s account.
        /// </summary>
        /// <param name="verificationHash">Verification hash of account</param> 
        /// <returns>ApiResponse of bool?</returns>
        public ApiResponse< bool? > VerifyUserWithHttpInfo (string verificationHash)
        {
            
            // verify the required parameter 'verificationHash' is set
            if (verificationHash == null)
                throw new ApiException(400, "Missing required parameter 'verificationHash' when calling DefaultApi->VerifyUser");
            
    
            var path_ = "/user/verify/{verificationHash}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (verificationHash != null) pathParams.Add("verificationHash", Configuration.ApiClient.ParameterToString(verificationHash)); // path parameter
            
            
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling VerifyUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling VerifyUser: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
    
        /// <summary>
        ///  Verify a user&#39;s account.
        /// </summary>
        /// <param name="verificationHash">Verification hash of account</param>
        /// <returns>Task of bool?</returns>
        public async System.Threading.Tasks.Task<bool?> VerifyUserAsync (string verificationHash)
        {
             ApiResponse<bool?> response = await VerifyUserAsyncWithHttpInfo(verificationHash);
             return response.Data;

        }

        /// <summary>
        ///  Verify a user&#39;s account.
        /// </summary>
        /// <param name="verificationHash">Verification hash of account</param>
        /// <returns>Task of ApiResponse (bool?)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<bool?>> VerifyUserAsyncWithHttpInfo (string verificationHash)
        {
            // verify the required parameter 'verificationHash' is set
            if (verificationHash == null) throw new ApiException(400, "Missing required parameter 'verificationHash' when calling VerifyUser");
            
    
            var path_ = "/user/verify/{verificationHash}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (verificationHash != null) pathParams.Add("verificationHash", Configuration.ApiClient.ParameterToString(verificationHash)); // path parameter
            
            
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling VerifyUser: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling VerifyUser: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<bool?>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (bool?) Configuration.ApiClient.Deserialize(response, typeof(bool?)));
            
        }
        
        /// <summary>
        ///  Get profile of target user.
        /// </summary>
        /// <param name="targetUserId">ID of target user</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>List&lt;UserProfile&gt;</returns>
        public List<UserProfile> GetProfileById (int? targetUserId, string token)
        {
             ApiResponse<List<UserProfile>> response = GetProfileByIdWithHttpInfo(targetUserId, token);
             return response.Data;
        }

        /// <summary>
        ///  Get profile of target user.
        /// </summary>
        /// <param name="targetUserId">ID of target user</param> 
        /// <param name="token">Authentication token</param> 
        /// <returns>ApiResponse of List&lt;UserProfile&gt;</returns>
        public ApiResponse< List<UserProfile> > GetProfileByIdWithHttpInfo (int? targetUserId, string token)
        {
            
            // verify the required parameter 'targetUserId' is set
            if (targetUserId == null)
                throw new ApiException(400, "Missing required parameter 'targetUserId' when calling DefaultApi->GetProfileById");
            
            // verify the required parameter 'token' is set
            if (token == null)
                throw new ApiException(400, "Missing required parameter 'token' when calling DefaultApi->GetProfileById");
            
    
            var path_ = "/user/{targetUserId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (targetUserId != null) pathParams.Add("targetUserId", Configuration.ApiClient.ParameterToString(targetUserId)); // path parameter
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            
    
            // make the HTTP request
            IRestResponse response = (IRestResponse) Configuration.ApiClient.CallApi(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams,
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
    
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetProfileById: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetProfileById: " + response.ErrorMessage, response.ErrorMessage);
    
            return new ApiResponse<List<UserProfile>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<UserProfile>) Configuration.ApiClient.Deserialize(response, typeof(List<UserProfile>)));
            
        }
    
        /// <summary>
        ///  Get profile of target user.
        /// </summary>
        /// <param name="targetUserId">ID of target user</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of List&lt;UserProfile&gt;</returns>
        public async System.Threading.Tasks.Task<List<UserProfile>> GetProfileByIdAsync (int? targetUserId, string token)
        {
             ApiResponse<List<UserProfile>> response = await GetProfileByIdAsyncWithHttpInfo(targetUserId, token);
             return response.Data;

        }

        /// <summary>
        ///  Get profile of target user.
        /// </summary>
        /// <param name="targetUserId">ID of target user</param>
        /// <param name="token">Authentication token</param>
        /// <returns>Task of ApiResponse (List&lt;UserProfile&gt;)</returns>
        public async System.Threading.Tasks.Task<ApiResponse<List<UserProfile>>> GetProfileByIdAsyncWithHttpInfo (int? targetUserId, string token)
        {
            // verify the required parameter 'targetUserId' is set
            if (targetUserId == null) throw new ApiException(400, "Missing required parameter 'targetUserId' when calling GetProfileById");
            // verify the required parameter 'token' is set
            if (token == null) throw new ApiException(400, "Missing required parameter 'token' when calling GetProfileById");
            
    
            var path_ = "/user/{targetUserId}";
    
            var pathParams = new Dictionary<String, String>();
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>(Configuration.DefaultHeader);
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            Object postBody = null;

            // to determine the Content-Type header
            String[] httpContentTypes = new String[] {
                "application/json"
            };
            String httpContentType = Configuration.ApiClient.SelectHeaderContentType(httpContentTypes);

            // to determine the Accept header
            String[] httpHeaderAccepts = new String[] {
                "application/json"
            };
            String httpHeaderAccept = Configuration.ApiClient.SelectHeaderAccept(httpHeaderAccepts);
            if (httpHeaderAccept != null)
                headerParams.Add("Accept", httpHeaderAccept);

            // set "format" to json by default
            // e.g. /pet/{petId}.{format} becomes /pet/{petId}.json
            pathParams.Add("format", "json");
            if (targetUserId != null) pathParams.Add("targetUserId", Configuration.ApiClient.ParameterToString(targetUserId)); // path parameter
            
            
            if (token != null) headerParams.Add("Token", Configuration.ApiClient.ParameterToString(token)); // header parameter
            
            
            

            

            // make the HTTP request
            IRestResponse response = (IRestResponse) await Configuration.ApiClient.CallApiAsync(path_, 
                Method.GET, queryParams, postBody, headerParams, formParams, fileParams, 
                pathParams, httpContentType);

            int statusCode = (int) response.StatusCode;
 
            if (statusCode >= 400)
                throw new ApiException (statusCode, "Error calling GetProfileById: " + response.Content, response.Content);
            else if (statusCode == 0)
                throw new ApiException (statusCode, "Error calling GetProfileById: " + response.ErrorMessage, response.ErrorMessage);

            return new ApiResponse<List<UserProfile>>(statusCode,
                response.Headers.ToDictionary(x => x.Name, x => x.Value.ToString()),
                (List<UserProfile>) Configuration.ApiClient.Deserialize(response, typeof(List<UserProfile>)));
            
        }
        
    }
    
}
