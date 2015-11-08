using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

public class UI_CountDown : MonoBehaviour {
	DateTime startTime;
	readonly int StartCount = 4;
	bool isStart;

    public Text Counter;
	public Action onCountDownFinish;

    void Start () {
		Counter.text = "3".ToString();
		startTime = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update () {
		if (isStart) return;
		TimeSpan progress = DateTime.Now - startTime;
		if (progress.TotalSeconds > StartCount) {
			isStart = true;
			Counter.gameObject.SetActive(false);
			if(onCountDownFinish != null) onCountDownFinish();
		} else if (StartCount - progress.TotalSeconds <= 1) {
			Counter.fontSize = 40;
			Counter.text = "START";
		} else {
			Counter.text = string.Format("{0}", (int)(StartCount - progress.TotalSeconds));
		}
    }
}
