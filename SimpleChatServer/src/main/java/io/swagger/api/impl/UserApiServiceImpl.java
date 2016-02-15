package io.swagger.api.impl;

import com.andromeda.Database.Database;
import io.swagger.api.*;
import io.swagger.model.*;

import com.sun.jersey.multipart.FormDataParam;

import io.swagger.model.Error;
import io.swagger.model.UserProfile;

import java.util.List;
import io.swagger.api.NotFoundException;

import java.io.InputStream;

import com.sun.jersey.core.header.FormDataContentDisposition;
import com.sun.jersey.multipart.FormDataParam;

import javax.ws.rs.core.Response;
import javax.ws.rs.core.SecurityContext;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-13T07:37:36.259-05:00")
public class UserApiServiceImpl extends UserApiService {
    
    @Override
    public Response registerUser(String username, String password, String email, SecurityContext securityContext)
    throws NotFoundException {
        Boolean exists = Database.checkUsernameExists(username);

        if(exists) {
            Error error = new Error();
            error.setCode(100);
            error.setMessage("Username already exists");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        Boolean success = Database.registerUser(username, password, email);
        return Response.ok(success).build();
    }

    @Override
    public Response deleteUser(String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        Boolean success = Database.deleteUser(21);

        if(!success) {
            Error error = new Error();
            error.setCode(203);
            error.setMessage("Could not delete account");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(success).build();
    }

    @Override
    public Response loginUser(String username, String password, SecurityContext securityContext)
    throws NotFoundException {
        String token = Database.loginUser(username, password);
        if(token == null) {
            Error error = new Error();
            error.setCode(200);
            error.setMessage("Invalid username/password combination");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(token).build();
    }

    @Override
    public Response verifyUser(String verificationHash, SecurityContext securityContext)
    throws NotFoundException {
        Boolean verified = Database.verifyUser(verificationHash);
        if(!verified) {
            Error error = new Error();
            error.setCode(201);
            error.setMessage("Could not verify account");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(verified).build();
    }

    @Override
    public Response getProfileById(Integer targetUserId, String token, SecurityContext securityContext)
    throws NotFoundException {
        UserProfile currentUser = Database.verifyToken(token);
        if(currentUser == null) {
            Error error = new Error();
            error.setCode(800);
            error.setMessage("Invalid token");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        UserProfile profile = Database.getProfileById(targetUserId);
        if(profile == null) {
            Error error = new Error();
            error.setCode(202);
            error.setMessage("Invalid account");
            return Response.status(Response.Status.NOT_FOUND).entity(error).build();
        }

        return Response.ok(profile).build();
    }
}
