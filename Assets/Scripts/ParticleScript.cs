using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScript : MonoBehaviour
{
    private float restTime;
    public bool isOriginal;
    // Start is called before the first frame update
    void Start()
    {
        restTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isOriginal)
        {
            restTime -= Time.deltaTime;
        }
        if (restTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
