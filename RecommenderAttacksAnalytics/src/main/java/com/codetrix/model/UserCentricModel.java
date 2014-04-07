
package com.codetrix.model;


import java.util.HashMap;
import java.util.List;
import java.util.Map;

import org.hibernate.Query;
import org.hibernate.Session;

import com.codetrix.entities.database.DBUser;
import com.codetrix.entities.localpersistence.RatingsLookupTable;
import com.codetrix.entities.common.IPersistenceEntity;
import com.codetrix.entities.common.EntityEntityPair;

import com.codetrix.output.LocalToDbFormatter;
import com.codetrix.util.DatabaseInfos;
import com.codetrix.util.HibernateUtil;
import java.util.LinkedList;


public class UserCentricModel extends AbstractModel {
    
    private DatabaseInfos dbInfos; 
    private DBUser selectedUser;
    private List<DBUser> users = new LinkedList<DBUser>();
    private Map<DBUser, Float> pearsonValuesMap = new HashMap<DBUser, Float>();
    private float similarityCutoff = 0.1f;
    
    public UserCentricModel(DatabaseInfos infos)
    {
        this.dbInfos = infos;
    }
  
    @Override
	public void select(long id) {
    	//if()
	}
    
    // TODO: Can be placed in AbstractModel
    @Override
    protected float computeSimilarityToNeighbor(IPersistenceEntity user, IPersistenceEntity neighbor)
    {	
    	float resultTop = (user.diffFromAverage() * neighbor.diffFromAverage());
    	float resultBottomLeft = (float) Math.sqrt(user.diffFromAverageSquared());
    	float resultBottomRight = (float) Math.sqrt(neighbor.diffFromAverageSquared());
  
    	return (resultTop / (resultBottomLeft * resultBottomRight));
    }

    @Override
    protected void computePearsonCoefficients() {
    	pearsonValuesMap = new HashMap<DBUser, Float>();
    	for(DBUser neighbor : users)
    	{
    		if(neighbor.getId() == selectedUser.getId())
    			continue;
    		else
    		{	
    			Float coefficient = computeSimilarityToNeighbor(selectedUser, neighbor);
    			if(coefficient >= similarityCutoff)
    				pearsonValuesMap.put(neighbor, coefficient);
    		}
    	}	
    }

    @Override
    public void fetchEntities() {
    	Session session = HibernateUtil.getSessionFactory().openSession();
     	Query query = session.createQuery("from DBUser");
     	users = query.list();
    	
     	HibernateUtil.shutdown();
    }

    @Override
    public void pushEntities() {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
    @Override
	protected void computePredictions() {
		
		
	}
    
    private float getPearsonAbsoluteCoefficientsSum()
    {
    	float totalCoefficient = 0.0f;
    	for(Float coefficient :  pearsonValuesMap.values())
    		totalCoefficient += Math.abs(coefficient);
    	
    	return totalCoefficient;
    }
   
    /*
    private float get()
    {
    	
    }
    */
    
    private void getPredictedScoreForItem()
    {
    	
    }
        
    
    public DBUser getSpecifiedUser()
    {
    	long userId = Long.parseLong(promptWithAnswer("Input user number: "));
    	return getUser(userId);
    }
    
    public  DBUser getUser(long userId)
    {    	
    	Session session = HibernateUtil.getSessionFactory().openSession();
    	Query query = session.createQuery("from DBUser where userId = :id");
    	query.setParameter("id", userId);
    	
    	List<DBUser> list = query.list();	
    	DBUser user = list.get(0);
    	
    	HibernateUtil.shutdown();
    	
    	return user;
    }

	
    
    
    
	
    
}
