using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHelper : MonoBehaviour
{
    [SerializeField] private float timeRemaining = 15f;
    [SerializeField] private bool timerIsRunning = false;

    public AudioClip backgroundMiusic;

    [SerializeField] private HealthSystem _playerHealthSystem;
    // Start is called before the first frame update
    void Start()
    {
        timerIsRunning = true;
        SoundManager2.instance.PlaySoundFX(backgroundMiusic);
    }


    void Update()
    {
        CheckHealth();
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;

            }
            else
            {
                Debug.Log("Time has run out!");
                SceneManager.LoadScene("WonScene");
                timerIsRunning = false;


                timeRemaining = 0;

            }
        }
    }


    public void CheckHealth()
    {
        if (_playerHealthSystem.GetHealth() < 50)
        {

            SceneManager.LoadScene("DeadScene");
        }
    }
}
