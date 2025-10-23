using UnityEngine;
using System.Collections.Generic;
public class Inventory : MonoBehaviour
{
    public Enemy enemy;
    public List<string> inventory = new List<string>();

    public void AddItem(string itemName)
    {
        inventory.Add(itemName);
        Debug.Log(itemName + " added to inventory!");
        enemy.SetState(Enemy.EnemyState.Follow);
    }
}
