using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    [SerializeField] public static GameManager current;

    [SerializeField] float TimeToWin;
    [SerializeField] float totalGameTime;
    [SerializeField] bool isGameOver;
    [SerializeField] public GameObject player;





    
    void Awake()
    {
        MakeSingleton();

        // FindPlayerRefference();

    }

    private void FindPlayerRefference()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        HealthSystem health = player.GetComponent<HealthSystem>();
    }


    // Update is called once per frame
    void Update()
    {

        if (isGameOver)
        {
            return;
        }
        totalGameTime = Time.timeSinceLevelLoad;

        UIManager.UpdateTimeUI(time: totalGameTime);




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
        //SceneManager.LoadScene("DeadScene");

        if (current == null)
        {
            return;
        }
        current.isGameOver = true;







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

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        current.totalGameTime -= totalGameTime;
        //  UIManager.UpdateTimeUI(current.totalGameTime);
        ;


    }



    private void MakeSingleton()
    {
        if (current != null && current != this)
        {
            Destroy(gameObject);
            return;
        }
        current = this;


        DontDestroyOnLoad(gameObject);
    }


   


}

