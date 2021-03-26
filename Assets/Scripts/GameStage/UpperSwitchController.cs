using UnityEngine;

public class UpperSwitchController : MonoBehaviour
{
    [SerializeField] 
    private Animation moveWall;
    private PlayerManager m_PlayerManager;
    private Animation m_UpperAnim;
    private Collider m_UpperColl;


    // Use this for initialization
    void Start()
    {
        m_PlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        m_UpperAnim = GetComponent<Animation>();
        m_UpperColl = GetComponent<Collider>();

        moveWall = moveWall.GetComponent<Animation>();
    }

    /// <summary>
    /// Playerがスイッチに触れるとスイッチが下がり、壁が動いて先に進めるようになる
    /// PlayerManagerにスイッチを押したと知らせる
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            m_UpperAnim.Play();
            m_PlayerManager.m_OnUpperSwitch = true;
            Destroy(m_UpperColl);

            moveWall.Play();
        }
    }
}
