
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    // Public method to be called when the button is clicked
    public void ChangeToTutorial()
    {
        // Load the Tutorial screen
        SceneManager.LoadScene("Tutorial");

    }
}
