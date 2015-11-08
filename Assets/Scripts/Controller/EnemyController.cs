using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour
{
	[Serializable]
	public struct Enemy{
		public EnemyCollision collision;
		public Vector3 position;
		public Quaternion rotate;
		public Vector3 scale;
		public GameObject target;
	}

	[SerializeField] List<Enemy> enemyList;

	public void Appear(){
		foreach(Enemy e in enemyList){
			GameObject ego = Util.InstantiateTo (e.target, e.collision.gameObject);
			ego.transform.localPosition = e.position;
			ego.transform.localRotation = e.rotate;
			ego.transform.localScale = e.scale;
		}
	}

}