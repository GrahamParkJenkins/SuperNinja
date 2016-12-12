using UnityEngine;
using System.Collections;

public class PatrolEnemy : Enemy {

    float mCurrDir = 1;

    Rigidbody2D mRigidBody;

	void Start ()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
        mSpeed = 500;
    }

    void FixedUpdate()
    {
        mRigidBody.AddForce(new Vector2(mCurrDir, 0) * mSpeed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "InvisBlock")
        {
            mCurrDir = -mCurrDir;
        }



        if(col.gameObject.tag == "Player")
        {
            GameManager.sInstance.PlayerDie();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bullet")
        {
            GameManager.sInstance.AddKill(1);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
