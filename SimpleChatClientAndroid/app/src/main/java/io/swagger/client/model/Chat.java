package io.swagger.client.model;

import java.util.*;

import io.swagger.annotations.*;
import com.google.gson.annotations.SerializedName;


@ApiModel(description = "")
public class Chat  {
  
  @SerializedName("id")
  private Integer id = null;
  @SerializedName("chatTitle")
  private String chatTitle = null;
  @SerializedName("users")
  private List<Integer> users = null;

  
  /**
   **/
  @ApiModelProperty(value = "")
  public Integer getId() {
    return id;
  }
  public void setId(Integer id) {
    this.id = id;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public String getChatTitle() {
    return chatTitle;
  }
  public void setChatTitle(String chatTitle) {
    this.chatTitle = chatTitle;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public List<Integer> getUsers() {
    return users;
  }
  public void setUsers(List<Integer> users) {
    this.users = users;
  }

  

  @Override
  public String toString()  {
    StringBuilder sb = new StringBuilder();
    sb.append("class Chat {\n");
    
    sb.append("  id: ").append(id).append("\n");
    sb.append("  chatTitle: ").append(chatTitle).append("\n");
    sb.append("  users: ").append(users).append("\n");
    sb.append("}\n");
    return sb.toString();
  }
}
