package com.marcus.stealth;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;

/**
 * Created by Raxl on 7/7/15.
 */
public class Score implements Serializable {

    private int id;
    private int score;
    private String initials;
    private int levelCompleteTime;
    private Date date;

    private static final String TAG_ID = "id";
    private static final String TAG_SCORE = "score";
    private static final String TAG_INITIALS = "initials";
    private static final String TAG_TIME = "time";
    private static final String TAG_DATE = "date";

    public Score (JSONObject jO) throws JSONException, ParseException
    {
        id = jO.getInt(TAG_ID);
        score = jO.getInt(TAG_SCORE);
        initials = jO.getString(TAG_INITIALS);
        levelCompleteTime = jO.getInt(TAG_TIME);

        String dateStr = jO.getString(TAG_DATE);
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        date = sdf.parse(dateStr);
    }

    public Score (String score, String initial, Integer time)
    {



    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getScore() {
        return score;
    }

    public void setScore(int score) {
        this.score = score;
    }

    public String getInitials() {
        return initials;
    }

    public void setInitials(String initials) {
        this.initials = initials;
    }

    public int getLevelCompleteTime() {
        return levelCompleteTime;
    }

    public void setLevelCompleteTime(int levelCompleteTime) {
        this.levelCompleteTime = levelCompleteTime;
    }

    public Date getDate() {
        return date;
    }

    public void setDate(Date date) {
        this.date = date;
    }

    @Override
    public String toString()
    {
        return " score=" + score + ", initials=" + initials + ", time=" + levelCompleteTime;
    }

}
