using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Made by Oscar Oosterling
 * 
 * Add this script to Main Camera.
 * This script lets the user exit the build version of this project
 * */
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
