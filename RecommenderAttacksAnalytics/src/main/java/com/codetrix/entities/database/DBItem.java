package com.codetrix.entities.database;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Set;

import com.codetrix.entities.localpersistence.Item;
import com.codetrix.entities.localpersistence.User;

public class DBItem implements Serializable{

	private static final long serialVersionUID = -321973360789099117L;
	private long itemId;
	
	//private Set<User> raters = new HashSet<User>();
	
	public DBItem() { }
	
	
	public DBItem(Item item) 
	{
		this.itemId = item.getId();
	}
	
	public long getItemId() {
		return itemId;
	}

	public void setItemId(long itemId) {
		this.itemId = itemId;
	}

	/*
	public Set<User> getRaters() {
		return raters;
	}

	public void setRaters(Set<User> raters) {
		this.raters = raters;
	}
	*/
	
	@Override	
	public String toString() {
		return String.valueOf(this.itemId);
	}
}
