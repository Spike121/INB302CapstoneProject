package persistence;

import java.util.LinkedList;
import java.util.List;

public class Item {

	private String itemId;
	private List<User> raters = new LinkedList<User>();
	
	public Item(String id){
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
		return itemId;
	}

	public void addUser(User newUser) {
		raters.add(newUser);
	}

	public String getId() {
		return this.itemId;
	}
	
	
}
