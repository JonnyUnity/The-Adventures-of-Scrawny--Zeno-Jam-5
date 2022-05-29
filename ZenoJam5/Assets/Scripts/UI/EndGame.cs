using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private AudioClip _endMusic;


    private void Start()
    {
        AudioManager.Instance.FadeMusicIn(_endMusic, 1f);
    }

    public void BackToStart()
    {
        GameManager.Instance.LoadMainMenu();
    
    }

}