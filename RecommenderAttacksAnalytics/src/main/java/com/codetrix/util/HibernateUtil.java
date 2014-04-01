package com.codetrix.util;

import java.io.File;

import org.hibernate.SessionFactory;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;
import org.hibernate.HibernateException;
import org.hibernate.Session;



public class HibernateUtil {
	
	private static final SessionFactory sessionFactory = buildSessionFactory();
	 
    private static SessionFactory buildSessionFactory() {
        try {
        	/*
        	Configuration configuration = new Configuration();  
            configuration.configure("main/java/resources/hibernate.cfg.xml");  
            new ServiceRegistryBuilder().applySettings(configuration.getProperties());
        	*/
        	
            // Create the SessionFactory from hibernate.cfg.xml
            return new Configuration().configure(new File("src\\hibernate.cfg.xml")).buildSessionFactory();
        }
        catch (Throwable ex) { 
            // Make sure you log the exception, as it might be swallowed
            System.err.println("Initial SessionFactory creation failed." + ex);
            throw new ExceptionInInitializerError(ex);
        }
    }
 
    public static SessionFactory getSessionFactory() {
        return sessionFactory;
    }
 
    public static void shutdown() {
    	// Close caches and connection pools
    	getSessionFactory().close();
    }
}
