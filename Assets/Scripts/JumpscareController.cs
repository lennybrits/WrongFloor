using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class JumpscareController : MonoBehaviour
{
    public GameObject jumpscareCanvas;
    public VideoPlayer videoPlayer;
    private bool isPlaying = false;

    void Start()
    {
        jumpscareCanvas.SetActive(true);
        jumpscareCanvas.GetComponent<CanvasGroup>().alpha = 0;
        videoPlayer.Prepare();
    }

    public void PlayJumpscare()
    {
        if (isPlaying) return;  
        isPlaying = true;
        
        jumpscareCanvas.GetComponent<CanvasGroup>().alpha = 1;
        videoPlayer.Play();
        AudioManager.Instance.Play("Jumpscare");
        StartCoroutine(HideAfterVideo());
    }

    private System.Collections.IEnumerator HideAfterVideo()
    {
        yield return new WaitForSeconds((float)videoPlayer.length);
        PlayerMovement player = FindFirstObjectByType<PlayerMovement>();
        SceneManager.LoadScene("Scene1");
    }
}
