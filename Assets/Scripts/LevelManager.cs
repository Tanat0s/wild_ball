using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField]private GameObject pauseButton;
    [SerializeField]private GameObject pausePanel;

    UnityEvent MyEvent = new UnityEvent();

    private void Start()
    {
        MyEvent.AddListener(OnPause);
    }

    private void OnPause()
    {
        if(pauseButton != null)
            pauseButton.SetActive(false);       
        
        if(pausePanel != null)
            pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        if(pausePanel != null && !pausePanel.activeSelf &&  Cursor.lockState == CursorLockMode.None)
            Cursor.lockState =  CursorLockMode.Locked;
        if(pausePanel != null && pausePanel.activeSelf && Cursor.lockState == CursorLockMode.Locked)
            Cursor.lockState =  CursorLockMode.None;

        if(Input.GetKeyDown(KeyCode.Escape) && MyEvent != null)
        {
            MyEvent.Invoke();
        }
    }
    public void LoadLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);        
    }

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);        
    }
}
