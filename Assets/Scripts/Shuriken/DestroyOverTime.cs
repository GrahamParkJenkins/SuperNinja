﻿using UnityEngine;
using System.Collections;

public class DestroyOverTime : MonoBehaviour
{
    public float destroyTime;

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject, destroyTime);
    }
}
