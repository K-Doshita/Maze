using UnityEngine;

public class TimeManager : MonoBehaviour {

    [SerializeField]
    private static float totalTime;

    /// <summary>
    /// スタートからクリアまでの時間を計測
    /// </summary>
    // Update is called once per frame
    private void FixedUpdate()
    {
        totalTime += Time.deltaTime;
	}

    /// <summary>
    /// ClearSceneに経過時間を返す
    /// </summary>
    /// <returns></returns>
    public static float TotalTime()
    {
        return totalTime;
    }
}
