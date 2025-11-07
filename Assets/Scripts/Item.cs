using UnityEngine;

public class Item : MonoBehaviour
{
	public GameObject player;
	public Transform playerDistance; 
    public string itemName = "Item"; 
	public float minDistance = 6f;


    private void OnMouseDown()
    {
 		Inventory inventory = player.GetComponent<Inventory>();
		float distance = Vector3.Distance(playerDistance.position, transform.position);
        if (inventory != null && distance <= minDistance )
        {
            inventory.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}
