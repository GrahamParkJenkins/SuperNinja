using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {

    public Enemy[] mEnemies;

    public int mCurrLevel;

    // Use this for initialization
    void Start()
    {
        mCurrLevel = GameManager.sInstance.mLevelNumber;
        Debug.Log(mCurrLevel);
        Spawn();
    }

    private void Spawn()
    {
        mEnemies[mCurrLevel - 1].gameObject.SetActive(true);
    }

    public void LevelUp()
    {
        if (mCurrLevel < mEnemies.Length)
        {
            mEnemies[mCurrLevel - 1].gameObject.SetActive(false);
            GameManager.sInstance.mLevelNumber++;
            Spawn();
        }

    }

    public void Restart()
    {
        Destroy(mEnemies[mCurrLevel]);
        Instantiate(mEnemies[mCurrLevel], mEnemies[mCurrLevel].transform.position, mEnemies[mCurrLevel].transform.rotation);
    }
}
