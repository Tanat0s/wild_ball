using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]private GameObject pauseButton;
    [SerializeField]private GameObject pausePanel;

    UnityEvent pauseEvent = new UnityEvent();

    private void Start()
    {
        pauseEvent.AddListener(OnPause);
    }

    private void OnPause()
    {
        if(pauseButton != null)
            pauseButton.SetActive(false);       
        
        if(pausePanel != null)
            pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if(pausePanel != null && !pausePanel.activeSelf &&  Cursor.lockState == CursorLockMode.None)
            Cursor.lockState =  CursorLockMode.Locked;

        if(pausePanel != null && pausePanel.activeSelf && Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState =  CursorLockMode.None;

        if(Input.GetKeyDown(KeyCode.Escape) && pauseEvent != null)
        {
            pauseEvent.Invoke();
        }
    }

    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);        
    }

    //When in football gate go to the next level
    //TODO Don't forget to check last level
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
