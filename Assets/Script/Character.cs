using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

 public struct Element
{

    public string ElePower;
    public bool EleStay;
    public string EleName;
    public int EleIndex;
    public bool EleCheck;
    public string EleCombi;
    public List<string> EleState;
    public float EleTimer;
    public string EleEffect;


}

public class Character : MonoBehaviour
{
    public Element Ele;

    [SerializeField]
    GameObject SkillPool;
    Transform Tr;
    Rigidbody Rg;
    CharacterController CC;
    Animator Ani;
    CastingBar cast;
    GameObject Indicator;
    Canvas Cn;
    SoundScript sound;

    static public event EleGroup EleImage;
    static public event Clear ClearSet;

    float playerHp = 150;
    float maxSpeed = 5;
    float Slowly = 1;
    float Timer;
    float Shield = 0;
    float move;
    Vector3 StartPoint;
    Vector3 targetPos;
    bool TimerOn;
    bool LightningStun;
    bool Casting = false;
    bool PuaseCheck = false;
    bool playerdeath = false;
    int FireStack;
    string AttackClass = null;





    private void Awake()
    {
        Cn = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        Cn.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        Ele.EleEffect = null;
        Ele.EleIndex = 0;
        Ele.EleCheck = false;
        Ele.EleState = new List<string>();
        FireStack = 0;
        Rg = GetComponent<Rigidbody>();
        Tr = GetComponent<Transform>();
        CC = GetComponent<CharacterController>();
        Ani = GetComponent<Animator>();
        cast = GetComponent<CastingBar>();
        sound = GetComponent<SoundScript>();
        Indicator = Tr.GetChild(2).gameObject;
        StartPoint = Tr.position;




    }
    
    void Update()
    {


        if (!playerdeath)
        {
            if (!LightningStun && !PuaseCheck  )
            {
                // CC.Move(Vector3.Lerp(Tr.position,StartPoint,0));
                Element();
                Move();
                ElementTime();
                Attack();

            }
            Puase();
            ElementEffect();
            RaycastHit Hit;
        }
        //Debug.DrawRay(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z),((transform.forward * 10) ), Color.red, 0.01f);
        //if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), transform.forward * 10, out Hit, 10))
        //{
          
        //}
    }
    public void SetPoint()
    {
        CC.enabled = false;
        Tr.position = StartPoint;
        Clear();
        CC.enabled = true;
    }
    public void SetSpeed(float speed)
    {
        maxSpeed = speed;
    }
     void Puase()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!Cn.enabled)
            {
                Cn.enabled = true;
                Time.timeScale = 0f;
                PuaseCheck = true;
            }
            else if (Cn.enabled)
            {
                Cn.enabled = false;
                Time.timeScale = 1f;
                
            }
        }
        if (!Cn.enabled)
            PuaseCheck = false;
    }
    void Element() //원소 추출
    {
        if (Ele.EleStay)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (Ele.EleState.Count < 5)
                {
                    sound.ChangeAudio("Element");
                    EleImage(Ele.EleName,Ele.EleState.Count);
                    Ele.EleState.Add(Ele.EleName);
                }
                Debug.Log(Ele.EleState.Count);
                Debug.Log(Ele.EleName);
                Ele.EleStay = false;
                //Ele.EleStay = false;
                //Timer = .0f;
                //Rg.transform.Translate(Vector3.forward * 20);
                //Rg.transform.position += transform.forward * 20;
                //CC.Move(transform.forward * 20);
            }
        }
    }
    
    public float GetHp()
    {
        return playerHp;
    }
    void Attack()// 공격
    {
        if (Input.GetMouseButtonDown(0))
        {
            EleCombo();
            //StartCoroutine(Fire());
            if(AttackClass != null) 
            Test();
            Debug.Log(Ele.EleState.Count);
        }

    }
    void SetIndicator(float value)
    {
        Indicator.SetActive(true);
        Indicator.transform.localScale = new Vector3(1,1,value);
    }
    void Test()
    {
        if (cast.GetTime() == 0)
        {
            var SkillShoot = SkillPool.transform.Find(AttackClass + "(Clone)");
            if (SkillShoot.name == "Fire(Clone)")
                StartCoroutine(Fire("Fire", 0.5f, 1f, 2));
            else if (SkillShoot.name == "Rock(Clone)")
                StartCoroutine(Fire("Rock", 0.5f, 1f, 2));
            else if (SkillShoot.name == "Water(Clone)")
                StartCoroutine(Fire("Water", 0f, 0.1f, 9));
            else if (SkillShoot.name == "Lightning(Clone)")
                StartCoroutine(Fire("Lightning", 1f, 0.1f, 9));
            else if (SkillShoot.name == "Tree(Clone)")
                StartCoroutine(Fire("Tree", 0f, 0.1f, 9));
            else if (SkillShoot.name == "FireRock(Clone)")
                StartCoroutine(Fire("FireRock", 0f, 0.2f, 9));
            else
            if (!SkillShoot.gameObject.activeSelf)
            {
                StartCoroutine(SkillCast(SkillShoot));
            }
        }
    }

    IEnumerator SkillCast(Transform skill)
    {
        if (skill.name == "UpRock(Clone)" || skill.name == "FullRock(Clone)")
        {
            cast.SetTime(1f);
            yield return new WaitForSeconds(1f);
        }
        else if (skill.name == "FullTree(Clone)")
        {
            cast.SetTime(3f);
            Casting = true;
           
            yield return new WaitForSeconds(3f);
            playerHp += 50;
            if (playerHp > 150)
            {
                playerHp = 150;
                
            }
            var HpCheck = GetComponent<PlayerHp>();
            HpCheck.FillAmount(GetHp(), 150);

        }
        else if (skill.name == "FullWater(Clone)" || skill.name == "FullLightning(Clone)" || skill.name == "Element")
        {
            cast.SetTime(3f);

            //if(skill.name == "FullLightning(Clone)")
            //    SetIndicator(1);
            yield return new WaitForSeconds(3f);

        }
        else if (skill.name == "TreeFire(Clone)")
        {
            cast.SetTime(5f);
            yield return new WaitForSeconds(5f);

        }
        else if (skill.name == "WaterLightning(Clone)")
        {
            Shield = 60;

        }
        Indicator.SetActive(false);
        Casting = false;
        skill.gameObject.SetActive(true);
        Clear();
    }
    IEnumerator Fire(string n , float first,float time,int index)
    {
        Clear();
        cast.SetTime(first);
        SetIndicator(1);
        yield return new WaitForSeconds(first);
        Indicator.SetActive(false);
        var bullet = ObjectPolling.GetObject(n);
        bullet.transform.position = Tr.GetChild(1).transform.position;
        bullet.transform.rotation = Tr.transform.rotation;
        bullet.Set(bullet, Vector3.forward,n);
        for (int i = 0; i < index; i++)
        {
            yield return new WaitForSeconds(time);
            bullet = ObjectPolling.GetObject(n);
            bullet.transform.position = Tr.GetChild(1).transform.position;
            bullet.transform.rotation = Tr.transform.rotation;
            bullet.Set(bullet, Vector3.forward, n);
        }


    }
 
    void Clear()//원소 초기화
    {
        Ele.EleState.Clear();
        Ele.ElePower = null;
        AttackClass = null;
        Ele.EleIndex = 0;
        Ele.EleCheck = false;
        Ele.EleCombi = null;
        ClearSet();

    }
    void EleCombo()//원소 조합
    {
        if (Ele.EleState.Count > 0)
        {
            Ele.ElePower = AttackClass = Ele.EleState[0];
            bool Check = false;
            string Combo;
            if (Ele.EleState.Count == 5)
            {
                for (int i = 0; i < Ele.EleState.Count; i++)
                {
                    Combo = Ele.EleState[i];
                    for (int j = 0; j < Ele.EleState.Count; j++)
                    {
                        if (j != i)
                            if (Combo == Ele.EleState[j])
                            {
                                Check = true;
                                break;
                            }
                    }
                    if (Check)
                        break;
                }
                if (!Check)
                {
                    AttackClass = "FullPower";
                    goto Combination;
                }
            }
            for (int i = 0; i < Ele.EleState.Count; i++)
            {
                if (Ele.ElePower == Ele.EleState[i])
                    Ele.EleIndex++;
                else if (Ele.ElePower == "Fire" && Ele.EleState[i] == "Rock" && Ele.EleIndex > 2)
                {
                    AttackClass = "FireRock";
                    goto Combination;
                }
                else if (Ele.ElePower == "Water" && Ele.EleState[i] == "Lightning" && Ele.EleIndex > 2)
                {
                    AttackClass = "WaterLightning";
                    goto Combination;
                }
                else if (Ele.ElePower == "Tree" && Ele.EleState[i] == "Fire" && Ele.EleIndex > 2)
                {
                    AttackClass = "TreeFire";
                    goto Combination;
                }
                else if (Ele.ElePower == "Rock" && Ele.EleState[i] == "Fire" && Ele.EleIndex < 3)
                {
                    Ele.EleCheck = true;
                    Ele.EleCombi = Ele.EleState[i];
                    goto CombiCheck;
                }
                else if (Ele.ElePower == "Lightning" && Ele.EleState[i] == "Water" && Ele.EleIndex < 3)
                {
                    Ele.EleCheck = true;
                    Ele.EleCombi = Ele.EleState[i];
                    goto CombiCheck;
                }
                else if (Ele.ElePower == "Fire" && Ele.EleState[i] == "Tree" && Ele.EleIndex < 3)
                {
                    Ele.EleCheck = true;
                    Ele.EleCombi = Ele.EleState[i];
                    goto CombiCheck;
                }
                else
                    break;
            }
            if (Ele.EleIndex > 4)
                AttackClass = "Full" + Ele.ElePower;
            else if (Ele.EleIndex > 2)
                AttackClass = "Up" + Ele.ElePower;
            CombiCheck:;
            if (Ele.EleCheck)
            {
                int j = Ele.EleIndex;
                Ele.EleIndex = 0;
                for (int i = j; i < Ele.EleState.Count; i++)
                {
                    if (Ele.EleCombi == Ele.EleState[i])
                        Ele.EleIndex++;
                    else
                        break;
                }
                if (Ele.EleIndex > 2)
                    AttackClass = Ele.EleCombi + Ele.ElePower;
            }
        }
    Combination:;
        Ele.EleIndex = 0;
        Debug.Log(AttackClass);
    }
    void Move()//캐릭터 이동
    {
       
        float movex = 0f;
        float movez = 0f;
        float mouse_X = Input.GetAxisRaw("Mouse X");

        Vector3 Cam = Camera.main.transform.position;
        Ray dir = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(dir, out hit, 10000f,LayerMask.GetMask("Ground")))
        {
            targetPos = hit.point;
        }
        Vector3 Dir = targetPos - Tr.position;
        Vector3 DirXz = new Vector3(Dir.x, 0f, Dir.z);
        Quaternion Rot = Quaternion.LookRotation(DirXz);
        Tr.rotation = Rot;

        //// Tr.rotation = Quaternion.RotateTowards(transform.rotation, Rot, 100f);
        // Rg.rotation = Quaternion.RotateTowards(transform.rotation, Rot, 100f);
        if (!Casting)
        {
            if (Input.GetKey(KeyCode.W))
            {
                movez = 1f;
                Ani.SetBool("IsWalk", true);

            }
            if (Input.GetKey(KeyCode.S))
            {
                movez = -1f;
                Ani.SetBool("IsWalk", true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                movex = -1f;
                Ani.SetBool("IsWalk", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                movex = 1f;
                Ani.SetBool("IsWalk", true);
            }
        }
        if (movex == 0f && movez == 0f)
        {
            
            Ani.SetBool("IsWalk", false);
        }


        CC.Move(new Vector3(movex * Time.deltaTime * (maxSpeed * Slowly), 0, movez * Time.deltaTime * (maxSpeed * Slowly)));



    }


    void ElementTime()// 원소 머물시 효과
    {
        if(TimerOn)
        {
            //Debug.Log(Timer);
            Timer += Time.deltaTime;
            if (Timer >= 2)
            {
                Timer = 0;
                TimerOn = false;
                if (Ele.EleName == "Fire")
                {
                    Ele.EleEffect = Ele.EleName;
                  
                }
                else if(Ele.EleName == "Lightning")
                {
                    Ele.EleEffect = Ele.EleName;
                    
                    Ele.EleTimer = 3.0f;
                    LightningStun = true;
                    playerHp -= 10;
                    var HpCheck = GetComponent<PlayerHp>();
                    HpCheck.FillAmount(playerHp, 70);
                    Debug.Log("StunOn");
                }
                else if(Ele.EleName == "Tree")
                {
                    playerHp += 10;
                }
            }

        }
    }

    void ElementEffect()
    {
       if(Ele.EleEffect == "Fire")
        {
            Ele.EleTimer += Time.deltaTime;
            if (Ele.EleTimer >= 1)
            {
                Ele.EleTimer = 0;
                playerHp -= 3;
                var HpCheck = GetComponent<PlayerHp>();
                HpCheck.FillAmount(playerHp, 70);
                FireStack++;
                if (FireStack >= 5)
                {
                    FireStack = 0;
                    Ele.EleEffect = null;
                    if (Ele.EleStay)
                        TimerOn = true;
                }
                Debug.Log(playerHp);
            }

        }
       if(Ele.EleEffect == "Lightning")
        {
            Ele.EleTimer -= Time.deltaTime;
            if(Ele.EleTimer <=0)
            {
                if (Ele.EleStay)
                    TimerOn = true;
                Ele.EleEffect = null;
                LightningStun = false;
                Debug.Log("StunOff");

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Element")
        {
            if (Ele.EleName != other.name)
                Timer = 0;
            Ele.EleStay = true;
            Ele.EleName = other.name;

            if (other.name == "Water")
            {
                sound.ChangeAudio("Slow");
                sound.PlayAudio();
                Slowly = 0.8f;
            }
            else if ((other.name == "Fire" || other.name == "Tree" || other.name == "Lightning") && Ele.EleEffect == null)
                TimerOn = true;
           


        }
       
    }


    //private void OnControllerColliderHit(ControllerColliderHit hit)
    //{
    //    if (hit.gameObject.tag == "Element")
    //    {

    //        Ele.EleStay = true;
    //        Ele.EleName = hit.gameObject.name;
    //        Debug.Log(Ele.EleName);


    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Element")
        {

            Ele.EleStay = true;
            Ele.EleName = collision.gameObject.name;
            Debug.Log(Ele.EleName);


        }
    }
    private void OnTriggerExit(Collider other)
    {
       
        if (other.tag == "Element")
        {

            Ele.EleStay = false;
            

            if (other.name == "Water")
                Slowly = 1f;
            else if (other.name == "Fire" || other.name == "Tree" || other.name == "Lightning")
                TimerOn = false;
            
        }
    }
    public void TakeDamage(float damage)
    {
        float check = 0;
        if (!playerdeath)
        {
            if (Shield > 0)
            {
                if (damage > Shield)
                {
                    check = damage - Shield;
                    Shield = 0;
                    playerHp -= check;
                    var HpCheck = GetComponent<PlayerHp>();
                    HpCheck.FillAmount(GetHp(), 150);
                    if (playerHp > 0)
                    {
                        sound.ChangeAudio("Hit");
                        sound.PlayAudio();
                        Ani.SetBool("IsHit", true);
                    }
                    else
                    {
                        Rg.isKinematic = true;
                        sound.ChangeAudio("DEATH_PLAYER");
                        sound.PlayAudio();
                        if (!Ani.GetBool("IsDeath"))
                            Ani.SetBool("IsDeath", true);
                        playerdeath = true;
                       
                    }

                }
                else
                    Shield -= damage;
                if (Shield <= 0)
                {
                    FindObjectOfType<ReinForceShield>().gameObject.SetActive(false);
                }
            }
            else
            {


                playerHp -= damage;
                var HpCheck = GetComponent<PlayerHp>();
                HpCheck.FillAmount(GetHp(), 150);
                if (playerHp > 0)
                {
                    sound.ChangeAudio("Hit");
                    sound.PlayAudio();
                    Ani.SetBool("IsHit", true);
                }
                else
                {
                    sound.ChangeAudio("DEATH_PLAYER");
                    sound.PlayAudio();
                    if (!Ani.GetBool("IsDeath"))
                        Ani.SetBool("IsDeath", true);
                    playerdeath = true;
                    Rg.isKinematic = true;
                 
                }
            }
        }
        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Element")
        {

            Ele.EleStay = false;

           



        }

    }
}



