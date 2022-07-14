using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrawnyController : BugController
{
    [SerializeField] private EventChannelSO _loadNextLevel;

    [SerializeField] private BoolEventChannelSO _scrawnyDeath;

    [Header("Scrawny SFX")]
    [SerializeField] private AudioClip _deathScreamClip;
    [SerializeField] private AudioClip _deathSplatClip;

    [Header("Events")]
    [SerializeField] private EventChannelSO _reachedGoal;

    private void OnEnable()
    {
        _reachedGoal.OnEventRaised += ReachedGoal;
        _scrawnyDeath.OnEventRaised += ScrawnyDied;
    }

    private void OnDisable()
    {
        _reachedGoal.OnEventRaised -= ReachedGoal;
        _scrawnyDeath.OnEventRaised -= ScrawnyDied;
    }



    protected override void ReachedGoal()
    {
        base.ReachedGoal();
        Debug.Log("Do animation!");

        StartCoroutine(VictoryDanceCoroutine());

    }

    private void ScrawnyDied(bool scrawnyEaten)
    {
        var clipToUse = scrawnyEaten ? _deathScreamClip : _deathSplatClip;
        StartCoroutine(DeathSoundCoroutine(clipToUse));
    }


    private IEnumerator DeathSoundCoroutine(AudioClip clip)
    {
        yield return new WaitForSeconds(0.5f);
        _audioSource.PlayOneShot(clip);
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
