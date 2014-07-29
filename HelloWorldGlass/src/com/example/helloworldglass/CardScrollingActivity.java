/*
package com.example.helloworldglass;

import java.util.ArrayList;
import java.util.List;

import android.app.Activity;
import android.content.Context;
import android.content.res.TypedArray;
import android.os.Bundle;
import android.speech.tts.TextToSpeech;
import android.view.Gravity;
import android.view.MotionEvent;
import android.view.View;
import android.view.ViewGroup;
import android.view.ViewGroup.LayoutParams;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import com.google.android.glass.app.Card;
import com.google.android.glass.touchpad.Gesture;
import com.google.android.glass.touchpad.GestureDetector;
import com.google.android.glass.widget.CardScrollAdapter;
import com.google.android.glass.widget.CardScrollView;

public class CardScrollingActivity extends Activity {
	
	//Alternate CardScrollView, using static cards instead of views
	//Not currently used

	private List<Card> mCards;
	
	private CardScrollView mCardScrollView;
	private GestureDetector mGestureDetector;
	private TextToSpeech mSpeech;
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState){
		mSpeech = new TextToSpeech(this, new TextToSpeech.OnInitListener() {
            @Override
            public void onInit(int status) {
                // Do nothing.
            }
        });

		super.onCreate(savedInstanceState);
		createCards();
		mCardScrollView=new CardScrollView(this);
		PhotoAdapter adapter=new PhotoAdapter();
		
		mCardScrollView.setAdapter(adapter);
		mCardScrollView.activate();
		setContentView(mCardScrollView);
		mGestureDetector=createGestureDetector(this);
	}
	
	private GestureDetector createGestureDetector(Context context){
		GestureDetector gestureDetector=new GestureDetector(context);
		gestureDetector.setBaseListener(new GestureDetector.BaseListener(){
			@Override
			public boolean onGesture(Gesture gesture){
				if(gesture==Gesture.TAP||gesture==Gesture.LONG_PRESS){
					String caption=(String)((Card)mCardScrollView.getSelectedItem()).getText();
					mSpeech.speak(caption, TextToSpeech.QUEUE_FLUSH, null);
					return true;
				}
				else if (gesture == Gesture.TWO_TAP) {

	                return true;
	            } else if (gesture == Gesture.SWIPE_RIGHT) {

	                return true;
	            } else if (gesture == Gesture.SWIPE_LEFT) {

	                return true;
	            }else if (gesture == Gesture.TWO_SWIPE_LEFT) {
	            	
	                return true;
	            }
	            else if (gesture == Gesture.TWO_SWIPE_RIGHT) {
	            	
	                return true;
	            }
				
				
				return false;
				}
			});
		
		gestureDetector.setTwoFingerScrollListener(new GestureDetector.TwoFingerScrollListener(){
			
			@Override
			public boolean onTwoFingerScroll(float arg0, float arg1, float arg2) {
			
				return true;
				// TODO Auto-generated method stub
				
				
			}
		});
		
		gestureDetector.setFingerListener(new GestureDetector.FingerListener() {
            @Override
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
	public boolean onGenericMotionEvent(MotionEvent event) {
	        if (mGestureDetector != null) {
	            return mGestureDetector.onMotionEvent(event);
	        }
	        return false;
	    }
	    
	
	
	private void createCards(){
		String[] cardTexts=getResources().getStringArray(R.array.photo_text);
		TypedArray imgs=getResources().obtainTypedArray(R.array.photo_src);
		mCards=new ArrayList<Card>();
		Card card;
		int resId;
		
		for (int id=0;id<cardTexts.length;id++){
			card=new Card(this);
			card.setImageLayout(Card.ImageLayout.FULL);
			card.setText(cardTexts[id]);
			resId=imgs.getResourceId(id, -1);
			if(resId!=-1)
				card.addImage(resId);
			mCards.add(card);
		}
		
	}
	

	private class PhotoAdapter extends CardScrollAdapter {
		
		private class ViewHolder{
			private ImageView background;
			private TextView smallText;
			private TextView mediumText;
			private TextView largeText;
		}
		
		@Override
		public int getPosition(Object item){
			return mCards.indexOf(item);
		}
		
		@Override
		public int getCount(){
			return mCards.size();
		}
		
		@Override
		public Object getItem(int pos){
			return mCards.get(pos);
		}
		
		
		
		@Override
		public int getViewTypeCount(){
			return Card.getViewTypeCount();
		}
		
		@Override
		public int getItemViewType(int pos){
			return mCards.get(pos).getItemViewType();
		}
		
		
		@Override
		public View getView(int pos, View convertView, ViewGroup parent){
			return mCards.get(pos).getView(convertView,parent);
			
			
		}
	}
		
		
	}

*/