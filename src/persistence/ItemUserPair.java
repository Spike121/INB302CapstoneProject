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
		
		if ( !(obj instanceof ItemUserPair))
			return false;
		
		if(obj == this)
			return true;
		
		return this.item.getId().equals(((ItemUserPair) obj).item.getId()) && this.user.getId().equals(((ItemUserPair) obj).user.getId());
	}
	
	@Override
	public int hashCode() {		
		return Integer.parseInt(this.item.getId()) * Integer.parseInt(this.user.getId());
	}
}
