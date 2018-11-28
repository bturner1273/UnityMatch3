using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool isGameActive;

	// Use this for initialization
	void Start () {
        isGameActive = true;
	}

    public static void SetGameActive(bool initGameActive)
    {
        isGameActive = initGameActive;
    }

    public static bool IsGameActive()
    {
        return isGameActive;
    }
	
	 
}
