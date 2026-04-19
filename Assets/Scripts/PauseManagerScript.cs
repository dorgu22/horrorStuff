using UnityEngine;

public class PauseManagerScript : MonoBehaviour
{
    private bool _isPaused = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
        {
            if (!_isPaused)
            {
                GetComponent<FirstPersonController>().enabled = false;
                GetComponent<InteractionScript>().enabled = false;

                Pause();
            }
            else
            {
                GetComponent<FirstPersonController>().enabled = true;
                GetComponent<InteractionScript>().enabled = true;

                Unpause();
            }
        }
    }

    public void Pause()
    {
        _isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game is paused");
    }

    public void Unpause()
    {
        _isPaused = false;
        Time.timeScale = 1f;
        Debug.Log("Game is unpaused");
    }
}
