package com.andromeda.simplechat;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import java.util.ArrayList;
import java.util.List;

import andromeda.com.simplechatclientandroid.R;
import io.swagger.client.model.Message;
import io.swagger.client.model.UserProfile;

public class ChatInviteActivity extends AppCompatActivity {
    int mChatId;
    EditText mUsernameField;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_chat_invite);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        mChatId = getIntent().getIntExtra("chat_id", -1);
        mUsernameField = (EditText)findViewById(R.id.invite_username);

        Button inviteButton = (Button)findViewById(R.id.invite_user_button);
        inviteButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                inviteUser();
            }
        });

    }

    private void inviteUser() {
        mUsernameField.setError(null);

        if(TextUtils.isEmpty(mUsernameField.getText())) {
            mUsernameField.setError(getString(R.string.error_invalid_invite_username));
            mUsernameField.requestFocus();
            return;
        }

        InviteUserTask inviteUserTask = new InviteUserTask(mChatId, mUsernameField.getText().toString());
        inviteUserTask.execute();
    }

    /**
     * Invite user to specified chat
     */
    public class InviteUserTask extends AsyncTask<Void, Void, Integer> {
        private int chatId;
        private String username;

        InviteUserTask(int chatId, String username) {
            this.chatId = chatId;
            this.username = username;
        }

        @Override
        protected Integer doInBackground(Void... params) {
            return ApiGateway.inviteUserToChat(chatId, username);
        }

        @Override
        protected void onPostExecute(final Integer result) {
            if(result == 403) {
                mUsernameField.setError(getString(R.string.error_invalid_invite_username));
            } else if(result == 604) {
                mUsernameField.setError(getString(R.string.error_user_already_in_chat));
            } else if(result == 1) {
                finish();
            }
        }

        @Override
        protected void onCancelled() {
        }
    }
}
