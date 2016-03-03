package com.andromeda.simplechat;

import android.content.SharedPreferences;
import android.util.Log;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.List;

import io.swagger.client.ApiException;
import io.swagger.client.model.Chat;
import io.swagger.client.model.Message;
import io.swagger.client.model.UserProfile;

import static android.app.PendingIntent.getActivity;

public class ApiGateway {
    private ApiGateway() {
    }

    private static ApiGateway gateway;

    public static ApiGateway getInstance() {
        if (gateway == null) {
            gateway = new ApiGateway();
        }

        return gateway;
    }

    public static Boolean LoginUserByToken() {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        if(getToken() == null) {
            // No token, no token login
            return false;
        }

        boolean result = false;
        try {
            result = api.verifyUser(getToken());
            Log.d("ApiGateway", "Login by token: " + result);
        } catch (ApiException e) {
            // Clear out the token in case verification failed
            setToken(null);
            return false;
        }

        if(!result) {
            // Clear out the token in case verification failed
            setToken(null);
        }

        return result;
    }

    public static Boolean LoginUser(String username, String password) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            setToken(api.loginUser(URLEncoder.encode(username, "UTF-8"), URLEncoder.encode(password, "UTF-8")));
        } catch (ApiException e) {
            return false;
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        if(getToken() == null) {
            Log.d("ApiGateway", "Login by username/password: " + getToken());
        }

        // Don't store login information unless requested
        if (!getStoreLoginInformation()) {
            username = null;
            password = null;
        }

        setUsername(username);
        setPassword(password);

        return true;
    }

    public static Boolean RegisterUser(String username, String password) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        String result = "";
        try {
            result = api.registerUser(URLEncoder.encode(username, "UTF-8"), URLEncoder.encode(password, "UTF-8"), null, null);
        } catch (ApiException e) {
            return false;
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        return true;
    }

    public static UserProfile getUserProfile() {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            return api.getMyProfile(getToken());
        } catch (ApiException e) {
            e.printStackTrace();
        }

        return null;
    }

    public static Chat getChat(int chatId) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            return api.getChat(chatId, getToken());
        } catch (ApiException e) {
            e.printStackTrace();
        }

        return null;
    }

    public static List<Chat> getChats() {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            return api.getChats(getToken());
        } catch (ApiException e) {
            e.printStackTrace();
        }

        return null;
    }

    public static Message sendMessage(int chatId, String message) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            return api.sendChatMessage(chatId, URLEncoder.encode(message, "UTF-8"), getToken());
        } catch (ApiException e) {
            e.printStackTrace();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        return null;
    }

    public static List<Message> getChatMessages(int chatId, int lastId) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            if(lastId == -1)
                return api.getChatMessages(chatId, getToken(), null);
            else
                return api.getChatMessages(chatId, getToken(), lastId);
        } catch (ApiException e) {
            e.printStackTrace();
        }

        return null;
    }

    public static UserProfile getProfileById(int userId) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            return api.getProfileById(userId, getToken());
        } catch (ApiException e) {
            e.printStackTrace();
        }

        return null;
    }

    public static int inviteUserToChat(int chatId, String username) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        int res = 0;
        try {
            api.inviteUserToChat(chatId, URLEncoder.encode(username, "UTF-8"), getToken());
            res = 1;
        } catch (ApiException e) {
            e.printStackTrace();

            try {
                JSONObject json = new JSONObject(e.getMessage());
                res = json.getInt("code");
            } catch (JSONException e1) {
                e1.printStackTrace();
            }
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        return res;
    }

    public static Boolean updateChat(int chatId, String chatTitle) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            return api.updateChat(getToken(), chatId, URLEncoder.encode(chatTitle, "UTF-8"));
        } catch (ApiException e) {
            e.printStackTrace();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        return false;
    }

    public static Boolean updateUser(String displayName, String password) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            if(password != null)
                password = URLEncoder.encode(password, "UTF-8");

            return api.updateUser(getToken(), null, password, null, URLEncoder.encode(displayName, "UTF-8"));
        } catch (ApiException e) {
            e.printStackTrace();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        }

        return false;
    }

    public static int createChatGroup(String chatTitle) {
        io.swagger.client.api.DefaultApi api = new io.swagger.client.api.DefaultApi();
        api.setBasePath("http://10.0.0.2:8080/api"); // Local address

        try {
            ArrayList<Integer> userIds = new ArrayList<Integer>();
            return api.createChatGroup(userIds, URLEncoder.encode(chatTitle, "UTF-8"), getToken());
        } catch (ApiException e) {
            e.printStackTrace();
        } catch (UnsupportedEncodingException e) {
            e.printStackTrace();
        } catch(ClassCastException e) {
            // For some reason, swagger really messes this up somewhere and sends a double when I'm sending an integer
            // Eat this exception as a workaround since it's not really neccessary to get the chat id anyway
            return 0;
        }

        return -1;
    }


    public static Boolean getStoreLoginInformation() {
        SharedPreferences prefs = getSharedPreferences();
        return prefs.getBoolean("store_login_information", false);
    }

    public static void setStoreLoginInformation(Boolean val) {
        SharedPreferences.Editor prefs = getSharedPreferences().edit();
        prefs.putBoolean("store_login_information", val);
        prefs.commit();

        if(val == false) {
            // Remove login information
            setUsername(null);
            setPassword(null);
        }
    }

    public static Boolean getAutomaticLogin() {
        SharedPreferences prefs = getSharedPreferences();
        return prefs.getBoolean("auto_login", false);
    }

    public static void setAutomaticLogin(Boolean val) {
        SharedPreferences.Editor prefs = getSharedPreferences().edit();
        prefs.putBoolean("auto_login", val);
        prefs.commit();
    }

    public static String getUsername() {
        SharedPreferences prefs = getSharedPreferences();
        return prefs.getString("username", "");
    }

    public static void setUsername(String val) {
        SharedPreferences.Editor prefs = getSharedPreferences().edit();
        prefs.putString("username", val);
        prefs.commit();
    }

    public static String getPassword() {
        SharedPreferences prefs = getSharedPreferences();
        return prefs.getString("password", "");
    }

    public static void setPassword(String val) {
        SharedPreferences.Editor prefs = getSharedPreferences().edit();
        prefs.putString("password", val);
        prefs.commit();
    }

    public static String getToken() {
        SharedPreferences prefs = getSharedPreferences();
        return prefs.getString("token", null);
    }

    public static void setToken(String val) {
        SharedPreferences.Editor prefs = getSharedPreferences().edit();
        prefs.putString("token", val);
        prefs.commit();
    }

    private SharedPreferences sharedPreferences;
    public static SharedPreferences getSharedPreferences() {
        return getInstance().sharedPreferences;
    }

    public static void setSharedPreferences(SharedPreferences val) {
        getInstance().sharedPreferences = val;
    }
}
