﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBuild : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
            Debug.Log("Quit");
        }
    }
}
