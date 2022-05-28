using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(menuName = "Level Data/Level")]
public class LevelSO : ScriptableObject
{
    public AssetReference sceneReference;
	public GameSceneType _sceneType;
	public enum GameSceneType
	{
		//Playable scenes
		Location, //SceneSelector tool will also load PersistentManagers and Gameplay
		Menu, //SceneSelector tool will also load Gameplay

		//Special scenes
		Initialisation,
		PersistentManagers,
		Gameplay,

		//Work in progress scenes that don't need to be played
		Art,
	}

}
