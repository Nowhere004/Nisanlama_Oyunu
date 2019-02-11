using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Oyuncu : MonoBehaviour {

    private Rigidbody2D rb;
    [SerializeField]
    private float hiz;
    private Vector2 moveVel;
    private Vector2 moveVelDash;
    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;
    public GameObject dashEffect;
    private bool isDashing;
    public int health;
    public GameObject gameOver;
    public Image healthShow;
    public Sprite healhSp;
    public GameObject finishEffect;

    void Start () {
        if (SceneManager.GetActiveScene().name=="4")
        {
            hiz += 10;
        }
        if (SceneManager.GetActiveScene().name == "5")
        {
            hiz += 13;
        }
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
        isDashing = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
        moveVel = hiz * moveInput;
        moveVelDash = dashSpeed * moveInput;
        if (health<=0)
        {
            healthShow.sprite = healhSp;
            Time.timeScale = 0;
            gameOver.SetActive(true);
            Destroy(gameObject);
            
        }


    }
    private void FixedUpdate()
    {
        //Player Move    
          rb.MovePosition(rb.position + moveVel * Time.fixedDeltaTime);             

       
       
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NextLevel"))
        {     
            int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextLevel);
               
        }
        if (other.CompareTag("FinishEffect"))
        {
            GameObject effect = Instantiate(finishEffect, transform.position, Quaternion.identity);           
            Destroy(effect, 0.5f);
        }
    }


    void DashMove()
    {

        if (direction == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyDown(KeyCode.C))
            {
                direction = 1;
           
            }
            else if (Input.GetKey(KeyCode.RightArrow) && Input.GetKeyDown(KeyCode.C))
            {
                direction = 2;
            }
            else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKeyDown(KeyCode.C))
            {
                direction = 3;
            }
            else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKeyDown(KeyCode.C))
            {
                direction = 4;
            }
        }
        else
        {
            if (dashTime <= 0)
            {
                direction = 0;
                dashTime = startDashTime;
                //rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if (direction == 1)
                {
                    GameObject effect = Instantiate(dashEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 0.1f);
                    rb.MovePosition(rb.position/2 + moveVelDash*Time.fixedDeltaTime);
                    
                }
                else if (direction == 2)
                {
                    GameObject effect = Instantiate(dashEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 0.1f);
                    rb.MovePosition(rb.position/2 + moveVelDash * Time.fixedDeltaTime);
                }
                else if (direction == 3)
                {
                    GameObject effect = Instantiate(dashEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 0.1f);
                    rb.MovePosition(rb.position/2 + moveVelDash * Time.fixedDeltaTime);
                }
                else if (direction == 4)
                {
                    GameObject effect = Instantiate(dashEffect, transform.position, Quaternion.identity);
                    Destroy(effect, 0.1f);
                    rb.MovePosition(rb.position/2 + moveVelDash * Time.fixedDeltaTime);
                }

            }
        }
    }
}
