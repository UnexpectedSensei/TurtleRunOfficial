using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Public method to be called when the button is clicked
    public void ChangeToMainMenu()
    {
        // Load the Main Menu screen
        SceneManager.LoadScene("MainMenu");
        
        

    }
}
