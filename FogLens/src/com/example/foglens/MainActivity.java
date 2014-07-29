package com.example.foglens;

import android.app.Activity;
import android.hardware.Camera;
import android.media.AudioFormat;
import android.media.AudioRecord;
import android.media.MediaRecorder.AudioSource;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import android.widget.ImageView;
import android.widget.RelativeLayout;
import android.widget.SeekBar;
import android.widget.SeekBar.OnSeekBarChangeListener;
import android.widget.Toast;

import com.example.drawtools.DrawTools;

public class MainActivity extends Activity implements OnSeekBarChangeListener {
  
  private SurfaceView preview=null;
  private SurfaceHolder previewHolder=null;
  private Camera camera=null;
  private boolean inPreview=false;
  private boolean cameraConfigured=false;
  private SeekBar mOpacityBar=null;
  private ImageView fogView,lensView;
  private DrawTools dTools;
  private Thread rThread;
  private int numCrossing,p;
  private short audioData[];
  private int bufferSize;
  private AudioRecord recorder;
  private int frequency; 
  private int amplitude;
  private double lastLevel;
  
  
  //Recorder constants
  private static final int SAMPLE_DELAY = 75;
  private static final int AMP_LIMIT=15000;
  private static final int FREQ_LIMIT=80;
  
  
  //
  //Layout initialisation
  //
  
  @Override
  public void onCreate(Bundle savedInstanceState) {
    super.onCreate(savedInstanceState);
    setContentView(R.layout.activity_main);
    this.initViews();
    bufferSize=AudioRecord.getMinBufferSize(8000,AudioFormat.CHANNEL_IN_MONO,
	AudioFormat.ENCODING_PCM_16BIT)*3; //get the buffer size to use with this audio record
    }

 
 private void initViews(){
	  
	    dTools=new DrawTools(this);
	    //fog texture
	    fogView=(ImageView)this.findViewById(R.id.maskedTexture);
	    fogView.setImageBitmap(dTools.getMaskedBitmap(105));	//align lens with texture
	    fogView.setTranslationY(fogView.getTranslationY()+20);
	    
	    //lens overlay
	    lensView=(ImageView)this.findViewById(R.id.lens);
	    lensView.setImageResource(R.drawable.lens);
	    
	    //camera preview
	    preview=(SurfaceView)findViewById(R.id.preview);
	    previewHolder=preview.getHolder();
	    previewHolder.addCallback(surfaceCallback);
	   
	    RelativeLayout rl=(RelativeLayout)findViewById(R.id.foglens);	//set dragging for the lens
	    rl.setOnTouchListener(new TouchListener());
	    
	    //slider
	    mOpacityBar=(SeekBar)this.findViewById(R.id.seekBarID);
	    mOpacityBar.setProgress(105);
	    mOpacityBar.setOnSeekBarChangeListener(this);
}
 
 private void initRecorder(){
	 			recorder = new AudioRecord (AudioSource.MIC,8000,AudioFormat.CHANNEL_IN_MONO,
				AudioFormat.ENCODING_PCM_16BIT,bufferSize); //instantiate the AudioRecorder 
				                
				recorder.startRecording();
				rThread = new Thread(new Runnable() {
				        public void run() {
				        	while(rThread != null && !rThread.isInterrupted()){
				        		try{Thread.sleep(SAMPLE_DELAY);}catch(InterruptedException ie){ie.printStackTrace();}
				        		readAudioBuffer();
								
								runOnUiThread(new Runnable() {
									
									@Override
									public void run() {
										Log.e("FREQ",Double.toString(frequency));
										Log.e("AMP",Double.toString(amplitude));
										
										if(amplitude>AMP_LIMIT&&frequency<FREQ_LIMIT){
											fogView.setImageBitmap(dTools.getMaskedBitmap(mOpacityBar.getProgress()+10));
											mOpacityBar.setProgress(mOpacityBar.getProgress()+10);
										}
										
									}
								});
				        	}
				        }
				    });
				rThread.start();
 }
  
 private void readAudioBuffer() {
	 
	try {
		audioData = new short [bufferSize]; //short array that pcm data is put into.
			
			recorder.read(audioData,0,bufferSize); //read the PCM audio data into the audioData array
	          
		    //Now we need to decode the PCM data using the Zero Crossings Method
		                            
		    numCrossing=0; //initialize your number of zero crossings to 0
		    for (p=0;p<bufferSize/4;p+=4) {
		           if (audioData[p]>0 && audioData[p+1]<=0) numCrossing++;
		            if (audioData[p]<0 && audioData[p+1]>=0) numCrossing++;
		            if (audioData[p+1]>0 && audioData[p+2]<=0) numCrossing++;
		            if (audioData[p+1]<0 && audioData[p+2]>=0) numCrossing++;
		            if (audioData[p+2]>0 && audioData[p+3]<=0) numCrossing++;
		            if (audioData[p+2]<0 && audioData[p+3]>=0) numCrossing++;
		            if (audioData[p+3]>0 && audioData[p+4]<=0) numCrossing++;
		            if (audioData[p+3]<0 && audioData[p+4]>=0) numCrossing++;
		            }//for p
		    
		      for (p=(bufferSize/4)*4;p<bufferSize-1;p++) {
		            if (audioData[p]>0 && audioData[p+1]<=0) numCrossing++;
		            if (audioData[p]<0 && audioData[p+1]>=0) numCrossing++;
		            }
		                                            
		                                            
			for (short s : audioData) { amplitude += Math.abs(s); } 
			amplitude=amplitude/1000;
			frequency=(8000/bufferSize)*(numCrossing/2); 
			
			

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
 
 
 
 //
  //Camera preview implementation
  //
  
  @Override
  public void onResume() {
    super.onResume();
    camera=Camera.open();
    startPreview();
    initRecorder();
	
  }
    
  
  
  @Override
  public void onPause() {
	  //intrerrupt camera and recorder thread
	  
	  super.onPause();
	  if (inPreview) {
      camera.stopPreview();
    }
    rThread.interrupt();
    rThread=null;
    try{
    	if(recorder!=null){
    		recorder.stop();
    		recorder.release();
    		recorder=null;
    	}
    }
    catch(Exception e){e.printStackTrace();}
    
    camera.release();
    camera=null;
    inPreview=false;
          
   
  }
  
  private Camera.Size getBestPreviewSize(int width, int height,
                                         Camera.Parameters parameters) {
    Camera.Size result=null;
    
    for (Camera.Size size : parameters.getSupportedPreviewSizes()) {
      if (size.width<=width && size.height<=height) {
        if (result==null) {
          result=size;
        }
        else {
          int resultArea=result.width*result.height;
          int newArea=size.width*size.height;
          
          if (newArea>resultArea) {
            result=size;
          }
        }
      }
    }
    
    return(result);
  }
  
  private void initPreview(int width, int height) {
    if (camera!=null && previewHolder.getSurface()!=null) {
      try {
        camera.setPreviewDisplay(previewHolder);
      }
      catch (Throwable t) {
        Log.e("PreviewDemo-surfaceCallback",
              "Exception in setPreviewDisplay()", t);
        Toast
          .makeText(MainActivity.this, t.getMessage(), Toast.LENGTH_LONG)
          .show();
      }

      if (!cameraConfigured) {
        Camera.Parameters parameters=camera.getParameters();
        Camera.Size size=getBestPreviewSize(width, height,
                                            parameters);
        
        if (size!=null) {
          parameters.setPreviewSize(size.width, size.height);
          camera.setParameters(parameters);
          cameraConfigured=true;
        }
      }
    }
  }
  
  private void startPreview() {
    if (cameraConfigured && camera!=null) {
      camera.startPreview();
      inPreview=true;
    }
  }
  
  SurfaceHolder.Callback surfaceCallback=new SurfaceHolder.Callback() {
    public void surfaceCreated(SurfaceHolder holder) {
      // no-op -- wait until surfaceChanged()
    }
    
    public void surfaceChanged(SurfaceHolder holder,
                               int format, int width,
                               int height) {
      initPreview(width, height);
      startPreview();
    }
    
    public void surfaceDestroyed(SurfaceHolder holder) {
      // no-op
    }
  };
  
  
  
  
  
  
  //
  //SeekBar Listener implementation
  //
  
  @Override
  public void onStopTrackingTouch(SeekBar seekBar) {
      // TODO Auto-generated method stub

  }

  @Override
  public void onStartTrackingTouch(SeekBar seekBar) {
      // TODO Auto-generated method stub

  }

  @Override
  public void onProgressChanged(SeekBar seekBar, int progress,
          boolean fromUser) {
      // TODO Auto-generated method stub
	 int opacity=progress;
	 if(fogView!=null)
		 fogView.setImageBitmap(dTools.getMaskedBitmap(opacity));
	 
  }
  
  
  
 
}