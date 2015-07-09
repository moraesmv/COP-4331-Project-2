package com.marcus.stealth;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ListView;

import java.util.ArrayList;

/**
 * Created by Raxl on 7/8/15.
 */
public class ScoreChoice extends Fragment
    {


        private View rootView;
        private ArrayList<Score> mScoreItems;
        private CustomAdapter adapter;
        private ListView mListView;

        public static ScoreChoice newInstance(ArrayList<Score> mScoreItems)
        {
            ScoreChoice scoreFragment = new ScoreChoice();
            Bundle args = new Bundle();
            args.putSerializable("scores", mScoreItems);
            scoreFragment.setArguments(args);
            return scoreFragment;
        }



        public void onCreate(Bundle savedInstanceState)
        {
            super.onCreate(savedInstanceState);
        }

        /**
         * Create the fragment, initialize items and call task to execute test
         *
         */
        @Override
        public View onCreateView(LayoutInflater inflater, ViewGroup container,
                                 Bundle savedInstanceState)
        {
            rootView = inflater.inflate(R.layout.fragment_section_dummy, container, false);
            mScoreItems = (ArrayList<Score>)getArguments().getSerializable("scores");
            mListView = (ListView) rootView.findViewById(R.id.list);
            adapter = new CustomAdapter(getActivity(), mScoreItems);
            mListView.setAdapter(adapter);

            return rootView;
        }

    }
