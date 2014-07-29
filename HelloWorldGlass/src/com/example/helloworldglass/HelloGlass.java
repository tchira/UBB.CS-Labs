package com.example.helloworldglass;


import android.app.PendingIntent;
import android.app.Service;
import android.content.Intent;
import android.os.Handler;
import android.os.IBinder;
import android.speech.tts.TextToSpeech;
import android.widget.RemoteViews;

import com.google.android.glass.timeline.LiveCard;
import com.google.android.glass.timeline.LiveCard.PublishMode;

public class HelloGlass extends Service {
	
	//Main application service
	//Supports the TextToSpeech objects and triggers the menu activity
	
	private static final String LIVE_CARD_TAG="scroller";
	private LiveCard mLiveCard; //LiveCard instance
	private RemoteViews mLiveCardView; //LiveCard contents
	

	 @Override
	    public IBinder onBind(Intent intent) {
	        //If the service starts an activity and it expects data back from it, the connection is made through a binder
		 	//We need nothing from the menu activity -> returns null
	        return null;
	    }
	 
	 @Override
	 public void onCreate(){
		 //Service creation 
		 
		 super.onCreate();
	}
	 
	 @Override  
	 public int onStartCommand(Intent intent, int flags, int startId) {
	     //Called at service start
		 //Creates the LiveCard using the template in activity_main.xml
		 //Associates LiveCard tapping with starting the HelloWorldActivity (application menu)
		 //Attaches and publishes the LiveCard to the main timeline menu
		 
	      if(mLiveCard == null){
	    	  mLiveCard=new LiveCard(this, LIVE_CARD_TAG);
	    	  mLiveCardView=new RemoteViews(getPackageName(),R.layout.activity_main);
	    	  mLiveCard.setViews(mLiveCardView);
	    	  Intent menuIntent=new Intent(this,MenuActivity.class);
	    	  menuIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK | Intent.FLAG_ACTIVITY_CLEAR_TASK);
	    	  mLiveCard.setAction(PendingIntent.getActivity(this, 0, menuIntent, 0));
	    	  mLiveCard.attach(this);
	    	  mLiveCard.publish(PublishMode.REVEAL);
	    	 
	      }
	      return START_STICKY;
	    } 
	    
	 @Override   
	 public void onDestroy(){
		 //Called at service finish
		 //Takes the LiveCard off the main timeline and deletes it, deletes the TextToSpeech object
	    	if(mLiveCard!=null){
	    		mLiveCard.unpublish();
	    		mLiveCard=null;
	    	}
	    	
	    	super.onDestroy();
	    }
	    

}
	    
	 

	
