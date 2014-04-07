
package com.codetrix.entities.common;


// Represents a storable entity (whether local or db) at its highest level

public interface IPersistenceEntity {

    public float diffFromAverageSquared();
    public float diffFromAverage();
    
    public long getId();
}
