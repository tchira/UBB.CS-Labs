package com.example.helloworldglass;

import java.util.Random;

import com.google.android.glass.touchpad.Gesture;
import com.google.android.glass.touchpad.GestureDetector;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.graphics.Color;
import android.os.Bundle;
import android.view.Gravity;
import android.view.MotionEvent;
import android.widget.TextView;

public class SequenceTest extends Activity {
	private Boolean isDigit;
	private TextView seqDisplay;
	private GestureDetector mGestureDetector;
	private int it;
	

	@Override
	protected void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		mGestureDetector=this.createGestureDetector(this);
		Bundle b=this.getIntent().getExtras();
		isDigit=b.getBoolean("isDigit");
		seqDisplay=new TextView(this);
		seqDisplay.setGravity(Gravity.CENTER);
		seqDisplay.setText(generateSequence(isDigit));
		seqDisplay.setBackgroundColor(Color.WHITE);
		seqDisplay.setTextColor(Color.BLACK);
		seqDisplay.setTextSize(11);
		setContentView(seqDisplay);
	}
	
	private GestureDetector createGestureDetector(Context context){
		GestureDetector gestureDetector=new GestureDetector(context);
		gestureDetector.setBaseListener(new GestureDetector.BaseListener(){
			
			@Override
			//Gesture detection & handling mechanism
			public boolean onGesture(Gesture gesture){
				if(gesture ==Gesture.TAP){
					seqDisplay.setText(generateSequence(isDigit));
					
					return true;
				}
				return false;
				}
			});
		
		return gestureDetector;
		}
	
	@Override
	public boolean onGenericMotionEvent(MotionEvent event) {
	        if (mGestureDetector != null) {
	            return mGestureDetector.onMotionEvent(event);
	        }
	        return false;
	    }
	
	public String generateSequence(Boolean digit){
		 StringBuilder sb = new StringBuilder();
		Random generator=new Random(System.currentTimeMillis());
		if(digit){
			  for(int i = 0; i < 5; i++) {
				  int randomNum = generator.nextInt((57 - 48) + 1) + 48;
			        char c = (char)randomNum;
			        sb.append(c);
			        sb.append("				");
			    }
			    return sb.toString();
			}
		else {
			
			    for(int i = 0; i < 5; i++) {
			    	int randomNum = generator.nextInt((90 - 65) + 1) + 65;
			        char c = (char)randomNum;
			        sb.append(c);
			        sb.append("				");
			    }
			    return sb.toString();
			
			
		}
	}
		
}
			
		

