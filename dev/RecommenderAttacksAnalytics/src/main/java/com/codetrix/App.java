package com.codetrix;

import com.codetrix.events.IFetchEntityEvent;
import com.codetrix.ui.MainAppFrame;
import javax.swing.JFrame;


import com.codetrix.ui.MainAppFrame;
import javax.swing.JFrame;

import com.codetrix.util.DatabaseInfos;

public class App implements IFetchEntityEvent
{
	
    public static void main( String[] args )
    {
    	System.out.println("Maven + Hibernate + Oracle");
    	
        /*
    	boolean exit = false;
		do
		{
			System.out.println("Select command: ");
			Scanner in = new Scanner(System.in);
			String input = in.next();
			switch(input)
			{
				case "1": readAndExportToDb();
					break;
				case "2": getSpecifiedUser();
					break;
				default:										
			}
				
		}
		while(!exit);
		
    	RatingsLookupTable lookup = readInValuesFromTextInput();
    	exportValuesToDb(lookup);
        */
             
        
        /* Create and display the form */
        java.awt.EventQueue.invokeLater(new Runnable() {

            public void run() {
                MainAppFrame frame = new MainAppFrame();
                frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                frame.setVisible(true);
            }
        });  
    }

    public void OnFetchEntity(long id) {
        
    }
  

    	
}


