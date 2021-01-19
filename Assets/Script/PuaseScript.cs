using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PuaseScript : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
{
    List<Sprite> Button = new List<Sprite>();
    List<Sprite> HowSprite = new List<Sprite>();
    List<Sprite> EleSprite = new List<Sprite>();
    List<Image> Object = new List<Image>();
    List<Image> HowObject = new List<Image>();
    List<Image> EleObject = new List<Image>();
    Image Parant;
    SoundScript sound;
    int index = 0;
    //Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<SoundScript>();
        Init();
    }

    //Update is called once per frame
    void Update()
    {

    }
    void Init()
    {
        Parant = GetComponent<Image>();
        Button.Add(Resources.Load<Sprite>("Puase/ELEMENT_COMBINATION"));
        Button.Add(Resources.Load<Sprite>("Puase/ELEMENT_COMBINATION_PRESSED"));
        Button.Add(Resources.Load<Sprite>("Puase/HOW_TO_PLAY"));
        Button.Add(Resources.Load<Sprite>("Puase/HOW_TO_PLAY_PRESSED"));
        Button.Add(Resources.Load<Sprite>("Puase/GAME_EXIT"));
        Button.Add(Resources.Load<Sprite>("Puase/GAME_EXIT_PRESSED"));
        HowSprite.Add(Resources.Load<Sprite>("Puase/PAGE_0"));
        HowSprite.Add(Resources.Load<Sprite>("Puase/PAGE_1"));
        HowSprite.Add(Resources.Load<Sprite>("Puase/PAGE_2"));
        EleSprite.Add(Resources.Load<Sprite>("Puase/PAGE_00"));
        EleSprite.Add(Resources.Load<Sprite>("Puase/PAGE_01"));
        EleSprite.Add(Resources.Load<Sprite>("Puase/PAGE_02"));
        EleSprite.Add(Resources.Load<Sprite>("Puase/PAGE_03"));


        Object.Add(this.transform.GetChild(0).gameObject.GetComponent<Image>());
        Object.Add(this.transform.GetChild(1).gameObject.GetComponent<Image>());
        Object.Add(this.transform.GetChild(2).gameObject.GetComponent<Image>());
        Object.Add(this.transform.GetChild(3).gameObject.GetComponent<Image>());
        Object.Add(this.transform.GetChild(4).gameObject.GetComponent<Image>());
        Object.Add(this.transform.GetChild(5).gameObject.GetComponent<Image>());
        HowObject.Add(this.transform.GetChild(4).transform.GetChild(0).GetComponent<Image>());
        HowObject.Add(this.transform.GetChild(4).transform.GetChild(1).GetComponent<Image>());
        HowObject.Add(this.transform.GetChild(4).transform.GetChild(2).GetComponent<Image>());
        EleObject.Add(this.transform.GetChild(5).transform.GetChild(0).GetComponent<Image>());
        EleObject.Add(this.transform.GetChild(5).transform.GetChild(1).GetComponent<Image>());
        EleObject.Add(this.transform.GetChild(5).transform.GetChild(2).GetComponent<Image>());
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (Object[1].gameObject == eventData.pointerEnter)
            Object[1].sprite = Button[3];
        else if (Object[0].gameObject == eventData.pointerEnter)
            Object[0].sprite = Button[1];
        else if (Object[2].gameObject == eventData.pointerEnter)
            Object[2].sprite = Button[5];

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Object[1].gameObject == eventData.pointerEnter)
            Object[1].sprite = Button[2];
        else if (Object[0].gameObject == eventData.pointerEnter)
            Object[0].sprite = Button[0];
        else if (Object[2].gameObject == eventData.pointerEnter)
            Object[2].sprite = Button[4];
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Object[1].gameObject == eventData.pointerEnter)
        {
            Parant.enabled = false;
            Object[0].enabled = false;
            Object[1].enabled = false;
            Object[2].enabled = false;
            Object[3].enabled = false;
            Object[4].gameObject.SetActive(true);
        }
        else if (Object[0].gameObject == eventData.pointerEnter)
        {
            Parant.enabled = false;
            Object[0].enabled = false;
            Object[1].enabled = false;
            Object[2].enabled = false;
            Object[3].enabled = false;
            Object[5].gameObject.SetActive(true);
        }
        else if (Object[3].gameObject == eventData.pointerEnter)
        {
            this.transform.GetComponentInParent<Canvas>().enabled = false;
            Time.timeScale = 1f;
        }
        else if (Object[2].gameObject == eventData.pointerEnter)
        {
            Application.Quit();
        }
        else if (HowObject[0].gameObject == eventData.pointerEnter)
        {
            sound.PlayAudio();
            if (index == 0)
            {
                Object[4].sprite = HowSprite[2];
                index = 2;
            }
            else if (index == 1)
            {
                Object[4].sprite = HowSprite[0];
                index--;
            }
            else if (index == 2)
            {
                Object[4].sprite = HowSprite[1];
                index--;
            }

        }
        else if (HowObject[1].gameObject == eventData.pointerEnter)
        {
            sound.PlayAudio();
            if (index == 0)
            {
                Object[4].sprite = HowSprite[1];
                index++;
            }
            else if (index == 1)
            {
                Object[4].sprite = HowSprite[2];
                index++;
            }
            else if (index == 2)
            {
                Object[4].sprite = HowSprite[0];
                index = 0;
            }
        }
        else if (HowObject[2].gameObject == eventData.pointerEnter)
        {
            Object[4].gameObject.SetActive(false);
            Parant.enabled = true;
            Object[0].enabled = true;
            Object[1].enabled = true;
            Object[1].sprite = Button[2];
            Object[2].enabled = true;
            Object[3].enabled = true;
        }
        else if (EleObject[0].gameObject == eventData.pointerEnter)
        {
            sound.PlayAudio();
            if (index == 0)
            {
                Object[5].sprite = EleSprite[3];
                index = 3;
            }
            else if (index == 1)
            {
                Object[5].sprite = EleSprite[0];
                index--;
            }
            else if (index == 2)
            {
                Object[5].sprite = EleSprite[1];
                index--;
            }
            else if (index == 3)
            {
                Object[5].sprite = EleSprite[2];
                index--;
            }

        }
        else if (EleObject[1].gameObject == eventData.pointerEnter)
        {
            sound.PlayAudio();
            if (index == 0)
            {
                Object[5].sprite = EleSprite[1];
                index++;
            }
            else if (index == 1)
            {
                Object[5].sprite = EleSprite[2];
                index++;
            }
            else if (index == 2)
            {
                Object[5].sprite = EleSprite[3];
                index++;
            }
            else if (index == 3)
            {
                Object[5].sprite = EleSprite[0];
                index = 0;
            }
        }
        else if (EleObject[2].gameObject == eventData.pointerEnter)
        {
            Object[5].gameObject.SetActive(false);
            Parant.enabled = true;
            Object[0].enabled = true;
            Object[0].sprite = Button[0];
            Object[1].enabled = true;
            Object[2].enabled = true;
            Object[3].enabled = true;
        }



    }

}
