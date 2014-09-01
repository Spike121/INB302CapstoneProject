package com.codetrix.util;

public class Logger {
	
	public static void log(String str){
		
		System.out.println(str);
	}
	
	public static void logWarning(String str){
		
		System.err.println("Warning: " + str);
	}
	
	public static void logError(String str){
		
		System.err.println("Error: " + str);
	}

}
