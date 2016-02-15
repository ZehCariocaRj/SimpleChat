package com.andromeda.Database;

import io.swagger.model.Friend;
import io.swagger.model.Message;
import io.swagger.model.UserProfile;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.Properties;

public class Database {
    private static Connection conn = null;

    private static String serverName = "localhost";
    private static String databaseName = "simplechat";
    private static int portNumber = 3306;

    private static String username = "root";
    private static String password = "";

    private Database() {}

    public static Connection getConnection() {
        try {
            if (conn == null) {
                Properties connectionProps = new Properties();
                connectionProps.put("user", Database.username);
                connectionProps.put("password", Database.password);

                conn = DriverManager.getConnection("jdbc:mysql://" + Database.serverName + ":" + Database.portNumber + "/" + databaseName, connectionProps);
            }
        } catch(SQLException e) {
            // eat exception
        }

        return conn;
    }

    public static ArrayList<Friend> getMyFriends(int userId) {
        ArrayList<Friend> friends = new ArrayList<Friend>();

        Connection conn = getConnection();
        if(conn == null)
            return friends;

        // Get friends from database
        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT * FROM relationships WHERE sourceid = ? AND status = ?");
            statement.setInt(1, userId);
            statement.setInt(2, RelationshipStatus.Friend);

            ResultSet results = statement.executeQuery();

            while(results.next()) {
                int sourceId = results.getInt("sourceid");
                int targetId = results.getInt("targetid");
                int status = results.getInt("status");

                UserProfile profile = getProfileById(targetId);
                if(profile != null) {
                    Friend friend = new Friend();
                    friend.setDisplayName(profile.getDisplayName());
                    friend.setId(profile.getUserId());
                    friend.setUsername(profile.getUsername());

                    friends.add(friend);
                }
            }
        } catch(SQLException e) {

        }

        return friends;
    }

    public static UserProfile getProfileById(int targetId) {
        UserProfile profile = null;

        Connection conn = getConnection();
        if (conn == null)
            return profile;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT * FROM userprofilesview WHERE userid = ?");
            statement.setInt(1, targetId);

            ResultSet results = statement.executeQuery();
            while (results.next()) {
                int userid = results.getInt("userid");
                String username = results.getString("username");
                String displayname = results.getString("displayname");
                String email = results.getString("email");
                Boolean enabled = results.getBoolean("enabled");

                profile = new UserProfile();
                profile.setUserId(userid);
                profile.setUsername(username);
                profile.setDisplayName(displayname);
                profile.setEmail(email);
                profile.setEnabled(enabled);
            }
        } catch (SQLException e) {

        }

        return profile;
    }

    public static Boolean registerUser(String username, String password, String email) {
        Boolean result = false;

        Connection conn = getConnection();
        if (conn == null)
            return result;

        try {
            int enabled = 1;

            // TODO: Replace with something more secure
            password = getHashedString(password);

            PreparedStatement statement = null;
            statement = conn.prepareStatement("INSERT INTO users (username, password, email, enabled) VALUES (?,?,?,?)");
            statement.setString(1, username);
            statement.setString(2, password);
            statement.setString(3, email);
            statement.setInt(4, enabled);
            statement.executeUpdate();

            int userId = getUserIdFromUsername(username);
            String verificationHash =  generateRandomHashString();
            statement = conn.prepareStatement("INSERT INTO verification (userid, verificationhash) VALUES (?,?) ON DUPLICATE KEY UPDATE verificationhash=?");
            statement.setInt(1, userId);
            statement.setString(2, verificationHash);
            statement.setString(3, verificationHash);
            statement.executeUpdate();

            result = true;
        } catch (SQLException e) {
            System.out.println(e);
        }

        return result;
    }

    public static Boolean checkUsernameExists(String username) {
        Boolean result = false;

        Connection conn = getConnection();
        if (conn == null)
            return result;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT COUNT(*) FROM users WHERE username = ?");
            statement.setString(1, username);

            ResultSet results = statement.executeQuery();
            results.next();

            result = results.getInt(1) > 0;
        } catch (SQLException e) {
            System.out.println(e);
        }

        return result;
    }

    public static int getUserIdFromUsername(String username) {
        int userId = -1;

        Connection conn = getConnection();
        if (conn == null)
            return userId;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT userid FROM users WHERE username = ?");
            statement.setString(1, username);

            ResultSet results = statement.executeQuery();
            results.next();

            userId = results.getInt("userid");
        } catch (SQLException e) {
            System.out.println(e);
        }

        return userId;
    }

    public static Boolean deleteUser(int userId) {
        Boolean result = false;

        Connection conn = getConnection();
        if (conn == null)
            return result;

        try {
            // For referential integrity purposes, remove all possible references to the userid
            PreparedStatement statement = null;

            // Blank all references to userid in chat so that conversations don't get lost
            statement = conn.prepareStatement("UPDATE messages SET userid=null WHERE userid = ?");
            statement.setInt(1, userId);
            statement.addBatch();

            // Remove chat participant
            statement = conn.prepareStatement("DELETE FROM chats WHERE participant = ?");
            statement.setInt(1, userId);
            statement.addBatch();

            // Remove relationships
            statement = conn.prepareStatement("DELETE FROM relationships WHERE sourceid = ? OR targetid = ?");
            statement.setInt(1, userId);
            statement.setInt(2, userId);
            statement.addBatch();

            // Remove tokens
            statement = conn.prepareStatement("DELETE FROM tokens WHERE userid = ?");
            statement.setInt(1, userId);
            statement.addBatch();

            // Remove user profile
            statement = conn.prepareStatement("DELETE FROM userprofiles WHERE userid = ?");
            statement.setInt(1, userId);
            statement.addBatch();

            // Finally, delete user
            statement = conn.prepareStatement("DELETE FROM users WHERE userid = ?");
            statement.setInt(1, userId);
            statement.addBatch();

            statement.executeBatch();

            result = true;
        } catch (SQLException e) {
            System.out.println(e);
        }

        return result;
    }

    public static Boolean addFriend(int userId, String targetUsername, int status) {
        Boolean result = false;

        Connection conn = getConnection();
        if (conn == null)
            return result;

        try {
            int targetId = getUserIdFromUsername(targetUsername);

            PreparedStatement statement = null;

            statement = conn.prepareStatement("INSERT INTO relationships (sourceid, targetid, status) VALUES (?,?,?) ON DUPLICATE KEY UPDATE sourceid=?, targetid=?, status=?");
            statement.setInt(1, userId);
            statement.setInt(2, targetId);
            statement.setInt(3, status);
            statement.setInt(4, userId);
            statement.setInt(5, targetId);
            statement.setInt(6, status);
            statement.executeUpdate();

            result = true;
        } catch (SQLException e) {
            System.out.println(e);
        }

        return result;
    }

    public static Boolean deleteFriend(int userId, int targetId) {
        Boolean result = false;

        Connection conn = getConnection();
        if (conn == null)
            return result;

        try {
            PreparedStatement statement = null;

            statement = conn.prepareStatement("DELETE FROM relationships WHERE sourceId = ? AND targetId = ?");
            statement.setInt(1, userId);
            statement.setInt(2, targetId);
            statement.executeUpdate();

            result = true;
        } catch (SQLException e) {
            System.out.println(e);
        }

        return result;
    }

    public static Boolean verifyUser(String verificationHash) {
        Boolean success = false;

        Connection conn = getConnection();
        if (conn == null)
            return success;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT COUNT(*), userid FROM verification WHERE verificationHash = ?");
            statement.setString(1, verificationHash);

            ResultSet results = statement.executeQuery();
            results.next();

            Boolean found = results.getInt(1) == 1;

            if(found) {
                int userId = results.getInt("userid");

                statement = conn.prepareStatement("UPDATE users SET enabled=1 WHERE userid = ?");
                statement.setInt(1, userId);
                statement.executeUpdate();

                statement = conn.prepareStatement("DELETE FROM verification WHERE userid = ?");
                statement.setInt(1, userId);
                statement.executeUpdate();

                success = true;
            }
        } catch (SQLException e) {
            System.out.println(e);
        }

        return success;
    }

    public static Boolean verifyPassword(String username, String password) {
        Boolean matched = false;
        String passwordHash = "";

        // Calculate hash of password
        passwordHash = getHashedString(password);

        Connection conn = getConnection();
        if (conn == null)
            return matched;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT COUNT(*) FROM users WHERE username = ? AND password = ? AND enabled = 1");
            statement.setString(1, username);
            statement.setString(2, passwordHash);

            ResultSet results = statement.executeQuery();
            results.next();

            // Must return exactly one match to be valid
            matched = results.getInt(1) == 1;

            if(results.getInt(1) > 1) {
                throw new Exception("Multiple users found that matched username/password combo");
            }

        } catch (SQLException e) {
            System.out.println(e);
        } catch(Exception e) {
            System.out.println(e);
        }

        return matched;
    }

    public static UserProfile verifyToken(String token) {
        UserProfile user = null;

        Connection conn = getConnection();
        if (conn == null)
            return user;

        String tokenhash = getHashedString(token);

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT COUNT(*), userid, creationdate FROM tokens WHERE tokenhash = ?");
            statement.setString(1, tokenhash);

            ResultSet results = statement.executeQuery();
            results.next();

            // Must return exactly one match to be valid
            Boolean valid = results.getInt(1) == 1;


            if(valid) {
                long delta = ((24 * 60) + 0) * 1000; // 6 hours and 0 minutes
                Timestamp creationDate = results.getTimestamp("creationdate");
                Timestamp expiryDate = new Timestamp(creationDate.getTime() + delta);
                Timestamp curTimestamp = new Timestamp(new java.util.Date().getTime());

                System.out.println(creationDate);
                System.out.println(expiryDate);
                System.out.println(curTimestamp);

                if (curTimestamp.after(expiryDate)) {
                    // Expired token, delete from database

                    statement = conn.prepareStatement("DELETE FROM tokens WHERE tokenhash = ?");
                    statement.setString(1, tokenhash);
                    statement.executeUpdate();

                    user = null;
                } else {
                    user = getProfileById(results.getInt("userid"));
                }
            }

        } catch (SQLException e) {
            System.out.println(e);
        } catch(Exception e) {
            System.out.println(e);
        }

        System.out.println(user);

        return user;
    }

    public static String loginUser(String username, String password) {
        String token = null;
        int userId = getUserIdFromUsername(username);
        Boolean valid = verifyPassword(username, password);

        if(valid) {
            // Username/password combo verified, generate a login token
            Connection conn = getConnection();
            if (conn == null)
                return token;

            token = generateRandomHashString();

            String tokenhash = getHashedString(token);

            try {
                PreparedStatement statement = null;
                statement = conn.prepareStatement("INSERT INTO tokens (userid, tokenhash, creationdate) VALUES (?,?,NOW()) ON DUPLICATE KEY UPDATE userid=?, tokenhash=?, creationdate=NOW()");
                statement.setInt(1, userId);
                statement.setString(2, tokenhash);
                statement.setInt(3, userId);
                statement.setString(4, tokenhash);
                statement.executeUpdate();

            } catch (SQLException e) {
                System.out.println(e);
                token = null;
            }
        }

        return token;
    }

    private static String generateRandomHashString() {
        SecureRandom random = new SecureRandom();
        byte tokendata[] = new byte[32];
        random.nextBytes(tokendata);

        String token = "";
        for (int i = 0; i < tokendata.length; i++) {
            token += String.format("%02x", tokendata[i]);
        }

        return token;
    }

    private static String getHashedString(String password) {
        String output = null;

        try {
            MessageDigest messageDigest = MessageDigest.getInstance("SHA-256");
            messageDigest.update(password.getBytes());

            output = "";
            byte digest[] = messageDigest.digest();
            for (int i = 0; i < digest.length; i++) {
                output += String.format("%02x", digest[i]);
            }
        } catch (NoSuchAlgorithmException e) {

        }

        return output;
    }

    public static int createChatGroup(String chatTitle, List<Integer> userIds) {
        int chatId = -1;

        ArrayList<Integer> validUserIds = new ArrayList<Integer>();
        for(int userId : userIds) {
            UserProfile profile = getProfileById(userId);

            if (profile.getEnabled() && !validUserIds.contains(userId)) {
                // Only add valid users to the chat
                validUserIds.add(userId);
            }
        }

        if(validUserIds.size() == 0) {
            // Can't create chat because no users exist
            return chatId;
        }

        // Username/password combo verified, generate a login token
        Connection conn = getConnection();
        if (conn == null)
            return chatId;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("INSERT INTO chats (title) VALUES (?)", Statement.RETURN_GENERATED_KEYS);
            statement.setString(1, chatTitle);
            statement.executeUpdate();

            ResultSet keys = statement.getGeneratedKeys();
            keys.next();
            chatId = (int)keys.getLong(1);

            for(int userId : validUserIds) {
                try {
                    statement = conn.prepareStatement("INSERT INTO participants (chatid, participant) VALUES (?,?)");
                    statement.setInt(1, chatId);
                    statement.setInt(2, userId);
                    statement.executeUpdate();
                } catch(Exception e) {
                }
            }
        } catch (SQLException e) {
            System.out.println(e);
            chatId = -1;
        }

        return chatId;
    }

    public static Message sendChatMessage(int targetId, int sourceUserId, String message) {
        Message result = null;

        Connection conn = getConnection();
        if (conn == null)
            return result;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("INSERT INTO messages (chatid, userid, message) VALUES (?,?,?)", Statement.RETURN_GENERATED_KEYS);
            statement.setInt(1, targetId);
            statement.setInt(2, sourceUserId);
            statement.setString(3, message);
            statement.executeUpdate();

            ResultSet keys = statement.getGeneratedKeys();
            keys.next();
            int messageId = (int)keys.getLong(1);

            result = getChatMessage(messageId);

        } catch (SQLException e) {
            System.out.println(e);
        }

        return result;
    }

    public static Message getChatMessage(int messageId) {
        Message message = null;

        Connection conn = getConnection();
        if (conn == null)
            return message;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT * FROM messages WHERE messageid = ?");
            statement.setInt(1, messageId);

            ResultSet results = statement.executeQuery();
            results.next();

            message = new Message();
            message.setMessageId(results.getInt("messageid"));
            message.setChatId(results.getInt("chatid"));
            message.setUserId(results.getInt("userid"));
            message.setMessage(results.getString("message"));
            message.setTimestamp(results.getTimestamp("timestamp").toString());
        } catch (SQLException e) {
            System.out.println(e);
        }

        return message;
    }

    public static List<Message> getChatMessages(int targetId) {
        return getChatMessagesSinceLastId(targetId, 0);
    }

    public static List<Message> getChatMessagesSinceLastId(int targetId, int lastMessageId) {
        ArrayList<Message> messages = null;

        Connection conn = getConnection();
        if (conn == null)
            return messages;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT messageid FROM messages WHERE chatid = ? AND messageid > ?");
            statement.setInt(1, targetId);
            statement.setInt(2, lastMessageId);

            ResultSet results = statement.executeQuery();
            messages = new ArrayList<Message>();

            while(results.next()) {
                Message message = getChatMessage(results.getInt("messageid"));
                messages.add(message);
            }
        } catch (SQLException e) {
            System.out.println(e);
        }

        return messages;
    }
}
