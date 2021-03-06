﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public Level[] mLevels;

    public bool levelUp;

    public int mCurrLevel;

    public GameObject mCoinPrefab;

    public GameObject mEnemyPrefab;

    List<GameObject> mPlacedCoins = new List<GameObject>();

    List<GameObject> mSpawnedEnemies = new List<GameObject>();

    bool mCanContinue = true;

    // Use this for initialization
    void Start()
    {
        mCurrLevel = GameManager.sInstance.mLevelNumber;
        Spawn();
    }

    private void Spawn()
    {
        mLevels[mCurrLevel - 1].gameObject.SetActive(true);
        GameManager.sInstance.mPlayerController.gameObject.transform.position = mLevels[mCurrLevel - 1].mStartPos.position;
        RepawnCoins();
        RepawnEnemies();
    }

    public void LevelUp()
    {
        GameManager.sInstance.mLives = GameManager.sInstance.mMaxLives;
        if (mCurrLevel < mLevels.Length)
        {
            mLevels[mCurrLevel - 1].gameObject.SetActive(false);
            mCurrLevel++;
            Spawn();
        }

        if(mCurrLevel == mLevels.Length)
        {
            GameManager.sInstance.mPlayerController.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            RepawnCoins();
            RepawnEnemies();

        }

    }

    public void ShowResults()
    {
        GameManager.sInstance.mUIManager.mEndGameImage.SetActive(true);
        GameManager.sInstance.mUIManager.SetResults(GameManager.sInstance.mEnemiesKilled, GameManager.sInstance.mCoins, mLevels[mCurrLevel - 1].mEnemySpawn.Length, mLevels[mCurrLevel - 1].mCoinSpawn.Length);
        GameManager.sInstance.mPaused = true;
    }

    void RepawnCoins()
    {
        GameManager.sInstance.mCoins = 0;

        GameObject tempObj;

        for (int j = 0; j < mPlacedCoins.Count; j++)
        {
            Destroy(mPlacedCoins[j]);
        }

        mPlacedCoins.Clear();

        for (int i = 0; i < mLevels[mCurrLevel - 1].mCoinSpawn.Length; i++)
        {

            tempObj = Instantiate(mCoinPrefab, mLevels[mCurrLevel - 1].mCoinSpawn[i].transform.position, mLevels[mCurrLevel - 1].mCoinSpawn[i].transform.rotation) as GameObject;
            mPlacedCoins.Add(tempObj);
        }
    }

    void RepawnEnemies()
    {
        GameManager.sInstance.mEnemiesKilled = 0;

        GameObject tempObj;

        for (int j = 0; j < mSpawnedEnemies.Count; j++)
        {
            Destroy(mSpawnedEnemies[j]);
        }

        mSpawnedEnemies.Clear();

        for (int i = 0; i < mLevels[mCurrLevel - 1].mEnemySpawn.Length; i++)
        {

            tempObj = Instantiate(mEnemyPrefab, mLevels[mCurrLevel - 1].mEnemySpawn[i].transform.position, mLevels[mCurrLevel - 1].mEnemySpawn[i].transform.rotation) as GameObject;
            mSpawnedEnemies.Add(tempObj);
        }
    }
    

    public void Restart()
    {
        GameManager.sInstance.mPlayerController.gameObject.transform.position = mLevels[mCurrLevel - 1].mStartPos.position;
        RepawnEnemies();
        RepawnCoins();
    }
}
