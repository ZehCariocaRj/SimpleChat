package io.swagger.client.api;

import io.swagger.client.ApiException;
import io.swagger.client.ApiInvoker;
import io.swagger.client.Pair;

import io.swagger.client.model.*;

import java.util.*;

import io.swagger.client.model.Chat;
import io.swagger.client.model.Error;
import io.swagger.client.model.Message;
import io.swagger.client.model.Friend;
import io.swagger.client.model.UserProfile;

import org.apache.http.HttpEntity;
import org.apache.http.entity.mime.MultipartEntityBuilder;

import java.util.Map;
import java.util.HashMap;
import java.io.File;

public class DefaultApi {
  String basePath = "http://localhost/api";
  ApiInvoker apiInvoker = ApiInvoker.getInstance();

  public void addHeader(String key, String value) {
    getInvoker().addDefaultHeader(key, value);
  }

  public ApiInvoker getInvoker() {
    return apiInvoker;
  }

  public void setBasePath(String basePath) {
    this.basePath = basePath;
  }

  public String getBasePath() {
    return basePath;
  }

  
  /**
   * 
   * Get specific chat.
   * @param targetId ID of target group
   * @param token Authentication token
   * @return Chat
   */
  public Chat  getChat (Integer targetId, String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'targetId' is set
    if (targetId == null) {
       throw new ApiException(400, "Missing the required parameter 'targetId' when calling getChat");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling getChat");
    }
    

    // create path and map variables
    String path = "/chat".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "targetId", targetId));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Chat) ApiInvoker.deserialize(response, "", Chat.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Send a chat message.
   * @param targetId ID of target group
   * @param message Message to send
   * @param token Authentication token
   * @return Message
   */
  public Message  sendChatMessage (Integer targetId, String message, String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'targetId' is set
    if (targetId == null) {
       throw new ApiException(400, "Missing the required parameter 'targetId' when calling sendChatMessage");
    }
    
    // verify the required parameter 'message' is set
    if (message == null) {
       throw new ApiException(400, "Missing the required parameter 'message' when calling sendChatMessage");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling sendChatMessage");
    }
    

    // create path and map variables
    String path = "/chat".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "targetId", targetId));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "message", message));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Message) ApiInvoker.deserialize(response, "", Message.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Get all chats.
   * @param token Authentication token
   * @return List<Chat>
   */
  public List<Chat>  getChats (String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling getChats");
    }
    

    // create path and map variables
    String path = "/chat/all".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (List<Chat>) ApiInvoker.deserialize(response, "array", Chat.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Invite user to chat group.
   * @param chatId ID of group chat
   * @param username Username of user to be added to chat group
   * @param token Authentication token
   * @return Boolean
   */
  public Boolean  inviteUserToChat (Integer chatId, String username, String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'chatId' is set
    if (chatId == null) {
       throw new ApiException(400, "Missing the required parameter 'chatId' when calling inviteUserToChat");
    }
    
    // verify the required parameter 'username' is set
    if (username == null) {
       throw new ApiException(400, "Missing the required parameter 'username' when calling inviteUserToChat");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling inviteUserToChat");
    }
    

    // create path and map variables
    String path = "/chat/invite".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "chatId", chatId));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "username", username));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Boolean) ApiInvoker.deserialize(response, "", Boolean.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Update chat info.
   * @param token Authentication token
   * @param chatId Chat group&#39;s ID
   * @param chatTitle Chat group&#39;s new title
   * @return Boolean
   */
  public Boolean  updateChat (String token, Integer chatId, String chatTitle) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling updateChat");
    }
    
    // verify the required parameter 'chatId' is set
    if (chatId == null) {
       throw new ApiException(400, "Missing the required parameter 'chatId' when calling updateChat");
    }
    
    // verify the required parameter 'chatTitle' is set
    if (chatTitle == null) {
       throw new ApiException(400, "Missing the required parameter 'chatTitle' when calling updateChat");
    }
    

    // create path and map variables
    String path = "/chat/manage".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "chatId", chatId));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "chatTitle", chatTitle));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "PUT", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Boolean) ApiInvoker.deserialize(response, "", Boolean.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Create a chat group.
   * @param userIds IDs of users to be added to chat group
   * @param chatTitle Name of chat group to be created
   * @param token Authentication token
   * @return Integer
   */
  public Integer  createChatGroup (List<Integer> userIds, String chatTitle, String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'userIds' is set
    if (userIds == null) {
       throw new ApiException(400, "Missing the required parameter 'userIds' when calling createChatGroup");
    }
    
    // verify the required parameter 'chatTitle' is set
    if (chatTitle == null) {
       throw new ApiException(400, "Missing the required parameter 'chatTitle' when calling createChatGroup");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling createChatGroup");
    }
    

    // create path and map variables
    String path = "/chat/manage".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("csv", "userIds", userIds));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "chatTitle", chatTitle));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Integer) ApiInvoker.deserialize(response, "", Integer.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Get all chat messages from target group chat.
   * @param targetGroupId ID of target group
   * @param token Authentication token
   * @param lastMessageId ID of last message received
   * @return List<Message>
   */
  public List<Message>  getChatMessages (Integer targetGroupId, String token, Integer lastMessageId) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'targetGroupId' is set
    if (targetGroupId == null) {
       throw new ApiException(400, "Missing the required parameter 'targetGroupId' when calling getChatMessages");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling getChatMessages");
    }
    

    // create path and map variables
    String path = "/chat/{targetGroupId}".replaceAll("\\{format\\}","json").replaceAll("\\{" + "targetGroupId" + "\\}", apiInvoker.escapeString(targetGroupId.toString()));

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "lastMessageId", lastMessageId));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (List<Message>) ApiInvoker.deserialize(response, "array", Message.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Get a list of all friends for the currently logged in user.
   * @param token Authentication token
   * @return List<Friend>
   */
  public List<Friend>  getMyFriends (String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling getMyFriends");
    }
    

    // create path and map variables
    String path = "/friends".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (List<Friend>) ApiInvoker.deserialize(response, "array", Friend.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Add friend to friend list of currently logged in user.
   * @param username Username of person to friend
   * @param token Authentication token
   * @return Friend
   */
  public Friend  addFriend (String username, String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'username' is set
    if (username == null) {
       throw new ApiException(400, "Missing the required parameter 'username' when calling addFriend");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling addFriend");
    }
    

    // create path and map variables
    String path = "/friends".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "username", username));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Friend) ApiInvoker.deserialize(response, "", Friend.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Delete friend from friend list.
   * @param targetId User ID of friend to delete
   * @param token Authentication token
   * @return Boolean
   */
  public Boolean  deleteFriend (Integer targetId, String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'targetId' is set
    if (targetId == null) {
       throw new ApiException(400, "Missing the required parameter 'targetId' when calling deleteFriend");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling deleteFriend");
    }
    

    // create path and map variables
    String path = "/friends".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "targetId", targetId));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Boolean) ApiInvoker.deserialize(response, "", Boolean.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Get profile of current logged in user.
   * @param token Authentication token
   * @return UserProfile
   */
  public UserProfile  getMyProfile (String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling getMyProfile");
    }
    

    // create path and map variables
    String path = "/user".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (UserProfile) ApiInvoker.deserialize(response, "", UserProfile.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Update account and profile information.
   * @param token Authentication token
   * @param username Account&#39;s username
   * @param password Account&#39;s password
   * @param email Account&#39;s email
   * @param displayName Account&#39;s display name
   * @return Boolean
   */
  public Boolean  updateUser (String token, String username, String password, String email, String displayName) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling updateUser");
    }
    

    // create path and map variables
    String path = "/user".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "username", username));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "password", password));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "email", email));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "displayName", displayName));
    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "PUT", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Boolean) ApiInvoker.deserialize(response, "", Boolean.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Register new account.
   * @param username New account&#39;s username
   * @param password New account&#39;s password
   * @param email New account&#39;s email
   * @param displayName New account&#39;s display name
   * @return String
   */
  public String  registerUser (String username, String password, String email, String displayName) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'username' is set
    if (username == null) {
       throw new ApiException(400, "Missing the required parameter 'username' when calling registerUser");
    }
    
    // verify the required parameter 'password' is set
    if (password == null) {
       throw new ApiException(400, "Missing the required parameter 'password' when calling registerUser");
    }
    

    // create path and map variables
    String path = "/user".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "username", username));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "password", password));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "email", email));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "displayName", displayName));
    

    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (String) ApiInvoker.deserialize(response, "", String.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Delete account.
   * @param token Authentication token
   * @return Boolean
   */
  public Boolean  deleteUser (String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling deleteUser");
    }
    

    // create path and map variables
    String path = "/user".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "DELETE", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Boolean) ApiInvoker.deserialize(response, "", Boolean.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Get a login token.
   * @param username User&#39;s username
   * @param password User&#39;s password
   * @return String
   */
  public String  loginUser (String username, String password) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'username' is set
    if (username == null) {
       throw new ApiException(400, "Missing the required parameter 'username' when calling loginUser");
    }
    
    // verify the required parameter 'password' is set
    if (password == null) {
       throw new ApiException(400, "Missing the required parameter 'password' when calling loginUser");
    }
    

    // create path and map variables
    String path = "/user/login".replaceAll("\\{format\\}","json");

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "username", username));
    
    queryParams.addAll(ApiInvoker.parameterToPairs("", "password", password));
    

    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "POST", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (String) ApiInvoker.deserialize(response, "", String.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Verify a user&#39;s token.
   * @param token Verification token of account is still active
   * @return Boolean
   */
  public Boolean  verifyUser (String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling verifyUser");
    }
    

    // create path and map variables
    String path = "/user/verify/{token}".replaceAll("\\{format\\}","json").replaceAll("\\{" + "token" + "\\}", apiInvoker.escapeString(token.toString()));

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    

    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (Boolean) ApiInvoker.deserialize(response, "", Boolean.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
  /**
   * 
   * Get profile of target user.
   * @param targetUserId ID of target user
   * @param token Authentication token
   * @return UserProfile
   */
  public UserProfile  getProfileById (Integer targetUserId, String token) throws ApiException {
    Object postBody = null;
    
    // verify the required parameter 'targetUserId' is set
    if (targetUserId == null) {
       throw new ApiException(400, "Missing the required parameter 'targetUserId' when calling getProfileById");
    }
    
    // verify the required parameter 'token' is set
    if (token == null) {
       throw new ApiException(400, "Missing the required parameter 'token' when calling getProfileById");
    }
    

    // create path and map variables
    String path = "/user/{targetUserId}".replaceAll("\\{format\\}","json").replaceAll("\\{" + "targetUserId" + "\\}", apiInvoker.escapeString(targetUserId.toString()));

    // query params
    List<Pair> queryParams = new ArrayList<Pair>();
    // header params
    Map<String, String> headerParams = new HashMap<String, String>();
    // form params
    Map<String, String> formParams = new HashMap<String, String>();

    

    
    headerParams.put("Token", ApiInvoker.parameterToString(token));
    

    String[] contentTypes = {
      "application/json"
    };
    String contentType = contentTypes.length > 0 ? contentTypes[0] : "application/json";

    if (contentType.startsWith("multipart/form-data")) {
      // file uploading
      MultipartEntityBuilder builder = MultipartEntityBuilder.create();
      

      HttpEntity httpEntity = builder.build();
      postBody = httpEntity;
    } else {
      // normal form params
      
    }

    try {
      String response = apiInvoker.invokeAPI(basePath, path, "GET", queryParams, postBody, headerParams, formParams, contentType);
      if(response != null){
        return (UserProfile) ApiInvoker.deserialize(response, "", UserProfile.class);
      }
      else {
        return null;
      }
    } catch (ApiException ex) {
      throw ex;
    }
  }
  
}
