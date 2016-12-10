using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager sInstance = null;

    public EnemyManager mEnemyManager;

    public LevelManager mLevelManager;

    public PlayerController mPlayerController;

    public CameraController mCameraController;

    public int mLevelNumber;

    public int mLives;

    public int mCoins;

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

        mLevelNumber = 1;
    }

    public void PlayerDie()
    {
        mLives--;
        if (mLives <= 0)
        {
            mLives = 0;
            //you die
            mPlayerController.enabled = false;
            Time.timeScale = 0;
        }
        else
        {
            mLevelManager.Restart();
        }
    }

    public void AddCoins(int amount)
    {
        if(amount >= 0)
        {
            mCoins += amount;
        }
    }
	
	void Start ()
    {
	    
	}
	
	
	void Update ()
    {
	    
	}
}
