using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{ 
    public void GoToGame()
    {
        LoadScene.SwitchToScene("Main");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
