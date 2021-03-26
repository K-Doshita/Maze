using UnityEngine;

public class BoxKey2GuardManager : MonoBehaviour
{
    public PlayerManager m_PlayerManager;

    /// <summary>
    /// BoxKey1を持っていればオブジェクト削除
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (m_PlayerManager.m_HasBoxKey1 == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}