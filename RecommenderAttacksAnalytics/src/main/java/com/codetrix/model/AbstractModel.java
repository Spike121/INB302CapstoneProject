
package com.codetrix.model;

import com.codetrix.entities.common.IPersistenceEntity;
import com.codetrix.entities.database.DBItem;
import java.util.HashMap;
import java.util.Map;
import java.util.Scanner;


public abstract class AbstractModel {
    
    public abstract void fetchEntities();
    public abstract void pushEntities();
    public abstract void select(long id);
    public void addFakeProfiles(DBItem productToPromote, int numOfProfiles) {}
    
    protected Map<DBItem, Float> itemsScorePredictions = new HashMap<>();
    
    protected abstract float computeSimilarityToNeighbor(IPersistenceEntity mainEntity, IPersistenceEntity neighborEntity);
    protected abstract void computePearsonCoefficients();
    protected abstract void computePredictions();
   
    public Map<DBItem, Float> getPredictions()
    {
        return itemsScorePredictions;
    }
    
    protected  String promptWithAnswer(String str)
    {
    	System.out.println(str);
		Scanner in = new Scanner(System.in);			
		return in.nextLine();
    }
	
}
