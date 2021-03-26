using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //壁上げスイッチ接触判定
    public bool m_OnUpperSwitch;
    //パズル壁接触判定
    public bool m_IsAnswer;
    //ゴール到達判定
    public bool m_OnMagicCircle;
    //BoxKey1所持判定
    public bool m_HasBoxKey1;
    //BoxKey2所持判定
    public bool m_HasBoxKey2;
    //DoorKey所持判定
    public bool m_HasDoorKey;

    // Use this for initialization
    void Start()
    {
        m_OnUpperSwitch = false;
        m_IsAnswer = false;
        m_OnMagicCircle = false;
        m_HasBoxKey1 = false;
        m_HasBoxKey2 = false;
        m_HasDoorKey = false;

    }

}

