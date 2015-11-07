using UnityEngine;
using System.Collections;

public class SceneCtrlGame : MonoBehaviour {

	enum STATE
	{
		COUNT_3,
		COUNT_2,
		COUNT_1,
		IN_GAME ,
		CLEAR ,
		GAME_ORVER,
	}
	
	bool m_EnterPls = false;
	STATE m_State;
	STATE m_OldState;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (m_State != m_OldState)
		{
			m_State = m_OldState;
			m_EnterPls = true;
		}
		else
		{
			m_EnterPls = false;
        }

		switch (m_State)
		{
			case (STATE.COUNT_3):
				break;
			case (STATE.COUNT_2):
				break;
			case (STATE.COUNT_1):
				break;
			case (STATE.IN_GAME):
				break;
			case (STATE.GAME_ORVER):
				break;
			case (STATE.CLEAR):
				break;
		}
	}


}
