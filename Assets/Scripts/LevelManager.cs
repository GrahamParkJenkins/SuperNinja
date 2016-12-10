using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Levels;
    public int levelCount;
    public bool levelUp;

    public Transform mStartPos;

    GameObject mCurrentLevel;

    // Use this for initialization
    void Start()
    {

        Levels[levelCount].SetActive(true);

        mCurrentLevel = Instantiate(Levels[levelCount], mStartPos.position, mStartPos.rotation) as GameObject;

        GameManager.sInstance.mPlayerController.gameObject.transform.position = mCurrentLevel.GetComponent<Level>().mStartPos.position;
    }

    public void LevelUp()
    {
        levelCount++;
        if(levelCount <= Levels.Length - 1)
        {
            Levels[levelCount - 1].SetActive(false);
            Levels[levelCount].SetActive(true);

            Destroy(mCurrentLevel);

            mCurrentLevel = Instantiate(Levels[levelCount], mStartPos.position, mStartPos.rotation) as GameObject;

            GameManager.sInstance.mPlayerController.gameObject.transform.position = mCurrentLevel.GetComponent<Level>().mStartPos.position;
        }

    }

    public void Restart()
    {
        Destroy(mCurrentLevel);

        mCurrentLevel = Instantiate(Levels[levelCount], mStartPos.position, mStartPos.rotation) as GameObject;

        GameManager.sInstance.mPlayerController.gameObject.transform.position = mCurrentLevel.GetComponent<Level>().mStartPos.position;
    }
}
