package io.swagger.model;

import java.util.Objects;
import com.fasterxml.jackson.annotation.JsonProperty;
import com.fasterxml.jackson.annotation.JsonValue;
import io.swagger.annotations.ApiModel;
import io.swagger.annotations.ApiModelProperty;





@javax.annotation.Generated(value = "class io.swagger.codegen.languages.JavaJerseyServerCodegen", date = "2016-02-14T22:40:24.503-05:00")
public class Message   {
  
  private Integer messageId = null;
  private Integer chatId = null;
  private Integer userId = null;
  private String message = null;
  private String timestamp = null;

  
  /**
   **/
  public Message messageId(Integer messageId) {
    this.messageId = messageId;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("messageId")
  public Integer getMessageId() {
    return messageId;
  }
  public void setMessageId(Integer messageId) {
    this.messageId = messageId;
  }

  
  /**
   **/
  public Message chatId(Integer chatId) {
    this.chatId = chatId;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("chatId")
  public Integer getChatId() {
    return chatId;
  }
  public void setChatId(Integer chatId) {
    this.chatId = chatId;
  }

  
  /**
   **/
  public Message userId(Integer userId) {
    this.userId = userId;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("userId")
  public Integer getUserId() {
    return userId;
  }
  public void setUserId(Integer userId) {
    this.userId = userId;
  }

  
  /**
   **/
  public Message message(String message) {
    this.message = message;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("message")
  public String getMessage() {
    return message;
  }
  public void setMessage(String message) {
    this.message = message;
  }

  
  /**
   **/
  public Message timestamp(String timestamp) {
    this.timestamp = timestamp;
    return this;
  }

  
  @ApiModelProperty(value = "")
  @JsonProperty("timestamp")
  public String getTimestamp() {
    return timestamp;
  }
  public void setTimestamp(String timestamp) {
    this.timestamp = timestamp;
  }

  

  @Override
  public boolean equals(Object o) {
    if (this == o) {
      return true;
    }
    if (o == null || getClass() != o.getClass()) {
      return false;
    }
    Message message = (Message) o;
    return Objects.equals(messageId, message.messageId) &&
        Objects.equals(chatId, message.chatId) &&
        Objects.equals(userId, message.userId) &&
        Objects.equals(message, message.message) &&
        Objects.equals(timestamp, message.timestamp);
  }

  @Override
  public int hashCode() {
    return Objects.hash(messageId, chatId, userId, message, timestamp);
  }

  @Override
  public String toString() {
    StringBuilder sb = new StringBuilder();
    sb.append("class Message {\n");
    
    sb.append("    messageId: ").append(toIndentedString(messageId)).append("\n");
    sb.append("    chatId: ").append(toIndentedString(chatId)).append("\n");
    sb.append("    userId: ").append(toIndentedString(userId)).append("\n");
    sb.append("    message: ").append(toIndentedString(message)).append("\n");
    sb.append("    timestamp: ").append(toIndentedString(timestamp)).append("\n");
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

