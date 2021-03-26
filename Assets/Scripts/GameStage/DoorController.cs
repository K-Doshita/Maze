using UnityEngine;

public class DoorController : MonoBehaviour {

    private PlayerManager m_PlayerManager;
    private Animation m_DoorAnim;

	// Use this for initialization
	void Start () {
        m_PlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        m_DoorAnim = GetComponent<Animation>();
	}
	
    /// <summary>
    /// DoorKeyを持っていればドアが開く
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(m_PlayerManager.m_HasDoorKey == true)
            {
                m_DoorAnim.Play();
            }
        }
    }
}
