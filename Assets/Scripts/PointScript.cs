using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    public GameObject highlighter;
    public SpriteRenderer highlighterrender;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Indicator.optionSelected == "movebutton")
        {
            highlighterrender.enabled = true;
            if (gameObject.name == "Point" + (PlayerOnMap.points + 1))
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point" + (PlayerOnMap.points - 1))
            {
                if (gameObject.name != "Point20")
                {
                    highlighter.transform.position = this.transform.position;
                }
            }
            if (gameObject.name == "Point20" && PlayerOnMap.points == 10)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point10" && PlayerOnMap.points == 20)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point42" && PlayerOnMap.points == 19)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point19" && PlayerOnMap.points == 42)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point21" && PlayerOnMap.points == 17)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point17" && PlayerOnMap.points == 21)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point41" && PlayerOnMap.points == 28)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point28" && PlayerOnMap.points == 41)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point40" && PlayerOnMap.points == 30)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point30" && PlayerOnMap.points == 40)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point43" && PlayerOnMap.points == 9)
            {
                highlighter.transform.position = this.transform.position;
            }
            if (gameObject.name == "Point9" && PlayerOnMap.points == 43)
            {
                highlighter.transform.position = this.transform.position;
            }
        }
    }

    private void OnMouseExit()
    {
        highlighterrender.enabled = false;
    }

    private void OnMouseDown()
    {
        if (PlayerOnMap.playerRestTime <= 0 && Indicator.optionSelected == "movebutton")
        {
            highlighterrender.enabled = false;
            if (gameObject.name == "Point" + (PlayerOnMap.points + 1))
            {
                PlayerOnMap.points += 1;
            }
            if (gameObject.name == "Point" + (PlayerOnMap.points - 1))
            {
                if (gameObject.name != "Point20")
                {
                    PlayerOnMap.points -= 1;
                }
            }
            if (gameObject.name == "Point20" && PlayerOnMap.points == 10)
            {
                PlayerOnMap.points = 20;
            }
            if (gameObject.name == "Point10" && PlayerOnMap.points == 20)
            {
                PlayerOnMap.points = 10;
            }
            if (gameObject.name == "Point42" && PlayerOnMap.points == 19)
            {
                PlayerOnMap.points = 42;
            }
            if (gameObject.name == "Point19" && PlayerOnMap.points == 42)
            {
                PlayerOnMap.points = 19;
            }
            if (gameObject.name == "Point21" && PlayerOnMap.points == 17)
            {
                PlayerOnMap.points = 21;
            }
            if (gameObject.name == "Point17" && PlayerOnMap.points == 21)
            {
                PlayerOnMap.points = 17;
            }
            if (gameObject.name == "Point41" && PlayerOnMap.points == 28)
            {
                PlayerOnMap.points = 41;
            }
            if (gameObject.name == "Point28" && PlayerOnMap.points == 41)
            {
                PlayerOnMap.points = 28;
            }
            if (gameObject.name == "Point40" && PlayerOnMap.points == 30)
            {
                PlayerOnMap.points = 40;
            }
            if (gameObject.name == "Point30" && PlayerOnMap.points == 40)
            {
                PlayerOnMap.points = 30;
            }
            if (gameObject.name == "Point43" && PlayerOnMap.points == 9)
            {
                PlayerOnMap.points = 43;
            }
            if (gameObject.name == "Point9" && PlayerOnMap.points == 43)
            {
                PlayerOnMap.points = 9;
            }
            if (Indicator.hydrationPoints <= 0 || Indicator.hungerPoints <= 0)
            {
                Indicator.healthPoints -= 1;
            }
            Indicator.hydrationPoints -= 1;
            PlayerOnMap.playerRestTime = 2;
            Indicator.optionSelected = "none";
        }
    }
}
