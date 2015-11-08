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
	public Action onCountDownStart;
	
	public int CurrentScore{
		get{
			return calculator.CurrentScore;
		}
	}

	List<EnemyCollision> aliveList = new List<EnemyCollision>();

	public void Initialize()
	{
		GameObject go = Util.InstantiateTo (this.gameObject, timerCounter);
		TimeCounter tc = go.GetComponent<TimeCounter> ();
		tc.onComplete = () => {
			LoadResult();
		};
		tc.Inithialize ();

		GameObject cgo = Util.InstantiateTo (this.gameObject, scoreCalculator);
		calculator = cgo.GetComponent<ScoreCalculator>();

		GameObject coGo = Util.InstantiateTo (this.gameObject, countDown);
		coGo.GetComponent<UI_CountDown>().onCountDownFinish = () => {
			if(onCountDownStart != null) onCountDownStart();
		};

		int id = 1;
		foreach(Enemy e in enemyList){
			GameObject ego = Util.InstantiateTo (e.target, e.collision.gameObject);
			ego.transform.localPosition = e.position;
			ego.transform.localRotation = e.rotation;
			ego.transform.localScale = e.scale;
			ego.name = id.ToString();
			EnemyCollision ec = ego.GetComponent<EnemyCollision>();
			aliveList.Add(ec);
			id++;
			ec.OnDestroyed = (EnemyCollision enemyCollision) => {
				aliveList.RemoveAll((eneC) => eneC.name == enemyCollision.name);
				if(aliveList.Count <= 0){
					LoadResult();
				}
			};
		}
	}
	
	public void AddScore(int score){
		calculator.AddScore (score);
	}

	void LoadResult(){
		FadeManager.Instance.LoadLevel("Result", 1.0f);
	}
}