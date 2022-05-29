using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrawnyController : BugController
{
    [SerializeField] private EventChannelSO _loadNextLevel;

    private void OnEnable()
    {
        _reachedGoal.OnEventRaised += ReachedGoal;
    }

    private void OnDisable()
    {
        _reachedGoal.OnEventRaised -= ReachedGoal;
    }


    protected override void ReachedGoal()
    {
        base.ReachedGoal();
        Debug.Log("Do animation!");

        StartCoroutine(VictoryDanceCoroutine());

    }


    private IEnumerator VictoryDanceCoroutine()
    {
        Debug.Log("Victory dance!");
        yield return new WaitForSeconds(2f);
        _loadNextLevel.RaiseEvent();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
