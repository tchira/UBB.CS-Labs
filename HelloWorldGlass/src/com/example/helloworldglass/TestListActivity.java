package com.example.helloworldglass;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.MotionEvent;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.ListView;

import com.google.android.glass.touchpad.Gesture;
import com.google.android.glass.touchpad.GestureDetector;

public class TestListActivity extends Activity {
	//Displays a gallery of photos and captions, navigable through swipe gestures
	
	private List<String> mTests;
	private ListView mListView;
	private GestureDetector mGestureDetector;
	private ArrayAdapter<String> mAdapter;
	
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.testlist);
		mListView=(ListView)findViewById(R.id.list);
		mTests=new ArrayList<String>();
			String[] testNames=getResources().getStringArray(R.array.test_names);
			mTests=Arrays.asList(testNames);
			mAdapter=new ArrayAdapter<String>(this,R.layout.listitem,mTests);
			mListView.setAdapter(mAdapter);
			mGestureDetector=createGestureDetector(this);
			mListView.setSelection(0);
		
	}
		
	
	
	private GestureDetector createGestureDetector(Context context){
		GestureDetector gestureDetector=new GestureDetector(context);
		gestureDetector.setBaseListener(new GestureDetector.BaseListener(){
			
			@Override
			//Gesture detection & handling mechanism
			public boolean onGesture(Gesture gesture){
				if(gesture ==Gesture.TAP){
					if(mListView.getSelectedItemPosition()==0){
						Intent intent=new Intent(TestListActivity.this,SequenceTest.class);
						Bundle b=new Bundle();
						b.putBoolean("isDigit", false);
						intent.putExtras(b);
						startActivity(intent);
					}
					else if(mListView.getSelectedItemPosition()==1){
						Intent intent=new Intent(TestListActivity.this,SequenceTest.class);
						Bundle b=new Bundle();
						b.putBoolean("isDigit", true);
						intent.putExtras(b);
						startActivity(intent);
					}
					else if(mListView.getSelectedItemPosition()==2){
						setContentView(R.layout.imagetest);
						ImageView astigmaTest=(ImageView)findViewById(R.id.visiontest);
						astigmaTest.setImageResource(R.drawable.astigmatism);
						
					}
					
					return true;
					
					
					
				}
				
				if (gesture == Gesture.TWO_TAP) {
					//default
	                return true;
	                
	            } else if (gesture == Gesture.SWIPE_RIGHT) {
	            	//default
	            	mListView.setSelection(mListView.getSelectedItemPosition()+1);	
	                return true;
	                
	            } else if (gesture == Gesture.SWIPE_LEFT) {
	            	mListView.setSelection(mListView.getSelectedItemPosition()-1);	
	            	//default	
	                return true;
	            }
	            return false;
				}
			});
		
		return gestureDetector;
		}
	
	
	@Override
	//passes all detected gestures/events to the custom GestureDetector
	public boolean onGenericMotionEvent(MotionEvent event) {
	        if (mGestureDetector != null) {
	            return mGestureDetector.onMotionEvent(event);
	        }
	        return false;
	    }
	    
	
	

		
		
		
}
