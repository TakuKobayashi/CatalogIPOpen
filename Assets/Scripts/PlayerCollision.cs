using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {


	void OnCollisionEnter(Collision collision)
	{
		
		
		EnemyCollision enemyCompo = collision.other.gameObject.GetComponent<EnemyCollision>();

		if (enemyCompo != null)
		{
			SendMessage( "DestroyEnemy" );
			enemyCompo.DestroyPlay();
		}
	}
	
}
