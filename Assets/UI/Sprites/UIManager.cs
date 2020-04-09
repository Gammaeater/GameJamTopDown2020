using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{


    [SerializeField]
    [Header("UI")]
    public float _health;
    public float _health_Max;
    public TextMeshProUGUI timeText;



    [SerializeField] public Slider healthBar;
    static UIManager current;
    
    private float time;


    
    void Awake()
    {

        if (current != null && current != this)
        {

            Destroy(gameObject);
            return;
        }


        current = this;
    
    }

    
    void Update()
    {
       

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            _health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().GetHealth();
        }

        


        healthBar.value = _health;
    }

    public static void UpdateTimeUI(float time)
    {
        
        if (current == null)
        {
            return;
        }

        
        int minutes = (int)(time / 60);
        float seconds = time % 60f;

       
        current.timeText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }




}
