using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBug : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    [SerializeField] private BoolEventChannelSO _scrawnyDied;
    [SerializeField] private AudioClip _chompClip;

    private AudioSource _audioSource;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BugController controller = collision.gameObject.GetComponent<BugController>();

            controller.StopInPlace();
            _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

            _audioSource.PlayOneShot(_chompClip);

            Debug.Log("Eat the bug!");

            _scrawnyDied.RaiseEvent(true);            
        }
    }
}