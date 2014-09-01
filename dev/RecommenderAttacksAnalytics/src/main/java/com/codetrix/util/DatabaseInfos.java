
package com.codetrix.util;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import org.w3c.dom.Document;
import org.w3c.dom.NodeList;
import org.w3c.dom.Node;
import org.w3c.dom.Element;
import java.io.File;

public class DatabaseInfos {
    
    
    private final static String URL_XML_PROPERTY_TAG = "hibernate.connection.url";
    private final static String USERNAME_XML_PROPERTY_TAG = "hibernate.connection.username";
    private final static String PASSWORD_XML_PROPERTY_TAG = "hibernate.connection.password";
    private final static String SCHEMA_XML_PROPERTY_TAG = "hibernate.default_schema";
    
    private static String url;
    private static String username;
    private static String password;
    private static String defaultSchemaName;
    
    public static void setAllConfigurations() {
    	try {
    	File hibernateInfo = new File("src/hibernate.cfg.xml");
    	DocumentBuilderFactory dbFactory = DocumentBuilderFactory.newInstance();
    	DocumentBuilder dBuilder = dbFactory.newDocumentBuilder();
    	Document hibernateXML = dBuilder.parse(hibernateInfo);
    	hibernateXML.getDocumentElement().normalize();
    	NodeList nList = hibernateXML.getElementsByTagName("property");
    	
    	for (int temp = 0; temp < nList.getLength(); temp++) {
    		Node nNode = nList.item(temp);
    		
    		if(nNode.getNodeType() == Node.ELEMENT_NODE) {
    			Element eElement = (Element) nNode;
    			if(eElement.getAttributeNode("name").getValue().equals(URL_XML_PROPERTY_TAG)) {
    				url = eElement.getChildNodes().item(0).getNodeValue();
    			}
    			if(eElement.getAttributeNode("name").getValue().equals(USERNAME_XML_PROPERTY_TAG)) {
    				username = eElement.getChildNodes().item(0).getNodeValue();
    			}
    			if(eElement.getAttributeNode("name").getValue().equals(PASSWORD_XML_PROPERTY_TAG)) {
    				password = eElement.getChildNodes().item(0).getNodeValue();
    			}
    			if(eElement.getAttributeNode("name").getValue().equals(SCHEMA_XML_PROPERTY_TAG)) {
    				defaultSchemaName = eElement.getChildNodes().item(0).getNodeValue();
    			}
    		}
    		
    	}
    	
    	} catch (Exception e) {
    		e.printStackTrace();
    	}
    }	
    
    // TODO: Persist as options --> (2 constructors: default/from filepath)
}
