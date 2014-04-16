package com.codetrix.entities.database;

import com.codetrix.entities.common.AbstractUser;
import com.codetrix.util.Logger;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;


public class DBUser extends AbstractUser implements Serializable {

	private static final long serialVersionUID = -7573207794958163613L;

	//private boolean isAuthentic = true;
	//private Set<DBItem> ratedItems = new HashSet<DBItem>();
	
	private Set<DBUserItemRating> userItemRatings = new HashSet<DBUserItemRating>();
	
	public DBUser() { }
	
	public DBUser(long userId) {
		this.userId = userId;
	}

	public long getUserId() {
		return this.userId;
	}
 
	public void setUserId(long userId) {
		this.userId = userId;
	}

	public void addRatedItem(final DBItem item, int rating)
	{
		final DBUserItemRating userItemRating = new DBUserItemRating(this,item,rating);
		this.getUserItemRatings().add(userItemRating);
	}
        
	@Override
	public float diffFromAverage()
	{
		return computeDiffFromAverage(false);
	}
	
    @Override
	public float diffFromAverageSquared()
	{
		return computeDiffFromAverage(true);
	}
	
	private float computeDiffFromAverage(boolean isSquared)
	{
		float totalDiff = 0.0f;
		float average = getItemRatingsAverage();
		Iterator<DBUserItemRating> it = userItemRatings.iterator();
		
		while(it.hasNext())
		{
			DBUserItemRating userItemRating = it.next();
			float diff = userItemRating.getRating() - average;			
			
			if(isSquared)
				diff = (float) Math.pow(diff, 2);
			
			totalDiff += diff;
		}
		
		return totalDiff;
	}
	
	public float diffFromAverageForSpecificItem(DBItem item)
	{
		Iterator<DBUserItemRating> it = userItemRatings.iterator();
		float average = getItemRatingsAverage();
		
		while(it.hasNext())
		{
			DBUserItemRating userItemRating = it.next();
			if(userItemRating.getItem().getId() == item.getId())
				return userItemRating.getRating() - average;						
		}
		
		Logger.logWarning("Item " + item.getId() + "not found - returned 0.0 as diff. Results may be innacurate");
		return 0.0f;
	}
	
	/*
	public void removeRatedItem()
	{
		final DBUserItemRating userItemRating = new DBUserItemRating(this,item,rating);
		this.getUserItemRatings().add(userItemRating);
	}
	*/
	
	
	/*
	public Set<DBItem> getRatedItems() {
		return ratedItems;
	}

	public void setRatedItems(Set<DBItem> ratedItems) {
		this.ratedItems = ratedItems;
	}
	*/
	
	@Override	
	public String toString() {
		return String.valueOf(this.userId);
	}
	
	public float getItemRatingsAverage()
	{
		Iterator<DBUserItemRating> it = userItemRatings.iterator();
		float average = 0.0f;
		
		while(it.hasNext())
		{
			DBUserItemRating userItemRating = it.next();
			average += userItemRating.getRating();
		}
		
		average /= userItemRatings.size();
		
		return average;
	}
	
	
	
	public Set<DBUserItemRating> getUserItemRatings() {
		return userItemRatings;
	}

	public void setUserItemRatings(Set<DBUserItemRating> userItemRatings) {
		this.userItemRatings = userItemRatings;
	}
	 
	
	/*
	public boolean isAuthentic() {
		return isAuthentic;
	}

	public void setAuthentic(boolean isAuthentic) {
		this.isAuthentic = isAuthentic;
	}	
	*/
}
