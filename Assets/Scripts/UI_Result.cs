using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class UI_Result : MonoBehaviour {
    public Button Title_Move;
    // Use this for initialization
    void Start () {
	Title_Move.onClick.AddListener(Move);
    }
    void Move()
    {
        Application.LoadLevel("Title");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
