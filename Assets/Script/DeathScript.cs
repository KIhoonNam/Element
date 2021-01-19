using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class DeathScript : MonoBehaviour, IPointerClickHandler
{

    GameObject Restart;
    GameObject Quit;
    // Start is called before the first frame update
    void Start()
    {
        Restart = gameObject.transform.GetChild(1).gameObject;
        Quit = gameObject.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
    
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Restart == eventData.pointerEnter)
        {
            LoadingSceneManager.LoadScene("MainScene");
        }
        else if (Quit == eventData.pointerEnter)
        {
            LoadingSceneManager.LoadScene("IntroScene");
        }
    }
}
