using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory : MonoBehaviour
{

    public List<string> inventory = new List<string>();

	public bool HasItem(string itemName)
	{
		return inventory.Contains(itemName);
	}	

    public void AddItem(string itemName)
    {
        inventory.Add(itemName);
        Debug.Log(itemName + " added to inventory!");

		Enemy sceneEnemy = GetEnemyInScene();
    	if (sceneEnemy != null)
    	{
        	sceneEnemy.SetState(Enemy.EnemyState.Follow);
    	}
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

	private Enemy GetEnemyInScene()
	{
		Enemy sceneEnemy = FindFirstObjectByType<Enemy>();
		if (sceneEnemy == null)
        	Debug.LogWarning("No Enemy found in the current scene!");
    	return sceneEnemy;
	}
}
