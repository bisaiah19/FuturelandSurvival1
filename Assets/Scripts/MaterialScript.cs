using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialScript : MonoBehaviour
{
    public string Type;
    private bool isCloseToPlayer;

    public GameObject highlighter;
    public SpriteRenderer highlighterrender;

    public GameObject treepart;
    public GameObject metalpart;

    private AudioSource source;
    public AudioClip treechop;
    public AudioClip stonebreak;
    public AudioClip drinking;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerMineRadius")
        {
            isCloseToPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerMineRadius")
        {
            isCloseToPlayer = false;
        }
    }

    private void OnMouseOver()
    {
        if (Indicator.optionSelected == "minebutton" && Type != "lake")
        {
            highlighterrender.enabled = true;
            highlighter.transform.position = this.transform.position;
        }
        if (Indicator.optionSelected == "duplicatebutton" && Type != "lake" && Indicator.itemBeingDuplicated == "none")
        {
            highlighterrender.enabled = true;
            highlighter.transform.position = this.transform.position;
        }
        if (Indicator.optionSelected == "consumebutton" && Type == "lake")
        {
            highlighterrender.enabled = true;
            highlighter.transform.position = this.transform.position;
        }
    }

    private void OnMouseExit()
    {
        if (Indicator.optionSelected == "minebutton" || Indicator.optionSelected == "consumebutton" || Indicator.optionSelected == "duplicatebutton")
        {
            highlighterrender.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("I got clicked 2!" + isCloseToPlayer + " / " + Type + " / " + Indicator.optionSelected);
        highlighterrender.enabled = false;
        if (isCloseToPlayer && Type == "tree" && Indicator.optionSelected == "minebutton")
        {
            source.PlayOneShot(treechop);
            Indicator.hydrationPoints -= 2;
            Indicator.hungerPoints -= 2;
            Indicator.wood += 3;
            Indicator.optionSelected = "none";
            var treepartspawn = Instantiate(treepart, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            treepartspawn.GetComponent<ParticleScript>().isOriginal = false;
            Debug.Log("I got clicked!" + isCloseToPlayer + " / " + Type + " / " + Indicator.optionSelected);
            Invoke("DestroyObject", .5f);
        }
        if (isCloseToPlayer && Type == "tree" && Indicator.optionSelected == "duplicatebutton")
        {
            Indicator.itemBeingDuplicated = "tree";
        }
        if (isCloseToPlayer && Type == "iron" && Indicator.optionSelected == "minebutton")
        {
            source.PlayOneShot(stonebreak);
            Indicator.hydrationPoints -= 2;
            Indicator.hungerPoints -= 2;
            Indicator.iron += 2;
            Indicator.optionSelected = "none";
            var metalspawn = Instantiate(metalpart, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            metalspawn.GetComponent<ParticleScript>().isOriginal = false;
            Invoke("DestroyObject", .5f);
        }
        if (isCloseToPlayer && Type == "iron" && Indicator.optionSelected == "duplicatebutton")
        {
            Indicator.itemBeingDuplicated = "iron";
        }
        if (isCloseToPlayer && Type == "gold" && Indicator.optionSelected == "minebutton")
        {
            source.PlayOneShot(stonebreak);
            Indicator.hydrationPoints -= 2;
            Indicator.hungerPoints -= 2;
            Indicator.gold += 2;
            Indicator.optionSelected = "none";
            var metalspawn = Instantiate(metalpart, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            metalspawn.GetComponent<ParticleScript>().isOriginal = false;
            Invoke("DestroyObject", .5f);
        }
        if (isCloseToPlayer && Type == "gold" && Indicator.optionSelected == "duplicatebutton")
        {
            Indicator.itemBeingDuplicated = "gold";
        }
        if (isCloseToPlayer && Type == "crystal" && Indicator.optionSelected == "minebutton")
        {
            source.PlayOneShot(stonebreak);
            Indicator.hydrationPoints -= 3;
            Indicator.hungerPoints -= 3;
            Indicator.crystal += 2;
            Indicator.optionSelected = "none";
            var metalspawn = Instantiate(metalpart, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            metalspawn.GetComponent<ParticleScript>().isOriginal = false;
            Invoke("DestroyObject", .5f);
        }
        if (isCloseToPlayer && Type == "crystal" && Indicator.optionSelected == "duplicatebutton")
        {
            Indicator.itemBeingDuplicated = "crystal";
        }
        if (isCloseToPlayer && Type == "lake" && Indicator.optionSelected == "consumebutton")
        {
            source.PlayOneShot(drinking);
            if (Indicator.hydrationPoints < 18)
            {
                Indicator.hydrationPoints += 3;
            }
            if (Indicator.hydrationPoints == 18 || Indicator.hydrationPoints == 19)
            {
                Indicator.hydrationPoints = 20;
            }
            Indicator.optionSelected = "none";
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }
}
