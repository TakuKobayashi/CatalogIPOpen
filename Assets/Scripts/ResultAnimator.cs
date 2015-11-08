using UnityEngine;
using System.Collections;

public class ResultAnimator : MonoBehaviour {

	GameObject m_ResultChara;
	Animator m_Anime;
	void Awake()
	{
		m_ResultChara = GameObject.Find("ValkyrieFaceAnimation");
		m_Anime = m_ResultChara.GetComponent<Animator>();
    }

	void Start()
	{
		m_Anime.Play("003_NOT01_Final", -1 , 0.062f);
    }
}
