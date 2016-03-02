package com.andromeda.simplechat;

import android.app.Activity;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.design.widget.FloatingActionButton;
import android.support.design.widget.Snackbar;
import android.support.v7.app.AppCompatActivity;
import android.support.v7.widget.Toolbar;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.content.Intent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

import java.util.ArrayList;
import java.util.List;

import andromeda.com.simplechatclientandroid.R;
import io.swagger.client.model.Chat;
import io.swagger.client.model.UserProfile;

public class MainActivity extends AppCompatActivity {
    private UpdateProfileTask mUpdateProfileTask = null;
    private UpdateChatTask mUpdateChatTask = null;
    private List<Chat> mChatListData = null;

    private TextView mUsernameView;
    private TextView mDisplayNameView;
    private ListView mChatListView;

    private ChatArrayAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

        ApiGateway.setSharedPreferences(getPreferences(Context.MODE_PRIVATE));

        // Go to login menu before main activity
        Intent intent = new Intent(this, LoginActivity.class);
        startActivityForResult(intent, 0);

        setContentView(R.layout.activity_main);
        Toolbar toolbar = (Toolbar) findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        FloatingActionButton fab = (FloatingActionButton) findViewById(R.id.fab);
        fab.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                // Let you add a new chat easily
                Snackbar.make(view, "Replace with your own action", Snackbar.LENGTH_LONG)
                        .setAction("Action", null).show();
            }
        });

        mUsernameView = (TextView)findViewById(R.id.username);
        mDisplayNameView = (TextView)findViewById(R.id.displayName);
        mChatListView = (ListView)findViewById(R.id.chat_list);

        mChatListData = new ArrayList<Chat>();

        adapter = new ChatArrayAdapter(this, R.layout.chat_list_entry, mChatListData);
        mChatListView.setAdapter(adapter);
        mChatListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                // Load chat
                Chat chat = (Chat)parent.getItemAtPosition(position);

                Log.d("SimpleChat_Main", "Clicked: " + chat.getChatTitle());

                Intent chatIntent = new Intent(view.getContext(), ChatActivity.class);
                chatIntent.putExtra("chat_id", chat.getId());
                startActivity(chatIntent);
            }
        });
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        mUpdateProfileTask = new UpdateProfileTask();
        mUpdateProfileTask.execute((Void) null);

        mUpdateChatTask = new UpdateChatTask();
        mUpdateChatTask.execute((Void) null);
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu_main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_settings) {
            return true;
        }

        return super.onOptionsItemSelected(item);
    }

    /**
     * Get the user's profile and update UI
     */
    public class UpdateProfileTask extends AsyncTask<Void, Void, UserProfile> {

        UpdateProfileTask() {
        }

        @Override
        protected UserProfile doInBackground(Void... params) {
            return ApiGateway.getUserProfile();
        }

        @Override
        protected void onPostExecute(final UserProfile profile) {
            mUpdateProfileTask = null;

            if(profile != null) {
                mUsernameView.setText(profile.getUsername());
                mDisplayNameView.setText(profile.getDisplayName());
            }
        }

        @Override
        protected void onCancelled() {
            mUpdateProfileTask = null;
        }
    }

    /**
     * Get the user's chats  and update UI
     */
    public class UpdateChatTask extends AsyncTask<Void, Void, List<Chat>> {

        UpdateChatTask() {
        }

        @Override
        protected List<Chat> doInBackground(Void... params) {
            List<Chat> chats = ApiGateway.getChats();

            for(int i = 0; i < chats.size(); i++) {
                Chat chat = chats.get(i);
                chat.setChatTitle(Utils.getUtf8String(chat.getChatTitle()));
            }

            return chats;
        }

        @Override
        protected void onPostExecute(final List<Chat> chats) {
            mUpdateChatTask = null;
            adapter.addAll(chats);
        }

        @Override
        protected void onCancelled() {
            mUpdateChatTask = null;
        }
    }

    private class ChatArrayAdapter extends ArrayAdapter<Chat> {
        private class ChatHolder {
            TextView chatTitle;
        }

        private Context context;
        private int resource;

        public ChatArrayAdapter(Context context, int resource, List<Chat> chats) {
            super(context, resource, chats);
            this.context = context;
            this.resource = resource;
        }

        @Override
        public View getView(int position, View convertView, ViewGroup parent) {
            ChatHolder chatHolder = null;

            Log.d("SimpleChat_Main", "Found position: " + position);

            if(convertView == null)
            {
                LayoutInflater inflater = ((Activity)context).getLayoutInflater();
                convertView = inflater.inflate(resource, parent, false);

                chatHolder = new ChatHolder();
                chatHolder.chatTitle = (TextView)convertView.findViewById(R.id.displayName);

                convertView.setTag(chatHolder);
            }
            else
            {
                chatHolder = (ChatHolder)convertView.getTag();
            }

            Chat chat = getItem(position);
            chatHolder.chatTitle.setText(chat.getChatTitle());

            return convertView;
        }
    }
}
