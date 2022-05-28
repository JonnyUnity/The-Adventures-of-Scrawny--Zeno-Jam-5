using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private LoadEventChannelSO _loadLevel = default;
    [SerializeField] private FadeChannelSO _fadeChannel = default;

    private LevelSO _levelToLoad;
    private LevelSO _currentlyLoadedScene;
    private AsyncOperationHandle<SceneInstance> _loadingOperationHandle;

    private float _fadeDuration = .5f;

    private void OnEnable()
    {
        _loadLevel._OnLoadingRequested += LoadLevel;
    }

    private void OnDisable()
    {
        _loadLevel._OnLoadingRequested -= LoadLevel;
    }

    private void LoadLevel(LevelSO levelToLoad, bool fadeScreen)
    {
        _levelToLoad = levelToLoad;


        StartCoroutine(UnloadPreviousScene());

    }

    private IEnumerator UnloadPreviousScene()
    {
        _fadeChannel.FadeOut(_fadeDuration);

        yield return new WaitForSeconds(_fadeDuration);

        if (_currentlyLoadedScene != null) //would be null if the game was started in Initialisation
        {
            if (_currentlyLoadedScene.sceneReference.OperationHandle.IsValid())
            {
                //Unload the scene through its AssetReference, i.e. through the Addressable system
                _currentlyLoadedScene.sceneReference.UnLoadScene();
            }
#if UNITY_EDITOR
            else
            {
                //Only used when, after a "cold start", the player moves to a new scene
                //Since the AsyncOperationHandle has not been used (the scene was already open in the editor),
                //the scene needs to be unloaded using regular SceneManager instead of as an Addressable
                SceneManager.UnloadSceneAsync(_currentlyLoadedScene.sceneReference.editorAsset.name);
            }
#endif
        }

        LoadNewScene();
    }


    private void LoadNewScene()
    {
        _loadingOperationHandle = _levelToLoad.sceneReference.LoadSceneAsync(LoadSceneMode.Additive, true, 0);
        _loadingOperationHandle.Completed += OnNewSceneLoaded;
    }

    private void OnNewSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {

        SceneManager.SetActiveScene(obj.Result.Scene);
        _fadeChannel.FadeIn(_fadeDuration);

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
