﻿using UnityEngine;
using System.Collections;

public class ScoreCul : MonoBehaviour {

	GameInstanceData.HoldValue m_GameInstance;

	void Awake()
	{
		m_GameInstance = GameInstanceData.GetGrobal();
    }
	
	void AddScore( int score )
	{
		m_GameInstance.m_Score += score;
    }

	private void OnTriggerEnter(Collider other)
	{

	}
}
