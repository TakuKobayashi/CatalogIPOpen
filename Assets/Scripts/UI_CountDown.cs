using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_CountDown : MonoBehaviour {
    public Text Count;
    int Fcnt=0;
    // Use this for initialization
    void Start () {
        Fcnt = 0;
        Count.text = "3";
    }
	
	// Update is called once per frame
	void Update () {
        Fcnt++;
        if (Fcnt == 60) Count.text = "2";
        if (Fcnt == 120) Count.text = "1";
        if (Fcnt == 180) Count.text = "GO";
        if (Fcnt == 200) Count.text = "";
        IngameController.Instance.onFinish = () => {
            FadeManager.Instance.LoadLevel("Result", 1.0f);
        };
        if (Input.GetKeyUp(KeyCode.E))
        {
            FadeManager.Instance.LoadLevel("Result", 1.0f);
        }
    }
}
