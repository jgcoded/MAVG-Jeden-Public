package com.reddit.MakeAVideoGame.Core;

import java.awt.image.BufferedImage;
import java.io.File;
import java.io.FileNotFoundException;
import java.net.URL;
import java.util.Scanner;

import javax.imageio.ImageIO;

public class Utils {
	
	/** 
	 * 
	 * @param image - image file name example: "player.png"
	 * @return
	 */
	
	public static BufferedImage loadImage(String image){
		try { 
			return ImageIO.read(new URL(C.filePath + image));
		}
		catch (Exception e){
			System.out.println("Cannot load resource.");
			e.printStackTrace();
			return null;
		}
	}

	
	/**
	 * 
	 * @param filename - the name of the file you want to read, i.e Level1.txt
	 * @return - the file's content in string format
	 */
	public static String fileToString(String filename) {
		String fileToString = "";
		try {
			Scanner s = new Scanner(new File("Resources/" + filename));
			while(s.hasNextLine()) {
				fileToString += s.nextLine();
			}
			s.close();
		} 
		catch (FileNotFoundException e) {
			e.printStackTrace();
		}
		return fileToString;
	}
	
}
