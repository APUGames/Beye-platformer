using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSession : MonoBehaviour
{
    [SerializeField] int Lives = 5;
    [SerializeField] Text lives;

    public void ProcessPlayerDeath()
    {
        if(Lives > 1)
        {
            SubtractLife();
        }
        else
        {
            ResetGameSession();
        }
    }

    private void ResetGameSession()
    {
        SceneManager.LoadScene(01);

        Destroy(gameObject);
    }

    private void SubtractLife()
    {
        Lives--;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        lives.text = Lives.ToString();
    }

    void Awake()
    {
        //Will find the number of occurrences of this GAme Object
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        lives.text = Lives.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
