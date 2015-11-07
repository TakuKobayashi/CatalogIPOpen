using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float Player_MoveLimit;
    public float Player_Move;
    float Player_RotX, Player_RotY;
    public ParticleSystem[] Afterburner;

    // Use this for initialization
    void Start()
    {
        Player_Move = Player_MoveLimit;
    }

    // Update is called once per frame
    void Update()
    {
        Player_Input();
        Player_Update();
    }

    void Player_Input()
    {
        Player_RotX = Input.GetAxis("Mouse X");
        Player_RotY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0) == true)
        {
            Player_Move = Player_MoveLimit*10.0f;
        }
       
        //[1]ボタンが押されているかどうかを取得する
        bool mouseLeftButton = Input.GetMouseButton(0);
        bool mouseRightButton = Input.GetMouseButton(1);
        bool mouseWheelButton = Input.GetMouseButton(2);

        //[2]ボタンが"1回"押されたかどうかを取得する
        bool mouseLeftButtonDown = Input.GetMouseButtonDown(0);
        bool mouseRightButtonDown = Input.GetMouseButtonDown(1);
        bool mouseWheelButtonDown = Input.GetMouseButtonDown(2);

        //[3]ボタンが"1回"離されたかどうかを取得する
        bool mouseLeftButtonUp = Input.GetMouseButtonUp(0);
        bool mouseRightButtonUp = Input.GetMouseButtonUp(1);
        bool mouseWheelButtonUp = Input.GetMouseButtonUp(2);

    }

    void Player_Update()
    {
        if (Player_Move > Player_MoveLimit)
        {
            Player_Move -= Player_MoveLimit;
        }
        Afterburner[0].emissionRate = Player_Move * 50.0f;
        Afterburner[1].emissionRate = Player_Move * 50.0f;

        transform.Rotate(new Vector3(-Player_RotY, Player_RotX, 0.0f));

        Vector3 Player_Vec;
        Player_Vec = new Vector3(0.0f, 0.0f, Player_Move);
        transform.Translate(Player_Vec);
    }

    void OnCollisionEnter(Collision collision)
    {
        transform.Translate(new Vector3(0.0f, 0.0f, -5.0f));
    }

}
