using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	enum STATE{
		BLANK ,
		WAIT ,
		INTRO ,
		MAIN
	}
	STATE m_State = STATE.BLANK;
	STATE m_StateOld;
	bool m_EnterPls;
	float m_StateTime = 0.0f;

	public AudioSource m_Intro;
	public AudioSource m_Main;
	public float m_IntroTime = 0.0f;
	bool StartFlg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
			case ( STATE.WAIT ):
				stWait();
                break;
			case (STATE.INTRO):
				stIntro();
				break;
			case (STATE.MAIN):
				stMain();
				break;
		}
		StartFlg = false;
    }

	void stBlank()
	{
		m_State = STATE.WAIT ;
    }

	void stWait()
	{
		if (true)
		{
			m_State = STATE.INTRO;
		}
	}

	void stIntro()
	{
		if ( m_EnterPls )
		{
			m_Intro.Play();
        }
		if (m_StateTime > m_IntroTime)
		{
			m_State = STATE.MAIN;
		}
	}

	void stMain()
	{
		if (m_EnterPls)
		{
			m_Main.Play();
		}
	}

	public void StartFlgOn()
	{
		StartFlg = true;
    }
}
