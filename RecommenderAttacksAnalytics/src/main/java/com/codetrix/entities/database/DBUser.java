package com.codetrix.entities.database;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Set;

import com.codetrix.entities.localpersistence.Item;
import com.codetrix.entities.localpersistence.User;

public class DBUser implements Serializable {

	private static final long serialVersionUID = -7573207794958163613L;
	private long userId;
	private Set<Item> ratedItems = new HashSet<Item>();
	
	public DBUser() { }
	
	public DBUser(long userId) {
		this.userId = userId;
	}

	public DBUser(User user) {
		this.userId = user.getId();
	}

	public long getUserId() {
		return this.userId;
	}
 
	public void setUserId(long userId) {
		this.userId = userId;
	}

	public Set<Item> getRatedItems() {
		return ratedItems;
	}

	public void setRatedItems(Set<Item> ratedItems) {
		this.ratedItems = ratedItems;
	}	

}
