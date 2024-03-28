using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManu_ButtonManager : MonoBehaviour
{
    public string gameScene;

    //START GAME
    public void Play()
    {
        SceneManager.LoadScene(gameScene);
    }

    //QUIT
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
