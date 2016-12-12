using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public GameObject mEndGameImage;

    public Texture2D mFilledStar;
    public Texture2D mNoStar;

    public Text mCoinsText;
    public Text mLivesText;
    public Text mLevelText;

    public RawImage mStarImage1;
    public RawImage mStarImage2;
    public RawImage mStarImage3;

    public Text mEnemiesKilledText;
    public Text mCoinsCollectedText;

    int starLevel;

    int mCoins;
    int mLives;
    int mLevel;

    int mEnemiesKilled;

    void Start ()
    {
        mCoins = GameManager.sInstance.mCoins;
        mLives = GameManager.sInstance.mLives;
        mLevel = GameManager.sInstance.mLevelManager.mCurrLevel;
    }


    void Update ()
    {
	    if(mCoins != GameManager.sInstance.mCoins)
        {
            mCoins = GameManager.sInstance.mCoins;
        }

        if (mLives != GameManager.sInstance.mLives)
        {
            mLives = GameManager.sInstance.mLives;
        }

        if (mLevel != GameManager.sInstance.mLevelManager.mCurrLevel)
        {
            mLevel = GameManager.sInstance.mLevelManager.mCurrLevel;
        }



        mLivesText.text = "Lives: " + mLives;

        mLevelText.text = "Level: " + (mLevel);

        mCoinsText.text = "Coins: " + mCoins;
    }

    public void SetResults(int enemies,int coins,int totalEnemies,int totalCoins)
    {
        //Debug.Log(enemies + "," + coins + "," + totalEnemies + "," + totalCoins);



        float totalPoints = (enemies+coins);

        float allStuff = (totalEnemies + totalCoins);

        starLevel = 0;
        mEnemiesKilledText.text = "" + enemies;
        mCoinsCollectedText.text = "" + coins;

        if(((totalPoints/allStuff) * 100) > 10)
        {
            starLevel = 1;
        }
        if (((totalPoints / allStuff) * 100) > 50)
        {
            starLevel = 2;
        }
        if (((totalPoints / allStuff) * 100) > 70)
        {
            starLevel = 3;
        }

        if(starLevel > 1)
        {
            mStarImage1.texture = mFilledStar;
        }
        else
        {
            mStarImage1.texture = mNoStar;
        }

        if (starLevel > 2)
        {
            mStarImage2.texture = mFilledStar;
        }
        else
        {
            mStarImage2.texture = mNoStar;
        }

        if (starLevel > 3)
        {
            mStarImage3.texture = mFilledStar;
        }
        else
        {
            mStarImage3.texture = mNoStar;
        }
    }

    public void Replay()
    {
        GameManager.sInstance.mPaused = false;
        GameManager.sInstance.mLevelManager.Restart();
        GameManager.sInstance.mUIManager.mEndGameImage.SetActive(false);

    }

    public void NextLevel()
    {
        GameManager.sInstance.mPaused = false;
        GameManager.sInstance.mLevelManager.LevelUp();
        GameManager.sInstance.mUIManager.mEndGameImage.SetActive(false);

    }

}
