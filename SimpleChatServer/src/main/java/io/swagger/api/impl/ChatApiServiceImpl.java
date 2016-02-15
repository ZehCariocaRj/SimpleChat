package io.swagger.api.impl;

import com.andromeda.Database.Database;
import io.swagger.api.*;
import io.swagger.model.*;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Chat;
import io.swagger.model.Error;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-13T11:08:33.351-05:00")
public class ChatApiServiceImpl extends ChatApiService {
    
    @Override
    public Response sendChatMessage(Integer targetId, String message, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        Message sentMessage = Database.sendChatMessage(targetId, currentUser.getUserId(), message);

        if(sentMessage == null) {
            Error error = new Error();
            error.setCode(601);
            error.setMessage("Could not send message to group.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(sentMessage).build();
    }

    @Override
    public Response createChatGroup(List<Integer> userIds, String chatTitle, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        userIds.add(currentUser.getUserId()); // Add self to group if needed

        int chatId = Database.createChatGroup(chatTitle, userIds);

        if(chatId == -1) {
            Error error = new Error();
            error.setCode(600);
            error.setMessage("Could not create chat group.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok().entity(new ApiResponseMessage(ApiResponseMessage.OK, "magic!")).build();
    }

    @Override
    public Response getChatMessages(Integer targetGroupId, Integer lastMessageId, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        List<Message> messages = null;
        if(lastMessageId == null) {
            messages = Database.getChatMessages(targetGroupId);
        } else {
            messages = Database.getChatMessagesSinceLastId(targetGroupId, lastMessageId);
        }

        if(messages == null) {
            Error error = new Error();
            error.setCode(603);
            error.setMessage("Could not get messages.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(messages).build();
    }
}
