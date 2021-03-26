/// <summary>
/// Manager main.
/// </summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;	//Text
using MiniJSON;		// Json
using System;		// File
using System.IO;	// File
using System.Text;	// File
using UnityEngine.Networking;

public class ManagerMain : MonoBehaviour {

	[SerializeField] public Text DisplayField;

	[SerializeField] public Text InputName;
	[SerializeField] public Text InputMessage;


	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {
		
	}

	/// <summary>
	/// Raises the click clear display event.
	/// </summary>
	public void OnClickClearDisplay(){

		DisplayField.text	= " ";

	}

	/// <summary>
	/// Raises the click get json from www event.
	/// </summary>
	public void OnClickGetMessagesApi(){

		DisplayField.text	= "wait...";
		GetJsonFromWww();

	}
	/// <summary>
	/// Raises the click get json from www event.
	/// </summary>
	public void OnClickSetMessageApi(){

		DisplayField.text	= "wait...";
		SetJsonFromWww();

	}

	/// <summary>
	/// Gets the json from www.
	/// </summary>
	private void GetJsonFromWww(){

		// APIが設置してあるURLパス
		string	sTgtURL	= "http://localhost/messageboardsapi/MessageBoards/getMessages";
//		string	sTgtURL	= "http://127.0.0.1/messageboardsapi/MessageBoards/getMessages";

		// Wwwを利用して json データ取得をリクエストする
		StartCoroutine(GetMessages( sTgtURL, CallbackWwwSuccess, CallbackWwwFailed));

	}
	/// <summary>
	/// Callbacks the www success.
	/// </summary>
	/// <param name="response">Response.</param>
	private void CallbackWwwSuccess( string response) {

		// json データ取得が成功したのでデシリアライズして整形し画面に表示する
		List<RankingData>	messageList	= RankingDataModel.DesirializeFromJson(response);

		string sStrOutput	= "";
		foreach(RankingData message in messageList){
			sStrOutput	+= string.Format("Id:{0}\n",message.Id);
			//sStrOutput	+= string.Format("Score:{0}\n",message.Score);
			//sStrOutput	+= string.Format("Name:{0}\n",message.Name);
		}
		DisplayField.text	= sStrOutput;

	}
	/// <summary>
	/// Callbacks the www failed.
	/// </summary>
	private void CallbackWwwFailed() {

		// jsonデータ取得に失敗した
		DisplayField.text	= "Www Failed";

	}
	/// <summary>
	/// Callbacks the API success.
	/// </summary>
	/// <param name="response">Response.</param>
	private void CallbackApiSuccess( string response) {

		// json データ取得が成功したのでデシリアライズして整形し画面に表示する
		DisplayField.text	= response;

	}

	/// <summary>
	/// Downloads the json.
	/// </summary>
	/// <returns>The json.</returns>
	/// <param name="sTgtURL">S tgt UR.</param>
	/// <param name="cbkSuccess">Cbk success.</param>
	/// <param name="cbkFailed">Cbk failed.</param>
	private IEnumerator GetMessages( string sTgtURL, Action<string> cbkSuccess=null, Action cbkFailed=null ) {

		// WWWを利用してリクエストを送る
		WWW www = new WWW(sTgtURL);
		
		// WWWレスポンス待ち
		yield return StartCoroutine( ResponceCheckForTimeOutWWW( www, 5.0f));
		
		if(www.error != null){
			//レスポンスエラーの場合
			Debug.LogError(www.error);
			if(null!=cbkFailed){
				cbkFailed();
			}
		}else
		if(www.isDone){
			// リクエスト成功の場合
			Debug.Log( string.Format("Success:{0}",www.text));
			if(null!=cbkSuccess){
				cbkSuccess( www.text);
			}
		}
	}
	/// <summary>
	/// Responces the check for time out WWW.
	/// </summary>
	/// <returns>The check for time out WWW.</returns>
	/// <param name="www">Www.</param>
	/// <param name="timeout">Timeout.</param>
	private IEnumerator ResponceCheckForTimeOutWWW(WWW www, float timeout) {
		float requestTime = Time.time;
		
		while(!www.isDone){
			if(Time.time - requestTime < timeout){
				yield return null;
			}else{
				Debug.LogWarning("TimeOut"); //タイムアウト
				break;
			}
		}
		yield return null;
	}


	/// <summary>
	/// Sets the json from www.
	/// </summary>
	private void SetJsonFromWww(){

		// APIが設置してあるURLパス
		string	sTgtURL	= "http://localhost/mazetime/mazetime/setmazetime";
//		string	sTgtURL	= "http://127.0.0.1/messageboardsapi/MessageBoards/setMessage";

//		string name		= "123";
//		string message	= "abc";
		string Id		= InputName.text;
		string Time	= InputMessage.text;

		// Wwwを利用して json データ取得をリクエストする
		StartCoroutine(SetMessage( sTgtURL, Id, Time, CallbackApiSuccess, CallbackWwwFailed));

	}
	/// <summary>
	/// Sets the message.
	/// </summary>
	/// <returns>The message.</returns>
	/// <param name="urlTarget">URL target.</param>
	/// <param name="name">Name.</param>
	/// <param name="message">Message.</param>
	/// <param name="cbkSuccess">Cbk success.</param>
	/// <param name="cbkFailed">Cbk failed.</param>
	private IEnumerator SetMessage( string urlTarget, string name, string message, Action<string> cbkSuccess=null, Action cbkFailed=null ) {

		WWWForm form = new WWWForm();
		form.AddField("name",		name);
		form.AddField("message",	message);

/*		using(UnityWebRequest ww2 = UnityWebRequest.Post(urlTarget, form)) {
			yield return ww2.Send();

			if (ww2.isNetworkError) {
				Debug.Log(ww2.error);
				if(null!=cbkFailed){
					cbkFailed();
				}
			} else {
				Debug.Log("Form upload complete!");
				if(null!=cbkSuccess){
					cbkSuccess( "-");
				}
			}
		}
*/

		// WWWを利用してリクエストを送る
		WWW www = new WWW( urlTarget, form );
//		WWW www = new WWW( urlTarget);

		// WWWレスポンス待ち
		yield return StartCoroutine( ResponceCheckForTimeOutWWW( www, 5.0f));
		
		if(www.error != null){
			//レスポンスエラーの場合
			Debug.LogError(www.error);
			if(null!=cbkFailed){
				cbkFailed();
			}
		}else
		if(www.isDone){
			// リクエスト成功の場合
			Debug.Log( string.Format("Success:{0}",www.text));
			if(null!=cbkSuccess){
				cbkSuccess( www.text);
			}
		}
/**/
	}




}
