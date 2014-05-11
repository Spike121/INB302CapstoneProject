package com.codetrix.entities.database;

import com.codetrix.entities.common.AbstractItem;
import java.io.Serializable;
import com.codetrix.entities.localpersistence.Item;


public class DBItem extends AbstractItem implements Serializable{

	private static final long serialVersionUID = -321973360789099117L;
	
	//private Set<User> raters = new HashSet<User>();
	
	public DBItem() { }
	
        public DBItem(long id) { 
            this.itemId = id;
        }
        
        
	
	public DBItem(Item item) 
	{
                this(item.getId());
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

    public float diffFromAverageSquared() {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    public float diffFromAverage() {
        throw new UnsupportedOperationException("Not supported yet.");
    }
}
