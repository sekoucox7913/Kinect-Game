using UnityEngine;
using System.Collections;

public class ScreenResolution: MonoBehaviour {

	float fScale;
	int m_CurWidth;
	int m_CurHeight;

	void Awake()
	{

		fScale = 768f / 5376f;
		m_CurWidth =  Screen.width;
		m_CurHeight = (int)(m_CurWidth * fScale);
		Screen.SetResolution (m_CurWidth, m_CurHeight, false);
	}


	void Update()
	{
	
		if (Input.GetKeyDown (KeyCode.P)) {
		
			//Screen.SetResolution (m_CurWidth, m_CurHeight, true);
			Screen.fullScreen = true;
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			
			Screen.SetResolution (m_CurWidth, m_CurHeight, false);
		}

	}

}