using UnityEngine;
using System;
using System.Collections;

public class GameController : SingletonBehaviour<GameController> 
{
	string loadingString;
	bool isReady;
	[SerializeField] Prefab timerCounter;

	public bool IsReady { get { return isReady; } }

	public void OnDestroy()
	{
		if(Instance == this)
		{
			Application.RegisterLogCallback(null);
			Application.RegisterLogCallbackThreaded(null);
		}
	}

	public void Initialize()
	{
		AbortAll();
		isReady = true;
		GameObject go = Util.InstantiateTo (this.gameObject, timerCounter);
		go.GetComponent<TimeCounter>().onComplete = FinishGame;
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