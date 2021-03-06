﻿using UnityEngine;
using System.Collections;

public class SceneCtrlTitle : MonoBehaviour {


	AudioSource m_AudioSource;

	public AnimationCurve m_Curve;
	Vector3 m_StartPos;
	public float m_MaxPos;
	public float m_OutTime;
	public float m_SoundEndTime;
	GameObject m_TitleChara;

	public string m_TitleCharaName;
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
		m_TitleChara = GameObject.Find(m_TitleCharaName);
		m_AudioSource = GameObject.Find("Main Camera").gameObject.GetComponent<AudioSource>();
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
		if (m_EnterPls)
		{
			m_AudioSource.Play();
        }

		if ( m_StateTime > m_OutTime && m_StateTime > m_SoundEndTime)
		{
			m_State = STATE.END;
		}

		Vector3 tempPos = m_StartPos;
		tempPos.y = tempPos.y + m_Curve.Evaluate( m_StateTime / m_OutTime)* m_MaxPos;
		m_TitleChara.transform.position = tempPos;
    }

	void stEnd()
	{
		if (m_EnterPls)
		{
			Application.LoadLevel("Playing");
		}
	}
}
