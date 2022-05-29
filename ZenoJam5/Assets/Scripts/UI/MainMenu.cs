using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioClip _menuMusic;
    [SerializeField] private GameObject _quitButton;

    private void Start()
    {
        AudioManager.Instance.FadeMusicIn(_menuMusic, 1f);
#if UNITY_WEBGL && !UNITY_EDITOR
    _quitButton.SetActive(false);
#endif

    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }

}
