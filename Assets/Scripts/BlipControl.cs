using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BlipControl : MonoBehaviour {

    private float mMaxSpeed = 10f;
    private Rigidbody2D mRigidBody;

	void Awake() {
        mRigidBody = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {
        float xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        float yMove = CrossPlatformInputManager.GetAxis("Vertical");

        Vector2 move = new Vector2(xMove * mMaxSpeed, yMove * mMaxSpeed);
        mRigidBody.AddForce(move);
    }
}
