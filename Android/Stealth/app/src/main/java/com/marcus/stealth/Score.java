package com.marcus.stealth;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.Serializable;
import java.sql.Time;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.concurrent.TimeUnit;

/**
 * Created by Raxl on 7/7/15.
 */
public class Score implements Serializable {

    private String id;
    private int score;
    private String initials;
    private String levelCompleteTime;
    private Date date;

    private static final String TAG_ID = "_id";
    private static final String TAG_SCORE = "Score";
    private static final String TAG_INITIALS = "Initials";
    private static final String TAG_TIME = "LevelTime";
    private static final String TAG_DATE = "Date";

    public Score (JSONObject jO) throws JSONException, ParseException
    {
        System.out.println(jO.toString());
        id = jO.getString(TAG_ID);
        score = jO.getInt(TAG_SCORE);
        initials = jO.getString(TAG_INITIALS);
        long intTime = (long)jO.getInt(TAG_TIME);
        long minute = TimeUnit.SECONDS.toMinutes(intTime);
        long second = TimeUnit.SECONDS.toSeconds(intTime) - (TimeUnit.SECONDS.toMinutes(intTime) *60);

        levelCompleteTime = ""+ minute + " minutes " + second + " seconds";

        String dateStr = jO.getString(TAG_DATE);
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss");
        date = sdf.parse(dateStr);
    }


    public String getId() {
        return id;
    }

    public void setId(String id) {
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

    public String getLevelCompleteTime() {
        return levelCompleteTime;
    }

    public void setLevelCompleteTime(String levelCompleteTime) {
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
