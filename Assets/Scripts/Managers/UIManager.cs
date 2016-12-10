using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text mCoinsText;
    public Text mLivesText;
    public Text mLevelText;

    int mCoins;
    int mLives;
    int mLevel;

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
}
