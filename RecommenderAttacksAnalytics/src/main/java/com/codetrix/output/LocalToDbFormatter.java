package com.codetrix.output;

import java.util.List;
import java.util.Map.Entry;

import org.hibernate.Session;

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
		
		/*
		session.save(user);		
		System.out.println("User saved");
		*/
		
		try
		{
			for(Entry<ItemUserPair, Integer> entry : table.getRatingsLookup().entrySet())
			{
				ItemUserPair pair = entry.getKey();
				DBUser dbUser = new DBUser(pair.getUser());
				session.save(dbUser);
				System.out.println("User " + dbUser.getUserId() + " persisted");
			}
			
			session.getTransaction().commit();
			
		} catch(Exception e) {
			e.printStackTrace();
			session.getTransaction().rollback();
		} finally {
			HibernateUtil.shutdown();	
		}
		
		
		System.out.println("DB updated");
	}
	
	public static void outputUsersToDb(List<User> users)
	{
		
	}
	
	public static void outputItemsToDb(List<Item> items)
	{
		
	}

}
