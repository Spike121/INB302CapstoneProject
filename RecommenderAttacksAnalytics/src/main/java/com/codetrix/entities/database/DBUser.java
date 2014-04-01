package com.codetrix.entities.database;

import java.io.Serializable;

import com.codetrix.entities.localpersistence.User;

public class DBUser implements Serializable {

	private static final long serialVersionUID = -7573207794958163613L;
	private long userId;
	
	public DBUser() { }
	
	public DBUser(long userId) {
		this.userId = userId;
	}

	public DBUser(User user) {
		this.userId = user.getId();
	}

	public long getUserId() {
		return this.userId;
	}
 
	public void setUserId(long userId) {
		this.userId = userId;
	}	
	
}
