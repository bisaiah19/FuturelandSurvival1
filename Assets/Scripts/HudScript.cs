using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudScript : MonoBehaviour
{
    public string Type;
    public GameObject UItext;
    TextMeshProUGUI myText;

    public GameObject highlighter;
    public SpriteRenderer highlighterrender;

    public SpriteRenderer spriterenderer;
    public BoxCollider2D boxcollider;

    // Start is called before the first frame update
    void Start()
    {
        if (Type == "hydrationtext")
        {
            myText = GameObject.Find("HydPoints").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "hungertext")
        {
            myText = GameObject.Find("HungerPoints").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "healthtext")
        {
            myText = GameObject.Find("HitPoints").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "woodtext")
        {
            myText = GameObject.Find("WoodAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "irontext")
        {
            myText = GameObject.Find("IronAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "goldtext")
        {
            myText = GameObject.Find("GoldAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "crystaltext")
        {
            myText = GameObject.Find("CrystalAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "rawbeartext")
        {
            myText = GameObject.Find("RawBearAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "rawporktext")
        {
            myText = GameObject.Find("RawPorkAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "cookedbeartext")
        {
            myText = GameObject.Find("CookedBearAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "cookedporktext")
        {
            myText = GameObject.Find("CookedPorkAmt").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "movebutton")
        {
            myText = GameObject.Find("MoveButton").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "minebutton")
        {
            myText = GameObject.Find("MineButton").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "consumebutton")
        {
            myText = GameObject.Find("ConsumeButton").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "duplicatebutton")
        {
            myText = GameObject.Find("DuplicateButton").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "usefurnace")
        {
            myText = GameObject.Find("UseFurnace").GetComponent<TextMeshProUGUI>();
        }
        if (Type == "cookfood")
        {
            myText = GameObject.Find("Activate").GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Type == "hydrationtext")
        {
            myText.text = "Hydration: " + Indicator.hydrationPoints;
        }
        if (Type == "hungertext")
        {
            myText.text = "Hunger: " + Indicator.hungerPoints;
        }
        if (Type == "healthtext")
        {
            myText.text = "Health: " + Indicator.healthPoints;
        }
        if (Type == "woodtext")
        {
            myText.text = "x " + Indicator.wood;
        }
        if (Type == "irontext")
        {
            myText.text = "x " + Indicator.iron;
        }
        if (Type == "goldtext")
        {
            myText.text = "x " + Indicator.gold;
        }
        if (Type == "crystaltext")
        {
            myText.text = "x " + Indicator.crystal;
        }
        if (Type == "rawbeartext")
        {
            myText.text = "x " + Indicator.rawBear;
        }
        if (Type == "rawporktext")
        {
            myText.text = "x " + Indicator.rawPork;
        }
        if (Type == "cookedbeartext")
        {
            myText.text = "x " + Indicator.cookedBear;
        }
        if (Type == "cookedporktext")
        {
            myText.text = "x " + Indicator.cookedPork;
        }
        if (Type == "usefurnace")
        {
            if (Indicator.isCloseToFurnace)
            {
                myText.text = "Use Furnace - 2";
                boxcollider.enabled = true;
            }
            if (!Indicator.isCloseToFurnace)
            {
                myText.text = "";
                boxcollider.enabled = false;
            }
        }
        if (Type == "woodrequirement")
        {
            if (Indicator.isCloseToFurnace)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToFurnace)
            {
                spriterenderer.enabled = false;
            }
            if (Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = false;
            }
        }
        if (Type == "ironrequirement")
        {
            if (Indicator.isCloseToForge)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToForge)
            {
                spriterenderer.enabled = false;
            }
            if (Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = false;
            }
        }
        if (Type == "goldrequirement")
        {
            if (Indicator.isCloseToForge)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToForge)
            {
                spriterenderer.enabled = false;
            }
            if (Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = false;
            }
        }
        if (Type == "crystalrequirement")
        {
            if (Indicator.isCloseToForge)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToForge)
            {
                spriterenderer.enabled = false;
            }
            if (Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = true;
            }
            if (!Indicator.isCloseToPortalSite)
            {
                spriterenderer.enabled = false;
            }
        }
        if (Type == "cookfood")
        {
            if (Indicator.isCloseToFurnace)
            {
                boxcollider.enabled = true;
                if (!Indicator.isCloseToLitFurnace)
                {
                    myText.text = "Furnace Inactive";
                    myText.color = Color.white;
                }
                if (Indicator.isCloseToLitFurnace)
                {
                    myText.text = "Cook Food";
                    if (Indicator.optionSelected == "cookfood")
                    {
                        myText.color = Color.magenta;
                    }
                    if (Indicator.optionSelected != "cookfood" && Input.GetMouseButtonDown(0))
                    {
                        myText.color = Color.white;
                    }
                }
            }
            if (Indicator.isCloseToPortalSite)
            {
                boxcollider.enabled = true;
                if (Indicator.wood < 10 || Indicator.iron < 10 || Indicator.gold < 10 || Indicator.crystal < 10)
                {
                    myText.text = "10 of each material required";
                    myText.color = Color.white;
                }
                if (Indicator.wood >= 10 && Indicator.iron >= 10 && Indicator.gold >= 10 && Indicator.crystal >= 10)
                {
                    myText.text = "Create Portal";
                    myText.color = Color.white;
                }
            }
            if (!Indicator.isCloseToFurnace && !Indicator.isCloseToPortalSite)
            {
                myText.text = "";
                boxcollider.enabled = false;
            }
        }
        if (Type == "movebutton")
        {
            if (Indicator.optionSelected == "movebutton")
            {
                myText.color = Color.magenta;
            }
            if (Indicator.optionSelected != "movebutton" && Input.GetMouseButtonDown(0))
            {
                myText.color = Color.white;
            }
        }
        if (Type == "minebutton")
        {
            if (Indicator.optionSelected == "minebutton")
            {
                myText.color = Color.magenta;
            }
            if (Indicator.optionSelected != "minebutton" && Input.GetMouseButtonDown(0))
            {
                myText.color = Color.white;
            }
        }
        if (Type == "consumebutton")
        {
            if (Indicator.optionSelected == "consumebutton")
            {
                myText.color = Color.magenta;
            }
            if (Indicator.optionSelected != "consumebutton" && Input.GetMouseButtonDown(0))
            {
                myText.color = Color.white;
            }
        }
        if (Type == "duplicatebutton")
        {
            if (Indicator.optionSelected == "duplicatebutton")
            {
                myText.color = Color.magenta;
            }
            if (Indicator.optionSelected != "duplicatebutton" && Input.GetMouseButtonDown(0))
            {
                myText.color = Color.white;
            }
        }
    }

    private void OnMouseOver()
    {
        if (Indicator.optionSelected == "consumebutton")
        {
            if (Type == "rawpork" || Type == "rawbear" || Type == "cookedpork" || Type == "cookedbear")
            {
                highlighter.transform.position = this.transform.position;
            }
        }
        if (Indicator.optionSelected == "cookfood")
        {
            if (Type == "rawpork" || Type == "rawbear")
            {
                highlighter.transform.position = this.transform.position;
            }
        }
    }

    private void OnMouseEnter()
    {
        if (Type == "movebutton")
        {
            myText.color = Color.yellow;
        }
        if (Type == "minebutton")
        {
            myText.color = Color.yellow;
        }
        if (Type == "consumebutton")
        {
            myText.color = Color.yellow;
        }
        if (Type == "duplicatebutton")
        {
            myText.color = Color.yellow;
        }
        if (Type == "usefurnace")
        {
            myText.color = Color.yellow;
        }
        if (Type == "cookfood" && Indicator.isCloseToLitFurnace)
        {
            myText.color = Color.yellow;
        }
    }

    private void OnMouseExit()
    {
        highlighterrender.enabled = false;
        if (Type == "movebutton" && Indicator.optionSelected != "movebutton")
        {
            myText.color = Color.white;
        }
        if (Type == "minebutton" && Indicator.optionSelected != "minebutton")
        {
            myText.color = Color.white;
        }
        if (Type == "consumebutton" && Indicator.optionSelected != "consumebutton")
        {
            myText.color = Color.white;
        }
        if (Type == "duplicatebutton" && Indicator.optionSelected != "duplicatebutton")
        {
            myText.color = Color.white;
        }
        if (Type == "usefurnace" && Indicator.optionSelected != "usefurnace")
        {
            myText.color = Color.white;
        }
        if (Type == "cookfood" && Indicator.optionSelected != "cookfood")
        {
            myText.color = Color.white;
        }
    }

    private void OnMouseDown()
    {
        if (Type == "movebutton")
        {
            if (!PlayerOnMap.isFighting)
            {
                Indicator.optionSelected = "movebutton";
            }
        }
        if (Type == "minebutton")
        {
            Indicator.optionSelected = "minebutton";
        }
        if (Type == "consumebutton")
        {
            Indicator.optionSelected = "consumebutton";
        }
        if (Type == "duplicatebutton")
        {
            Indicator.optionSelected = "duplicatebutton";
        }
        if (Type == "cookfood")
        {
            if (!Indicator.isCloseToPortalSite)
            {
                Indicator.optionSelected = "cookfood";
            }
            if (Indicator.isCloseToPortalSite)
            {
                SceneManager.LoadScene("Congrats");
            }
        }
        if (Indicator.optionSelected == "consumebutton")
        {
            if (Type == "rawpork")
            {
                Indicator.rawPork -= 1;
                Indicator.hungerPoints += 1;
                Indicator.healthPoints += 1;
            }
            if (Type == "rawbear")
            {
                Indicator.rawBear -= 1;
                Indicator.hungerPoints += 1;
                Indicator.healthPoints += 1;
            }
            if (Type == "cookedpork")
            {
                Indicator.cookedPork -= 1;
                Indicator.hungerPoints += 3;
                Indicator.healthPoints += 2;
            }
            if (Type == "cookedbear")
            {
                Indicator.cookedBear -= 1;
                Indicator.hungerPoints += 3;
                Indicator.healthPoints += 2;
            }
        }
        if (Indicator.optionSelected == "cookfood" && Indicator.isCloseToLitFurnace)
        {
            if (Type == "rawpork")
            {
                Indicator.cookedPork += 1;
                Indicator.rawPork -= 1;
            }
            if (Type == "rawbear")
            {
                Indicator.cookedBear += 1;
                Indicator.rawBear -= 1;
            }
        }
        if (Type == "usefurnace")
        {
            if (Indicator.wood >= 2)
            {
                Indicator.isCloseToLitFurnace = true;
                Indicator.wood -= 2;
                Invoke("TurnOffFurnace", 5);
            }
        }
    }

    void TurnOffFurnace()
    {
        Indicator.isCloseToLitFurnace = false;
        Indicator.optionSelected = "none";
    }
}
