using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloseGame : MonoBehaviour
{
    public void Exit()
    {
        if (Input.GetButton("Confirm"))
        
            Application.Quit();
    }
}
