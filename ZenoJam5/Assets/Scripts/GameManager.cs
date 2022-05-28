using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    private int _sceneIndex;


    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReachedGoal()
    {
        _sceneIndex++;

        // load next scene!
        SceneManager.LoadScene(_sceneIndex);

    }

}
