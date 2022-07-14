using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Goal : MonoBehaviour
{

    [SerializeField] private EventChannelSO _reachedGoal;
    [SerializeField] private CinemachineVirtualCamera _goalCam;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTrigger"))
        {
            // reached goal!
            _audioSource.Play();
            _goalCam.Priority = 3;
            _reachedGoal.RaiseEvent();

        }

    }

}
