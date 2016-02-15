package io.swagger.api.impl;

import com.andromeda.Database.Database;
import com.andromeda.Database.RelationshipStatus;
import io.swagger.api.*;
import io.swagger.model.*;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Friend;
import io.swagger.model.Error;

import java.util.ArrayList;
import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-13T07:37:36.259-05:00")
public class FriendsApiServiceImpl extends FriendsApiService {
    
    @Override
    public Response getMyFriends(String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        ArrayList<Friend> friends = Database.getMyFriends(currentUser.getUserId());
        return Response.ok(friends).build();
    }
    
    @Override
    public Response addFriend(String username, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        if(username.equals(currentUser.getUsername())) {
            Error error = new Error();
            error.setCode(403);
            error.setMessage("Can't add self as friend.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        int status = Database.addFriend(currentUser.getUserId(), username, RelationshipStatus.Friend);
        if(status == 0) {
            Error error = new Error();
            error.setCode(400);
            error.setMessage("Could not add friend.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }
        else if(status == -1) {
            Error error = new Error();
            error.setCode(402);
            error.setMessage("Friend already exists.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }
        else if(status == -2) {
            Error error = new Error();
            error.setCode(403);
            error.setMessage("User does not exist.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(status).build();
    }
    
    @Override
    public Response deleteFriend(Integer targetId, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        Boolean status = Database.deleteFriend(currentUser.getUserId(), targetId);
        if(status == false) {
            Error error = new Error();
            error.setCode(401);
            error.setMessage("Could not delete friend.");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(status).build();
    }
    
}
