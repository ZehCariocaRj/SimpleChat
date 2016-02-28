package io.swagger.client.model;


import io.swagger.annotations.*;
import com.google.gson.annotations.SerializedName;


@ApiModel(description = "")
public class Message  {
  
  @SerializedName("messageId")
  private Integer messageId = null;
  @SerializedName("chatId")
  private Integer chatId = null;
  @SerializedName("userId")
  private Integer userId = null;
  @SerializedName("message")
  private String message = null;
  @SerializedName("timestamp")
  private String timestamp = null;

  
  /**
   **/
  @ApiModelProperty(value = "")
  public Integer getMessageId() {
    return messageId;
  }
  public void setMessageId(Integer messageId) {
    this.messageId = messageId;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public Integer getChatId() {
    return chatId;
  }
  public void setChatId(Integer chatId) {
    this.chatId = chatId;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public Integer getUserId() {
    return userId;
  }
  public void setUserId(Integer userId) {
    this.userId = userId;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public String getMessage() {
    return message;
  }
  public void setMessage(String message) {
    this.message = message;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public String getTimestamp() {
    return timestamp;
  }
  public void setTimestamp(String timestamp) {
    this.timestamp = timestamp;
  }

  

  @Override
  public String toString()  {
    StringBuilder sb = new StringBuilder();
    sb.append("class Message {\n");
    
    sb.append("  messageId: ").append(messageId).append("\n");
    sb.append("  chatId: ").append(chatId).append("\n");
    sb.append("  userId: ").append(userId).append("\n");
    sb.append("  message: ").append(message).append("\n");
    sb.append("  timestamp: ").append(timestamp).append("\n");
    sb.append("}\n");
    return sb.toString();
  }
}
