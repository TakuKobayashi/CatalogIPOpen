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
		public Quaternion rotation;
		public Vector3 scale;
		public GameObject target;
	}

	[SerializeField] Prefab timerCounter;
	[SerializeField] Prefab scoreCalculator;
	[SerializeField] Prefab countDown;
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
		TimeCounter tc = go.GetComponent<TimeCounter> ();
		tc.onComplete = () => {
			if (onFinish != null)
				onFinish ();
		};
		tc.Inithialize ();

		GameObject cgo = Util.InstantiateTo (this.gameObject, scoreCalculator);
		calculator = cgo.GetComponent<ScoreCalculator>();

		Util.InstantiateTo (this.gameObject, countDown);

		foreach(Enemy e in enemyList){
			GameObject ego = Util.InstantiateTo (e.target, e.collision.gameObject);
			ego.transform.localPosition = e.position;
			ego.transform.localRotation = e.rotation;
			ego.transform.localScale = e.scale;
		}
	}

	public void AddScore(int score){
		calculator.AddScore (score);
	}
}