using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class IntroScript : MonoBehaviour,IPointerDownHandler,IPointerExitHandler,IPointerUpHandler
{
    List<Sprite> Button = new List<Sprite>();
    List<Image> Object = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }


    private void Init()
    {
        
        Button.Add(Resources.Load<Sprite>("Intro/START_BUTTON"));
        Button.Add(Resources.Load<Sprite>("Intro/START_PRESS"));
        Button.Add(Resources.Load<Sprite>("Intro/QUIT_BUTTON"));
        Button.Add(Resources.Load<Sprite>("Intro/QUIT_PRESS"));
        Object.Add(this.transform.GetChild(0).gameObject.GetComponent<Image>());
        Object.Add(this.transform.GetChild(1).gameObject.GetComponent<Image>());

    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Object[1].gameObject == eventData.pointerEnter)
            Object[1].sprite = Button[3];
        if (Object[0].gameObject == eventData.pointerEnter)
            Object[0].sprite = Button[1];

    }

    public void OnPointerExit(PointerEventData eventData)
    {
      if(Object[1].gameObject == eventData.pointerEnter)
            Object[1].sprite = Button[2];
        if (Object[0].gameObject == eventData.pointerEnter)
            Object[0].sprite = Button[0];
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (Object[1].gameObject == eventData.pointerEnter)
        {
            Application.Quit();
        }
        else if (Object[0].gameObject == eventData.pointerEnter)
            LoadingSceneManager.LoadScene("MainScene");

    }
}
