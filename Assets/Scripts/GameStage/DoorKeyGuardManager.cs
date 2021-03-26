using UnityEngine;

public class DoorKeyGuardManager : MonoBehaviour
{
    public PlayerManager m_PlayerManager;

    /// <summary>
    /// BoxKey2を持っていればオブジェクト削除
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (m_PlayerManager.m_HasBoxKey2 == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
