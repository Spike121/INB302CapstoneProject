package com.codetrix.entities.database;

import java.io.Serializable;

public class DBUserItemRating implements Serializable{

	private static final long serialVersionUID = 4993050300979728734L;
	
	private DBUser user;
	private DBItem item;
	private int rating;
	
	public DBUserItemRating()
	{
		
	}
	
	public DBUserItemRating(DBUser dbUser, DBItem item, int rating) {
		this.user = dbUser;
		this.item = item;
		this.rating = rating;
	}
	
	@Override
	public boolean equals(Object obj) {
		if(!(obj instanceof DBUserItemRating))
			return false;
		
		DBUserItemRating userItemRating = (DBUserItemRating) obj;
		return userItemRating.item.getItemId() == this.item.getItemId() && userItemRating.user.getUserId() == this.user.getUserId();
	};
	
	@Override
	public int hashCode() {
		return Long.valueOf(this.item.getItemId() * this.user.getUserId()).hashCode();
	};
	
	public DBUser getUser() {
		return user;
	}
	public void setUser(DBUser user) {
		this.user = user;
	}
	public DBItem getItem() {
		return item;
	}
	public void setItem(DBItem item) {
		this.item = item;
	}
	public int getRating() {
		return rating;
	}
	public void setRating(int rating) {
		this.rating = rating;
	}
}
