using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject restartBackground;
    public Button yesRestart;
    public Button noRestart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        restartBackground.SetActive(false);//Panel is disabled

        //yesRestart.onClick.AddListener(RestartGame());
        //noRestart.onClick.AddListener(CancelRestart());
    }

    public void ShowRestartPrompt()
    {
        Time.timeScale = 0f; // Stops game time
        restartBackground.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resumes game time
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Gets and activates panel
    }

    public void CancelRestart()
    {
        Time.timeScale = 1f; // Resumes game time
        restartBackground.SetActive(false);
    }


}
