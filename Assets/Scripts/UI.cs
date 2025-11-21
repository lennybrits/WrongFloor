
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject instructionsPanel;

	void Start()
	{
		ShowMain();
	}

    public void ShowInstructions()
    {
        mainPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void ShowMain()
    {
        instructionsPanel.SetActive(false);
        mainPanel.SetActive(true);
    }

	public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame()
    {
        Application.Quit();

		#if UNITY_EDITOR
        	UnityEditor.EditorApplication.isPlaying = false;
		#endif
    }

	public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
	
}

