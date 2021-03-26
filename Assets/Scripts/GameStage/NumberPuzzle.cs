using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberPuzzle : MonoBehaviour {

    public Text m_numberText;
    public int m_ClickNumber;

	// Use this for initialization
	void Start () {
        //初期値は0に
        m_ClickNumber = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {if (m_ClickNumber < 9)
        {
            //表示されている数字が9未満の場合は現在の数字に1を足してボタンに表示する
            m_ClickNumber += 1;
            m_numberText.text = m_ClickNumber.ToString();
        }
    else if(m_ClickNumber >= 9)
        {
            //表示されている数字9の場合は0をボタンに表示
            m_ClickNumber = 0;
            m_numberText.text = m_ClickNumber.ToString();
        }
    }
}
