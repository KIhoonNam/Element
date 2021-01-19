using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    public Image Hp;
    Character Pl;

    // Start is called before the first frame update
    void Start()
    {
        Pl = FindObjectOfType<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      Image GetHp()
    {
        return Hp;
    }

    public  void FillAmount(float hp,float Maxhp)
    {
        GetHp().fillAmount = hp / Maxhp;
    }
}
