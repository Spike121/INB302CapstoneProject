
package com.codetrix.entities.common;

public abstract class AbstractItem implements IPersistenceEntity{
    
    protected long itemId;
    
    public long getId(){
        return this.itemId;
    }
}
