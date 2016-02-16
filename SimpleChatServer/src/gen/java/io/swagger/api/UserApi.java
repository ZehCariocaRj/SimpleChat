package io.swagger.api;

import io.swagger.model.*;
import io.swagger.api.UserApiService;
import io.swagger.api.factories.UserApiServiceFactory;

import io.swagger.annotations.ApiParam;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.UserProfile;
import io.swagger.model.Error;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;
import javax.ws.rs.*;

@Path("/user")
@Consumes({ "application/json" })
@Produces({ "application/json" })
@io.swagger.annotations.Api(description = "the user API")
@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-15T18:16:57.803-05:00")
public class UserApi  {
   private final UserApiService delegate = UserApiServiceFactory.getUserApi();

    @GET
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Get profile of current logged in user.", response = UserProfile.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "user profile response", response = UserProfile.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = UserProfile.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = UserProfile.class) })

    public Response getMyProfile(
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.getMyProfile(token,securityContext);
    }
    @PUT
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Update account and profile information.", response = Boolean.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "user delete response", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Boolean.class) })

    public Response updateUser(
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@ApiParam(value = "Account's username") @QueryParam("username") String username
,@ApiParam(value = "Account's password") @QueryParam("password") String password
,@ApiParam(value = "Account's email") @QueryParam("email") String email
,@ApiParam(value = "Account's display name") @QueryParam("displayName") String displayName
,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.updateUser(token,username,password,email,displayName,securityContext);
    }
    @POST
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Register new account.", response = String.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "user creation response", response = String.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = String.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = String.class) })

    public Response registerUser(@ApiParam(value = "New account's display name",required=true) @QueryParam("displayName") String displayName
,@ApiParam(value = "New account's username",required=true) @QueryParam("username") String username
,@ApiParam(value = "New account's password",required=true) @QueryParam("password") String password
,@ApiParam(value = "New account's email",required=true) @QueryParam("email") String email
,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.registerUser(displayName,username,password,email,securityContext);
    }
    @DELETE
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Delete account.", response = Boolean.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "user delete response", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Boolean.class) })

    public Response deleteUser(
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.deleteUser(token,securityContext);
    }
    @POST
    @Path("/login")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Get a login token.", response = String.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "login response", response = String.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = String.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = String.class) })

    public Response loginUser(@ApiParam(value = "User's username",required=true) @QueryParam("username") String username
,@ApiParam(value = "User's password",required=true) @QueryParam("password") String password
,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.loginUser(username,password,securityContext);
    }
    @GET
    @Path("/verify/{verificationHash}")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Verify a user's account.", response = Boolean.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "verification response", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Boolean.class) })

    public Response verifyUser(
@ApiParam(value = "Verification hash of account",required=true) @PathParam("verificationHash") String verificationHash,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.verifyUser(verificationHash,securityContext);
    }
    @GET
    @Path("/{targetUserId}")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Get profile of target user.", response = UserProfile.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "user profile response", response = UserProfile.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = UserProfile.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = UserProfile.class) })

    public Response getProfileById(
@ApiParam(value = "ID of target user",required=true) @PathParam("targetUserId") Integer targetUserId,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.getProfileById(targetUserId,token,securityContext);
    }
}
