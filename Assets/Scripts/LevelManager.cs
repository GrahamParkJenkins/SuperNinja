using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject[] Levels;
    public int levelCount;
    public bool levelUp;
    // Use this for initialization
    void Start()
    {
        levelUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(levelUp == true)
        {
            Instantiate(Levels[levelCount]);
        }
    }
}
