using UnityEngine;

public class ButtonHole : MonoBehaviour
{
    private GameObject player;
    public string itemName = "Button1"; 
    public float minDistance = 100f;

    public Item buttonToSpawn;

	void Start()
	{
    	player = GameObject.FindGameObjectWithTag("Player");
	}

    void OnMouseDown()
    {
        Inventory inventory = player.GetComponent<Inventory>();
        inventory.CheckInventory();
        if (inventory.HasItem(itemName))
        {
            buttonToSpawn.SpawnButtonInElevator(transform.position);
            Debug.Log("placed");
        }
    }
}
