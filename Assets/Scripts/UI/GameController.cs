using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    int maxLives;

    [SerializeField]
    HealthScript healthScript;

    [SerializeField]
    int currentLives;

    [SerializeField]
    static string baseScene = "TestMap";


    [SerializeField]
    static int currentScrollingLevel;

    public static bool hostileCanMove = true;

    [SerializeField]
    static int scrollingLevels = 2;

    static bool[] finishedScrollingLevel = new bool[scrollingLevels];
    public static bool[] destroyedShield = new bool[scrollingLevels];

    [SerializeField]
    static string[] scrollingScenes = new string[] { "Scrolling1", "Scrolling2" };

    public bool isEndless;

    public static bool paused = false;

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void Start() {
        if (GameObject.FindGameObjectsWithTag("GameController").Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }
        SceneManager.sceneLoaded += OnLevelFinishedLoading;

        DontDestroyOnLoad(this);
        currentLives = maxLives;
        getHealthScript().UpdateLives(currentLives);

    }

    public void StopAllHostile()
    {
        hostileCanMove = false;
    }

    public void PlayerDie()
    {
        --currentLives;



        StopAllHostile();
        //SceneManager.LoadScene("TestMap");
    }

    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        hostileCanMove = true;
        healthScript = null;
        getHealthScript().UpdateLives(currentLives);

        foreach (EnergyCore core in FindObjectsOfType<EnergyCore>())
            if (finishedScrollingLevel[core.scrollingIndex])
                core.broken = true;

    }

    public void Portal(int world)
    {
        currentScrollingLevel = world;
        SceneManager.LoadScene(scrollingScenes[world]);
    }

    // Update is called once per frame
    void Update () {
		
	}

    HealthScript getHealthScript()
    {
        if (!healthScript)
            healthScript = FindObjectOfType<HealthScript>();
        return healthScript;
    }

    public static void FinishScrollingLevel()
    {
        finishedScrollingLevel[currentScrollingLevel] = true;
        Debug.Log(finishedScrollingLevel);

        SceneManager.LoadScene(baseScene);
    }

}
