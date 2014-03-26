package persistence;

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
		
		return super.equals(obj);		
	}
	
}
