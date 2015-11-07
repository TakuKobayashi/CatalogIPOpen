using UnityEngine;
using System;
using System.Collections;

public class IngameController : SingletonBehaviour<IngameController> 
{
	[SerializeField] Prefab timerCounter;
	[SerializeField] Prefab scoreCalculator;
	ScoreCalculator calculator;
	public Action onFinish;

	public int CurrentScore{
		get{
			return calculator.CurrentScore;
		}
	}

	public void Initialize()
	{
		GameObject go = Util.InstantiateTo (this.gameObject, timerCounter);
		go.GetComponent<TimeCounter>().onComplete = onFinish;

		GameObject cgo = Util.InstantiateTo (this.gameObject, scoreCalculator);
		calculator = cgo.GetComponent<ScoreCalculator>();
	}

	public void AddScore(int score){
		calculator.AddScore (score);
	}
}