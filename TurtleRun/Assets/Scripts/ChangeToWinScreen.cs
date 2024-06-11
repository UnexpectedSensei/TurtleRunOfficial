using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToWinScreen : MonoBehaviour
{
    // Load the game screen
    void WinScreen()
    {
        SceneManager.LoadScene("WinScreen");
        Debug.Log("Go to game");
    }
    
}
