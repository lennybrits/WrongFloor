using UnityEngine;

public class MoveCamera : MonoBehaviour
{
	private Transform player;
    public Vector3 cameraOffset = new Vector3(0, 2.5f, 0f); // height & distance

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
            Debug.LogError("No player found with tag 'Player'!");
    }

    void LateUpdate()
    {
        if (player != null)
            transform.position = player.position + cameraOffset;
    }
}
