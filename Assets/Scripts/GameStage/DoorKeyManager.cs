using UnityEngine;

public class DoorKeyManager : MonoBehaviour {

    public PlayerManager m_PlayerManager;

    /// <summary>
    /// アイテムを手に入れるとオブジェクト削除
    /// </summary>
    // Update is called once per frame
    void Update () {
        if (m_PlayerManager.m_HasDoorKey == true)
        {
            Destroy(this.gameObject);
        }
    }
}
