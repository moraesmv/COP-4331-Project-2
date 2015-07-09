
package com.marcus.stealth;


import android.os.Bundle;
import android.support.v4.app.FragmentActivity;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;

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

    // URL to get contacts JSON
    private static String uri = "http://168.235.74.170:8080/api/";

    // JSON Node names
    private static final String TAG_SCORES = "scores";

    ArrayList<Score> scoreList;
    public ScoreChoice scoreChoice;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        scoreList = new ArrayList<>();
        readJsonFromUrl(uri);

        FragmentManager fm = getSupportFragmentManager();
        scoreChoice = (ScoreChoice) fm.findFragmentByTag(TAG_SCORES);
        FragmentTransaction ft = getSupportFragmentManager().beginTransaction();
        scoreChoice = ScoreChoice.newInstance(scoreList);
        ft.add(R.id.score_list, scoreChoice, TAG_SCORES);
        ft.commit();

    }

    public void readJsonFromUrl(String url)
    {
        JsonArrayRequest jreq = new JsonArrayRequest(url,
                new Response.Listener<JSONArray>() {

                    @Override
                    public void onResponse(JSONArray response) {

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

