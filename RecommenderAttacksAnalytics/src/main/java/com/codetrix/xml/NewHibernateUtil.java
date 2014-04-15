/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.codetrix.xml;

/**
 *
 * @author Mikhail
 */

public class NewHibernateUtil {

private final SessionFactory sessionFactory;
 
 String host;
 String database;
 String username;
 String password;
 
 NewHibernateUtil (String host,String database,String username,String password){
     this.host=host;
     this.database=database;
     this.username=username;
     this.password=password;
     AnnotationConfiguration ac = new AnnotationConfiguration().configure();
     ac.setProperty("hibernate.connection.url", "jdbc:mysql://"+host+"/"+database+"");  
     ac.setProperty("hibernate.connection.username", username);  
     ac.setProperty("hibernate.connection.password", password);             
     sessionFactory = ac.buildSessionFactory();         
 }    

public SessionFactory getSessionFactory() {
    return sessionFactory;
}    
}
/* This is another method

public static void hibernate.SetSessionFactory() {
    try {

      AnnotationConfiguration conf = new AnnotationConfiguration().configure();
      // <!-- Database connection settings -->
      conf.setProperty("hibernate.connection.url", URL);
      conf.setProperty("hibernate.connection.username", USERNAME);
      conf.setProperty("hibernate.connection.password", PASSWORD);
      SESSION_FACTORY = conf.buildSessionFactory();

    } catch (Throwable ex) {
      // Log exception!
      throw new ExceptionInInitializerError(ex);
    }
  }
*/