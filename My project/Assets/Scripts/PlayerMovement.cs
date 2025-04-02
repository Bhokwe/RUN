using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //public float playerSpeed = 5;
    //public float horizontalSpeed = 4;
    //public float leftLimit = -3;
    //public float rightLimit = 3;
    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    public float horizontalMultiplier = 2;

    public bool alive = true;

    private void FixedUpdate()
    {
        if (!alive) return;
        Vector3 forwardMove = transform.forward *speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right*horizontalInput*speed * Time.fixedDeltaTime*horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);
        
    }


    private void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");
        ////player speed relative to the game world
        //transform.Translate(Vector3.forward * Time.deltaTime * playerSpeed, Space.World);

        ////Binds movement
        //if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        //{
        //    if (this.gameObject.transform.position.x > leftLimit)
        //    {
        //        transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
        //    }

        //}
        //if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        //{
        //    if (this.gameObject.transform.position.x < rightLimit)
        //    {
        //        transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
        //    }

        //}
        if (transform.position.y < -5)
        {
            Die();

        }
        if (transform.position.y > 5)
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
}
