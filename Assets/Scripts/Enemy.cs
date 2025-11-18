using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	public enum EnemyState {Idle, Follow};
	public EnemyState currentState = EnemyState.Idle;

    private GameObject player;    
	private Rigidbody rb;
	private Animator anim;
	private string sceneName;   

	public float rotationSpeed = 1f;
    public float speed = 0.5f;       
    public float stoppingDistance = 1.5f;

	public Vector3 scene3SpawnPoint = new Vector3(-12f, 0f, -16f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animator>();
		player = GameObject.FindGameObjectWithTag("Player");
		sceneName = SceneManager.GetActiveScene().name;

    	if (sceneName == "Scene3")
    	{
        	transform.position = scene3SpawnPoint;
            SetState(EnemyState.Idle);
    	}
    }
    
	private void FixedUpdate()
    {
		if (player == null) return;

        if (currentState == EnemyState.Follow)
        {
            FollowPlayer();
        }
        else
        {
            LookAtPlayer(); 
        }
    }
    
	void LookAtPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0;
        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }

	void FollowPlayer()
	{
		LookAtPlayer();
        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0; 

        float distance = direction.magnitude;

        if (distance > stoppingDistance)
        {
			Vector3 move = direction.normalized * speed * Time.fixedDeltaTime;
			rb.MovePosition(rb.position + move);
        }
	}

	public void SetState(EnemyState newState)
    {
        currentState = newState;
		
		if (anim != null)
		{
			anim.SetBool("IsWalking", newState == EnemyState.Follow);
		}

		switch (sceneName)
		{
            case "Scene1":
                if (newState == EnemyState.Follow)
                {
                    gameObject.SetActive(false);
                }
                break;

            case "Scene2":
				AudioManager.Instance.Play("Lights Flickering");
				if (newState == EnemyState.Follow)
                {
                    AudioManager.Instance.Play("First Chase");
					AudioManager.Instance.Play("Enemy Footsteps");
                }
                break;

            case "Scene3":
				AudioManager.Instance.Play("Lights Flickering");
                if (newState == EnemyState.Follow)
                {
                    transform.position = scene3SpawnPoint;
					speed = 7f;
                    gameObject.SetActive(true);
					AudioManager.Instance.Play("Final Chase");
                }
                break;
		}
    }

}
