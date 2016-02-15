package io.swagger.api;

import io.swagger.api.*;
import io.swagger.model.*;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.UserProfile;
import io.swagger.model.Error;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-15T11:52:14.312-05:00")
public abstract class UserApiService {
  
      public abstract Response getMyProfile(String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response updateUser(String token,String username,String password,String email,String displayName,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response registerUser(String username,String password,String email,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response deleteUser(String token,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response loginUser(String username,String password,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response verifyUser(String verificationHash,SecurityContext securityContext)
      throws NotFoundException;
  
      public abstract Response getProfileById(Integer targetUserId,String token,SecurityContext securityContext)
      throws NotFoundException;
  
}
