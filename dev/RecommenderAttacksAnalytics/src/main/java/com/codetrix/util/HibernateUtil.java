package com.codetrix.util;

import java.io.File;

import org.hibernate.SessionFactory;
import org.hibernate.boot.registry.StandardServiceRegistryBuilder;
import org.hibernate.cfg.Configuration;
import org.hibernate.service.ServiceRegistry;
import org.hibernate.service.ServiceRegistryBuilder;
import org.hibernate.HibernateException;
import org.hibernate.Session;



public class HibernateUtil {
	
	private static final SessionFactory sessionFactory = buildSessionFactory();
	private static ServiceRegistry serviceRegistry;
	
    private static SessionFactory buildSessionFactory() {
        try {
        	Configuration config = new Configuration().configure(new File("src\\hibernate.cfg.xml"));
        	serviceRegistry = new StandardServiceRegistryBuilder().applySettings(config.getProperties()).build();
            
        	// Create the SessionFactory from hibernate.cfg.xml
        	return config.buildSessionFactory(serviceRegistry);        	            
        }
        catch (Throwable ex) { 
      
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
