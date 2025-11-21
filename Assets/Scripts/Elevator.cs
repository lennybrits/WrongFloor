using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("ToOpen", true);
		AudioManager.Instance.Play("Elevator Doors Close");
    }

    public void CloseDoors()
    {
        animator.SetBool("ToOpen", false);
		AudioManager.Instance.Play("Elevator Doors Close");
		AudioManager.Instance.Play("Elevator Moving");
    }

    public void OpenDoors()
    {
        animator.SetBool("ToOpen", true);
		AudioManager.Instance.Play("ElevatorDoorsOpen");
    }
}
