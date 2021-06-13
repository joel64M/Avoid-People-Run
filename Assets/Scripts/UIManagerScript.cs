using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManagerScript : MonoBehaviour
{
    public static UIManagerScript instance;

    GameManagerScript gms;
  
    public Image levelProgressFill;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;

    [Header("Panels")]
    [SerializeField] GameObject beforeStartPanel;
    [SerializeField] GameObject gamePlayPanel;
    [SerializeField] GameObject gameCompletePanel;
    [SerializeField] GameObject gameOverPanel;


    public Statistics mainPlayerStats;


    int currentLevel = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gms = GameManagerScript.instance;
       
        currentLevel = gms.level;

        currentLevelText.text = currentLevel.ToString();
        nextLevelText.text = (currentLevel + 1).ToString();

        levelProgressFill.fillAmount = 0;

        //for (int i = 0; i < gameCompletePanelList.Count; i++)
        //{
        //    GetComponentInChildren
        //}
        HideAllPanels();
        beforeStartPanel.SetActive(true);

    }
    private void Update()
    {
        if (gms.isGameStart)
        {
            levelProgressFill.fillAmount = mainPlayerStats.completion/100f;//  ((characterTransform.position.z - startZ) / divZ);
            if (mainPlayerStats.completion >= 100)
            {
                gms.GameComplete(); 
            }
        }
        else
        {
          
        }

    }

  
    void HideAllPanels()
    {
        beforeStartPanel.SetActive(false);
        gameCompletePanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
    }

    public void GameComplete()
    {
        HideAllPanels();
        gameCompletePanel.SetActive(true);
    }
    public void GameOver()
    {
        HideAllPanels();
        gameOverPanel.SetActive(true);
    }

    public void _GameButton()
    {
        if (gms.isGameComplete)
        {
            //  SceneManager.LoadScene("Level"+(currentLevel+1).ToString());
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            if (Application.CanStreamedLevelBeLoaded("Level" + (currentLevel + 1).ToString()))
            {
                SceneManager.LoadScene("Level" + (currentLevel + 1).ToString());
            }
            else
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
        else if (gms.isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (!gms.isGameStart && !gms.isGameOver && !gms.isGameComplete)
        {
         //   GameStart();
            gms.GameStart();
            HideAllPanels();
            gamePlayPanel.SetActive(true);
        }
        else
        {
            Debug.Log("No condition defined");
        }
    }

}
