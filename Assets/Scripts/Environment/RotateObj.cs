using UnityEngine;
using System.Collections;

public class RotateObj : MonoBehaviour {

    public Vector3 mRotation;
    public float mSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(mRotation);
	}
}
