using System.Collections;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{

    public int m_CenterNumber;
    public int m_LeftNumber;
    public int m_RightNumber;
    public bool m_IsAnswer;

    private Animation m_SwitchGuardAnim;

    public GameObject m_NumberCanvas;


    // Use this for initialization
    void Start()
    {
        //パズルを解いた後に再生するAnimationを取得し、GameManagerにまだパズルを解いていないと知らせる
        m_SwitchGuardAnim = GameObject.Find("SwitchGuardGlass").GetComponent<Animation>();
        m_IsAnswer = false;
    }

    // Update is called once per frame
    void Update()
    {
        //毎フレームごとに現在ボタンに表示されている数字を取得
        m_CenterNumber = GameObject.Find("CenterNumberManager").GetComponent<NumberPuzzle>().m_ClickNumber;
        m_LeftNumber = GameObject.Find("LeftNumberManager").GetComponent<NumberPuzzle>().m_ClickNumber;
        m_RightNumber = GameObject.Find("RightNumberManager").GetComponent<NumberPuzzle>().m_ClickNumber;


        //273とボタンを押すとまだパズルを解いていない場合コルーチン再生
        if (m_CenterNumber == 7 && m_LeftNumber == 2 && m_RightNumber == 3)
        {
            if (m_IsAnswer == false)
            {
                StartCoroutine("TrueAnswer");
            }
        }
    }


    //0.2秒の間ののちにアニメーションが再生され、画面に出ていたボタンを非表示にする　GameManagerにパズルを解いたと知らせる
    private IEnumerator TrueAnswer()
    {
        yield return new WaitForSeconds(0.2f);
        m_SwitchGuardAnim.Play();
        m_NumberCanvas.SetActive(false);
        Debug.Log("Answer");
        m_IsAnswer = true;
    }
}

