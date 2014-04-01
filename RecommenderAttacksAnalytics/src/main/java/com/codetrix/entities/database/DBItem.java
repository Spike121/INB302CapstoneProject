package com.codetrix.entities.database;

import java.io.Serializable;

import com.codetrix.entities.localpersistence.Item;

public class DBItem implements Serializable{

	private static final long serialVersionUID = -321973360789099117L;
	private long itemId;

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
	
}
