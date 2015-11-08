using UnityEngine;
using System.Collections;

public class SceneCtrlTitle : MonoBehaviour {

	public AnimationCurve m_Curve;
	Vector3 m_StartPos;
	public float m_MaxPos;
	public float m_OutTime;
	GameObject m_TitleChara;

	enum STATE {
		BLANK,
		WAIT,
		MOVE,
		END
	}

	STATE m_State = STATE.BLANK;
	STATE m_StateOld;
	bool m_EnterPls;
	float m_StateTime = 0.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update ()
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
			case (STATE.WAIT):
				stWait();
                break;
			case (STATE.MOVE):
				stMove();
                break;
			case (STATE.END):
				stEnd();
                break;
		}
	}

	void stBlank()
	{
		this.m_State = STATE.WAIT;
	}

	void stWait()
	{
		if (m_EnterPls)
		{
			m_StartPos = m_TitleChara.transform.position;
        }

		if (Input.GetKeyDown(KeyCode.Mouse0))
		{
			this.m_State = STATE.MOVE;
		}
	}

	void stMove()
	{
		if ( m_StateTime > m_OutTime )
		{
			m_State = STATE.END;
		}

		Vector3 tempPos = m_StartPos;
		tempPos.y = tempPos.y + m_Curve.Evaluate( m_StateTime / m_OutTime)* m_MaxPos;
    }

	void stEnd()
	{
		if (m_EnterPls)
		{
			Application.LoadLevel("Playing");
		}
	}
}
