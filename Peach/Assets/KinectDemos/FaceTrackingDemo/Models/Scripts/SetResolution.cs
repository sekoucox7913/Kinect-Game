using UnityEngine;
using System.Collections;

public class SetResolution : MonoBehaviour {

	float fScale;
	int m_CurWidth;
	int m_CurHeight;
	
	void Awake()
	{
		m_CurWidth = 1024;
		m_CurHeight = 768;
		//fScale = 768f / 1024f;
		//m_CurWidth =  Screen.width;
		//m_CurHeight = (int)(m_CurWidth * fScale);
		Screen.SetResolution (m_CurWidth, m_CurHeight, false);
	}
}
