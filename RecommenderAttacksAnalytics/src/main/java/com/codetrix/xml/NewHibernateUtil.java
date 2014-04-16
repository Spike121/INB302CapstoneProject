/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.codetrix.xml;

import org.hibernate.SessionFactory;
import org.hibernate.cfg.AnnotationConfiguration;

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
