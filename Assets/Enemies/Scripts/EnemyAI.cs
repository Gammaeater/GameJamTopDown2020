using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private static List<EnemyAI> enemyList;







    [SerializeField] public Transform player;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] protected Vector2 movment;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float _attackRadiusDistance;
    [SerializeField] private Vector3 startingPosition;

    private enum State
    {
        normal,
        attack,
        busy,
    }

    private void Start()
    {
      //  rb = GetComponent<Rigidbody2D>();



    }

    void Update()
    {
   
    }
    void FixedUpdate()
    {
        
    }
    //public void DamagedKB(Vector3 attackerPosition)
    //{

    //    Vector3 dirFromAttacker = (transform.position - attackerPosition).normalized;

    //    float KnockbackDistance = 5f;
    //    transform.position += dirFromAttacker * KnockbackDistance;
    //}











}



