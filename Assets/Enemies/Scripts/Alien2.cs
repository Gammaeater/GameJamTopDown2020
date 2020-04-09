using UnityEngine;

public class Alien2 : EnemyAI
{
    [SerializeField] private Animator anim;
    [SerializeField] private float TimeBetweenShots;
    [SerializeField] private float timeSinceLastShot;
    [SerializeField] private float baseAttack;
    [SerializeField] private HealthSystem playerHS;
    [SerializeField] private  float _attackRadiusDistanceRange = 30f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        {
            Vector3 direction = player.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle + 90;
            direction.Normalize();
            movment = direction;

        }

    }
    void FixedUpdate()
    {
        moveCharacter(movment);



    }
    public void moveCharacter(Vector2 direction)
    {


        if (Vector2.Distance(player.transform.position, transform.position) > _attackRadiusDistanceRange)
        {
            anim.SetBool("isMoving", true);
            anim.SetBool("Attack", false);
            rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);

            


        }
        else if ((Vector2.Distance(player.transform.position, transform.position) < _attackRadiusDistanceRange))
        {



            anim.SetBool("isMoving", false);
            anim.SetBool("Attack", true);

           



        }


    }

    public void Attack()
    {

        float randomBonusHit = (float)Random.Range(1, 5);
        float batfullAttack = baseAttack + randomBonusHit;



        playerHS.Damage(batfullAttack);







    }

}
