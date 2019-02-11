using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silah : MonoBehaviour {
    public float offset;
    public GameObject mermi;
    public Transform salNok;
    
    private float atisZamani;
    public float basAtisZaman;
    GameObject playerBulletEffect;
    private void Start()
    {
        
        atisZamani = basAtisZaman;
    }
    private void Update()
    {
        Vector3 fark = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(fark.y, fark.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ+offset);

        if (atisZamani<=0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                playerBulletEffect= Instantiate(mermi, salNok.position, transform.rotation);
                atisZamani = basAtisZaman;
                
                
            }            
            Destroy(playerBulletEffect, 0.5f);
        }
        else
        {
            atisZamani -= Time.deltaTime;
        }

       
    }

}
