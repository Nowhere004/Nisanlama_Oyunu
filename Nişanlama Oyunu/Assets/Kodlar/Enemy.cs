using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Enemy : MonoBehaviour {

    public float speed;
    public Transform[] movespots;
    private int randomIndex=0;
    private float waitTime;
    public float startWaitTime;
    public int health;
    private Oyuncu player;
    private float waitCol;
    public float startwaitCol;
    public GameObject deathEffect;
    public GameObject hurtEffect;
    public GameObject enemyBullet;  
    public GameObject playerHitSound;
    private float bulletMoveTime;
    public float startBulletMoveTime;
    public bool enMovePositionRight=true;

    private void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(),GameObject.FindGameObjectWithTag("Enemy").GetComponent<CircleCollider2D>(),true);
        
    }
    void Start () {
        if (SceneManager.GetActiveScene().name=="3" )
        {
            speed += 10;
        }
        else if (SceneManager.GetActiveScene().name == "4")
        {
            speed += 13;
        }
        else if (SceneManager.GetActiveScene().name == "5")
        {
            speed += 15;
        }

        bulletMoveTime = Random.Range(2,6);
        waitTime = startWaitTime;
        waitCol = startwaitCol;
        randomIndex = Random.Range(0,movespots.Length);
	}
	
	
	void Update () {
       
        transform.position = Vector2.MoveTowards(transform.position,movespots[randomIndex].position,speed*Time.deltaTime);
        if (Vector2.Distance(transform.position,movespots[randomIndex].position)<0.1f)
        {
            if (waitTime<=0)
            {
                randomIndex = Random.Range(0, movespots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        if (health<=0)
        {
            GameObject effect = Instantiate(deathEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
            Destroy(effect,0.5f);

        }
        if (bulletMoveTime<=0)
        {
           
                GameObject enBullet = Instantiate(enemyBullet, transform.position, Quaternion.identity);
                Destroy(enBullet, 3f);
            if (SceneManager.GetActiveScene().name == "4")
            {
                bulletMoveTime = Random.Range(1, 5);
            }
            else if (SceneManager.GetActiveScene().name == "5")
            {
                bulletMoveTime = Random.Range(0, 4);
            }
            else
            {
                bulletMoveTime = Random.Range(2, 6);
            }
            Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), GameObject.FindGameObjectWithTag("EnemyBullet").GetComponent<CircleCollider2D>(), true);
        }
        else
        {
            
            bulletMoveTime -= Time.deltaTime;
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.collider.tag=="Player")
        {
            GameObject sEffect = Instantiate(playerHitSound, transform.position, Quaternion.identity);
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
            player.health -= 1;
            Destroy(sEffect, 0.5f);

        }
        if (other.collider.tag=="Bullet")
        {
            GameObject effect = Instantiate(hurtEffect,transform.position,Quaternion.identity);
            health -= 1;
            Destroy(effect,0.5f);

        }
    }
}
