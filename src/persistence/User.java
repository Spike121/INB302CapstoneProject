package persistence;

import java.util.LinkedList;
import java.util.List;

public class User {

	private String userId;
	private List<Item> ratedItems = new LinkedList<Item>();
	
	public User(String id){
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
		return userId;
	}

	public void addItem(Item newItem) {
		ratedItems.add(newItem);
		
	}

	public String getId() {
		return this.userId;
	}
	
}
