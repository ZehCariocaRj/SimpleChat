package io.swagger.model;

import java.util.Objects;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonValue;
import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;
import java.util.*;





@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-13T21:12:36.938-05:00")
public class Chat   {
  
  private Integer id = null;
  private String chatTitle = null;
  private List<Integer> users = new ArrayList<Integer>();

  
  /**
   **/
  public Chat id(Integer id) {
    this.id = id;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("id")
  public Integer getId() {
    return id;
  }
  public void setId(Integer id) {
    this.id = id;
  }

  
  /**
   **/
  public Chat chatTitle(String chatTitle) {
    this.chatTitle = chatTitle;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("chatTitle")
  public String getChatTitle() {
    return chatTitle;
  }
  public void setChatTitle(String chatTitle) {
    this.chatTitle = chatTitle;
  }

  
  /**
   **/
  public Chat users(List<Integer> users) {
    this.users = users;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("users")
  public List<Integer> getUsers() {
    return users;
  }
  public void setUsers(List<Integer> users) {
    this.users = users;
  }

  

  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    Chat chat = (Chat) o;
    return Objects.equals(id, chat.id) &&
        Objects.equals(chatTitle, chat.chatTitle) &&
        Objects.equals(users, chat.users);
  }

  @Override
  public int hashCode() {
    return Objects.hash(id, chatTitle, users);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class Chat {\n");
    
    sb.append("    id: ").append(toIndentedString(id)).append("\n");
    sb.append("    chatTitle: ").append(toIndentedString(chatTitle)).append("\n");
    sb.append("    users: ").append(toIndentedString(users)).append("\n");
    sb.append("}");
    return sb.toString();
  }

  /**
   * Convert the given object to string with each line indented by 4 spaces
   * (except the first line).
   */
  private String toIndentedString(Object o) {
    if (o == null) {
      return "null";
    }
    return o.toString().replace("\n", "\n    ");
  }
}

