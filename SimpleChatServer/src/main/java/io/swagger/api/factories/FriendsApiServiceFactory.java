package io.swagger.api.factories;

import io.swagger.api.FriendsApiService;
import io.swagger.api.impl.FriendsApiServiceImpl;

@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-15T18:12:54.910-05:00")
public class FriendsApiServiceFactory {

   private final static FriendsApiService service = new FriendsApiServiceImpl();

   public static FriendsApiService getFriendsApi()
   {
      return service;
   }
}
