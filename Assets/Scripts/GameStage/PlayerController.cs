using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public PlayerManager m_PlayerManager;

    public GameObject m_BoxKey2GuardGlass;
    public GameObject m_DoorKeyGuardGlass;


    public void OnTriggerStay(Collider other)
    {
        //Puzzleの壁の前でSpaceキーを押すとパズル入力ボタン表示
        if (other.gameObject.tag == "Puzzle")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_PlayerManager.m_IsAnswer = true;
            }
        }


        //BoxKey1に触れてSpaceキーを押すとBoxKey1を所持したことになる
        if (other.gameObject.tag == "BoxKey1")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_PlayerManager.m_HasBoxKey1 = true;
            }
        }

        //BoxKey1を持っているときBoxKey2GuardGlassに触れてSpaceキーを押すとオブジェクト削除
        if (other.gameObject.tag == "BoxKey2GuardGlass")
        {
            if (m_PlayerManager.m_HasBoxKey1 == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(m_BoxKey2GuardGlass);
                }
            }
        }

        //BoxKey2に触れてSpaceキーを押すとBoxKey2を所持したことになる
        if (other.gameObject.tag == "BoxKey2")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_PlayerManager.m_HasBoxKey2 = true;
            }
        }

        //BoxKey2を持っているときDoorKeyGuardGlassに触れてSpaceキーを押すとオブジェクト削除
        if (other.gameObject.tag == "DoorKeyGuardGlass")
        {
            if (m_PlayerManager.m_HasBoxKey2 == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Destroy(m_DoorKeyGuardGlass);
                }
            }
        }

        //DoorKeyに触れてSpaceキーを押すとDoorKeyを所持したことになる
        if (other.gameObject.tag == "DoorKey")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_PlayerManager.m_HasDoorKey = true;
            }
        }
    }
}