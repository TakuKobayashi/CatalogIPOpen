using UnityEngine;
using System.Collections;

public class EnemyCollision : MonoBehaviour {

	public GameObject m_DestroyEffect;

	public void DestroyPlay()
	{
		GameObject.Instantiate(m_DestroyEffect);
	}
}
