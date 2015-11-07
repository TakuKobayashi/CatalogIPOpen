using UnityEngine;
using System;
using System.Collections;

public class IngameController : SingletonBehaviour<IngameController> 
{
	[SerializeField] Prefab timerCounter;
	public Action onFinish;
	
	public void Initialize()
	{
		GameObject go = Util.InstantiateTo (this.gameObject, timerCounter);
		go.GetComponent<TimeCounter>().onComplete = onFinish;
	}
}