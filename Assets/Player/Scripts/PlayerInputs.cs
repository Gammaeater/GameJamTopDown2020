﻿using CodeMonkey;
using CodeMonkey.Utils;
using UnityEngine;
using UnityEngine.UI;


public enum State
{
    normal,
    walk,
    attack,
    interact

}

public class PlayerInputs : MonoBehaviour
{
    [SerializeField]
    [Header("Movment Inputs Player")]
    private Vector2 movment;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private State currentState;
    [SerializeField] private Animator _anim;
    [SerializeField] private State state;
    [SerializeField] private Vector3 moveDir;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private LayerMask dashLayerMask;
    [SerializeField] private HealthSystem _playerHealthSystem;


    [Header("Attack")]
    [SerializeField] private float timeBtwAttack;
    [SerializeField] private float startTimeBtwAttack;
    [SerializeField] private Transform attacPos;
    [SerializeField] private float attacRange;
    [SerializeField] private LayerMask whatISEnemies;
    [SerializeField] private GameObject bloodEffect;
    [Header("Enemy")]
    [SerializeField] private HealthSystem enemyHealthSystem;
    





    [SerializeField]
    [Header("UI")]
    private Slider healthBar;




    void Awake()
    {
        state = State.normal;
    }


    void Update()
    {

        switch (state)
        {
            case State.normal:
                MovmentHandler();
                InteractHandler();
                HandleDash();

                break;
            case State.attack:
                InteractHandler();
                break;




        }
    }




    public void FixedUpdate()
    {

        rb.velocity = moveDir * _moveSpeed;

        _anim.SetFloat("Speed", movment.sqrMagnitude);

        Rotate();



    }


    public void MovmentHandler()
    {
        movment.x = Input.GetAxisRaw("Horizontal");
        movment.y = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(movment.x, movment.y).normalized;

    }
    public void Rotate()
    {


        var addAngle = 270;

        var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + addAngle;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    public void InteractHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {


            _anim.SetTrigger("Interact");
            Attack();
            state = State.attack;
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 attackDir = mousePosition = transform.position.normalized;
            float attackOffset = 10f;
            Vector3 attackPosition = transform.position + attackDir * attackOffset;

        }
        else
        {
            state = State.normal;
            
        }

    }

    private void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _anim.SetTrigger("Dash");
            float dashDistance = 5f;
            Vector3 dasPosition = transform.position + moveDir * dashDistance;

            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDir, dashDistance, dashLayerMask);
            if (raycastHit2D.collider != null)
            {
                dasPosition = raycastHit2D.point;
            }



            rb.MovePosition(transform.position + moveDir * dashDistance);

            //transform.position += lastMoveDir * dashDistance;
        }
    }

    public void Attack()
    {
        // anim.SetTrigger("Interact");
        Collider2D[] enemisToAction = Physics2D.OverlapCircleAll(attacPos.position, attacRange, whatISEnemies);
        foreach (Collider2D enemy in enemisToAction)
        {

            Debug.Log("Attack Method Player");

            float attack = 10f;
            float fullAttack = attack + Random.Range(1, 5);
            Instantiate(bloodEffect, enemy.transform.position, enemy.transform.rotation);
            // enemy.GetComponent<Animator>().SetTrigger("Damaged");
            enemy.GetComponent<HealthSystem>().Damage(fullAttack);


            //enemyHealthSystem.Damage(fullAttack);
            CMDebug.TextPopupMouse(fullAttack.ToString());




        }

        timeBtwAttack = startTimeBtwAttack;
        //enemy.GetComponent<Animator>().ResetTrigger("Damaged");

        // anim.ResetTrigger("Interact");
    }



    void OnTriggerEnter2D(Collider2D col)
    {

        switch (col.name)
        {
            case ("BulletPrefab(Clone)"):
                _playerHealthSystem.Damage(10f);
                Destroy(col.gameObject, 1);
                break;
            case ("BullerPrefab2Laser(Clone)"):
                _playerHealthSystem.Damage(10
                    );

                Destroy(col.gameObject, 1);
                break;
            case ("BullerPrefab3Laser(Clone)"):
                _playerHealthSystem.Damage(40f);

                Destroy(col.gameObject, 1);
                break;
        }



    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attacPos.position, attacRange);

    }
}
