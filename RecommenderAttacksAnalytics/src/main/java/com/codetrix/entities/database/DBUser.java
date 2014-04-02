package com.codetrix.entities.database;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Set;

import com.codetrix.entities.localpersistence.Item;
import com.codetrix.entities.localpersistence.User;

public class DBUser implements Serializable {

	private static final long serialVersionUID = -7573207794958163613L;
	private long userId;
	
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
