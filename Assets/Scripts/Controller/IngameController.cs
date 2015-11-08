using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class IngameController : SingletonBehaviour<IngameController> 
{
	[Serializable]
	public struct Enemy{
		public EnemyCollision collision;
		public Vector3 position;
		public Vector3 scale;
	}

	[SerializeField] Prefab timerCounter;
	[SerializeField] Prefab scoreCalculator;
	[SerializeField] GameObject valkyrie;
	[SerializeField] List<Enemy> enemyList;
	
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

		foreach(Enemy e in enemyList){
			GameObject ego = Util.InstantiateTo (valkyrie, e.collision.gameObject);
			ego.transform.localPosition = e.position;
			ego.transform.localScale = e.scale;
		}
	}

	public void AddScore(int score){
		calculator.AddScore (score);
	}
}