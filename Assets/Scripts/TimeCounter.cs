using UnityEngine;
using System;

public class TimeCounter : MonoBehaviour{
	DateTime startTime;

	public Action<TimeSpan> onProgress;
	public Action onComplete;
	public long limitTimeSecond;

	void Start(){
		startTime = DateTime.Now;
	}

	void Update(){
		TimeSpan progress = DateTime.Now - startTime;
		if(onProgress != null) onProgress(progress);
		if (limitTimeSecond > progress.TotalSeconds) {
			if(onComplete != null) onComplete();
			onComplete = null;
		}
	}

}
