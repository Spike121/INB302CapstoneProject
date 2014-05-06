
package com.codetrix.ui;

import com.codetrix.entities.database.DBItem;
import com.codetrix.entities.database.DBUser;
import com.codetrix.model.AbstractModel;
import com.codetrix.model.UserCentricModel;
import com.codetrix.util.Logger;
import com.codetrix.entities.localpersistence.*;

import java.util.Random;
import java.util.Map;

public class MainAppFrame extends javax.swing.JFrame {

    AbstractModel currentModel;
    
    public MainAppFrame() {
        initComponents();
        currentModel = new UserCentricModel();
    }

    private void addFakeProfilesBtnActionPerformed(java.awt.event.ActionEvent evt) {
    	
    	//PROBLEM: Find the corresponding DBItem for the ID the user enters
    	//Rest is done
    	DBItem randomItem = new DBItem(); //Using an empty DBItem at the moment, hoping Phil can help
		try {
			currentModel.addFakeProfiles(randomItem, 5);
		} catch (Exception e) {
			Logger.logError("Error:" + e);
		}
    }
    
    private void selectUserBtnActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_selectUserBtnActionPerformed
        
        try {
            currentModel.select(Long.valueOf(entityIdTextField.getText()));
        } 
        catch(NumberFormatException e)
        {
            Logger.logError("Invalid user number");
        }
        
        for(Map.Entry<DBItem, Float> entry : currentModel.getPredictions().entrySet())
        {
            //Logger.log(entry.getKey().getId());
            outputTextArea.append("Item " + entry.getKey().getId() + ":  " + entry.getValue() + "\n");
        }      
    }//GEN-LAST:event_selectUserBtnActionPerformed
    
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jSeparator1 = new javax.swing.JSeparator();
        selectUserBtn = new javax.swing.JButton();
        addFakeProfilesBtn = new javax.swing.JButton();
        jLabel1 = new javax.swing.JLabel();
        jScrollPane1 = new javax.swing.JScrollPane();
        entityIdTextField = new javax.swing.JTextPane();
        jScrollPane2 = new javax.swing.JScrollPane();
        outputTextArea = new javax.swing.JTextArea();

        setDefaultCloseOperation(javax.swing.WindowConstants.EXIT_ON_CLOSE);

        selectUserBtn.setText("Find");
        selectUserBtn.setMargin(new java.awt.Insets(2, 20, 2, 20));
        selectUserBtn.setName("searchUserBtn"); // NOI18N
        selectUserBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
                selectUserBtnActionPerformed(evt);
            }
        });
        
        addFakeProfilesBtn.setText("Add Fake Profiles");
        addFakeProfilesBtn.setMargin(new java.awt.Insets(3, 40, 3, 40));
        addFakeProfilesBtn.setName("addFakeProfilesBtn"); // NOI18N
        addFakeProfilesBtn.addActionListener(new java.awt.event.ActionListener() {
            public void actionPerformed(java.awt.event.ActionEvent evt) {
            	addFakeProfilesBtnActionPerformed(evt);
            }
        });

        jLabel1.setText("User id");

        jScrollPane1.setViewportView(entityIdTextField);

        outputTextArea.setColumns(20);
        outputTextArea.setRows(5);
        jScrollPane2.setViewportView(outputTextArea);

        javax.swing.GroupLayout layout = new javax.swing.GroupLayout(getContentPane());
        getContentPane().setLayout(layout);
        layout.setHorizontalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(javax.swing.GroupLayout.Alignment.TRAILING, layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                    .addComponent(jScrollPane2)
                    .addComponent(jSeparator1, javax.swing.GroupLayout.Alignment.LEADING)
                    .addGroup(javax.swing.GroupLayout.Alignment.LEADING, layout.createSequentialGroup()
                        .addComponent(jLabel1)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, 120, javax.swing.GroupLayout.PREFERRED_SIZE)
                        .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.RELATED, 163, Short.MAX_VALUE)
                        .addComponent(selectUserBtn)))
                .addContainerGap())
        );
        layout.setVerticalGroup(
            layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
            .addGroup(layout.createSequentialGroup()
                .addContainerGap()
                .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.LEADING)
                    .addComponent(selectUserBtn)
                    .addGroup(layout.createParallelGroup(javax.swing.GroupLayout.Alignment.TRAILING)
                        .addComponent(jLabel1)
                        .addComponent(jScrollPane1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)))
                .addPreferredGap(javax.swing.LayoutStyle.ComponentPlacement.UNRELATED)
                .addComponent(jSeparator1, javax.swing.GroupLayout.PREFERRED_SIZE, javax.swing.GroupLayout.DEFAULT_SIZE, javax.swing.GroupLayout.PREFERRED_SIZE)
                .addGap(18, 18, 18)
                .addComponent(jScrollPane2, javax.swing.GroupLayout.DEFAULT_SIZE, 324, Short.MAX_VALUE)
                .addContainerGap())
        );

        pack();
    }// </editor-fold>//GEN-END:initComponents

    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JTextPane entityIdTextField;
    private javax.swing.JLabel jLabel1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JScrollPane jScrollPane2;
    private javax.swing.JSeparator jSeparator1;
    private javax.swing.JTextArea outputTextArea;
    private javax.swing.JButton selectUserBtn;
    private javax.swing.JButton addFakeProfilesBtn;
    // End of variables declaration//GEN-END:variables
}
