
package com.codetrix.model;

import com.codetrix.entities.common.IPersistenceEntity;
import java.util.Scanner;


public abstract class AbstractModel {
    
    
    
    public abstract void fetchEntities();
    public abstract void pushEntities();
    public abstract void select(long id);
    
    protected abstract float computeSimilarityToNeighbor(IPersistenceEntity mainEntity, IPersistenceEntity neighborEntity);
    protected abstract void computePearsonCoefficients();
    protected abstract void computePredictions();
    
    protected  String promptWithAnswer(String str)
    {
    	System.out.println(str);
		Scanner in = new Scanner(System.in);			
		return in.nextLine();
    }
}
