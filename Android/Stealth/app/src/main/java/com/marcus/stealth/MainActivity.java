
package com.marcus.stealth;


import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.ListView;
import android.widget.Spinner;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.RequestQueue;
import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.JsonArrayRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.text.ParseException;
import java.util.ArrayList;

public class MainActivity extends FragmentActivity {

    // URI to get score JSON
    private static String heroku_uri = "http://copstealth.herokuapp.com/api/";
    private static int level_number = 1;
    private static int board_number = 0;
    private static String uri;
    private static String uri2;

    private static final String TAG_SCORES = "scores";

    ArrayList<Score> scoreList;
    public ScoreChoice scoreChoice;
    public Switch switch1;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        scoreList = new ArrayList<>();

        Spinner level_spinner = (Spinner) findViewById(R.id.level_spinner);

        ArrayAdapter<CharSequence> dropdown_level_names = ArrayAdapter.createFromResource(this,
                R.array.levels, android.R.layout.simple_spinner_item);
        dropdown_level_names.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        level_spinner.setAdapter(dropdown_level_names);

        level_spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                level_number = position + 1;
                ToastMe("Level: " + level_number);
                checkScore();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
                level_number = 1;
//                ToastMe("Level: " + level_number);
            }
        });


        Spinner leaderboard_spinner = (Spinner) findViewById(R.id.leaderboard_spinner);
        ArrayAdapter<CharSequence> dropdown_leaderboard_names = ArrayAdapter.createFromResource(this,
                R.array.leaderboards, android.R.layout.simple_spinner_item);

        dropdown_leaderboard_names.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        leaderboard_spinner.setAdapter(dropdown_leaderboard_names);

        leaderboard_spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                board_number = position;
                ToastMe("Board: " + board_number);
                checkScore();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {
                board_number = 0;
//                ToastMe("Board: " + board_number);
//                checkScore();
            }
        });

        checkScore();
    }

    public void ToastMe(String text)
    {
        Toast.makeText(this, text, Toast.LENGTH_SHORT).show();
    }

    public void checkScore ()
    {
        String url = heroku_uri + level_number + '/' + board_number;
        ToastMe(url);
        readJsonFromUrl(url);
    }

    public void updateFragment(){
        ToastMe("Updating Fragment");
        FragmentManager fm = getSupportFragmentManager();
        scoreChoice = (ScoreChoice) fm.findFragmentByTag(TAG_SCORES);
        FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
        if (scoreChoice != null) {

            FrameLayout scoreView = (FrameLayout) findViewById(R.id.score_list);
            scoreView.removeAllViewsInLayout();
            ft.remove(scoreChoice);
            //Toast toast = Toast.makeText(getApplicationContext(), scoreChoice.toString(), Toast.LENGTH_LONG);
            //toast.show();
        }
        scoreChoice = ScoreChoice.newInstance(scoreList);
        ft.add(R.id.score_list, scoreChoice, TAG_SCORES);
        ft.commit();
        ToastMe("Updated!");
    }


    public void readJsonFromUrl(String url)
    {

        JsonArrayRequest jreq = new JsonArrayRequest(url,
                new Response.Listener<JSONArray>() {

                    @Override
                    public void onResponse(JSONArray response) {
                        scoreList.clear();
                        for (int i = 0; i < response.length(); i++) {
                            try {

                                JSONObject jo = response.getJSONObject(i);
                                Score score = new Score(jo);

                                scoreList.add(score);
                            } catch (JSONException e) {
                                    e.printStackTrace();
                            } catch (ParseException e) {
                                e.printStackTrace();
                            }
                        }

                        updateFragment();
                    }
                }, new Response.ErrorListener() {
            @Override
            public void onErrorResponse(VolleyError error) {
            }
        });

        RequestQueue rq = Volley.newRequestQueue(this);

        rq.add(jreq);
    }


}

