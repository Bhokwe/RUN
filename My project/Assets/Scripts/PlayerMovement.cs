using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //public float playerSpeed = 5;
    //public float horizontalSpeed = 4;
    public float leftLimit = -3;
    public float rightLimit = 3;
    public float speed = 5;
    public Rigidbody rb;
    private float currentSpeed;


    private void Start()
    {
        currentSpeed = speed;
    }


    float horizontalInput;
    public float horizontalMultiplier = 2;

    public bool alive = true;

    //restart variables
    //public GameObject restartBackground;
    //public Button yesRestart;
    //public Button noRestart;

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

        //yesRestart.onClick.AddListener(RestartGame()); //Trying to integrate onClick and put the panel before the actual restart
        Invoke("Restart", 2);

        //noRestart.onClick.AddListener(CancelRestart()); //trying to invoke no restart onClick
    }
    void Restart() //un-commented to get the game working
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void ShowRestartPrompt() //from UI Manager script
    //{
    //    Time.timeScale = 0f; // Stops game time
    //    restartBackground.SetActive(true);
    //}

    //public void RestartGame()
    //{
    //    Time.timeScale = 1f; // Resumes game time
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Gets and activates panel
    //}

    //public void CancelRestart()
    //{
    //    Time.timeScale = 1f; // Resumes game time
    //    restartBackground.SetActive(false);
    //}

    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void ResetSpeed()
    {
        currentSpeed = speed;
    }
}
