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
            error.setMessage("Invalid token");
            return Response.status(403).entity(error).build();
        }

        ArrayList<Friend> friends = Database.getMyFriends(currentUser.getUserId());
        return Response.ok(friends).build();
    }
    
    @Override
    public Response addFriend(Integer targetId, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token");
            return Response.status(403).entity(error).build();
        }

        Boolean status = Database.addFriend(currentUser.getUserId(), targetId, RelationshipStatus.Friend);
        return Response.ok(status).build();
    }
    
    @Override
    public Response deleteFriend(Integer targetId, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token");
            return Response.status(403).entity(error).build();
        }

        Boolean status = Database.deleteFriend(currentUser.getUserId(), targetId);
        return Response.ok(status).build();
    }
    
}
