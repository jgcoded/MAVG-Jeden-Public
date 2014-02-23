package com.reddit.MakeAVideoGame.Core;

public class GameThread extends Thread {

	
	public GameThread(Runnable r) {
		super(r);
		start();
	}
}
