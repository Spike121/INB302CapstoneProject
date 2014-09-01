
package com.codetrix.model;


import com.codetrix.entities.common.IPersistenceEntity;
import com.codetrix.entities.database.DBItem;
import com.codetrix.entities.database.DBUser;
import com.codetrix.entities.database.DBUserItemRating;
import com.codetrix.util.DatabaseInfos;
import com.codetrix.util.HibernateUtil;
import java.util.Collections;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Random;
import java.util.Map.Entry;
import java.util.Set;
import org.hibernate.Hibernate;
import org.hibernate.Query;
import org.hibernate.Session;


public class UserCentricModel extends AbstractModel {
    
    private DatabaseInfos dbInfos; 
    private DBUser selectedUser;
    private List<DBUser> users = new LinkedList<>();
    private Map<DBUser, Float> pearsonValuesMap = new HashMap<>();
    
    
    private final float similarityCutoff = 0.1f;
    
    
    
    public UserCentricModel()
    {
    	
    }
    
    public UserCentricModel(DatabaseInfos infos)
    {
        this.dbInfos = infos;
    }
  
    @Override
    public void select(long id) {
        users = getTestUsers();
        selectedUser = users.get(0);
        computePredictions();
        /*
        fetchEntities();
       
        try{
            
            selectedUser = findUser(id);
            System.out.println(selectedUser.getItemRatingsAverage());
            computePredictions();
            
        } catch(UserNotFoundException e) {
            //TODO: Notify error to user through GUI
            System.out.println("User not found");
        }
        finally{
            HibernateUtil.shutdown();
        }
        */
        
        
        for(Entry<DBItem, Float> entry : itemsScorePredictions.entrySet())
        {
            //Logger.log(entry.getKey().getId());
            System.out.println("Item " + entry.getKey().getId() + ":  " + entry.getValue());
        }
    }
    
    
    //Not 100% Sure if this is even right, because so many methods are implemented more than once
    //Did I even use the right methods? Does addRatedItem even get used?
    //Will recomputing even check new UserItemRatings? Fuck knows. 
    @Override
    public void addFakeProfiles(DBItem productToPromote, int numOfProfiles) {
		Random randomRating = new Random(); //will be used when randomly rating a random product
    	for(int i = 0; i < numOfProfiles; i++) {
    		//Create a new user
    		DBUser newUser = new DBUser(9999 - i);
    		//Promote the main product
    		newUser.addRatedItem(productToPromote, 5);
    		
    		//Randomly rate a random number of other products
    		//NEED TO FIGURE THIS PART OUT STILL
			//NOT SURE HOW TO SELECT A RANDOM ITEM
    		//CURRENTLY Randomly rates the top however many predictions
    		for(Map.Entry<DBItem, Float> entry : getPredictions().entrySet())
    	    {
    			DBItem randomItem = entry.getKey();
    			newUser.addRatedItem(randomItem, randomRating.nextInt(5));	
    	    }
    	}
    }
  
    
    
    private DBUser findUser(long id) throws UserNotFoundException {
        for(DBUser user : users)
        {
            if(user.getId() == id)
                return user;
        }
        
        throw new UserNotFoundException();
    }
    
    // TODO: Could be placed in AbstractModel
    @Override
    protected float computeSimilarityToNeighbor(IPersistenceEntity user, IPersistenceEntity neighbor)
    {	
        List<DBItem> intemsInCommon = getCommonItems();
    	float resultTop = (user.diffFromAverage() * neighbor.diffFromAverage());
    	float resultBottomLeft = (float) Math.sqrt(user.diffFromAverageSquared());
        float resultBottomRight = (float) Math.sqrt(neighbor.diffFromAverageSquared());
        
    	return (resultTop / (resultBottomLeft * resultBottomRight));
    }
    
    private List<DBUserItemRating> getCommonItems(DBUser user, DBUser neighbor)
    {
        Set<DBUserItemRating> neighborSet = neighbor.getUserItemRatings();
        for(DBUserItemRating userItemRating : user.getUserItemRatings())
        {
            if(neighbor.hasRatedItem(userItemRating.getItem()))
                
        }
    }
           
    @Override
    protected void computePearsonCoefficients() {
    	pearsonValuesMap = new HashMap<>();
    	for(DBUser neighbor : users)
    	{
            if(neighbor.getId() == selectedUser.getId())
                    continue;
            else
            {	
                    Float coefficient = computeSimilarityToNeighbor(selectedUser, neighbor);
                    System.out.println(coefficient);
                    //if(coefficient >= similarityCutoff)
                            pearsonValuesMap.put(neighbor, coefficient);
            }
    	}	
    }

    @Override
    public void fetchEntities() {
    	Session session = HibernateUtil.getSessionFactory().openSession();
     	Query query = session.createQuery("FROM DBUser");
     	users = query.list();
    	
     	//HibernateUtil.shutdown();
    }

    @Override
    public void pushEntities() {
        throw new UnsupportedOperationException("Not supported yet.");
    }
    
    @Override
    protected void computePredictions() {

    itemsScorePredictions = new LinkedHashMap<>();
    Map<DBItem, Float> tempitemsScorePredictions = new HashMap<>();
    Set<DBUserItemRating> userItemRatings = selectedUser.getUserItemRatings();
    
    
    userItemRatings.size();
    //Hibernate.initialize(userItemRatings);
    computePearsonCoefficients();

    for(DBUserItemRating userItemRating : userItemRatings)
    {
            Float currentItemPrediction = getPredictedScoreForItem(userItemRating.getItem());
            tempitemsScorePredictions.put(userItemRating.getItem(), currentItemPrediction);
    }

    List<Entry<DBItem, Float>> sortedItemScorePairs = new LinkedList(tempitemsScorePredictions.entrySet());
    Collections.sort(sortedItemScorePairs, (Entry<DBItem, Float> e1, Entry<DBItem, Float> e2) -> e1.getValue().compareTo(e2.getValue()));
    itemsScorePredictions = new HashMap<>();

    for(Entry<DBItem, Float> entry : sortedItemScorePairs)
        itemsScorePredictions.put(entry.getKey(), entry.getValue());
    
    }
    
    private float getPredictedScoreForItem(DBItem dbItem)
    {
		float pearsonAbsCoefficientSum = getPearsonAbsoluteCoefficientsSum();
		float pearsonAdjustedDiff = getPearsonAjustedDiffForItem(dbItem);
                if(pearsonAbsCoefficientSum == 0)
                    pearsonAbsCoefficientSum = selectedUser.getItemRatingsAverage();
                
		return selectedUser.getItemRatingsAverage() + (pearsonAdjustedDiff / pearsonAbsCoefficientSum);
    }
    
    private float getPearsonAbsoluteCoefficientsSum()
    {
    	float totalCoefficient = 0.0f;
    	for(Float coefficient :  pearsonValuesMap.values())
    		totalCoefficient += Math.abs(coefficient);
    	
    	return totalCoefficient;
    }
      
    private float getPearsonAjustedDiffForItem(DBItem item)
    {
    	float total = 0.0f;
        System.out.println("");
    	for(Entry<DBUser, Float> pair : pearsonValuesMap.entrySet())
    	{
    		float pearsonCoefficient = pair.getValue();
    		DBUser user = pair.getKey();
    		total += pearsonCoefficient * user.diffFromAverageForSpecificItem(item);
    	}
    	
    	return total;
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
    
    public class UserNotFoundException extends Exception {

        public UserNotFoundException() {
            super("User was not found");
        }
        
    }
    
}
