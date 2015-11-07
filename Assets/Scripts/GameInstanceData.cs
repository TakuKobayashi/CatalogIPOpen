using UnityEngine;
using System.Collections;




public class GameInstanceData : MonoBehaviour {
	public class GameInstanceDataHold
	{
		public float m_DataA;

	}
	public static GameInstanceDataHold m_GameInstanceData;


	public float m_DataB;
	// Use this for initialization
	void Start()
	{
		if (m_GameInstanceData == null)
		{
			m_GameInstanceData = new GameInstanceDataHold();
		}
	}

	GameInstanceDataHold GetGrobal()
	{
		if (m_GameInstanceData == null)
		{
			m_GameInstanceData = new GameInstanceDataHold();
		}

		return m_GameInstanceData;
    }

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			m_GameInstanceData.m_DataA = 120f;
			Application.LoadLevel("sceneB");
		}

		if (Input.GetKeyDown(KeyCode.B))
		{
			m_DataB = m_GameInstanceData.m_DataA;
		}
	}
}
