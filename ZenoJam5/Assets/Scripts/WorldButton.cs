using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldButton : MonoBehaviour
{

    //[SerializeField] private GameEvent _OnButtonActivated;
    //[SerializeField] private GameEvent _OnButtonDeactivated;

    [SerializeField] private EventChannelSO _OnButtonActivated;
    [SerializeField] private EventChannelSO _OnButtonDeactivated;

    [SerializeField] private Sprite _buttonIdle;
    [SerializeField] private Sprite _buttonPressed;
    [SerializeField] private SpriteRenderer _buttonRenderer;

    [Header("SFX")]
    [SerializeField] private AudioClip _plateDownClip;
    [SerializeField] private AudioClip _plateUpClip;


    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();    
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _audioSource.PlayOneShot(_plateDownClip);
            _buttonRenderer.sprite = _buttonPressed;
            _OnButtonActivated.RaiseEvent();
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _audioSource.PlayOneShot(_plateUpClip);
            _buttonRenderer.sprite = _buttonIdle;
            _OnButtonDeactivated.RaiseEvent();
        }            
    }


}