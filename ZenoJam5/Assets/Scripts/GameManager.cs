using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{

    [SerializeField] private FadeChannelSO _fadeChannelSO;
    [SerializeField] private EventChannelSO _reachedGoal;
    [SerializeField] private EventChannelSO _LoadNextLevel;

    private float _fadeDuration = 2f;

    private int _currentSceneIndex;
    private int _sceneIndex;

    private ControlPanelManager _controlPanel;
    [SerializeField] private PauseMenu _pauseMenu;


    public GameState State { get; private set; }

    private bool _InGame
    {
        get
        {
            return (_currentSceneIndex > 2 && _currentSceneIndex < SceneManager.sceneCountInBuildSettings);
        }
    }


    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        _LoadNextLevel.OnEventRaised += LoadNextLevel;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        _LoadNextLevel.OnEventRaised -= LoadNextLevel;
    }

    private void Awake()
    {
        _controlPanel = GetComponent<ControlPanelManager>();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
    {
        _currentSceneIndex = scene.buildIndex;
        Debug.Log(scene.name + " " + _currentSceneIndex);

        if (_currentSceneIndex <= 2 || _currentSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            State = GameState.MAIN_MENU;
        }
        else
        {
            State = GameState.IN_GAME;
        }



        _controlPanel.HideControlPanel();

        _fadeChannelSO.FadeIn(_fadeDuration);
    }

    //private void Awake()
    //{
    //    DontDestroyOnLoad(gameObject);
    //}


    public void QuitLevels()
    {
        State = GameState.QUITTING;

        LoadMainMenu();

    }

    public void LoadMainMenu()
    {
        _sceneIndex = 2;
        
        StartCoroutine(UnloadPreviousScene());
    }


    public void StartGame()
    {
        AudioManager.Instance.FadeMusicOut(0.5f);
        _sceneIndex = 3;

        StartCoroutine(UnloadPreviousScene());
    }

    public void LoadNextLevel()
    {

        // play music?


        // wait for 

        _sceneIndex++;

        // load next scene!
        StartCoroutine(UnloadPreviousScene());
        //SceneManager.LoadScene(_sceneIndex);

    }





    public void RestartLevel()
    {
        StartCoroutine(UnloadPreviousScene());
    }


    private IEnumerator UnloadPreviousScene()
    {
        Time.timeScale = 1;
        _fadeChannelSO.FadeOut(_fadeDuration);

        yield return new WaitForSeconds(_fadeDuration);

        if (_currentSceneIndex > 1)
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

        //_fadeChannelSO.FadeIn(_fadeDuration);

        AsyncOperation handle =  SceneManager.LoadSceneAsync(_sceneIndex, LoadSceneMode.Additive);
        //handle.completed += OnNewSceneLoaded;

        //Time.timeScale = 1;

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


    public void ShowPauseMenu()
    {
        _pauseMenu.Show();
    }

    public void HidePauseMenu()
    {
        _pauseMenu.ReturnToGame();
    }



    private void Update()
    {

        if (State != GameState.IN_GAME)
            return;

        // key presses!
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseMenu.IsShowing)
            {
                HidePauseMenu();
            }
            else
            {
                ShowPauseMenu();
            }            
        }


    }


    public enum GameState
    {
        MAIN_MENU,
        IN_GAME,
        QUITTING
    }

}