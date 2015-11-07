using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {



	void OnCollisionEnter(Collision collision)
	{
		
		
		EnemyCollision enemyCompo = collision.other.gameObject.GetComponent<EnemyCollision>();

		if (enemyCompo != null)
		{
			enemyCompo.DestroyPlay();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
