/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package com.codetrix.model;

import com.codetrix.entities.common.IPersistenceEntity;
import com.codetrix.util.HibernateUtil;
import org.hibernate.Query;
import org.hibernate.Session;


public class TestModel extends AbstractModel{

    @Override
    public void fetchEntities() {
       Session session = HibernateUtil.getSessionFactory().openSession();
     	Query query = session.createQuery("FROM DBUser where userId = '9' OR userId = '8'");
     	users = query.list();
    }

    @Override
    public void pushEntities() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    public void select(long id) {
        
    }

    @Override
    protected float computeSimilarityToNeighbor(IPersistenceEntity mainEntity, IPersistenceEntity neighborEntity) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected void computePearsonCoefficients() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    @Override
    protected void computePredictions() {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
}
