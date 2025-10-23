using UnityEngine;

public class Item : MonoBehaviour
{
	public GameObject player;
    public string itemName = "Item"; 


    private void OnMouseDown()
    {
 		Inventory inventory = player.GetComponent<Inventory>();
        if (inventory != null)
        {
            inventory.AddItem(itemName);
            Destroy(gameObject);
        }
    }
}
