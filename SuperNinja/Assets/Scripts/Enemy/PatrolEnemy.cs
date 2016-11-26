using UnityEngine;
using System.Collections;

public class PatrolEnemy : Enemy {

    bool mFacingRight = true;

    public float mSpeed;

    float mCurrDir = 0;

    Rigidbody2D mRigidBody;

	void Start ()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
    }
	
	
	void Update ()
    {
        if (mFacingRight)
        {
            mCurrDir = 1;
        }
        else
        {
            mCurrDir = -1;
        }



	}

    void FixedUpdate()
    {
        mRigidBody.AddForce(new Vector2(mCurrDir, 0) * mSpeed * Time.deltaTime);
    }

    void TurnAround()
    {
        mFacingRight = !mFacingRight;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "InvisBlock")
        {
            Debug.Log("hitWall");
            TurnAround();
        }

        if(col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerController>().mHealth -= mDamage;
            Debug.Log("hit me with your best shot");
        }
    }
}
