using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceScript : MonoBehaviour
{
    public string Type;
    private bool isCloseToPlayer;
    public SpriteRenderer toolrender;
    public Sprite inactiveFurnace;
    public Sprite activeFurnace;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerMineRadius")
        {
            isCloseToPlayer = true;
            if (Type == "furnace")
            {
                Indicator.isCloseToFurnace = true;
            }
            if (Type == "forge")
            {
                Indicator.isCloseToForge = true;
            }
            if (Type == "portalsite")
            {
                Indicator.isCloseToPortalSite = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerMineRadius")
        {
            isCloseToPlayer = false;
            if (Type == "furnace")
            {
                Indicator.isCloseToFurnace = false;
            }
            if (Type == "forge")
            {
                Indicator.isCloseToForge = false;
            }
            if (Type == "portalsite")
            {
                Indicator.isCloseToPortalSite = false;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Indicator.isCloseToLitFurnace)
        {
            toolrender.sprite = inactiveFurnace;
        }
        if (Indicator.isCloseToLitFurnace)
        {
            toolrender.sprite = activeFurnace;
        }
    }
}
