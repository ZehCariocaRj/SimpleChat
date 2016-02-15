package io.swagger.api;

import io.swagger.model.*;
import io.swagger.api.ChatApiService;
import io.swagger.api.factories.ChatApiServiceFactory;

import io.swagger.annotations.ApiParam;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Message;
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

@Path("/chat")
@Consumes({ "application/json" })
@Produces({ "application/json" })
@io.swagger.annotations.Api(description = "the chat API")
@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-14T15:47:18.699-05:00")
public class ChatApi  {
   private final ChatApiService delegate = ChatApiServiceFactory.getChatApi();

    @POST
    
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Send a chat message.", response = Message.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "chat response", response = Message.class),
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Message.class) })

    public Response sendChatMessage(@ApiParam(value = "ID of target group",required=true) @QueryParam("targetId") Integer targetId
,@ApiParam(value = "Message to send",required=true) @QueryParam("message") String message
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.sendChatMessage(targetId,message,token,securityContext);
    }
    @POST
    @Path("/manage")
    @Consumes({ "application/json" })
    @Produces({ "application/json" })
    @io.swagger.annotations.ApiOperation(value = "", notes = "Create a chat group.", response = Integer.class, tags={  })
    @io.swagger.annotations.ApiResponses(value = { 
        @io.swagger.annotations.ApiResponse(code = 200, message = "create chat group response", response = Integer.class),
        
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
        
        @io.swagger.annotations.ApiResponse(code = 200, message = "unexpected error", response = Message.class, responseContainer = "List") })

    public Response getChatMessages(
@ApiParam(value = "ID of target group",required=true) @PathParam("targetGroupId") Integer targetGroupId,@ApiParam(value = "ID of last message received",required=true) @QueryParam("lastMessageId") Integer lastMessageId
,
@ApiParam(value = "Authentication token" ,required=true)@HeaderParam("Token") String token,@Context SecurityContext securityContext)
    throws NotFoundException {
        return delegate.getChatMessages(targetGroupId,lastMessageId,token,securityContext);
    }
}
