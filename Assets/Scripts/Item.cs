using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
	private GameObject player;
    public string itemName = "Button1"; 
	public float minDistance = 100f;
	public Elevator elevator;

	public Animator elevatorFlashAnim;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
    private void OnMouseDown()
    {
	    Transform playerDistance = player.transform;
		Inventory inventory = player.GetComponent<Inventory>();
		float distance = Vector3.Distance(playerDistance.position, transform.position);
        if (inventory != null && distance <= minDistance )
        {
           	inventory.AddItem("Button1");
			Debug.Log("button added");
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
		Debug.Log("button respawned");

		elevator.CloseDoors();

		gameObject.transform.position = position + new Vector3(0.012f, 0f, 0f); 
		gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 90f); 

		if(elevatorFlashAnim != null)
		{
			elevatorFlashAnim.SetTrigger("Flash Transition");
		}

		float flashDuration = 3f;
		StartCoroutine(LoadNextSceneAfterDelay(flashDuration));

	}

    private System.Collections.IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
