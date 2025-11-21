using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour
{
    private GameObject player;
    public string itemName = "Button1"; 
    public float minDistance = 10f;
    public Elevator elevator;

    public Animator elevatorFlashAnim;
    public CanvasGroup fadeCanvasGroup; 
    public float fadeDuration = 1f;

    [Header("Item Spawn Positions")]
    public Vector3[] spawnPositions; 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        if (SceneManager.GetActiveScene().name == "Scene1" || SceneManager.GetActiveScene().name == "Scene2")
        {
            SpawnAtRandomPosition();
        }
    }

    private void OnMouseDown()
    {
        Transform playerDistance = player.transform;
        Inventory inventory = player.GetComponent<Inventory>();
        float distance = Vector3.Distance(playerDistance.position, transform.position);
        if (inventory != null && distance <= minDistance )
        {
            inventory.AddItem(itemName);
            inventory.CheckInventory();
            gameObject.SetActive(false);
            AudioManager.Instance.Play("Item Pickup");
        }
    }

    public void SpawnButtonInElevator(Vector3 position)
    {
        gameObject.SetActive(true);
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.RemoveItem("Button1");
        AudioManager.Instance.Play("Button Fit");

        elevator.CloseDoors();

        gameObject.transform.position = position + new Vector3(0.012f, 0f, 0f); 
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f); 

        if (elevatorFlashAnim != null)
        {
            elevatorFlashAnim.SetTrigger("Flash Transition");
        }

        StartCoroutine(FadeAndLoadNextScene(1f));
    }

    private IEnumerator FadeAndLoadNextScene(float delayBeforeFade)
    {
        yield return new WaitForSeconds(delayBeforeFade);
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Clamp01(t / fadeDuration);
            yield return null;
        }
        fadeCanvasGroup.alpha = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void SpawnAtRandomPosition()
    {
        if (spawnPositions.Length == 0) return;

        int index = Random.Range(0, spawnPositions.Length);
        transform.position = spawnPositions[index];
        transform.rotation = Quaternion.identity; 
        gameObject.SetActive(true);
    }
}
