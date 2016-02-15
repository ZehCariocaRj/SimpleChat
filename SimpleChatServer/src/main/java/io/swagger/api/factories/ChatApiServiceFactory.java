package io.swagger.api.factories;

import io.swagger.api.ChatApiService;
import io.swagger.api.impl.ChatApiServiceImpl;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-15T10:43:32.805-05:00")
public class ChatApiServiceFactory {

   private final static ChatApiService service = new ChatApiServiceImpl();

   public static ChatApiService getChatApi()
   {
      return service;
   }
}
