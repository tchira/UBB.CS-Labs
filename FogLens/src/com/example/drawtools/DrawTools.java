package com.example.drawtools;


import android.content.Context;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.Bitmap.Config;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.PorterDuff;
import android.graphics.PorterDuffXfermode;
import android.os.Build;
import android.view.Display;
import android.view.WindowManager;

import com.example.foglens.R;

public class DrawTools {
	
	private Bitmap sourceTexture;
	private Bitmap lensMask;
	private Bitmap lensOverlay;
	private Context mContext;
	private int mWidth,mHeight;
	
	public DrawTools(Context context){
		this.mContext=context;
		this.getBitmapResources();
		
	}
	
	private void getBitmapResources(){
		
		Resources res = mContext.getResources();
		BitmapFactory.Options options = new BitmapFactory.Options();
		  
		  options.inPreferredConfig = Bitmap.Config.ARGB_8888;
		  Bitmap source = BitmapFactory.decodeResource(res,R.drawable.fog, options);
		  source.setHasAlpha(true);
		  this.sourceTexture=source;
		  
		  Bitmap mask = BitmapFactory.decodeResource(res,R.drawable.mask);
		  this.lensMask=mask;
		  
		  Bitmap lens = BitmapFactory.decodeResource(res,R.drawable.lens);
		  lens.setHasAlpha(true);
		  this.lensOverlay=lens;
	}
	
	public Bitmap getMaskedBitmap(int opacity) {
		
		int width = lensMask.getWidth();
	    int height = lensMask.getHeight();
	    Bitmap output= Bitmap.createBitmap(width, height, Config.ARGB_8888);  
	    
	    Canvas canvas=new Canvas(output);
	    Paint paint = new Paint();
	    paint.setAlpha(opacity);
	    canvas.drawBitmap(sourceTexture, 0, 0, paint);
		paint.setAlpha(255);
	    paint.setXfermode(new PorterDuffXfermode(PorterDuff.Mode.DST_IN));
		canvas.drawBitmap(lensMask, 0, 0, paint);
		return output;
	}
	
}
