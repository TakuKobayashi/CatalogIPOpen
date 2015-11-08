using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public float Player_MoveLimit;
    public float Player_Move;
    float Player_RotX, Player_RotY;
    public ParticleSystem[] Afterburner;

	public AnimationCurve m_DamegeBackCurve;
	public float m_BackSpeed;
	public float m_BackTime;
	bool m_Stop;

	STATE m_State = STATE.BLANK;
	STATE m_StateOld;
	bool m_EnterPls;
	float m_StateTime = 0.0f;

	public enum STATE
	{
		BLANK ,
		NORMAL ,
		DAMAGE 
	}

    // Use this for initialization
    void Start()
    {
        Player_Move = Player_MoveLimit;
    }

	void StateChart()
	{
		if (m_StateOld != m_State)
		{
			m_StateOld = m_State;
			m_EnterPls = true;
			m_StateTime = 0.0f;
		}
		else
		{
			m_StateTime += Time.deltaTime;
			m_EnterPls = false;
		}

		switch (m_State)
		{
			case (STATE.BLANK):
				stBlank();
				break;
			case (STATE.NORMAL):
				stNormal();
				break;
			case (STATE.DAMAGE):
				stDamage();
				break;

		}

	}

	void stBlank()
	{
		m_State = STATE.NORMAL;
	}

	void stNormal()
	{
		Player_Update();
	}
	
	void stDamage()
	{
		Player_Damage();
    }

// Update is called once per frame
void Update()
    {
        Player_Input();
		StateChart();
    }

    void Player_Input()
    {
        Player_RotX = Input.GetAxis("Mouse X");
        Player_RotY = Input.GetAxis("Mouse Y");

        if (Input.GetMouseButtonDown(0) == true)
        {
            Player_Move = Player_MoveLimit*20.0f;
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

        transform.Rotate(new Vector3(-Player_RotY * 2, Player_RotX * 2, 0.0f));
		
		Vector3 Player_Vec = new Vector3(0.0f, 0.0f, Player_Move);
        transform.Translate(Player_Vec);
    }

	void Player_Damage()
	{
		if (m_StateTime > m_BackTime )
		{
			m_State = STATE.NORMAL;
		}

		float damegeSpeed = m_DamegeBackCurve.Evaluate( m_StateTime / m_BackTime ) * m_BackSpeed;

		if (!m_Stop)
		{
			Vector3 Player_Vec = new Vector3(0.0f, 0.0f, damegeSpeed);
			transform.Translate(Player_Vec * Time.deltaTime);
		}

	}

	void OnCollisionEnter(Collision collision)
    {
		if ( m_EnterPls )
		{
			m_Stop = false;
        }

		if (m_State ==  STATE.DAMAGE && m_StateTime > 0.1f)
		{
			EnemyCollision otherCompo = collision.other.gameObject.GetComponent<EnemyCollision>();
			if (otherCompo == null)
			{
				m_Stop = true;
            }
		}else
		{
			m_State = STATE.DAMAGE;
		}


		
		//transform.Translate(new Vector3(0.0f, 0.0f, -5.0f));
	}

}
