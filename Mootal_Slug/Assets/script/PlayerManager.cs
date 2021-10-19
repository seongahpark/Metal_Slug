using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public static int life=2;

    float speed = 3;
    float jumpForce = 500f;
    float checkRadius = 0.35f; //���� �˻� ����

    bool isTouchRight; //������ ���� �����ߴ���
    bool isTouchLeft; // ���� ���� �����ߴ���
    bool bosscheck;   //���� ������ ���� ����
    bool ishittable;  
    
   


    public GameObject Stand; // ���ִ� ����
    public GameObject Player_Down; //���λ��� 
    public GameObject CM_camar;
    public GameObject bossborder;
    public GameObject Player_Die;

    public LayerMask islayer;

    public Transform raypos;
    

    public static int jumpCount = 0;

    public bool PDown = false; //�Ʒ� ����Ű ���Ǵ��� 
    public static bool isGround = false; //�ٴڿ� ��Ҵ���
    public static bool rayisGround ;
    

    private Rigidbody2D rb;
    

    
    private void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        
    }
    

    void Start()
    {
        
        ishittable = false;
        Player_Down.SetActive(false);
        Player_Die.SetActive(false);
    }

    
    void Update()
    {
        rayisGround = Physics2D.OverlapCircle(raypos.position, checkRadius, islayer);
        

        playermove();
        playerjump();
        playerdown();
        //playerhit();
        bossrespawn();
    }
    private void playermove()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;

       

        Vector3 curpos = transform.position;
        Vector3 nextpos = new Vector3(h, 0, 0) * speed * Time.deltaTime;
        if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
           
            

        }
        if (h > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
           



        }

        transform.position = curpos + nextpos;
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            playerLeg.anim.SetInteger("Input", (int)h);
            DownPlayer.anim.SetInteger("Input", (int)h);
        }
    }

    void playerjump()
    {
        if (isGround == false)
            return;
        if (Input.GetKeyDown(KeyCode.LeftAlt) && jumpCount == 0&&PDown==false&&isGround==true&&rayisGround==true)
        {
            
                jumpCount++;

                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(0, jumpForce));

                playerLeg.anim.SetInteger("jumpcount", jumpCount);
                playerbody.anim.SetInteger("jumpcount", jumpCount);
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt) && jumpCount == 0 && PDown == true && isGround == true && rayisGround == true)
        {
            //���λ��¿��� ����
            Player_Down.SetActive(false);
            Stand.SetActive(true);
            jumpCount++;

            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));

            playerLeg.anim.SetInteger("jumpcount", jumpCount);
            playerbody.anim.SetInteger("jumpcount", jumpCount);

        }
    }
    
    void playerdown() 
    {
        
            if (Input.GetKey(KeyCode.DownArrow))
            {
                PDown = true;

                if (jumpCount == 0&&isGround==true&&rayisGround==true) //���Ͻ�
                {
                
                Stand.SetActive(false);
                Player_Down.SetActive(true);
                
                }
                else   //������ �Ʒ���
                {
                playerLeg.anim.SetInteger("jumpcount", jumpCount);
                playerbody.anim.SetBool("Down", PDown);
                }

            }
        
        
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                PDown = false;
            Stand.SetActive(true);
            Player_Down.SetActive(false);
            playerbody.anim.SetBool("Down", PDown);
        }
    }
    void bossrespawn()
    {
        if (bosscheck == true)
        {
            CM_camar.SetActive(false);
            bossborder.SetActive(true);

        }
    }
    void playerhit()
    {
        if (ishittable == true)
        {
            ishittable = false;
            life--;
            Stand.SetActive(false);
            Player_Down.SetActive(false);
            Player_Die.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        
            if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("aaa");
            jumpCount = 0;
            isGround = true;
            playerLeg.anim.SetInteger("jumpcount", jumpCount);
            playerbody.anim.SetInteger("jumpcount", jumpCount);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bossborder")
        {
           
            bosscheck = true;
        }
        if (collision.gameObject.tag == "border")
        {
            Debug.Log("ccc");
            switch (collision.gameObject.name)
            {
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;

            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Ground")
        {
            Debug.Log("bbb");
            isGround = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "border")
        {
            switch (collision.gameObject.name)
            {
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;

            }
        }
    }

}
