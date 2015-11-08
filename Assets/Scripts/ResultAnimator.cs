using UnityEngine;
using System.Collections;

public class ResultAnimator : MonoBehaviour {

	GameObject m_ResultChara;
	Animator m_Anime;

	UnityChan.FaceUpdate m_FaceUpdate;

	float m_Time = 0.0f;
	bool m_FaceUpEnd = false;
	void Awake()
	{
		m_ResultChara = GameObject.Find("ValkyrieFaceAnimation");
		m_Anime = m_ResultChara.GetComponent<Animator>();
		m_FaceUpdate = m_ResultChara.GetComponent<UnityChan.FaceUpdate>();
    }

	void Start()
	{
		
		m_Anime.Play("003_NOT01_Final", -1 , 0.062f);

	}

	void Update()
	{
		m_Time += Time.deltaTime;
		if (m_Time > 0.1f && m_FaceUpEnd == false)
		{
			m_FaceUpdate.OnCallChangeFace("default@unitychan");
			m_FaceUpEnd = true;
        }
	}
}
