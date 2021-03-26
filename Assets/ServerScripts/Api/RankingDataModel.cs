using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;		// Json

public class RankingDataModel : MonoBehaviour {

    /// <summary>
    /// Desirializes from json.
    /// MessageData型のリストがjsonに入っていると仮定して
    /// </summary>
    /// <returns>The from json.</returns>
    /// <param name="sStrJson">S string json.</param>
    static public List<RankingData> DesirializeFromJson(string sStrJson)
    {
        List<RankingData> ret = new List<RankingData>();
        RankingData tmp = null;

        // JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
        IList jsonList = (IList)Json.Deserialize(sStrJson);

        // リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
        foreach (IDictionary jsonOne in jsonList)
        {

            //新レコード解析開始
            tmp = new RankingData();

            if (jsonOne.Contains("Id"))
            {
                tmp.Id = (int)(long)jsonOne["Id"];
            }
            if (jsonOne.Contains("st5time"))
            {
                tmp.st5time = (string)jsonOne["st5time"];
            }

            //現レコード解析終了
            ret.Add(tmp);
            tmp = null;
        }
        return ret;
    }
}
