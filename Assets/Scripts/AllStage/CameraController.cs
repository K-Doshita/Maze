using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform player;
    private Vector3 transOffset;

    // Use this for initialization
    void Start()
    {
        transOffset = GetComponent<Transform>().position - player.position;
    }

    /// <summary>
    /// Cameraが一定距離を保ちながらPlayerを追従
    /// </summary>
    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = player.position + transOffset;
    }
}
