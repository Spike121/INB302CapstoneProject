package com.codetrix.entities.localpersistence;

import com.codetrix.entities.localpersistence.Item;
import com.codetrix.entities.localpersistence.User;

public class ItemUserPair {

	private Item item;
	private User user;
	
	public ItemUserPair(Item item, User user)
	{
		this.item = item;
		this.user = user;
	}
	
	@Override	
	public boolean equals(Object obj) {
		
		if ( !(obj instanceof ItemUserPair))
			return false;
		
		if(obj == this)
			return true;
		
		return this.item.getId() == ((ItemUserPair) obj).item.getId() && this.user.getId() == ((ItemUserPair) obj).user.getId();
	}
	
	@Override
	public int hashCode() {		
		return (int) (this.item.getId() * this.user.getId());
	}

	public Item getItem() {
		return item;
	}

	public void setItem(Item item) {
		this.item = item;
	}

	public User getUser() {
		return user;
	}

	public void setUser(User user) {
		this.user = user;
	}
}
