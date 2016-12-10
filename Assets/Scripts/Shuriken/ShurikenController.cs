using UnityEngine;
using System.Collections;

public class ShurikenController : MonoBehaviour
{
    public float fireSpeed;
    Rigidbody2D mShurRigidBody;   

    void Start()
    {
        mShurRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mShurRigidBody.velocity = new Vector2(fireSpeed, 0);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player" && col.gameObject.tag != "Enemy" && col.gameObject.tag != "PickUp")
        {
            Destroy(this.gameObject);
        }
    }
}
