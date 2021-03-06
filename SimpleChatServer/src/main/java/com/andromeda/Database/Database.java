package com.andromeda.Database;

import io.swagger.model.Chat;
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
                connectionProps.setProperty("characterEncoding", "UTF-8");
                connectionProps.setProperty("useUnicode", "true");

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

    public static Boolean registerUser(String username, String password, String email, String displayName) {
        Boolean result = false;

        if(displayName == null) {
            displayName = username;
        }

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

            statement = conn.prepareStatement("INSERT INTO userprofiles (userid, displayname) VALUES (?,?)");
            statement.setInt(1, userId);
            statement.setString(2, displayName);
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

    public static int addFriend(int userId, String targetUsername, int status) {
        int result = 0;

        Connection conn = getConnection();
        if (conn == null)
            return result;

        try {
            int targetId = getUserIdFromUsername(targetUsername);

            if(targetId == -1) {
                result = -2;
                return result;
            }

            PreparedStatement statement = null;

            // Check if friend already exists
            statement = conn.prepareStatement("SELECT COUNT(*) FROM relationships WHERE sourceId = ? AND targetId = ?");
            statement.setInt(1, userId);
            statement.setInt(2, targetId);

            ResultSet results = statement.executeQuery();
            results.next();

            if(results.getInt(1) > 0) {
                result = -1;
            } else {
                statement = conn.prepareStatement("INSERT INTO relationships (sourceid, targetid, status) VALUES (?,?,?) ON DUPLICATE KEY UPDATE sourceid=?, targetid=?, status=?");
                statement.setInt(1, userId);
                statement.setInt(2, targetId);
                statement.setInt(3, status);
                statement.setInt(4, userId);
                statement.setInt(5, targetId);
                statement.setInt(6, status);
                statement.executeUpdate();

                result = 1;
            }
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

    public static int updateUser(int userId, String username, String password, String email, String displayName) {
        int ret = 0;

        Connection conn = getConnection();
        if (conn == null)
            return ret;

        try {
            PreparedStatement statement = null;
            int found = 0; // Write without username by default

            if(username != null) {
                statement = conn.prepareStatement("SELECT COUNT(*) FROM users WHERE username = ?");
                statement.setString(1, username);

                ResultSet results = statement.executeQuery();
                results.next();

                if(results.getInt(1) == 1) {
                    found = -1; // Writeout new username because of erro
                    ret = -1;
                }
                else {
                    found = 1;
                    ret = 1;
                }
            } else {
                ret = 1;
            }

            statement = conn.prepareStatement("UPDATE userprofiles SET displayname=? WHERE userid = ?");
            statement.setString(1, displayName);
            statement.setInt(2, userId);
            statement.executeUpdate();

            if(found == 1){
                if(password == null) {
                    statement = conn.prepareStatement("UPDATE users SET username=?, email=? WHERE userid = ?");
                    statement.setString(1, username);
                    statement.setString(2, email);
                    statement.setInt(3, userId);
                } else {
                    statement = conn.prepareStatement("UPDATE users SET username=?, email=?, password=? WHERE userid = ?");
                    statement.setString(1, username);
                    statement.setString(2, email);
                    statement.setString(3, password);
                    statement.setInt(4, userId);
                }

                statement.executeUpdate();
            } else {
                // Username exists, don't modify username
                if(password == null) {
                    statement = conn.prepareStatement("UPDATE users SET email=? WHERE userid = ?");
                    statement.setString(1, email);
                    statement.setInt(2, userId);
                } else {
                    statement = conn.prepareStatement("UPDATE users SET email=?, password=? WHERE userid = ?");
                    statement.setString(1, email);
                    statement.setString(2, password);
                    statement.setInt(3, userId);
                }

                statement.executeUpdate();
            }
        } catch (SQLException e) {
            System.out.println(e);
        }

        return ret;
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

    public static Chat getChat(int chatId) {
        List<Integer> participants = getChatParticipants(chatId);
        String chatTitle = getChatTitle(chatId);

        Chat chat = new Chat();
        chat.setId(chatId);
        chat.setUsers(participants);
        chat.setChatTitle(chatTitle);

        return chat;
    }

    public static List<Chat> getChats(int userId) {
        ArrayList<Chat> chats = null;

        Connection conn = getConnection();
        if (conn == null)
            return chats;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT * FROM participants WHERE participant = ?");
            statement.setInt(1, userId);

            ResultSet results = statement.executeQuery();

            chats = new ArrayList<Chat>();
            while(results.next()) {
                int chatId = results.getInt("chatId");
                List<Integer> participants = getChatParticipants(chatId);
                String chatTitle = getChatTitle(chatId);

                Chat chat = new Chat();
                chat.setId(chatId);
                chat.setUsers(participants);
                chat.setChatTitle(chatTitle);

                chats.add(chat);
            }
        } catch (SQLException e) {
            System.out.println(e);
        }

        return chats;
    }

    public static List<Integer> getChatParticipants(int chatId) {
        ArrayList<Integer> participants = null;

        Connection conn = getConnection();
        if (conn == null)
            return participants;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT * FROM participants WHERE chatid = ?");
            statement.setInt(1, chatId);

            ResultSet results = statement.executeQuery();

            participants = new ArrayList<Integer>();
            while(results.next()) {
                int participantId = results.getInt("participant");
                participants.add(participantId);
            }
        } catch (SQLException e) {
            System.out.println(e);
        }

        return participants;
    }

    public static String getChatTitle(int chatId) {
        String title = "";

        Connection conn = getConnection();
        if (conn == null)
            return title;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("SELECT * FROM chats WHERE chatid = ?");
            statement.setInt(1, chatId);

            ResultSet results = statement.executeQuery();

            results.next();
            title = results.getString("title");
        } catch (SQLException e) {
            System.out.println(e);
        }

        return title;
    }

    public static Boolean updateChat(Integer chatId, String chatTitle) {
        Boolean success = false;

        Connection conn = getConnection();
        if (conn == null)
            return success;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("UPDATE chats SET title=? WHERE chatid=?");
            statement.setString(1, chatTitle);
            statement.setInt(2, chatId);
            statement.executeUpdate();
            success = true;
        } catch (SQLException e) {
            System.out.println(e);
        }

        return success;
    }

    public static int inviteUserToChat(Integer chatId, String username) {
        int res = 0;
        int userId = getUserIdFromUsername(username);

        if(userId == -1) {
            res = -1;
            return res;
        }

        Connection conn = getConnection();
        if (conn == null)
            return res;

        try {
            PreparedStatement statement = null;
            statement = conn.prepareStatement("INSERT INTO participants (chatid, participant) VALUES (?,?)");
            statement.setInt(1, chatId);
            statement.setInt(2, userId);
            statement.executeUpdate();
            res = 1;
        } catch(com.mysql.jdbc.exceptions.jdbc4.MySQLIntegrityConstraintViolationException e) {
            // User is already in chat
            res = -2;
        } catch (SQLException e) {
            System.out.println(e);
        }

        return res;
    }
}
