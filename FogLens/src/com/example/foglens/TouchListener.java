package com.example.foglens;

import android.view.MotionEvent;
import android.view.View;
import android.widget.ImageView;
import android.widget.RelativeLayout;

public class TouchListener implements View.OnTouchListener {
	
	  private int _xDelta;
	   private int _yDelta;
	   View j;
	   
	   public boolean onTouch(View view, MotionEvent event) {
	        final int X = (int) event.getRawX();
	        final int Y = (int) event.getRawY();
	        j=(View)view;
	        switch (event.getAction() & MotionEvent.ACTION_MASK) {
	            case MotionEvent.ACTION_DOWN:
	                RelativeLayout.LayoutParams lParams = (RelativeLayout.LayoutParams) view.getLayoutParams();
	                _xDelta = (int) (X - j.getTranslationX());
	                _yDelta = (int) (Y - j.getTranslationY());
	                break;
	            case MotionEvent.ACTION_UP:
	                break;
	            case MotionEvent.ACTION_POINTER_DOWN:
	                break;
	            case MotionEvent.ACTION_POINTER_UP:
	                break;
	            case MotionEvent.ACTION_MOVE:
	                RelativeLayout.LayoutParams layoutParams = (RelativeLayout.LayoutParams) view.getLayoutParams();

	                j.setTranslationX(X - _xDelta);
	                j.setTranslationY(Y - _yDelta);
	                break;
	        }

	        return true;
	    }
	
}
