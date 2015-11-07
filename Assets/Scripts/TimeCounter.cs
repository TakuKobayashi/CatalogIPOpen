using UnityEngine;
using UnityEngine.UI;
using System;

public class TimeCounter : MonoBehaviour{
	DateTime startTime;

	public Action<TimeSpan> onProgress;
	public Action onComplete;
	public long limitTimeSecond;
	[SerializeField] Text remainTimeText;
	
	void Start(){
		startTime = DateTime.Now;
	}

	void Update(){
		TimeSpan progress = DateTime.Now - startTime;
		TimeSpan remainTime = TimeSpan.FromSeconds (limitTimeSecond) - progress;
		remainTimeText.text = string.Format ("{0}:{1}:{2}", remainTime.Minutes, remainTime.Seconds, remainTime.Milliseconds);
		if(onProgress != null) onProgress(progress);
		if (limitTimeSecond > progress.TotalSeconds) {
			if(onComplete != null) onComplete();
			onComplete = null;
		}
	}

}
