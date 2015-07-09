package com.marcus.stealth;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.TextView;

import java.util.ArrayList;

public class CustomAdapter extends ArrayAdapter
{
    private final static String TAG = "CustomAdapter";
    ArrayList<Score> scoreItems = null;
    Context context;

    /**
     * Create a adapter to generate the selection screen for the cyphers
     *
     * @param context  the context of the current  activity
     * @param resource the cyphers available on the device
     */
    public CustomAdapter(Context context, ArrayList<Score> resource)
    {
        super(context, R.layout.list_item, resource);
        // TODO Auto-generated constructor stub
        this.context = context;
        this.scoreItems = resource;
    }

    /**
     * Generate and display the cyphers accepted by the device and its
     * corresponding checkbox
     *
     * @param position    position of the item
     * @param convertView the area to place generated items
     * @param parent      the view that called the adapter
     * @return the view to be displayed to the user
     */
    @Override
    public View getView(final int position, View convertView, ViewGroup parent)
    {
        // TODO Auto-generated method stub
        LayoutInflater inflater = ((Activity) context).getLayoutInflater();
        convertView = inflater.inflate(R.layout.list_item, parent, false);
        TextView score = (TextView) convertView.findViewById(R.id.score);
        TextView initials = (TextView) convertView.findViewById(R.id.initial);
        TextView time = (TextView) convertView.findViewById(R.id.lct);



        if (scoreItems.get(position) != null)
        {
            Log.i(TAG, "getView - position " + position);
            score.setText((scoreItems.get(position).getScore()));
            initials.setText((scoreItems.get(position).getInitials()));
            time.setText((scoreItems.get(position).getLevelCompleteTime()));

        } else
        {
            Log.w(TAG, "mode is null");
        }


        return convertView;
    }

}