using UnityEngine;
using System.Collections;

public class ShurikenController : MonoBehaviour
{
    public float fireSpeed;
    Rigidbody2D rb2d;   

    void Start()
    {
        rb2d = FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = new Vector2(fireSpeed, rb2d.transform.position.y);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag != "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
