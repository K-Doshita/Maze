using UnityEngine;

public class PuzzleCollisionManager : MonoBehaviour
{

    public PlayerManager m_PlayerManager;
    public GameObject m_PuzzleText;

    // Use this for initialization
    void Start()
    {
        m_PlayerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
    }

    /// <summary>
    /// Puzzleの壁の前Spaceキーが押されるとパズル入力ボタン表示
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        if (m_PlayerManager.m_IsAnswer == true)
        {
            m_PuzzleText.SetActive(true);
        }
    }

}

