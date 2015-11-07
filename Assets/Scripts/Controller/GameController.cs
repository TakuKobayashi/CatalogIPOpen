using UnityEngine;
using System;
using System.Collections;

public class GameController : SingletonBehaviour<GameController> 
{
	string loadingString;
	bool isReady;
	
	public bool IsReady { get { return isReady; } }

	public void OnDestroy()
	{
		if(Instance == this)
		{
			Application.RegisterLogCallback(null);
			Application.RegisterLogCallbackThreaded(null);
		}
	}

	void Awake(){
		IngameController.Instance.Initialize ();
	}

	public void Initialize()
	{
		AbortAll();
		isReady = true;
	}

	void FinishGame(){
		// end of game
		Debug.Log("complete");
	}
	
	void AbortAll()
	{
		StopAllCoroutines();
	}
}