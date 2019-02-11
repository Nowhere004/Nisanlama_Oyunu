using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermi : MonoBehaviour {
    public float hiz;
    private Vector2 target;
    private Shake shake;
    public GameObject mermiPatlama;
    private Enemy enemy;
    public GameObject bulletSound;

    private void Awake()
    {
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), GameObject.FindGameObjectWithTag("Player").GetComponent<CircleCollider2D>(), true);
    }

    private void Start()
    {
        GameObject effect = Instantiate(bulletSound,transform.position,Quaternion.identity);
        Destroy(effect,0.5f);
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
     


    }
    private void Update()
    {
        

        transform.position = Vector2.MoveTowards(transform.position,target,hiz*Time.deltaTime);
        if (Vector2.Distance(transform.position,target)<0.1f)
        {
            GameObject patlama = Instantiate(mermiPatlama, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(patlama,0.2f);
            
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
       
        if (other.collider.tag=="Enviroment")
        {
            GameObject patlama = Instantiate(mermiPatlama, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(patlama, 0.2f);
        }
        if (other.collider.tag=="Enemy")
        {
            
            GameObject patlama = Instantiate(mermiPatlama, transform.position, Quaternion.identity);
            shake.CamShake();
            Destroy(gameObject);
            Destroy(patlama, 0.2f);
        }  
    }
}
