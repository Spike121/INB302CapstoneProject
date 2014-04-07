
package com.codetrix.entities.common;

public abstract class AbstractUser implements IPersistenceEntity {
    
    protected long userId;
    
    public long getId(){
        return this.userId;
    }
    
}
