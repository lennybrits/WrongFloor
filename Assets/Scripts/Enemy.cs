using UnityEngine;

public class Enemy : MonoBehaviour
{
	public enum EnemyState {Idle, Follow};
	public EnemyState currentState = EnemyState.Idle;

    public Transform player;       

	public float rotationSpeed = 1f;
    public float speed = 0.5f;       
    public float stoppingDistance = 1.5f;

	private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
    }

}
