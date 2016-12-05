using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject mPlayer;


    private Vector3 mOffset;

	void Start ()
    {
        mOffset = transform.position - mPlayer.transform.position;
	}

    void LateUpdate()
    {
        transform.position = new Vector3(mPlayer.transform.position.x - mOffset.x, mPlayer.transform.position.y - mOffset.y, transform.position.z);
    }
}
