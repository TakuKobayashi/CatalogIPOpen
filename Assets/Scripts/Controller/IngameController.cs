using UnityEngine;
using System;
using System.Collections;

public class IngameController : SingletonBehaviour<IngameController> 
{
	[SerializeField] Prefab timerCounter;
	
	public void Initialize()
	{
		GameObject go = Util.InstantiateTo (this.gameObject, timerCounter);
		go.GetComponent<TimeCounter>().onComplete = FinishGame;
	}

	void FinishGame(){
		// end of game
		Debug.Log("complete");
	}
}