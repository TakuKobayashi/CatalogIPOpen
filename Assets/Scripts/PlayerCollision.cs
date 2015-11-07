using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {


	void OnTriggerEnter(Collider other)
	{

		EnemyCollision enemyCompo = other.gameObject.GetComponent<EnemyCollision>();

		if (enemyCompo != null)
		{
			SendMessage("DestroyEnemy");
			enemyCompo.DestroyPlay();
		}


	}

	/*
	void OnCollisionEnter(Collision collision)
	{
		
		

	}
	*/

}
