
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    CharacterAnimation ca;
    public bool isGameStart=false, isGameComplete=false, isGameOver=false;
    public bool DeletePlayerPrefs;
    public int level = 0;
    Transform playerTransform;

    [SerializeField] GameObject celebrationObj;

    public List<Statistics> stats = new List<Statistics>();

    public class Completion : IComparer<Statistics>
    {
        public int Compare(Statistics x, Statistics y)
        {
            return x.completion.CompareTo(y.completion);
        }
    }
    void SortStats()
    {
        stats.Sort(new Completion());
        stats.Reverse();
        for (int i = 0; i < stats.Count; i++)
        {
            stats[i].rank = i;
        }
    }

    public void AddCharAnimation(CharacterAnimation ca)
    {
        this.ca = ca;
    }
    public void AddToStats(Statistics s)
    {
        stats.Add(s);
        if (s.isPlayer)
        {
            playerTransform = s.GetComponent<Transform>();
        }
        UIManagerScript.instance.mainPlayerStats = s;
    }


    private void Awake()
    {
        instance = this;
        level = PlayerPrefs.GetInt("LEVEL", 1);
        Application.targetFrameRate = 60;

        if (DeletePlayerPrefs)
            PlayerPrefs.DeleteAll();
    }

    void Start()
    {
        // isGameStart = true;
      LoadLevel();
    }

    void LoadLevel()
    {
        if (SceneManager.GetActiveScene().name != "Level" + level.ToString())
        {
            if (Application.CanStreamedLevelBeLoaded("Level" + level.ToString()))
            {
                SceneManager.LoadScene("Level" + level.ToString());
            }
            else
            {
                //  PlayerPrefs.DeleteAll();
                if (SceneManager.GetActiveScene().name != "FinalLevel")
                {
                    if (Application.CanStreamedLevelBeLoaded("FinalLevel"))
                        SceneManager.LoadScene("FinalLevel");
                    else
                    {
                        PlayerPrefs.DeleteAll();
                        SceneManager.LoadScene("Level1");
                    }
                }
            }
        }
        else
        {
            //  UIManagerScript.instance.SetUI();
                // GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, Application.version, level.ToString());
            // print("progression start" + level.ToString());

        }
    }
    public void GameStart()
    {
        isGameStart = true;
        isGameOver = false;
        isGameComplete = false;
        InvokeRepeating("SortStats", 2, 0.1f);

    }
    public void GameOver()
    {
        if (isGameOver)
        {
            return;
        }
        ca.GameFailedAnimation();
        isGameStart = false;
        isGameOver = true;
        isGameComplete = false;

        Invoke("DisplayGameOver", 2f);
    }

    void DisplayGameOver()
    {
        UIManagerScript.instance.GameOver();

    }

    void DisplayGameComplete()
    {
        UIManagerScript.instance.GameComplete();
      
    }
    void DisplayCelebration()
    {
        celebrationObj.SetActive(true);
        celebrationObj.transform.position = playerTransform.position;
        celebrationObj.transform.rotation = playerTransform.rotation;
    }
    public void GameComplete()
    {
        if (isGameComplete)
        {
            return;
        }

     


        ca.GameCompleteAnimation();
    
        isGameComplete = true;
        isGameStart = false;
        isGameOver = false;

        if (SceneManager.GetActiveScene().name == "Level" + level.ToString())
        {
            PlayerPrefs.SetInt("LEVEL", level + 1);
        }
        Invoke("DisplayCelebration", 0.1f);
        Invoke("DisplayGameComplete", 1f);
    }

    
}
