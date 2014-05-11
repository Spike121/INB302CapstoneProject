
package com.codetrix.entities.common;

public abstract class AbstractItem implements IPersistenceEntity{
    
    protected long itemId;
    
    public long getId(){
        return this.itemId;
    }
    
    @Override
    public boolean equals(Object obj)
    {
        if( !(obj instanceof AbstractItem) )
            return false;
        
        if(obj == this)
            return true;
        
        return ((AbstractItem)obj).itemId == this.itemId;
    }
    
    @Override
    public int hashCode()
    {
        return Long.valueOf(this.itemId).hashCode();
    }
}
