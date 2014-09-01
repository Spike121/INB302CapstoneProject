
package com.codetrix.entities.common;



public class EntityEntityPair {

    IPersistenceEntity firstEntity;
    IPersistenceEntity secondEntity;
    
    @Override
    public boolean equals(Object obj) {
    	if( !(obj instanceof EntityEntityPair))
    		return false;
    	
    	if(obj == this)
    		return true;
    	
    	EntityEntityPair otherPair = (EntityEntityPair) obj;
    	
    	return  (otherPair.firstEntity.getId() == this.firstEntity.getId() && otherPair.secondEntity.getId() == this.secondEntity.getId()) ||
    			(otherPair.firstEntity.getId() == this.secondEntity.getId() && otherPair.secondEntity.getId() == this.firstEntity.getId());     
    }
    
    @Override
    public int hashCode() {
    	return Long.valueOf(firstEntity.getId() * secondEntity.getId()).hashCode();
    }
    
}
