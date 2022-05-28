using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private AudioClip _musicClip;
    [SerializeField] private GameObject[] _interactables;

    // Start is called before the first frame update
    void Start()
    {
        if (_musicClip != null)
        {
            AudioManager.Instance.FadeMusicIn(_musicClip, 1f);
        }

        GameManager.Instance.LoadControlPanel(_interactables);    
    }

    
}
