using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class Enemy : MonoBehaviour
{
    //Enemy Stats (this method does not play well with Headers)
    public int curHP, maxHP, scoreToGive;
    public float moveSpeed, attackRange, yPathOffset;
    private float initMoveSpeed, initAttackRange;
    private bool rushOn, gamePaused;

    //coordinates for a path
    private List<Vector3> path;

    //private Weapon weapon;
    public float attackSpeed;
    private float lastHit;

    //target to follow
    private GameObject target;
    private PlayerController player;


    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;

        player = GameObject.Find("Player").GetComponent<PlayerController>();

        InvokeRepeating("UpdatePath", 0.0f, 0.5f);

        curHP = maxHP;
        initMoveSpeed = moveSpeed;
        initAttackRange = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        //Look at the target
        Vector3 dir = (target.transform.position - transform.position).normalized;

        //solve for angle
        float angle = Mathf.Atan2(dir.x,dir.z) * Mathf.Rad2Deg;
        //plug angle into object
        transform.eulerAngles = Vector3.up * angle;

        //calculate distance from the player to this enemy
        float dist = Vector3.Distance(transform.position, target.transform.position);

        if(dist <= attackRange){

            if(Time.time >= lastHit + attackSpeed){
                player.TakeDamage(1);
                lastHit = Time.time;

                /*if(weapon.CanShoot())
                    weapon.Shoot();*/
            }            

        } else { //if too far to attack, then chase
            ChaseTarget();
        }
    }


    //happens naturally
    void UpdatePath(){
        //calculate path to target
        NavMeshPath navMeshPath = new NavMeshPath();

                            //where am I?         my destination?                              give to variable
        NavMesh.CalculatePath(transform.position, target.transform.position, NavMesh.AllAreas, navMeshPath);

        path = navMeshPath.corners.ToList();
    }


    void ChaseTarget(){
        //prevent navigation if no path
        if(path.Count == 0)
            return;

        //move towards closest path
        transform.position = Vector3.MoveTowards(transform.position, path[0] + new Vector3(0,yPathOffset,0), moveSpeed * Time.deltaTime);
        
        //if reaching end, remove old path
        if(transform.position == path [0] + new Vector3(0, yPathOffset, 0))
            path.RemoveAt(0);
    }


    public void SpeedUp(){ //catch the thief!!
        moveSpeed *= 3;
        attackRange = 1f;
        rushOn = true;
    }


    public void Pause(bool paused){
        //prevent moving and attacking while restarting/quitting game
        moveSpeed = paused == true ? 0f : initMoveSpeed;
        attackRange = paused == true? 0f : initAttackRange;

        if(rushOn){
            SpeedUp();
        }
    }


    public void TakeDamage(int damage){
        curHP -= damage;

        if(curHP <= 0){
            Die();
        }
    }


    void Die(){
        //GameManager.instance.AddScore(scoreToGive);
        Destroy(gameObject);
    }
}
