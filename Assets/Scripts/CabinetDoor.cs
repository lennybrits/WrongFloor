using UnityEngine;

public class CabinetDoor : MonoBehaviour
{
    [SerializeField] private Cabinet parentScript;
    void OnMouseDown()
    {
        parentScript.OnMouseDown();
    }
}
