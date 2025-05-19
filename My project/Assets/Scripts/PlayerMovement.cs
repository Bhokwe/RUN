using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float horizontalMultiplier = 2f;
    public float leftLimit = -3f;
    public float rightLimit = 3f;

    public Rigidbody rb;
    private float currentSpeed;
    private float horizontalInput;

    public bool alive = true;

    private void Start()
    {
        currentSpeed = speed;

        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!alive) return;

        Vector3 forwardMove = transform.forward * currentSpeed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * currentSpeed * Time.fixedDeltaTime * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (transform.position.y < -5 || transform.position.y > 5)
        {
            Die();
        }
    }

    public void Die()
    {
        alive = false;
        Invoke("Restart", 2);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }
}
