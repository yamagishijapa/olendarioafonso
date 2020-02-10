using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//PROTOTIPO DE GERENCIADOR DE CENAS - NÃO UTILIZADO NA VERSÃO FINAL
//SUBSTITUÍDO PELO SceneManagerS.cs
public class SceneManagerGeral: MonoBehaviour
{
    public bool keep = false;
    public bool firstRun = false;
    public GameObject hero;
    public string nomeNext;
    public bool tutorial;
    public int currentScene;
    public int nextScene;
    public int previousScene;
    public Button tryAgain;
    public Button mainMenu;
    public Scene current;
    public Scene previous;

    private void Awake()
    {
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("SMG");
        if (keep == true)
        {
            DontDestroyOnLoad(this.gameObject);
            firstRun = true;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;
        previousScene = SceneManager.GetActiveScene().buildIndex -1;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        //SceneManager.
        tutorial = true;

    }

    // Update is called once per frame
    void Update()
    {
        
        currentScene = SceneManager.GetActiveScene().buildIndex;
        hero = GameObject.FindGameObjectWithTag("Hero");
        if(hero.GetComponent<Hero>().alive == false)
        {
            SceneManager.LoadScene("feedbackDerrota");
        }
    }

    public void NextScene ()
    {
        Debug.Log("Current"+SceneManager.GetActiveScene().name);
        current = SceneManager.GetActiveScene();
        previous = current;
        Debug.Log("Previous" + previous.name);
        //if(SceneManager.sceneCount > nextScene)
        previousScene = SceneManager.GetActiveScene().buildIndex - 1;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(previous.buildIndex + 1);
        Debug.Log("Current" + SceneManager.GetActiveScene().name);

        //SceneManager.MoveGameObjectToScene(this.gameObject, SceneManager.GetActiveScene());
    }

    public void PreviousScene()
    {
        Debug.Log("Current" + SceneManager.GetActiveScene().name);
        current = SceneManager.GetActiveScene();
        previous = current;
        Debug.Log("Previous" + previous.name);
        previousScene = SceneManager.GetActiveScene().buildIndex - 1;
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(previous.buildIndex);
        Debug.Log("Current" + SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
