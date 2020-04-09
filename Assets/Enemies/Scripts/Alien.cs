using UnityEngine;

public class Alien : EnemyAI
{
    [SerializeField] private Animator anim;
    [SerializeField] private  float TimeBetweenShots;
    [SerializeField] private float timeSinceLastShot;
    [SerializeField] private float baseAttack;
    [SerializeField] private HealthSystem playerHS;

   
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        


    }
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle + 90;
        direction.Normalize();
        movment = direction;

    }

    void FixedUpdate()
    {
        moveCharacter(movment);



    }

    public void moveCharacter(Vector2 direction)
    {


        if (Vector2.Distance(player.transform.position, transform.position) > _attackRadiusDistance)
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("Attack", false);
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);


        }
        else if ((Vector2.Distance(player.transform.position, transform.position) < _attackRadiusDistance))
        {


            if (Time.time > timeSinceLastShot + TimeBetweenShots)
            {

                //StartCoroutine(DmgSpawn());
                Attack();




                timeSinceLastShot = Time.time;



            }
            anim.SetBool("isMoving", false);
            anim.SetBool("Attack", true);

            Debug.Log("Alien-1 stop Move Character");


        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Vector2 diffrence = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + diffrence.x, transform.position.y + diffrence.y);
        }
    }



    public void Attack()
    {

        float randomBonusHit = (float)Random.Range(1, 5);
       float  batfullAttack = baseAttack + randomBonusHit;



        playerHS.Damage(batfullAttack);







    }

}


