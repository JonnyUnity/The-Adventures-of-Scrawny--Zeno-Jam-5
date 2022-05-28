using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private FadeChannelSO _fadeChannelSO;

    private float _fadeDuration = 0.5f;

    private int _currentSceneIndex;
    private int _sceneIndex;

    private ControlPanelManager _controlPanel;


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Awake()
    {
        _controlPanel = GetComponent<ControlPanelManager>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        _currentSceneIndex = scene.buildIndex;
        Debug.Log(scene.name + " " + _currentSceneIndex);
        _controlPanel.HideControlPanel();
    }

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}




    public void LoadMainMenu()
    {
        _sceneIndex = 2;
        StartCoroutine(UnloadPreviousScene());

        //SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }


    public void StartGame()
    {
        AudioManager.Instance.FadeMusicOut(0.5f);
        _sceneIndex = 3;

        StartCoroutine(UnloadPreviousScene());
        //SceneManager.LoadScene(3, LoadSceneMode.Additive);
    }

    public void ReachedGoal()
    {
        _sceneIndex++;

        // load next scene!
        StartCoroutine(UnloadPreviousScene());
        //SceneManager.LoadScene(_sceneIndex);

    }


    private IEnumerator UnloadPreviousScene()
    {

        _fadeChannelSO.FadeOut(_fadeDuration);

        yield return new WaitForSeconds(_fadeDuration);

        if (_currentSceneIndex > 0)
        {
            SceneManager.UnloadSceneAsync(_currentSceneIndex);
        }

        LoadNewScene();
    }


    private void LoadNewScene()
    {
        //if (_showLoadingScreen)
        //{
        //    _toggleLoadingScreen.RaiseEvent(true);
        //}

        

        AsyncOperation handle =  SceneManager.LoadSceneAsync(_sceneIndex, LoadSceneMode.Additive);
        //handle.completed += OnNewSceneLoaded;

        //_loadingOperationHandle = _sceneToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0);
        //_loadingOperationHandle.Completed += OnNewSceneLoaded;
    }

    public void LoadSceneFromEditorStartup(int sceneIndex)
    {
        _sceneIndex = sceneIndex;

        StartCoroutine(UnloadPreviousScene());
    }


    public void LoadControlPanel(GameObject[] interactables)
    {

        

        _controlPanel.BuildControlPanel(interactables);

    }

}