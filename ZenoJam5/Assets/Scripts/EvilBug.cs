using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilBug : MonoBehaviour
{
    private Rigidbody2D _rigidBody;


    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            BugController controller = collision.gameObject.GetComponent<BugController>();

            controller.StopInPlace();
            _rigidBody.constraints = RigidbodyConstraints2D.FreezePosition;

            Debug.Log("Eat the bug!");

            // restart level
            GameManager.Instance.RestartLevel();
        }
    }


}
