using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IngameController : SingletonBehaviour<IngameController> 
{
	[SerializeField] Prefab timerCounter;
	[SerializeField] Prefab scoreCalculator;
	[SerializeField] Prefab enemyController;

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

		GameObject ego = Util.InstantiateTo (this.gameObject, enemyController);
		EnemyController enemy = ego.GetComponent<EnemyController>();
		enemy.Appear();
	}

	public void AddScore(int score){
		calculator.AddScore (score);
	}
}