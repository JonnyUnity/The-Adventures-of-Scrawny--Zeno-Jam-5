using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private AudioClip _menuMusic;

    private void Start()
    {
        AudioManager.Instance.FadeMusicIn(_menuMusic, 1f);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

}
