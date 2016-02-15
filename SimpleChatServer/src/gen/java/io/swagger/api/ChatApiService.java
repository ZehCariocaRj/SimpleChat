package io.swagger.api;

import io.swagger.api.*;
import io.swagger.model.*;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Message;
import io.swagger.model.Error;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-14T22:40:24.503-05:00")
public abstract class ChatApiService {
  
      public abstract Response sendChatMessage(Integer targetId,String message,String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response createChatGroup(List<Integer> userIds,String chatTitle,String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response getChatMessages(Integer targetGroupId,Integer lastMessageId,String token,SecurityContext securityContext)
      throws NotFoundException;
  
}
