using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitFPS : MonoBehaviour
{
    public int target = 200;
    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = target;
    }

    void Update()
    {
        if(Application.targetFrameRate != target)
        {
            Application.targetFrameRate = target;
        }
    }
}
