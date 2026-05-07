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
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }

    public void Pause()
    {
        _isPaused = true;

        GetComponent<FirstPersonController>().enabled = false;
        GetComponent<InteractionScript>().enabled = false;

        Time.timeScale = 0f;
    }

    public void Unpause()
    {

        _isPaused = false;
        Time.timeScale = 1f;

        GetComponent<FirstPersonController>().enabled = true;
        GetComponent<InteractionScript>().enabled = true;
    }
}
