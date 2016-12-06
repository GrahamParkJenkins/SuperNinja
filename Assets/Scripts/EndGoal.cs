using UnityEngine;
using System.Collections;

public class EndGoal : MonoBehaviour {

    public LevelManager levelManager;
	
	void Start ()
    {
	
	}
	
	void Update ()
    {
	
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            levelManager.levelUp = true;
            levelManager.levelCount++;
            levelManager.levelUp = false;
        }
    }
}
