
package com.codetrix.model;

import com.codetrix.entities.common.IPersistenceEntity;
import com.codetrix.entities.localpersistence.RatingsLookupTable;
import com.codetrix.input.InputTextReader;
import com.codetrix.output.LocalToDbFormatter;
import java.io.FileNotFoundException;


public class LocalModel extends AbstractModel{
    
	private RatingsLookupTable lookup;
	
	
	@Override
	public void select(long id) {
	
	}

    @Override
    protected float computeSimilarityToNeighbor(IPersistenceEntity mainEntity, IPersistenceEntity neighborEntity) {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
    @Override
    protected void computePearsonCoefficients() {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    @Override
    public void fetchEntities() {
    	this.lookup = readInValuesFromTextInput();
    }

    @Override
    public void pushEntities() {
    	LocalToDbFormatter.outputToDb(lookup);
    }
    
    @Override
	protected void computePredictions() {
		// TODO Auto-generated method stub
		
	}
    
    public  RatingsLookupTable readInValuesFromTextInput()
    {
    	InputTextReader reader = new InputTextReader();
	    	
    	boolean readSuccesful;
    	do {
    					
			String fileName = promptWithAnswer("Enter filename (or enter for ratings.txt default) : ");
			
			if(fileName.isEmpty())
				fileName = "ratings.txt";
			
    		readSuccesful = false;    		
	    	try {
	    		readSuccesful = reader.readFromFile(fileName);
			} catch (FileNotFoundException e) {
				System.out.println("Invalid file name/path (" + fileName + ")");
				readSuccesful = false;
			}
	    	
    	} while(!readSuccesful);   
    	
    	return reader.getLookupTable();
    }

	
    
}
