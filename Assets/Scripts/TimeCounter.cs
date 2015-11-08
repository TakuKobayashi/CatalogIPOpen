using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeCounter : MonoBehaviour{
	DateTime startTime;

	public Action<TimeSpan> onProgress;
	public Action onComplete;
	public long limitTimeSecond;
	bool isFinish;
	bool isStart;
	[SerializeField] Text remainTimeText;
	
	public void Inithialize(){
		startTime = DateTime.Now;
		TimeSpan time = TimeSpan.FromSeconds (limitTimeSecond);
		remainTimeText.text = string.Format ("{0}:{1}:{2}", time.Minutes, time.Seconds, time.Milliseconds);
	}

	public void startTimer(){
		startTime = DateTime.Now;
		isStart = true;
	}

	void Update(){
		if(!isStart) return;
		TimeSpan progress = DateTime.Now - startTime;
		TimeSpan remainTime = TimeSpan.FromSeconds (limitTimeSecond) - progress;
		if (remainTime <= TimeSpan.FromSeconds (0)) {
			remainTime = TimeSpan.FromSeconds (0);
		}
		remainTimeText.text = string.Format ("{0}:{1}:{2}", remainTime.Minutes, remainTime.Seconds, remainTime.Milliseconds);
		if(onProgress != null) onProgress(progress);
		if (limitTimeSecond < progress.TotalSeconds && !isFinish) {
			if(onComplete != null) onComplete();
			isFinish = true;
		}
	}

}
