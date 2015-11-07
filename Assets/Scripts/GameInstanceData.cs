using UnityEngine;
using System.Collections;




public class GameInstanceData : MonoBehaviour {

	public static GameInstanceData m_GameInstanceData;


	public int m_Score;
	// Use this for initialization
	void Start()
	{
		if (m_GameInstanceData == null)
		{
			m_GameInstanceData = new GameInstanceData();
		}
	}

	static public GameInstanceData GetGrobal()
	{
		if (m_GameInstanceData == null)
		{
			m_GameInstanceData = new GameInstanceData();
		}

		return m_GameInstanceData;
    }


}
