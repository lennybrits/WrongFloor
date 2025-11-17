using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
	public enum EnemyState {Idle, Follow};
	public EnemyState currentState = EnemyState.Idle;

    public Transform player;       

	public float rotationSpeed = 1f;
    public float speed = 0.5f;       
    public float stoppingDistance = 1.5f;

	private Rigidbody rb;
	private Animator anim;
	private string sceneName;

	public Vector3 spawnPoint = new Vector3(21f, 0f, 0f);

    void Start()
    {
        rb = GetComponent<Rigidbody>();
		anim = GetComponentInChildren<Animator>();

		sceneName = SceneManager.GetActiveScene().name;

		switch (sceneName)
        {
            case "Scene1":
                break;

            case "Scene2":
                break;

            case "Scene3":
                gameObject.SetActive(false);
				speed = 5;
                break;
        }
    }

    
	private void FixedUpdate()
    {
		if (player == null) return;

        switch (currentState)
        {
            case EnemyState.Idle:
                LookAtPlayer();
                break;

            case EnemyState.Follow:
                FollowPlayer();
                break;
        }
    }
    
	void LookAtPlayer()
    {
        Vector3 direction = player.position - transform.position;
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
        Vector3 direction = player.position - transform.position;
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
        Debug.Log("Enemy state changed to: " + newState);
		
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
                break;

            case "Scene3":
                if (newState == EnemyState.Follow)
                {
                    if (spawnPoint != null)
                    {
                        transform.position = spawnPoint;
                        gameObject.SetActive(true);
                    }
                }
                break;
		}
    }

}
