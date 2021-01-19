using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class StageManager : MonoBehaviour
{
    public static event Clear Over;

    List<GameObject> Portal = new List<GameObject>();
    Character player;
    SoundScript sound;
    Canvas gameover;
    Text Kill;
    Text Wave;
    List<Image> alpha = new List<Image>();
    public StageManager instance;
    int kill;
    int Round = 1;
    int MonsterCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
        for (int i = 0; i < transform.childCount; i++)
        {
            var PortalObject = gameObject.transform.GetChild(i).gameObject;
            Portal.Add(PortalObject);
        }
        player = FindObjectOfType<Character>();
        sound = GetComponent<SoundScript>();
        gameover = GameObject.Find("DeathCanvas").GetComponent<Canvas>();
        Kill = gameover.transform.GetChild(4).GetComponent<Text>();
        Wave = gameover.transform.GetChild(3).GetComponent<Text>();
        for (int i = 0; i < 3; i++)
            alpha.Add(gameover.transform.GetChild(i).GetComponent<Image>());
    }


    private void Start()
    {   
       
        gameover.enabled = false;
    }

    public void GameOver()
    {
        gameover.enabled = true;
        Kill.text = kill + "";
        Wave.text = Round + "";
        Over();
        StartCoroutine(FadeGameOver());
        

    }

    IEnumerator FadeGameOver()
    {
        Color fade = alpha[0].color;
        while(alpha[0].color.a < 1f)
        {
            fade.a += Time.deltaTime;
            Kill.color = fade;
            Wave.color = fade;
            for (int i = 0; i < alpha.Count; i++)
                alpha[i].color = fade;
            yield return new WaitForFixedUpdate();
        }
        
    }

    public void MonsterCn()
    {

        MonsterCount -= 1;
        kill += 1;
        if (MonsterCount < 1)
        {
            sound.ChangeAudio("WAVE_END");
            sound.PlayAudio();
            player.SetPoint();
  
            Invoke("SetStage", 3);
        }
    }
    void SetStage()
    {
        Round++;

        StartCoroutine(Spawn(Round,0));
    }
    public IEnumerator Spawn(int point,float time)
    {
       
        yield return new WaitForSeconds(time);
        sound.ChangeAudio("WAVE_START");
        sound.PlayAudio();
        for (int i = 0; i < point; i++)
        {
            if (i % 5 == 0)
            {
                for (int j = 0; j < 8; j++)
                {
                    var Monster = MonsterPool.GetObject("OrcSoldier");
                    Monster.transform.position = Portal[i % 5].transform.position;
                    Monster.transform.LookAt(player.transform);

                    MonsterCount++;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else if (i % 5 == 1)
            {
                for (int j = 0; j < 8; j++)
                {
                    var Monster = MonsterPool.GetObject("OrcRanger");
                    Monster.transform.position = Portal[i % 5].transform.position;
                    Monster.transform.LookAt(player.transform);

                    MonsterCount++;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else if (i % 5 == 2)
            {
                for (int j = 0; j < 8; j++)
                {
                    var Monster = MonsterPool.GetObject("OrcSoldier");
                    Monster.transform.position = Portal[i % 5].transform.position;
                    Monster.transform.LookAt(player.transform);

                    MonsterCount++;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            else if (i % 5 == 3)
            {
                for (int j = 0; j < 8; j++)
                {
                    var Monster = MonsterPool.GetObject("OrcRanger");
                    Monster.transform.position = Portal[i % 5].transform.position;
                    Monster.transform.LookAt(player.transform);

                    MonsterCount++;
                    yield return new WaitForSeconds(0.1f);
                }
            }
            if (i % 5 == 4)
            {
                for (int j = 0; j < 8; j++)
                {
                    var Monster = MonsterPool.GetObject("OrcTanker");
                    Monster.transform.position = Portal[i % 5].transform.position;
                    Monster.transform.LookAt(player.transform);

                    MonsterCount++;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }


}
