using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{



    [SerializeField] public static GameManager current;

    [SerializeField] public Text healthText;


    [SerializeField] public HealthSystem playerHealthShystem;
    [SerializeField] public GameObject uAreDead;
    [SerializeField] public float dethsequenceDuration = 1.5f;

    [SerializeField] float totalGameTime;
    [SerializeField] bool isGameOver;



    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();



    }


    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            return;
        }
        totalGameTime = Time.timeSinceLevelLoad;

        //UIManager.UpdateTimeUI(time: totalGameTime);
    }

    public static bool IsGameOver()
    {
        if (current == null)
        {
            return false;
        }

        return current.isGameOver;

    }
    public static void PlayerDied()
    {

        if (current == null)
        {
            return;
        }
        //uAreDead.SetActive(true);

  



        current.Invoke("ShowDeadOptions", current.dethsequenceDuration);

    }
    public static void PlayerWon()
    {
        if (current == null)
        {
            return;
        }

        current.isGameOver = true;

    }




    public void RestartScene()
    {
        // toxicBarrels.Clear();
        //uAreDead.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        current.totalGameTime -= totalGameTime;
        //  UIManager.UpdateTimeUI(current.totalGameTime);
        //uAreDead.SetActive(false);


    }



    private void MakeSingleton()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;
        //uAreDead = GameObject.FindWithTag("uareDeadUI");
        //uAreDead.SetActive(false);
        //toxicBarrels = new List<ToxicBarrel>();
        // currentToxicBarrels = new List<ToxicBarrel>();

        DontDestroyOnLoad(gameObject);
    }


    public void UpdateHealth()
    {

        healthText.text = playerHealthShystem.GetHealth().ToString("0");




    }



}

