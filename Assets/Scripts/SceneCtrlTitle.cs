using UnityEngine;
using System.Collections;

public class SceneCtrlTitle : MonoBehaviour {

	public AnimationCurve m_Curve;
	public float m_OffsetSpeed;
	public float m_MaxSpeed;
	public float m_OutTime;

	enum STATE {
		BLANK,
		WAIT,
		MOVE,
		END
	}

	STATE m_State;
	STATE m_StateOld;
	bool m_EnterPls;

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
		}
		else
		{
			m_EnterPls = false;
		}

		switch (m_State)
		{
			case ():
				break;
		}
	}
}
