using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(01);
    }
    public void Replay()
    {
        SceneManager.LoadScene(01);
    }
}
