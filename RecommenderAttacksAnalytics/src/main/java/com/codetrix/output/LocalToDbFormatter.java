package com.codetrix.output;

import java.util.HashMap;
import java.util.HashSet;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;

import org.hibernate.Session;
import org.hibernate.mapping.Set;

import com.codetrix.entities.database.DBItem;
import com.codetrix.entities.database.DBUser;
import com.codetrix.entities.localpersistence.Item;
import com.codetrix.entities.localpersistence.ItemUserPair;
import com.codetrix.entities.localpersistence.RatingsLookupTable;
import com.codetrix.entities.localpersistence.User;
import com.codetrix.util.HibernateUtil;

public class LocalToDbFormatter {
	
	public static void outputToDb(RatingsLookupTable table)
	{
		
		Session session = HibernateUtil.getSessionFactory().openSession();		 
		session.beginTransaction();
		//session.clear() ;
		
		Map<Long, DBItem> itemsMap = new HashMap<Long, DBItem>();
		Map<Long, DBUser> usersMap = new HashMap<Long, DBUser>();
		
		try
		{
			for(Entry<ItemUserPair, Integer> entry : table.getRatingsLookup().entrySet())
			{
				ItemUserPair pair = entry.getKey();
				User rater = pair.getUser();
				Item ratedItem = pair.getItem();
				Integer rating = entry.getValue();
								
				DBUser dbUser;
				DBItem dbItem;
				
				// Get db user
				if(usersMap.containsKey(rater.getId()))
					dbUser = usersMap.get(rater.getId()); 
				else
				{	
					dbUser = new DBUser(rater.getId());
					usersMap.put(rater.getId(), dbUser);
				}
				
				// Get db item
				if(itemsMap.containsKey(ratedItem.getId()))
					dbItem = itemsMap.get(ratedItem.getId()); 
				else
				{	
					dbItem = new DBItem(ratedItem);
					itemsMap.put(ratedItem.getId(), dbItem);
				}
				
				dbUser.addRatedItem(dbItem, rating);																					
			}
			
			for(DBUser dbUser : usersMap.values())
			{
				session.save(dbUser);
				System.out.println("User " + dbUser.getUserId() + " persisted");
			}
			
			
			session.getTransaction().commit();
			System.out.println("DB updated");
			
		} catch(Exception e) {
			e.printStackTrace();
			session.getTransaction().rollback();
		} finally {
			HibernateUtil.shutdown();	
		}

		
		
	}
	
	public static void outputUsersToDb(List<User> users)
	{
		
	}
	
	public static void outputItemsToDb(List<Item> items)
	{
		
	}

}
