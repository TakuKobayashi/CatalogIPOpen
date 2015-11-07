using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    Vector3 Player_Vec;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Player_Vec += new Vector3(0.0f, 0.0f, 1.0f);
        transform.localPosition = Player_Vec;
    }
}
