using UnityEngine;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public Enemy enemy;
    public List<string> inventory = new List<string>();

	public bool HasItem(string itemName)
	{
		return inventory.Contains(itemName);
	}	

    public void AddItem(string itemName)
    {
        inventory.Add(itemName);
        Debug.Log(itemName + " added to inventory!");
        enemy.SetState(Enemy.EnemyState.Follow);
    }

 	public void RemoveItem(string itemName)
    {
        inventory.Remove(itemName);
        Debug.Log(itemName + " removed to inventory!");
    }

	public void CheckInventory()
	{
		foreach (string item in inventory)
		{
			Debug.Log(item); 
		}
		

	}
}
