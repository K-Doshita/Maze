using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour
{
    public void OnCLickRegister()
    {
        SetJsonFromWww();
    }
    private void SetJsonFromWww()
    {
        // APIが設置してあるURLパス
        string sTgtURL = "http://localhost/mazetime2/mazetime2/setmazetime";
        string GameTime = TimeText.putTime;
        // Wwwを利用して json データ取得をリクエストする
        StartCoroutine(SetMessage(sTgtURL, GameTime, CallbackApiSuccess, CallbackWwwFailed));
    }
    private IEnumerator SetMessage(string urlTarget, string GameTime, Action<string> cbkSuccess = null, Action cbkFailed = null)
    {
        WWWForm form = new WWWForm();
        //form.AddField("Name", name);
        form.AddField("st5time", GameTime);
        // WWWを利用してリクエストを送る
        WWW www = new WWW(urlTarget, form);
        // WWWレスポンス待ち
        yield return StartCoroutine(ResponceCheckForTimeOutWWW(www, 5.0f));
        if (www.error != null)
        {
            //レスポンスエラーの場合
            Debug.LogError(www.error);
            if (null != cbkFailed)
            {
                cbkFailed();
            }
        }
        else if (www.isDone)
        {
            // リクエスト成功の場合
            Debug.Log(string.Format("Success:{0}", www.text));
            if (null != cbkSuccess)
            {
                cbkSuccess(www.text);
            }
        }
    }
    private void CallbackApiSuccess(string response)
    {
        // json データ取得が成功したのでデシリアライズして整形し画面に表示する
        Debug.Log(response);
    }
    private void CallbackWwwFailed()
    {
        // jsonデータ取得に失敗した
        Debug.Log("Www Failed");
    }
    private IEnumerator ResponceCheckForTimeOutWWW(WWW www, float timeout)
    {
        float requestTime = Time.time;
        while (!www.isDone)
        {
            if (Time.time - requestTime < timeout)
            {
                yield return null;
            }
            else
            {
                Debug.LogWarning("TimeOut"); //タイムアウト
                break;
            }
        }
        yield return null;
    }
}
