using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreCalculator : MonoBehaviour {
	int currentScore;

	public int CurrentScore{
		get{
			return currentScore;
		}
	}

	[SerializeField] Text scoreText;
	
	public void Inithialize(){
		UpdateView ();
	}

	void UpdateView(){
		scoreText.text = string.Format ("score: {0}", PlayerPrefs.GetInt ("Score", 0));
	}

	public void AddScore(int score){
		currentScore += score;
		PlayerPrefs.SetInt ("Score", currentScore);
		UpdateView ();
	}
}
