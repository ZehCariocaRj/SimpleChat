package io.swagger.api;

import io.swagger.api.*;
import io.swagger.model.*;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Chat;
import io.swagger.model.Error;
import io.swagger.model.Message;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-03-02T06:39:20.385-05:00")
public abstract class ChatApiService {
  
      public abstract Response getChat(Integer targetId,String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response sendChatMessage(Integer targetId,String message,String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response getChats(String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response inviteUserToChat(Integer chatId,String username,String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response updateChat(String token,Integer chatId,String chatTitle,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response createChatGroup(List<Integer> userIds,String chatTitle,String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response getChatMessages(Integer targetGroupId,String token,Integer lastMessageId,SecurityContext securityContext)
      throws NotFoundException;
  
}
