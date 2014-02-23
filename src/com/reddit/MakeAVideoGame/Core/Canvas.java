package com.reddit.MakeAVideoGame.Core;

import java.applet.Applet;
import java.awt.Color;
import java.awt.Graphics;
import java.awt.Image;
import java.awt.image.BufferedImage;


public class Canvas extends Applet implements Runnable {

	//Just to get rid of the warning at the top in some IDEs
	private static final long serialVersionUID = 1L;
	
	//This method initializes variables to their original state.
	public void init() {
		thread = new GameThread(this);
		C.w = getWidth();
		C.h = getHeight();
		buffer = new BufferedImage(getWidth(), getHeight(), 1);
		g2d = buffer.createGraphics();
		offscreenImage = createImage(C.w, C.h);
		offscreen = offscreenImage.getGraphics();
		C.filePath = getCodeBase() + "Resources/";
		addKeyListener(new Keyboard());
		System.out.println(Utils.fileToString("test.txt"));
		this.start();
	}
	
	
	public void run() {
		Thread temp = Thread.currentThread();
		while(temp == thread) {
			try {
				Thread.sleep(30);
				repaint();
			}
			catch(Exception e) {e.printStackTrace();}
		}
	}
	

	/**
	 * TODO: Draw something!
	 */
	public void paint(Graphics g) {
		g.setColor(Color.green);
		g.fillRect(0, 0, C.w, C.h);
		//Don't hate on test.png, he's beautiful.
		g.drawImage(Utils.loadImage("test.png"), 0,0, null);
	}
	
	
	//This method removes the flickering that is caused by drawing too often.
	public void update(Graphics g){
		if (dbImage == null) {
			dbImage = createImage(C.w, C.h);
			dbg = dbImage.getGraphics();
		}
		dbg.setColor(getBackground());
		dbg.fillRect(0, 0, C.w, C.h);
		dbg.setColor(getForeground());
		paint(dbg);
		g.drawImage(dbImage, 0, 0, this);
	}

	
	private Image dbImage;
	private Graphics dbg;
	private Graphics g2d;
	private BufferedImage buffer;
	private Image offscreenImage;
	private Graphics offscreen;
	GameThread thread;
}
