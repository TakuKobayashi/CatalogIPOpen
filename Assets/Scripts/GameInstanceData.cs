using UnityEngine;
using System.Collections;




public class GameInstanceData : MonoBehaviour {

	public class HoldValue
	{
		public int m_Score;
	}

	public static HoldValue m_GameInstanceData;



	// Use this for initialization
	void awake()
	{
		if (m_GameInstanceData == null)
		{
			m_GameInstanceData = new HoldValue();
		}
	}


	static public HoldValue GetGrobal()
	{
		if (m_GameInstanceData == null)
		{
			m_GameInstanceData = new HoldValue();
		}

		return m_GameInstanceData;
    }
}
