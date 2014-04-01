package com.codetrix.entities.localpersistence;

import java.util.LinkedList;
import java.util.List;

public class Item implements Comparable<Item>{

	private long itemId;
	private List<User> raters = new LinkedList<User>();
	
	public Item(long id){
		this.itemId = id;
	}
	
	public List<ItemUserPair> getPairs()
	{
		List<ItemUserPair> pairs = new LinkedList<ItemUserPair>();
		for(User user : raters)
			pairs.add(new ItemUserPair(this,user));
		
		return pairs;
	}
	
	@Override
	public String toString()
	{
		return Long.toString(itemId);
	}

	public void addUser(User newUser) {
		raters.add(newUser);
	}

	public long getId() {
		return this.itemId;
	}

	@Override
	public int compareTo(Item o) {
		return (int) (this.itemId - o.itemId);
	}
	
}
