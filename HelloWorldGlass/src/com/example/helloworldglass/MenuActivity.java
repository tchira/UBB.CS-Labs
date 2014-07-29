package com.example.helloworldglass;


import android.app.Activity;
import android.content.ComponentName;
import android.content.Intent;
import android.content.ServiceConnection;
import android.os.Bundle;
import android.os.Handler;
import android.os.IBinder;
import android.speech.tts.TextToSpeech;
import android.view.Menu;
import android.view.MenuItem;


public class MenuActivity extends Activity {
	//Main menu activity
	
	//Used to handle threading
	private final Handler mHandler=new Handler();
	
	@Override
	public void onAttachedToWindow(){
		//Called at activity start
		//Called when the view is attached to the device window
		super.onAttachedToWindow();
		openOptionsMenu();
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu){
		//Creates the activity menu using the template in res/menu/smenu.xml
		this.getMenuInflater().inflate(R.menu.smenu, menu);
		return true;
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		//Options menu
		
		switch(item.getItemId()){
			case R.id.show_tests:
				//Show photo gallery
				 startActivity(new Intent(this,TestListActivity.class));
				 return true;
			
			case R.id.stop:
				//Stops application(Options menu + Service)
				mHandler.post(new Runnable() {

                    @Override
                    public void run() {
                        stopService(new Intent(MenuActivity.this, HelloGlass.class));
                    }
                });
                return true;
				
			default:
				return super.onOptionsItemSelected(item);
				
		}
	}
	
	@Override
	public void onOptionsMenuClosed(Menu menu){
		finish();
	}
	
	protected void post (Runnable runnable){
		//Thread start function
		mHandler.post(runnable);
	}
}
