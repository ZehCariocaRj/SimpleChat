package io.swagger.client;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import java.lang.reflect.Type;
import java.util.List;
import io.swagger.client.model.*;
import io.swagger.client.model.Error;

public class JsonUtil {
  public static GsonBuilder gsonBuilder;

  static {
    gsonBuilder = new GsonBuilder();
    gsonBuilder.serializeNulls();
    gsonBuilder.setDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSSZ");
  }

  public static Gson getGson() {
    return gsonBuilder.create();
  }

  public static String serialize(Object obj){
    return getGson().toJson(obj);
  }

  public static <T> T deserializeToList(String jsonString, Class cls){
    return getGson().fromJson(jsonString, getListTypeForDeserialization(cls));
  }

  public static <T> T deserializeToObject(String jsonString, Class cls){
    return getGson().fromJson(jsonString, getTypeForDeserialization(cls));
  }

  public static Type getListTypeForDeserialization(Class cls) {
    String className = cls.getSimpleName();
    
    if ("Friend".equalsIgnoreCase(className)) {
      return new TypeToken<List<Friend>>(){}.getType();
    }
    
    if ("Chat".equalsIgnoreCase(className)) {
      return new TypeToken<List<Chat>>(){}.getType();
    }
    
    if ("Message".equalsIgnoreCase(className)) {
      return new TypeToken<List<Message>>(){}.getType();
    }
    
    if ("UserProfile".equalsIgnoreCase(className)) {
      return new TypeToken<List<UserProfile>>(){}.getType();
    }
    
    if ("Error".equalsIgnoreCase(className)) {
      return new TypeToken<List<Error>>(){}.getType();
    }
    
    return new TypeToken<List<Object>>(){}.getType();
  }

  public static Type getTypeForDeserialization(Class cls) {
    String className = cls.getSimpleName();
    
    if ("Friend".equalsIgnoreCase(className)) {
      return new TypeToken<Friend>(){}.getType();
    }
    
    if ("Chat".equalsIgnoreCase(className)) {
      return new TypeToken<Chat>(){}.getType();
    }
    
    if ("Message".equalsIgnoreCase(className)) {
      return new TypeToken<Message>(){}.getType();
    }
    
    if ("UserProfile".equalsIgnoreCase(className)) {
      return new TypeToken<UserProfile>(){}.getType();
    }
    
    if ("Error".equalsIgnoreCase(className)) {
      return new TypeToken<Error>(){}.getType();
    }
    
    return new TypeToken<Object>(){}.getType();
  }

};
