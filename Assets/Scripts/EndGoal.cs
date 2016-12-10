using UnityEngine;
using System.Collections;

public class EndGoal : MonoBehaviour {
    
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            GameManager.sInstance.mLevelManager.LevelUp();
        }
    }
}
