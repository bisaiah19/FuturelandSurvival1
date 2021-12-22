using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
    public static string location;
    private GameObject target;
    private int Enemypoints;
    private float restTime;
    public bool isOriginal;
    public int enemyArea;
    private int locationChance;

    private bool isCloseToPlayer;
    private float xOffset;
    private float yOffset;
    private float chance;
    private int attackChance;
    private int starveChance;

    public GameObject highlighter;
    public SpriteRenderer highlighterrender;

    private AudioSource source;
    public AudioClip enemyDamaged;
    public AudioClip playerDamaged;
    public AudioClip bearRoar;

    public GameObject particleobj;

    private int health;
    // Start is called before the first frame update
    void Start()
    {
        if (enemyArea == 0)
        {
            Enemypoints = Random.Range(1, 6);
        }
        if (enemyArea == 1)
        {
            locationChance = Random.Range(0, 10);
            if (locationChance <= 3)
            {
                Enemypoints = Random.Range(7, 9);
            }
            if (locationChance > 3)
            {
                Enemypoints = Random.Range(43, 48);
            }
        }
        if (enemyArea == 2)
        {
            Enemypoints = Random.Range(10, 20);
        }
        if (enemyArea >= 3)
        {
            Enemypoints = Random.Range(21, 40);
        }
        xOffset = Random.Range(-3, 3);
        yOffset = Random.Range(-3, 3);
        health = 2;
        restTime = 2;
        source = GetComponent<AudioSource>();

        location = "Point" + Enemypoints;
        target = GameObject.Find(location);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, target.transform.position.z), 3 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOriginal)
        {
            location = "Point" + Enemypoints;
            target = GameObject.Find(location);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x + xOffset, target.transform.position.y + yOffset, target.transform.position.z), 3 * Time.deltaTime);
            if (Indicator.optionSelected == "movebutton")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    chance = Random.Range(0, 10);
                    if (enemyArea == 0)
                    {
                        if (chance >= 5 && Enemypoints > 1 && Enemypoints <= 7)
                        {
                            Enemypoints -= 1;
                        }
                        if (chance < 5 && Enemypoints < 7)
                        {
                            Enemypoints += 1;
                        }
                    }
                    if (enemyArea == 1)
                    {
                        if (chance >= 5 && Enemypoints == 9)
                        {
                            Enemypoints = 43;
                        }
                        if (chance < 5 && Enemypoints == 43)
                        {
                            Enemypoints = 9;
                        }
                        if (chance >= 5 && Enemypoints >= 7 && Enemypoints < 9)
                        {
                            Enemypoints += 1;
                        }
                        if (chance < 5 && Enemypoints > 7 && Enemypoints <= 9)
                        {
                            Enemypoints -= 1;
                        }
                        if (chance >= 5 && Enemypoints >= 43 && Enemypoints < 48)
                        {
                            Enemypoints += 1;
                        }
                        if (chance < 5 && Enemypoints <= 48 && Enemypoints > 43)
                        {
                            Enemypoints -= 1;
                        }
                    }
                    if (enemyArea == 2)
                    {
                        if (chance >= 5 && Enemypoints > 10 && Enemypoints <= 20)
                        {
                            Enemypoints -= 1;
                        }
                        if (chance < 5 && Enemypoints < 20 && Enemypoints >= 10)
                        {
                            Enemypoints += 1;
                        }
                    }
                    if (enemyArea >= 3)
                    {
                        if (chance >= 5 && Enemypoints > 21 && Enemypoints <= 40)
                        {
                            Enemypoints -= 1;
                        }
                        if (chance < 5 && Enemypoints < 40 && Enemypoints >= 21)
                        {
                            Enemypoints += 1;
                        }
                    }
                }
            }

            if (isCloseToPlayer)
            {
                PlayerOnMap.isFighting = true;
            }
            if (!isCloseToPlayer)
            {
                PlayerOnMap.isFighting = false;
            }

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "PlayerMineRadius")
        {
            isCloseToPlayer = true;
            source.PlayOneShot(bearRoar);
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
        if (Indicator.optionSelected == "minebutton")
        {
            highlighterrender.enabled = true;
            highlighter.transform.position = this.transform.position;
        }
    }

    private void OnMouseExit()
    {
        if (Indicator.optionSelected == "minebutton")
        {
            highlighterrender.enabled = false;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("I got clicked 2!" + isCloseToPlayer + " / " + Indicator.optionSelected);
        if (isCloseToPlayer && Indicator.optionSelected == "minebutton")
        {
            Debug.Log("I got clicked!" + isCloseToPlayer + " / " + Indicator.optionSelected);
            highlighterrender.enabled = false;
            source.PlayOneShot(enemyDamaged);
            var partspawn = Instantiate(particleobj, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            partspawn.GetComponent<ParticleScript>().isOriginal = false;
            health -= 1;
            if (Indicator.hydrationPoints <= 0 || Indicator.hungerPoints <= 0)
            {
                Indicator.healthPoints -= 1;
            }
            Indicator.hydrationPoints -= 1;
            attackChance = Random.Range(0, 10);
            starveChance = Random.Range(0, 10);
            Invoke("AttackPlayer", 1);
            Invoke("StarvePlayer", .3f);
            Indicator.optionSelected = "none";
        }
    }

    private void OnDestroy()
    {
        Indicator.rawBear += 1;
        PlayerOnMap.isFighting = false;
    }

    private void AttackPlayer()
    {
        if (attackChance >= 4)
        {
            source.PlayOneShot(playerDamaged);
            Indicator.healthPoints -= 1;
        }
    }

    private void StarvePlayer()
    {
        if (starveChance >= 8)
        {
            Indicator.hungerPoints -= 1;
        }
    }
}
