/*
package com.example.helloworldglass;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.content.res.TypedArray;
import android.os.Bundle;
import android.speech.tts.TextToSpeech;
import android.view.LayoutInflater;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import com.google.android.glass.app.Card;
import com.google.android.glass.touchpad.Gesture;
import com.google.android.glass.touchpad.GestureDetector;
import com.google.android.glass.widget.CardScrollAdapter;
import com.google.android.glass.widget.CardScrollView;

public class ViewScrollingActivity extends Activity {
	//Displays a gallery of photos and captions, navigable through swipe gestures
	
	
	
	private List<View> mViews;
	private CardScrollView mCardScrollView;
	private GestureDetector mGestureDetector;
	private TextToSpeech mSpeech;
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState){
		//Called on activity creation
		//Creates TextToSpeech object, used to read captions
		mSpeech = new TextToSpeech(this, new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                // Do nothing.
            }
        });

		super.onCreate(savedInstanceState);
		
		//Populates mViews with data 
		createViews();  
		
		//The CardScrollView is used as the photo display mechanism, using the views supplied by the adapter(defined below)
		mCardScrollView=new CardScrollView(this);
		PhotoAdapter adapter=new PhotoAdapter();
		mCardScrollView.setAdapter(adapter);
		mCardScrollView.activate();
		
		//Sets the screen content to the CardScrollView
		setContentView(mCardScrollView);
		
		//Used to detect swipes and taps
		mGestureDetector=createGestureDetector(this);
	}
	
	
	private GestureDetector createGestureDetector(Context context){
		GestureDetector gestureDetector=new GestureDetector(context);
		gestureDetector.setBaseListener(new GestureDetector.BaseListener(){
			
			@Override
			//Gesture detection & handling mechanism
			public boolean onGesture(Gesture gesture){
				if(gesture==Gesture.TAP||gesture==Gesture.LONG_PRESS){
					//if Glass is tapped or pressed, gets the current selected view's TextView caption and speaks it using TextToSpeech
					String caption=(String)(((TextView)((View)mCardScrollView.getSelectedItem()).findViewById(R.id.largeText)).getText());
					mSpeech.speak(caption, TextToSpeech.QUEUE_FLUSH, null);
					return true;
				}
				else if (gesture == Gesture.TWO_TAP) {
					//default
	                return true;
	                
	            } else if (gesture == Gesture.SWIPE_RIGHT) {
	            	//default
	                return true;
	                
	            } else if (gesture == Gesture.SWIPE_LEFT) {
	            	//default	
	                return true;
	                
	            } else if (gesture == Gesture.TWO_SWIPE_RIGHT) {
	            	//if swiped right with two fingers, double current TextView's font size
	            	TextView tv=(TextView)((View)mCardScrollView.getSelectedItem()).findViewById(R.id.swipeText);
	            	tv.setTextSize(tv.getTextSize()*2);
	            	return true;
	            	
	            }
	            else if (gesture == Gesture.TWO_SWIPE_LEFT) {
	            	//if swiped left with two fingers, halve current TextView's font size
	            	TextView tv=(TextView)((View)mCardScrollView.getSelectedItem()).findViewById(R.id.swipeText);
	            	tv.setTextSize(tv.getTextSize()/2);
	                return true;
	            }
				return false;
				}
			});
		
		
			gestureDetector.setTwoFingerScrollListener(new GestureDetector.TwoFingerScrollListener(){
			@Override
			//Enables two finger scrolling
			//Two finger scrolling is handled in the onGesture trigger
			public boolean onTwoFingerScroll(float arg0, float arg1, float arg2) {
			
				return true;
				// TODO Auto-generated method stub
				
				
			}
		});
		
		gestureDetector.setFingerListener(new GestureDetector.FingerListener() {
            @Override
            //Counts number of fingers used for gestures
            //if 2 fingers are detected,deactivates photo scrolling 
            //used for font size changes without interference
            
            public void onFingerCountChanged(int previousCount, int currentCount) {
            	 if(currentCount == 2){
                     mCardScrollView.deactivate();
                 }else{
                	 mCardScrollView.activate();
                 }
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
	    
	
	
	private void createViews(){
		//Used to populate mViews
		//gets all photo sources and captions from values/cardlist.xml
		//Photo and caption arrays can contain empty items (only text/only photos)
		String[] cardTexts=getResources().getStringArray(R.array.photo_text);
		TypedArray imgs=getResources().obtainTypedArray(R.array.photo_src);
		LayoutInflater inflater = (LayoutInflater)this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
		
		mViews=new ArrayList<View>();
		View newView;
		int resId;
		
		for (int id=0;id<cardTexts.length;id++){
			//instantiates views using the layout/singletext.xml template for a single line with modifiable font size
			//can use layout/cardlayout.xml for 3 lines of text with different fixed font sizez
			
		    	newView=inflater.inflate(R.layout.cardlayout,null);
				//newView=inflater.inflate(R.layout.singletext,null);
			
			//gets image from the image array, adds it to the ImageView
			//resId=-1 if image is not found
			ImageView iv=(ImageView)newView.findViewById(R.id.cardImage);
			resId=imgs.getResourceId(id, -1);
			if(resId!=-1)
				iv.setImageResource(resId);
			//gets photo captions, adds it to the TextView
			
			TextView tv=(TextView)newView.findViewById(R.id.swipeText);
			tv.setText(cardTexts[id]);
			
			
			//Used in conjunction with cardlayout.xml
				TextView tv=(TextView)newView.findViewById(R.id.smallText);
				tv.setText(cardTexts[id]);
				tv=(TextView)newView.findViewById(R.id.mediumText);
				tv.setText(cardTexts[id]);
				tv=(TextView)newView.findViewById(R.id.largeText);
				tv.setText(cardTexts[id]);
				
			
			mViews.add(newView);
		}
		
	}
	

	private class PhotoAdapter extends CardScrollAdapter {
		//Custom adapter feeding the created mViews to the CardScrollView
		@Override
		public int getPosition(Object item){
			return mViews.indexOf(item);
		}
		
		@Override
		public int getCount(){
			return mViews.size();
		}
		
		@Override
		public Object getItem(int pos){
			return mViews.get(pos);
		}
		
		
		@Override
		public View getView(int pos, View convertView, ViewGroup parent){
			return mViews.get(pos);
			
		}
	}
		
		
	}
	
*/
	
