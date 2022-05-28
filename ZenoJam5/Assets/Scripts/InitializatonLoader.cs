using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.SceneManagement;

public class InitializatonLoader : MonoBehaviour
{
    [SerializeField] private LevelSO _managersScene = default;
    [SerializeField] private LevelSO _mainMenu = default;

    [Header("Broadcasting on")]
    [SerializeField] private LoadEventChannelSO _menuLoadChannel = default;

    // Start is called before the first frame update
    private void Start()
    {
        //SceneManager.LoadScene(1); // persistent managers
        AsyncOperation handle = SceneManager.LoadSceneAsync(1);
        handle.completed += ManagersLoaded;

    }

    private void ManagersLoaded(AsyncOperation obj)
    {
        GameManager.Instance.LoadMainMenu();
    }




    //private void LoadEventChannel(AsyncOperationHandle<SceneInstance> obj)
    //{
    //    //obj.Result.RaiseEvent(_mainMenu, false);

    //    //SceneManager.UnloadSceneAsync(0); //Initialization is the only scene in BuildSettings, thus it has index 0
    //    _menuLoadChannel.RaiseEvent(_mainMenu, false);
    //    //SceneManager.UnloadSceneAsync(0);

    //        //_menuLoadChannel.LoadAssetAsync<LoadEventChannelSO>().Completed += LoadMainMenu;
    //}


}