using UnityEngine;
using System.Collections;

public class SceneCtrlTitle : MonoBehaviour {

	GameInstanceData.HoldValue m_HoldValue;

	// Use this for initialization
	void Start () {
		m_HoldValue = GameInstanceData.GetGrobal();
		m_HoldValue.m_NowStage = 1;
		m_HoldValue.m_Score = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
