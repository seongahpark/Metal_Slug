using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameManager gm;

    [SerializeField] private Text lifeText;
    [SerializeField] private Text armsText;
    public static int life=3; //플레이어 생명 3으로 고정

    float speed = 3;
    float jumpForce = 300f;
    float checkRadius = 0.35f; //레이 검사 범위

    bool isTouchRight; //오른쪽 끝에 도달했는지
    bool isTouchLeft; // 왼쪽 끝에 도달했는지
    bool bosscheck;   //보스 리스폰 지점 도달
    bool ishittable;  //맞을수있는 상태인지
    bool Diecheck; //죽은 상태인지


    public GameObject Stand; // 서있는 상태
    public GameObject Player_Down; //숙인상태 
    public GameObject CM_camar;
    public GameObject bossborder;
    public GameObject Player_Die;
    public GameObject Player_body;
    public GameObject Player_item_body;
    public GameObject Player_item_Down;

    public LayerMask islayer;

    public Transform raypos;
    

    public int shootCount = 0; //아이템 총알 개수
    public static int jumpCount = 0;
    //public static int Shot_Count; //연사 횟수

    public bool PDown = false; //아랫 방향키 눌렷는지 
    public static bool isGround = false; //바닥에 닿았는지
    public static bool rayisGround;
    public static bool itemcheck = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        life = 3;
        shootCount = 0;
        lifeText.text = "1UP = " + life.ToString(); // 생명 표시
        armsText.text = "<size=27>"+"∞"+"</size>";

        itemcheck = false;
        Player_item_body.SetActive(false);
        Diecheck = false;
        ishittable = true;
        Player_Down.SetActive(false);
        Player_Die.SetActive(false);
        Player_item_Down.SetActive(false);
    }

    
    void Update()
    {
        rayisGround = Physics2D.OverlapCircle(raypos.position, checkRadius, islayer);

        if (Diecheck == false)
        {
            playermove();
            playerjump();
            playerdown();
        }
        Item_Check();
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
            player_item_Down.anim.SetInteger("Input", (int)h);
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
            //숙인상태에서 점프
            Player_Down.SetActive(false);
            Player_item_Down.SetActive(false);
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

            if (jumpCount == 0 && isGround == true && rayisGround == true) //숙일시
            {
                Stand.SetActive(false);
                if (itemcheck == false)
                    Player_Down.SetActive(true);
                else if (itemcheck == true)
                    Player_item_Down.SetActive(true);
            }
            else   //점프중 아래로
            {
                playerLeg.anim.SetInteger("jumpcount", jumpCount);
                playerbody.anim.SetBool("Down", PDown);
                player_item_body.anim.SetBool("Down", PDown);
            }
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            PDown = false;
            Stand.SetActive(true);
            Player_Down.SetActive(false);
            Player_item_Down.SetActive(false);
            playerbody.anim.SetBool("Down", PDown);
            player_item_body.anim.SetBool("Down", PDown);
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
            if(!gm.gameOver) Invoke("Respawnplayer", 2.5f);
            ishittable = false;
            life--;
            lifeText.text = "1UP = " + life.ToString(); // 생명 표시
            itemcheck = false;
            shootCount = 0;
            Stand.SetActive(false);
            Player_Down.SetActive(false);
            Player_Die.SetActive(true);
            Diecheck = true;
            //StartCoroutine("blink");
            if(life  <= 0)
            {
                Diecheck = true;
                gm.gameOver = true;
            }
        }
    }
    void hittabletrue()
    {
        ishittable = true;
    }
    public void Respawnplayer()
    {
        Diecheck = false;
        
        Player_Die.SetActive(false);
        Stand.SetActive(true);
        this.transform.position = this.transform.position + new Vector3(0, 1f, 0);
        playershoot.bombcount = 10;
        Invoke("hittabletrue", 1.5f);
    }
    public void pickup_item()
    {
        shootCount = 1000;
        itemcheck = true;

        //Shot_Count += 150;
        //Player_body.SetActive(false);
        //Player_item_body.SetActive(true);
    }
    void Item_Check()
    {
        if (shootCount <= 0)
            itemcheck = false;

        if (itemcheck == false)
        {

            Player_body.SetActive(true);
            Player_item_body.SetActive(false);
        }
        else if (itemcheck == true)
        {
            Player_body.SetActive(false);
            Player_item_body.SetActive(true);
        }


        //Player_body.SetActive(false);
        //Player_item_body.SetActive(true);
        armsText.text = shootCount.ToString();
    }

    public void pickoff_item()
    {
        armsText.text = "<size=27>" + "∞" + "</size>";
        itemcheck = false;
        Player_item_body.SetActive(false);
        Player_body.SetActive(true);
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
        if (collision.gameObject.tag == "M_Enemy")
        {
            Debug.Log("DDD");
            playerhit();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bossborder")
        {
            bosscheck = true;
            gm.chkBossStage = true; // GM에서 Boss Stage Chk하는 변수 추가
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
        if (collision.gameObject.tag == "item")
        {
            pickup_item();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Bullet")
        {
            Debug.Log("DDD");
            playerhit();
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
