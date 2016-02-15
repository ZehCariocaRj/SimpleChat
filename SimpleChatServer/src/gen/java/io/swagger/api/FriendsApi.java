package io.swagger.api;

import io.swagger.model.*;
import io.swagger.api.FriendsApiService;
import io.swagger.api.factories.FriendsApiServiceFactory;

import io.swagger.annotations.ApiParam;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Friend;
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

@Path("/friends")
@Consumes({ "application/json" })
@Produces({ "application/json" })
@io.swagger.annotations.Api(description = "the friends API")
@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-15T11:52:14.312-05:00")
public class FriendsApi  {
   private final FriendsApiService delegate = FriendsApiServiceFactory.getFriendsApi();

    @GET
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Get a list of all friends for the currently logged in user.", response = Friend.class, responseContainer = "List", tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "friend response", response = Friend.class, responseContainer = "List"),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Friend.class, responseContainer = "List"),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Friend.class, responseContainer = "List") })

    public Response getMyFriends(
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.getMyFriends(token,securityContext);
    }
    @POST
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Add friend to friend list of currently logged in user.", response = Friend.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "friend response", response = Friend.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Friend.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Friend.class) })

    public Response addFriend(@ApiParam(value = "Username of person to friend",required=true) @QueryParam("username") String username
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.addFriend(username,token,securityContext);
    }
    @DELETE
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Delete friend from friend list.", response = Boolean.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "friend response", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Boolean.class) })

    public Response deleteFriend(@ApiParam(value = "User ID of friend to delete",required=true) @QueryParam("targetId") Integer targetId
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.deleteFriend(targetId,token,securityContext);
    }
}
