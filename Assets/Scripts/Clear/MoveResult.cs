using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveResult : MonoBehaviour
{
    /// <summary>
    /// ボタンをクリック
    /// </summary>
    public void OnClick()
    {
        StartCoroutine("EndGame");
    }

    /// <summary>
    /// 1秒後にResultSceneに遷移
    /// </summary>
    /// <returns></returns>
    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene("ResultScene");
    }
}
