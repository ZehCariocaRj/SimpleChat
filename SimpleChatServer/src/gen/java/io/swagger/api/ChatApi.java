package io.swagger.api;

import io.swagger.model.*;
import io.swagger.api.ChatApiService;
import io.swagger.api.factories.ChatApiServiceFactory;

import io.swagger.annotations.ApiParam;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Chat;
import io.swagger.model.Error;
import io.swagger.model.Message;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Context;
import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;
import javax.ws.rs.*;

@Path("/chat")
@Consumes({ "application/json" })
@Produces({ "application/json" })
@io.swagger.annotations.Api(description = "the chat API")
@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-15T18:16:57.803-05:00")
public class ChatApi  {
   private final ChatApiService delegate = ChatApiServiceFactory.getChatApi();

    @GET
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Get specific chat.", response = Chat.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "chat list response", response = Chat.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Chat.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Chat.class) })

    public Response getChat(@ApiParam(value = "ID of target group",required=true) @QueryParam("targetId") Integer targetId
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.getChat(targetId,token,securityContext);
    }
    @POST
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Send a chat message.", response = Message.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "chat response", response = Message.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Message.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Message.class) })

    public Response sendChatMessage(@ApiParam(value = "ID of target group",required=true) @QueryParam("targetId") Integer targetId
,@ApiParam(value = "Message to send",required=true) @QueryParam("message") String message
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.sendChatMessage(targetId,message,token,securityContext);
    }
    @GET
    @Path("/all")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Get all chats.", response = Chat.class, responseContainer = "List", tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "chat list response", response = Chat.class, responseContainer = "List"),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Chat.class, responseContainer = "List"),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Chat.class, responseContainer = "List") })

    public Response getChats(
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.getChats(token,securityContext);
    }
    @POST
    @Path("/invite")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Invite user to chat group.", response = Boolean.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "invite to chat group response", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Boolean.class) })

    public Response inviteUserToChat(@ApiParam(value = "ID of group chat",required=true) @QueryParam("chatId") Integer chatId
,@ApiParam(value = "Username of user to be added to chat group",required=true) @QueryParam("username") String username
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.inviteUserToChat(chatId,username,token,securityContext);
    }
    @PUT
    @Path("/manage")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Update chat info.", response = Boolean.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "chat update response", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Boolean.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Boolean.class) })

    public Response updateChat(
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@ApiParam(value = "Chat group's ID",required=true) @QueryParam("chatId") Integer chatId
,@ApiParam(value = "Chat group's new title",required=true) @QueryParam("chatTitle") String chatTitle
,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.updateChat(token,chatId,chatTitle,securityContext);
    }
    @POST
    @Path("/manage")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Create a chat group.", response = Integer.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "create chat group response", response = Integer.class),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Integer.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Integer.class) })

    public Response createChatGroup(@ApiParam(value = "IDs of users to be added to chat group",required=true) @QueryParam("userIds") List<Integer> userIds
,@ApiParam(value = "Name of chat group to be created",required=true) @QueryParam("chatTitle") String chatTitle
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.createChatGroup(userIds,chatTitle,token,securityContext);
    }
    @GET
    @Path("/{targetGroupId}")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Get all chat messages from target group chat.", response = Message.class, responseContainer = "List", tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "chat response", response = Message.class, responseContainer = "List"),
        
        @io.swagger.annotations.ApiResponse(code = 304, message = "Invalid token", response = Message.class, responseContainer = "List"),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Message.class, responseContainer = "List") })

    public Response getChatMessages(
@ApiParam(value = "ID of target group",required=true) @PathParam("targetGroupId") Integer targetGroupId,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@ApiParam(value = "ID of last message received") @QueryParam("lastMessageId") Integer lastMessageId
,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.getChatMessages(targetGroupId,token,lastMessageId,securityContext);
    }
}
