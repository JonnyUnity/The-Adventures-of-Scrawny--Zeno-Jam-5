using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour
{

    [SerializeField] private BoolEventChannelSO _scrawnyDied;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Death plane!");

            _scrawnyDied.RaiseEvent(false);
        }
    }

}
