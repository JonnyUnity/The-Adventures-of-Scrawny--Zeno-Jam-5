using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private bool _showButton1;
    [SerializeField] private bool _showButton2;
    [SerializeField] private bool _showButton3;

    // Start is called before the first frame update
    void Start()
    {
        if (_musicClip != null)
        {
            AudioManager.Instance.FadeMusicIn(_musicClip, 1f);
        }

        GameManager.Instance.LoadControlPanel(_showButton1, _showButton2, _showButton3);    
    }

}