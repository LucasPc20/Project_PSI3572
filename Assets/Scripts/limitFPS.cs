using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limitFPS : MonoBehaviour
{
    void Start()
    {
        Application.targetFrameRate = 200;
    }
}