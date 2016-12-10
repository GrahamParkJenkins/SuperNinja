using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager sInstance = null;

    public LevelManager mLevelManager;

    public PlayerController mPlayerController;

    public int mLives;

    void Awake()
    {
        if(sInstance == null)
        {
            sInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void PlayerDie()
    {
        mLives--;
        if(mLives <= 0)
        {
            //you die
        }
        else
        {
            mLevelManager.Restart();
        }
    }

	
	void Start ()
    {
	    


	}
	
	
	void Update ()
    {
	    


	}
}
