package io.swagger.api;

import io.swagger.api.*;
import io.swagger.model.*;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Friend;
import io.swagger.model.Error;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-13T21:12:36.938-05:00")
public abstract class FriendsApiService {
  
      public abstract Response getMyFriends(String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response addFriend(Integer targetId,String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response deleteFriend(Integer targetId,String token,SecurityContext securityContext)
      throws NotFoundException;
  
}
