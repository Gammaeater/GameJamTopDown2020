using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHeal : MonoBehaviour
{
    private HealthSystem healthSystem;


    // Start is called before the first frame update
    void Start()
    {
        // Update is called once per frame
        healthSystem = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D _other)
    {

        if (_other.gameObject.tag == "Player")
        {
            healthSystem.Heal(500f);
            Debug.Log("HpAdded To Health System");

            Destroy(this);




        }
    }


}
