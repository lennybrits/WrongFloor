
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private GameObject player; // Assign your player GameObject in the inspector

    void Start()
    {
        // Freeze player or disable movement at start
        if (player != null)
            player.SetActive(false);
    }

    // Called by button OnClick
    public void OnStartButtonPressed()
    {
        if (player != null)
            player.SetActive(true);

        // Disable the start screen
        gameObject.SetActive(false);
    }
}

