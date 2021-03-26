using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Text
using MiniJSON;		// Json
using System;		// File
using System.IO;	// File
using System.Text;	// File
using UnityEngine.Networking;

public class RankingManager : MonoBehaviour
{
    //現在サーバー連携がされていないため、常にjsonデータ取得に失敗しResultSceneにランキングが表示されない

    [SerializeField] private GameObject rankingContentPrefab;

    [SerializeField] private Transform contentTransform;

   // private float rankMinuts =0;
    private float totalRankMinute;
    private float totalRankSecond;
    private float allTimeSecond;

    // Use this for initialization
    void Start()
    {
        //下メソッド実行
        GetJsonFromWww();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void GetJsonFromWww()
    {

        // APIが設置してあるURLパス
        string sTgtURL = "http://localhost/mazetime2/mazetime2/getmazetime";
        //		string	sTgtURL	= "http://127.0.0.1/messageboardsapi/MessageBoards/getMessages";

        // Wwwを利用して json データ取得をリクエストする
        StartCoroutine(GetMessages(sTgtURL, CallbackWwwSuccess, CallbackWwwFailed));
    }




    /// <summary>
	/// Callbacks the www success.
	/// </summary>
	/// <param name="response">Response.</param>
	private void CallbackWwwSuccess(string response)
    {

        // json データ取得が成功したのでデシリアライズして整形し画面に表示する
        List<RankingData> rankingList = RankingDataModel.DesirializeFromJson(response);

        string sStrOutput = "";
        foreach (RankingData rankingData in rankingList)
        {
            sStrOutput += string.Format("ID:{0}\n", rankingData.Id);
            sStrOutput += string.Format("STAGE TIME:{0}\n", rankingData.st5time);

            CreateRankingContent(rankingData);
        }
        //DisplayField.text = sStrOutput;
        Debug.Log(sStrOutput);

    }
    /// <summary>
    /// Callbacks the www failed.
    /// </summary>
    private void CallbackWwwFailed()
    {

        // jsonデータ取得に失敗した
        // DisplayField.text = "Www Failed";

        Debug.Log("Www Failed");
    }


    /// <summary>
	/// Downloads the json.
	/// </summary>
	/// <returns>The json.</returns>
	/// <param name="sTgtURL">S tgt UR.</param>
	/// <param name="cbkSuccess">Cbk success.</param>
	/// <param name="cbkFailed">Cbk failed.</param>
	private IEnumerator GetMessages(string sTgtURL, Action<string> cbkSuccess = null, Action cbkFailed = null)
    {

        // WWWを利用してリクエストを送る
        WWW www = new WWW(sTgtURL);

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
        else
        if (www.isDone)
        {
            // リクエスト成功の場合
            Debug.Log(string.Format("Success:{0}", www.text));
            if (null != cbkSuccess)
            {
                cbkSuccess(www.text);
            }
        }
    }


    /// <summary>
	/// Responces the check for time out WWW.
	/// </summary>
	/// <returns>The check for time out WWW.</returns>
	/// <param name="www">Www.</param>
	/// <param name="timeout">Timeout.</param>
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

    private void CreateRankingContent(RankingData rankingData)
    {
        GameObject content = Instantiate(rankingContentPrefab);
        content.transform.SetParent(contentTransform);

        content.GetComponent<RankingContent>().idText.text = rankingData.Id.ToString();
        content.GetComponent<RankingContent>().time.text = rankingData.st5time;
    }
}