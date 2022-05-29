using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{

    [SerializeField] private EventChannelSO _reachedGoal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerTrigger"))
        {
            // reached goal!
            //GameManager.Instance.ReachedGoal();
            _reachedGoal.RaiseEvent();

        }

    }

}
