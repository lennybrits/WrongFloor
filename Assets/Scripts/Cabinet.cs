using UnityEngine;

public class Cabinet : MonoBehaviour
{
	private GameObject player;
	private Animator animator;
	public float minimumDistance = 5f;

	void Start()
	{
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

    public void OnMouseDown()
    {
		Transform playerDistance = player.transform;
		bool cabinetDoorsOpen = animator.GetBool("CabinetDoorsOpen");
		float distance = Vector3.Distance(playerDistance.position, transform.position);
		Debug.Log(distance + "," + minimumDistance);
        if (distance <= minimumDistance && cabinetDoorsOpen == false)
        {
            animator.SetBool("CabinetDoorsOpen", true);
			AudioManager.Instance.Play("Cabinet Doors Open");
        }

		else if (distance <= minimumDistance && cabinetDoorsOpen)
		{
			animator.SetBool("CabinetDoorsOpen", false);
			AudioManager.Instance.Play("Cabinet Doors Close");
		}
    }
}
