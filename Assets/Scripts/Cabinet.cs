using UnityEngine;

public class Cabinet : MonoBehaviour
{
	private GameObject player;
	private Animator animator;
	public float minimumDistance = 100f;

	void Start()
	{
		animator = GetComponent<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
	}

    public void HandleClick()
    {
		Transform playerDistance = player.transform;
		Debug.Log("clicked.");
		bool cabinetDoorsOpen = animator.GetBool("CabinetDoorsOpen");
		Debug.Log(cabinetDoorsOpen);
		float distance = Vector3.Distance(playerDistance.position, transform.position);
		Debug.Log(distance + "," + minimumDistance);
        if (distance <= minimumDistance && cabinetDoorsOpen == false)
        {
            animator.SetBool("CabinetDoorsOpen", true);
			Debug.Log("opened");
			AudioManager.Instance.Play("Cabinet Doors Open");
        }

		else if (distance <= minimumDistance && cabinetDoorsOpen)
		{
			animator.SetBool("CabinetDoorsOpen", false);
			AudioManager.Instance.Play("Cabinet Doors Close");
			Debug.Log("closed");
		}
    }
}
