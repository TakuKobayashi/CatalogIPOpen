using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
	{
		EnemyCollision enemyCompo = other.gameObject.GetComponent<EnemyCollision>();

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
