using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager sInstance = null;

    public EnemyManager mEnemyManager;

    public LevelManager mLevelManager;

    public UIManager mUIManager;

    public PlayerController mPlayerController;

    public CameraController mCameraController;

    public int mLevelNumber;

    public int mLives;

    public int mMaxLives;

    public int mCoins;

    public int mEnemiesKilled;

    public bool mPaused = false;


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
        mMaxLives = mLives;
    }

    public void PlayerDie()
    {
        mLives--;
        if (mLives <= 0)
        {
            mLives = 0;
            //you die
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


    public void AddKill(int amount)
    {
        if (amount >= 0)
        {
            mEnemiesKilled += amount;
        }
    }
	
	void Start ()
    {
	    
	}
	
	
	void Update ()
    {
        if (mPaused)
        {
            Time.timeScale = 0;
        }else
        {
            Time.timeScale = 1;
        }
	}
}
