using UnityEngine;
using System.Collections;

public class KillZone : MonoBehaviour {

    public GameObject mCam;
	
	void Update ()
    {
        transform.position = new Vector3(mCam.transform.position.x, transform.position.y, transform.position.z);
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            GameManager.sInstance.PlayerDie();
        }
    }

}
