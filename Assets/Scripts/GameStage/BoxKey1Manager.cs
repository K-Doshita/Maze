using UnityEngine;

public class BoxKey1Manager : MonoBehaviour {

    public PlayerManager m_PlayerManager;

    /// <summary>
    /// アイテムを手に入れるとオブジェクト削除
    /// </summary>
	// Update is called once per frame
	void Update () {
        if (m_PlayerManager.m_HasBoxKey1 == true)
        {
            Destroy(this.gameObject);
        }
    }
}
