using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody2D mRigidBody;

    public float mScrollSpeed;
    public float mJumpSpeed;

    bool mJumpKeyPressed = false;

    bool mGrounded = false;

    public Transform firePoint;
    public GameObject shuriken;

	void Start ()
    {
        mRigidBody = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate ()
    {
        mRigidBody.AddForce(new Vector2(mScrollSpeed, 0) * Time.deltaTime);

        if (mJumpKeyPressed && mGrounded)
        {
            mRigidBody.AddForce(new Vector2(0, mJumpSpeed) * Time.deltaTime);
            mJumpKeyPressed = false;
            mGrounded = false;
        }
        else
        {
            mJumpKeyPressed = false;
        }

	}

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            mJumpKeyPressed = true;
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(shuriken, firePoint.transform.position, firePoint.transform.rotation);
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
            mGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            mGrounded = false;
        }
    }
}
