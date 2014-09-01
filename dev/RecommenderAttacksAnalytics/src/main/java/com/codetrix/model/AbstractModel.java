
package com.codetrix.model;

import com.codetrix.entities.common.IPersistenceEntity;
import com.codetrix.entities.database.DBItem;
import com.codetrix.entities.database.DBUser;
import com.codetrix.entities.database.DBUserItemRating;
import java.util.HashMap;
import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Scanner;
import java.util.Set;


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
    
    protected  List<DBUser> getTestUsers()
    {
        DBUser secondUser = new DBUser(0);
        int[] secondUserRatings = {1,5,3,1,1};
        
        DBUser firstUser = new DBUser(1);
        int[] firstUserRatings = {1,4,3,4,5};
        
        assert  secondUserRatings.length == firstUserRatings.length;
        
        for(int i = 0; i < firstUserRatings.length; i++)
        {
            firstUser.addRatedItem(new DBItem(i), firstUserRatings[i]);
            secondUser.addRatedItem(new DBItem(i), secondUserRatings[i]);
        }
        
        List<DBUser> users = new LinkedList<>();
        users.add(firstUser);
        users.add(secondUser);
        
        return users;
    }
	
}
