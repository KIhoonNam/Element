using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EleGroupScript : MonoBehaviour
{
    [SerializeField]
    List<Image> Group = new List<Image>();
    Character player;
    // Start is called before the first frame update
    private void Awake()
    {
        player = FindObjectOfType<Character>();
    }
    void Start()
    {
        Character.EleImage += EleImageCheck;
        Character.ClearSet += Clear;

        for (int i = 0; i < transform.childCount; i++)
            Group.Add(transform.GetChild(i).gameObject.GetComponent<Image>());
    }

    private void Update()
    {

          
    }
    void Clear()
    {
        for (int i = 0; i < Group.Count; i++)
        {
            Group[i].enabled = false;
            Group[i].name = null;
        }

    }
    void EleImageCheck(string name, int index)
    {
        if (index >0 &&!LessCheck(index, name))
        {
            Group[index].sprite = Resources.Load<Sprite>("Image/UESLESS") as Sprite;
            Group[index].name = "UESLESS";
            Group[index].enabled = true;
        }
        else
        {
            Group[index].sprite = Resources.Load<Sprite>("Image/" + name) as Sprite;
            Group[index].name = name;
            Group[index].enabled = true;
        }
    }

    bool LessCheck(int index, string name)
    {
        int Stack = 0;
        bool Check = false;
        bool EleCheck = false;
        string Combo;
        if (index > 1 && Group[index - 1].name == "UESLESS"  )
            return false;

        if (index == 4)
        {
            for (int i = 0; i < index; i++)
            {
                Combo = Group[i].name;
                for (int j = 0; j < Group.Count; j++)
                {
                    if (j != i)
                        if (Combo == Group[i].name)
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
                goto Combination;
            }
        }
        if (index > 1)
        {
            for (int i = 0; i < Group.Count; i++)
            {
                if (Group[0].name == Group[i].name)
                    Stack++;
                else
                    break;
            }
            if (index == 2)
            {
                if (Stack == 2)
                {
                    if (Group[0].name == "Rock" && name == "Fire")
                        return true;
                    else if (Group[0].name == "Lightning" && name == "Water")
                        return true;
                    else if (Group[0].name == "Fire" && name == "Tree")
                        return true;
                    else if (Group[0].name != name)
                        return false;
                }
                else if(Stack == 1)
                {
                    if (Group[0].name == "Rock" && name == "Fire")
                        return true;
                    else if (Group[0].name == "Lightning" && name == "Water")
                        return true;
                    else if (Group[0].name == "Fire" && name == "Tree")
                        return true;

                    for (int i = 0; i < Group.Count; i++)
                    {
                        if (Group[i].name == name)
                        {
                                return false;
                        }

                    }
                }

            }
            else if (index == 3)
            {
                if (Stack == 3)
                {
                    if (Group[0].name == "Fire" && name == "Rock")
                        return true;
                    else if (Group[0].name == "Water" && name == "Lightning")
                        return true;
                    else if (Group[0].name == "Tree" && name == "Fire")
                        return true;
                    else if (Group[0].name != name)
                        return false;
                }
                else if(Stack == 1)
                {
                    if (Group[0].name == "Rock" && name == "Fire")
                        return true;
                    else if (Group[0].name == "Lightning" && name == "Water")
                        return true;
                    else if (Group[0].name == "Fire" && name == "Tree")
                        return true;
           
                    for (int i = 0; i < Group.Count; i++)
                    {
                        if (Group[i].name == name)
                        {
                            if (i == 0)
                                return true;
                            else
                                return false;
                        }

                    }
                }
                else
                {
                    if (Group[0].name == "Rock" && name == "Fire")
                        return true;
                    else if (Group[0].name == "Lightning" && name == "Water")
                        return true;
                    else if (Group[0].name == "Fire" && name == "Tree")
                        return true;
                    else if (Group[0].name != name)
                        return false;
                }
            }
            else if (index == 4)
            {
                if (Stack == 4)
                {
                   if (Group[0].name == "Fire" && name == "Rock")
                        return true;
                    else if (Group[0].name == "Water" && name == "Lightning")
                        return true;
                    else if (Group[0].name == "Tree" && name == "Fire")
                        return true;
                    else if (Group[0].name != name)
                        return false;
                }
                else if (Stack == 1)
                {
                    if (Group[0].name == "Rock" && name == "Fire")
                        return true;
                    else if (Group[0].name == "Lightning" && name == "Water")
                        return true;
                    else if (Group[0].name == "Fire" && name == "Tree")
                        return true;

                    for (int i = 0; i < Group.Count; i++)
                    {
                        if (Group[i].name == name)
                        {
                            if (i == 0)
                                return true;
                            else
                                return false;
                        }

                    }
                }
                else
                {
                    if (Group[0].name == "Rock" && name == "Fire")
                        return true;
                    else if (Group[0].name == "Lightning" && name == "Water")
                        return true;
                    else if (Group[0].name == "Fire" && name == "Tree")
                        return true;
                    else if (Group[0].name != name)
                        return false;
                }
            }


        }

    Combination:;
        return true;
    }
    private void OnDestroy()
    {
        Character.EleImage -= EleImageCheck;
        Character.ClearSet -= Clear;
    }
}
  
    
    

