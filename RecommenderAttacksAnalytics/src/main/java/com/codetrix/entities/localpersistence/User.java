package com.codetrix.entities.localpersistence;

import java.util.LinkedList;
import java.util.List;


public class User implements Comparable<User>{

	private long userId;
	private List<Item> ratedItems = new LinkedList<Item>();
	
	public User(long id){
		this.userId = id;
	}
	
	public List<ItemUserPair> getPairs()
	{
		List<ItemUserPair> pairs = new LinkedList<ItemUserPair>();
		for(Item item : ratedItems)
			pairs.add(new ItemUserPair(item,this));
		
		return pairs;
	}
	
	@Override
	public String toString()
	{
		return Long.toString(userId);
	}

	@Override
	public boolean equals(Object obj) {
		
		if(!(obj instanceof User))
			return false;
		
		if(obj == this)
			return true;
		
		return ((User) obj).userId == this.userId;
	};
	
	@Override
	public int hashCode() {
		return Long.valueOf(this.userId).hashCode();
	};
	
	public void addItem(Item newItem) {
		ratedItems.add(newItem);
	}

	public long getId() {
		return this.userId;
	}

	@Override
	public int compareTo(User o) {
		return (int) (this.userId - o.userId);
	}
}
