using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public GameObject m_DestroyEffect;

	IngameController m_Ctrl;


	void Start()
	{
		m_Ctrl = IngameController.Instance;
    }

	public void DestroyPlay()
	{
		GameObject.Instantiate(m_DestroyEffect);
		m_DestroyEffect.transform.position = this.transform.position;
		m_Ctrl.AddScore(10);
        GameObject.Destroy(this.gameObject);
	}
}
