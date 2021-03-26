using UnityEngine;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

    public Text timeText;
    public int totalMinute = 0;
    public int totalSecond = 0;
    public int allSecond;
    public static string putTime;

    /// <summary>
    /// GameSceneのtotalTimeを(分):(秒)に変換し表示
    /// </summary>
	// Use this for initialization
	void Awake () {
        
        float totalTime = TimeManager.TotalTime();
        if (totalTime >= 60f)
        {
            totalSecond = (int)totalTime % 60;
            allSecond = (int)totalTime - totalSecond;
            totalMinute = allSecond / 60;
        }
        timeText.text = totalMinute.ToString("00") + ":" + ((int)totalTime).ToString("00");
        putTime = timeText.text;
    }
}
