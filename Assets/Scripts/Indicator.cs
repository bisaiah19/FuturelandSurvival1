using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Indicator : MonoBehaviour
{
    public static int hydrationPoints;
    public static int hungerPoints;
    public static int healthPoints;
    public static int wood;
    public static int iron;
    public static int gold;
    public static int crystal;
    public static string optionSelected;
    public static string weaponType;

    public static int rawBear;
    public static int rawPork;
    public static int cookedBear;
    public static int cookedPork;

    public static string itemBeingDuplicated;

    public static bool isCloseToFurnace;
    public static bool isCloseToLitFurnace;
    public static bool isCloseToForge;
    public static bool isCloseToPortalSite;

    private AudioSource source;
    public AudioClip music1;
    public AudioClip playerdead;
    // Start is called before the first frame update
    void Start()
    {
        hydrationPoints = 15;
        hungerPoints = 15;
        healthPoints = 10;
        wood = 0;
        iron = 0;
        gold = 0;
        crystal = 0;
        optionSelected = "none";
        weaponType = "woodenPaxe";
        itemBeingDuplicated = "none";

        rawBear = 0;
        rawPork = 0;
        cookedBear = 0;
        cookedPork = 0;

        isCloseToFurnace = false;

        source = GetComponent<AudioSource>();
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (source.isPlaying == false)
        {
            source.PlayOneShot(music1);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay"))
        {
            if (healthPoints <= 0)
            {
                SceneManager.LoadScene("GameOver");
                source.PlayOneShot(playerdead);
            }
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("TitleScreen") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("GameOver"))
        {
            if (Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("Gameplay");
                hydrationPoints = 15;
                hungerPoints = 15;
                healthPoints = 10;
                wood = 0;
                iron = 0;
                gold = 0;
                crystal = 0;
                optionSelected = "none";
                weaponType = "woodenPaxe";
                itemBeingDuplicated = "none";

                rawBear = 0;
                rawPork = 0;
                cookedBear = 0;
                cookedPork = 0;

                isCloseToFurnace = false;
            }
        }
    }
}
