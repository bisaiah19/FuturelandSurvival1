using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private int spawnType;
    private int spawnArea;
    private float spawnTime;
    public GameObject bear;
    public GameObject tree;
    public GameObject iron;
    public GameObject gold;
    public GameObject crystal;
    Vector3 mousePos;
    Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()
    {
        var bearspawn = Instantiate(bear, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
        bearspawn.GetComponent<BearScript>().isOriginal = false;
        bearspawn.GetComponent<BearScript>().enemyArea = 0;
        spawnTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spawnTime -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0))
        {
            if (Indicator.itemBeingDuplicated == "tree")
            {
                var treespawn = Instantiate(tree, mousePosition, Quaternion.identity);
                Indicator.hydrationPoints -= 3;
                Indicator.hungerPoints -= 1;
                Indicator.optionSelected = "none";
                Indicator.itemBeingDuplicated = "none";
            }
            if (Indicator.itemBeingDuplicated == "iron")
            {
                var ironspawn = Instantiate(iron, mousePosition, Quaternion.identity);
                Indicator.hydrationPoints -= 3;
                Indicator.hungerPoints -= 1;
                Indicator.optionSelected = "none";
                Indicator.itemBeingDuplicated = "none";
            }
            if (Indicator.itemBeingDuplicated == "gold")
            {
                var goldspawn = Instantiate(gold, mousePosition, Quaternion.identity);
                Indicator.hydrationPoints -= 3;
                Indicator.hungerPoints -= 1;
                Indicator.optionSelected = "none";
                Indicator.itemBeingDuplicated = "none";
            }
            if (Indicator.itemBeingDuplicated == "crystal")
            {
                var crystalspawn = Instantiate(crystal, mousePosition, Quaternion.identity);
                Indicator.hydrationPoints -= 3;
                Indicator.hungerPoints -= 1;
                Indicator.optionSelected = "none";
                Indicator.itemBeingDuplicated = "none";
            }
        }
        if (spawnTime <= 0)
        {
            spawnArea = Random.Range(0, 4);
            var bearspawn = Instantiate(bear, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            bearspawn.GetComponent<BearScript>().isOriginal = false;
            bearspawn.GetComponent<BearScript>().enemyArea = spawnArea;
            spawnTime = 10;
        }
    }
}
