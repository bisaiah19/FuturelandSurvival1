using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOnMap : MonoBehaviour
{
    public static string location;
    private GameObject target;
    public static int points;
    public static float playerRestTime;
    public static bool isFighting;

    public List<GameObject> locationPoints;

    // Start is called before the first frame update
    void Start()
    {
        location = "Point1";
        points = 1;
        playerRestTime = 2;
        isFighting = false;
    }

    // Update is called once per frame
    void Update()
    {
        location = "Point" + points;
        target = GameObject.Find(location);
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 3 * Time.deltaTime);

        if (playerRestTime >= 0)
        {
            playerRestTime -= Time.deltaTime;
        }
    }
}
