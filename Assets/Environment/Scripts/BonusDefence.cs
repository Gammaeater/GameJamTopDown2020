using UnityEngine;

public class BonusDefence : MonoBehaviour
{
    private HealthSystem healthSystem;
    public float _health;


    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            _health = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().GetHealth();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D _other)
    {

        if (_other.gameObject.tag == "Player")
        {

            GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>().Heal(100f);

        }
    }


}
