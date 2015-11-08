using UnityEngine;
using System;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public GameObject m_DestroyEffect;
	public Action<EnemyCollision> OnDestroyed;

	IngameController m_Ctrl;


	void Start()
	{
		m_Ctrl = IngameController.Instance;
    }

	public void DestroyPlay()
	{
		GameObject effect = GameObject.Instantiate(m_DestroyEffect);
		effect.transform.position = this.transform.position;
		m_Ctrl.AddScore(10);
		if(OnDestroyed != null) OnDestroyed(this);
        GameObject.Destroy(this.gameObject);
	}
}
