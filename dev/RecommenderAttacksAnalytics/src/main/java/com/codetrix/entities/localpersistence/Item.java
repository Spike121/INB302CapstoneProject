package com.codetrix.entities.localpersistence;

import com.codetrix.entities.common.AbstractItem;
import java.util.LinkedList;
import java.util.List;

public class Item extends AbstractItem implements Comparable<Item>{

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

    @Override
    public boolean equals(Object obj) {

            if(!(obj instanceof Item))
                    return false;

            if(obj == this)
                    return true;

            return ((Item) obj).itemId == this.itemId;
    };

    @Override
    public int hashCode() {
            return Long.valueOf(this.itemId).hashCode();
    };

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

    public float diffFromAverageSquared() {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    public float diffFromAverage() {
        throw new UnsupportedOperationException("Not supported yet.");
    }
	
}
