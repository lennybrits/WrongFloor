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


    // Update is called once per frame
    void Update()
    {

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
		Debug.Log("door open sound");
    }
}
