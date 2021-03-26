using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMove : MonoBehaviour
{
    public PlayerManager m_PlayerManager;

    /// <summary>
    /// ゴールに到達すると接触判定を正にしコルーチン開始
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            m_PlayerManager.m_OnMagicCircle = true;
            StartCoroutine("MagicCircle");
        }
    }

    /// <summary>
    /// 3秒後にClearSceneに遷移
    /// </summary>
    /// <returns></returns>
    private IEnumerator MagicCircle()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("ClearScene");
    }
}
