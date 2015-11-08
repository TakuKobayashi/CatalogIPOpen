using UnityEngine;
using System.Collections;

public class Result_CameraAniation : MonoBehaviour {
    public float AnimY = 1.6f;
    public float AnimX = 0.02f;
    public int Cnt;
    int a=1,b=1;
    // Use this for initialization
    void Start () {
        Cnt = 0;
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(AnimX*b, AnimY*a, 0);
        Cnt+=a;
        if (Cnt > 45 || Cnt < -45)
        {
            a *= -1;
        }
        if (Cnt % 100 == 0)
        {
            b *= -1;
        }
    }
}
