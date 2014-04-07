
package com.codetrix.util;


public class DatabaseInfos {
    
    
    private  final String URL_XML_PROPERTY_TAG = "hibernate.connection.url";
    private  final String USERNAME_XML_PROPERTY_TAG = "hibernate.connection.username";
    private  final String PASSWORD_XML_PROPERTY_TAG = "hibernate.connection.password";
    private  final String SCHEMA_XML_PROPERTY_TAG = "hibernate.default_schema";
    
    private String url = "\\localhost";
    private String username = "root";
    private String password = "";
    private int port = 3306;
    private String defaultSchemaName = "";
    
    
    
    private String appendPortToUrl(String url)
    {
        return url.concat(":").concat(Integer.toString(port));
    }
    
    public String getFormattedUrl()
    {
        String url = "jdbc:mysql:".concat(this.url);
        return appendPortToUrl(url);
    }
    
    // TODO: Persist as options --> (2 constructors: default/from filepath)
}
