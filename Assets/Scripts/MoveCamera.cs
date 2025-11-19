using UnityEngine;
using UnityEngine.SceneManagement;

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

	void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
}
