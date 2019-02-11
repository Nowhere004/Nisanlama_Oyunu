using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EnemyMermi : MonoBehaviour {

    public float speed;
    private Vector2 moveBullet;
    private Enemy enemy;
    private Oyuncu player;
    public GameObject enemyBulletEffect;
    public GameObject playerBullet;
    public GameObject playerHitSound;
    public float randomBool;




    private void Start()
    {

        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Oyuncu>();
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), enemy.GetComponent<CircleCollider2D>(), true);
         randomBool = Random.Range(0, 5);

    }
    private void Update()
    {
        if (SceneManager.GetActiveScene().name=="2")
        {
            speed = 25;
        }

        if (randomBool == 1)
            BulletLeft();
        else if (randomBool == 2)
            BulletRight();
        else if (randomBool == 3)
            BulletUp();
        else if (randomBool == 4)
            BulletDown();
        else
            transform.position = Vector2.zero;

    }

    public void BulletRight()
    {       
        moveBullet = new Vector2(transform.position.x+20,transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, moveBullet, speed * Time.deltaTime);
    }
    public void BulletLeft()
    {
        
        moveBullet = new Vector2(transform.position.x-20, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, moveBullet, speed * Time.deltaTime);
    }
    public void BulletUp()
    {

        moveBullet = new Vector2(transform.position.x, transform.position.y+20);
        transform.position = Vector2.MoveTowards(transform.position, moveBullet, speed * Time.deltaTime);
    }
    public void BulletDown()
    {

        moveBullet = new Vector2(transform.position.x, transform.position.y - 20);
        transform.position = Vector2.MoveTowards(transform.position, moveBullet, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.health -= 1;            
            GameObject effect = Instantiate(enemyBulletEffect, transform.position, Quaternion.identity);
            GameObject sEffect = Instantiate(playerHitSound,transform.position,Quaternion.identity);
            Destroy(gameObject);
           Destroy(effect,0.5f);
           Destroy(sEffect, 0.5f);
        }
        if (other.CompareTag("Enviroment"))
        {
          GameObject effect = Instantiate(enemyBulletEffect, transform.position, Quaternion.identity);            
            Destroy(gameObject);
            Destroy(effect, 0.5f);
        }
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            GameObject effect = Instantiate(enemyBulletEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            GameObject effect2 = Instantiate(playerBullet, transform.position, Quaternion.identity);
            Destroy(effect2, 0.5f);
        }
    }
}
