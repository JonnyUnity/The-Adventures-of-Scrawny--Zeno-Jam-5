using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject _pauseMenu;


    public bool IsShowing => _pauseMenu.activeInHierarchy;

    public void Show()
    {
        // animate?
        Time.timeScale = 0;
        _pauseMenu.SetActive(true);
    }

    public void QuitToMenu()
    {
        //Time.timeScale = 1;
        _pauseMenu.SetActive(false);
        GameManager.Instance.QuitLevels();

    }

    public void ReturnToGame()
    {
        Time.timeScale = 1;
        _pauseMenu.SetActive(false);

    }


    //private void Update()
    //{


    //    // key presses!
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (IsShowing)
    //        {
    //            _pauseMenu.SetActive(false);
    //        }
    //        else
    //        {
    //            _pauseMenu.SetActive(true);
    //        }
    //    }


    //}


}
