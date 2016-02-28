package com.andromeda.simplechat;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.annotation.TargetApi;
import android.support.v7.app.AppCompatActivity;

import android.os.AsyncTask;

import android.os.Build;
import android.os.Bundle;
import android.text.TextUtils;
import android.util.Log;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;

import andromeda.com.simplechatclientandroid.R;
import io.swagger.client.ApiException;

/**
 * A login screen that offers login via username/password.
 */
public class LoginActivity extends AppCompatActivity {
    /**
     * Keep track of the login task to ensure we can cancel it if requested.
     */
    private UserLoginTask mAuthTask = null;
    private String mUserToken = null;

    // UI references.
    private AutoCompleteTextView mUsernameView;
    private EditText mPasswordView;
    private View mProgressView;
    private View mLoginFormView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);

        mUsernameView = (AutoCompleteTextView) findViewById(R.id.login);
        mPasswordView = (EditText) findViewById(R.id.password);

        Button mSigninButton = (Button) findViewById(R.id.sign_in_button);
        mSigninButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptLogin(false);
            }
        });

        Button mRegisterButton = (Button) findViewById(R.id.register_button);
        mRegisterButton.setOnClickListener(new OnClickListener() {
            @Override
            public void onClick(View view) {
                attemptLogin(true);
            }
        });

        CheckBox mStoreLoginInformation = (CheckBox)findViewById(R.id.remember_password);
        mStoreLoginInformation.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                ApiGateway.setStoreLoginInformation(isChecked);
            }
        });

        CheckBox mAutomaticLogin = (CheckBox)findViewById(R.id.auto_login);
        mAutomaticLogin.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                ApiGateway.setAutomaticLogin(isChecked);
            }
        });

        mLoginFormView = findViewById(R.id.login_form);
        mProgressView = findViewById(R.id.login_progress);

        // Initialize fields
        mStoreLoginInformation.setChecked(ApiGateway.getStoreLoginInformation());
        mAutomaticLogin.setChecked(ApiGateway.getAutomaticLogin());

        if(ApiGateway.getStoreLoginInformation()) {
            mUsernameView.setText(ApiGateway.getUsername());
            mPasswordView.setText(ApiGateway.getPassword());
        }

        // If automatic login is selected. attempt to login
        if(ApiGateway.getAutomaticLogin()) {
            attemptLogin(false);
        }
    }

    /**
     * Attempts to sign in or register the account specified by the login form.
     * If there are form errors (invalid username, missing fields, etc.), the
     * errors are presented and no actual login attempt is made.
     */
    private void attemptLogin(Boolean doRegister) {
        if (mAuthTask != null) {
            return;
        }

        // Reset errors.
        mUsernameView.setError(null);
        mPasswordView.setError(null);

        // Store values at the time of the login attempt.
        String username = mUsernameView.getText().toString();
        String password = mPasswordView.getText().toString();

        boolean cancel = false;
        View focusView = null;

        boolean tokenLogin = false;
        if(ApiGateway.getToken() != null) {
            tokenLogin = true;
        }

        if(!tokenLogin) {
            // Check for a valid password, if the user entered one.
            if (!TextUtils.isEmpty(password) && !isPasswordValid(password)) {
                mPasswordView.setError(getString(R.string.error_invalid_password));
                focusView = mPasswordView;
                cancel = true;
            }

            // Check for a valid username
            if (TextUtils.isEmpty(username)) {
                mUsernameView.setError(getString(R.string.error_field_required));
                focusView = mUsernameView;
                cancel = true;
            }
        }

        if (cancel) {
            // There was an error; don't attempt login and focus the first
            // form field with an error.
            focusView.requestFocus();
        } else {
            // Show a progress spinner, and kick off a background task to
            // perform the user login attempt.
            showProgress(true);

            mAuthTask = new UserLoginTask(username, password, doRegister, tokenLogin);
            mAuthTask.execute((Void) null);
        }
    }

    private boolean isPasswordValid(String password) {
        return password.length() >= 1;
    }

    /**
     * Shows the progress UI and hides the login form.
     */
    @TargetApi(Build.VERSION_CODES.HONEYCOMB_MR2)
    private void showProgress(final boolean show) {
        // On Honeycomb MR2 we have the ViewPropertyAnimator APIs, which allow
        // for very easy animations. If available, use these APIs to fade-in
        // the progress spinner.
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.HONEYCOMB_MR2) {
            int shortAnimTime = getResources().getInteger(android.R.integer.config_shortAnimTime);

            mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
            mLoginFormView.animate().setDuration(shortAnimTime).alpha(
                    show ? 0 : 1).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
                }
            });

            mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
            mProgressView.animate().setDuration(shortAnimTime).alpha(
                    show ? 1 : 0).setListener(new AnimatorListenerAdapter() {
                @Override
                public void onAnimationEnd(Animator animation) {
                    mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
                }
            });
        } else {
            // The ViewPropertyAnimator APIs are not available, so simply show
            // and hide the relevant UI components.
            mProgressView.setVisibility(show ? View.VISIBLE : View.GONE);
            mLoginFormView.setVisibility(show ? View.GONE : View.VISIBLE);
        }
    }

    /**
     * Represents an asynchronous login task used to authenticate
     * the user.
     */
    public class UserLoginTask extends AsyncTask<Void, Void, Boolean> {

        private final String mUsername;
        private final String mPassword;
        private final Boolean mDoRegistration;
        private final Boolean mTokenLogin;

        UserLoginTask(String username, String password, Boolean doRegister, Boolean tokenLogin) {
            mUsername = username;
            mPassword = password;
            mDoRegistration = doRegister;
            mTokenLogin = tokenLogin;
        }

        @Override
        protected Boolean doInBackground(Void... params) {
            if(mTokenLogin) {
                return ApiGateway.LoginUserByToken();
            }

            if(mDoRegistration)
                ApiGateway.RegisterUser(mUsername, mPassword);

            return ApiGateway.LoginUser(mUsername, mPassword);
        }

        @Override
        protected void onPostExecute(final Boolean success) {
            mAuthTask = null;
            showProgress(false);

            if (success) {
                finish();
            } else if(!mTokenLogin) {
                mPasswordView.setError(getString(R.string.error_incorrect_password));
                mPasswordView.requestFocus();
            }
        }

        @Override
        protected void onCancelled() {
            mAuthTask = null;
            showProgress(false);
        }
    }
}

