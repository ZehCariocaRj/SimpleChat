package io.swagger.client.model;


import io.swagger.annotations.*;
import com.google.gson.annotations.SerializedName;


@ApiModel(description = "")
public class UserProfile  {
  
  @SerializedName("userId")
  private Integer userId = null;
  @SerializedName("username")
  private String username = null;
  @SerializedName("displayName")
  private String displayName = null;
  @SerializedName("email")
  private String email = null;
  @SerializedName("enabled")
  private Boolean enabled = null;

  
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
  public String getUsername() {
    return username;
  }
  public void setUsername(String username) {
    this.username = username;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public String getDisplayName() {
    return displayName;
  }
  public void setDisplayName(String displayName) {
    this.displayName = displayName;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public String getEmail() {
    return email;
  }
  public void setEmail(String email) {
    this.email = email;
  }

  
  /**
   **/
  @ApiModelProperty(value = "")
  public Boolean getEnabled() {
    return enabled;
  }
  public void setEnabled(Boolean enabled) {
    this.enabled = enabled;
  }

  

  @Override
  public String toString()  {
    StringBuilder sb = new StringBuilder();
    sb.append("class UserProfile {\n");
    
    sb.append("  userId: ").append(userId).append("\n");
    sb.append("  username: ").append(username).append("\n");
    sb.append("  displayName: ").append(displayName).append("\n");
    sb.append("  email: ").append(email).append("\n");
    sb.append("  enabled: ").append(enabled).append("\n");
    sb.append("}\n");
    return sb.toString();
  }
}
