using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Script responsável pelo gerenciamento das cenas do jogo.

public class SceneManagerS: MonoBehaviour
{
    public Animator animate;
    public GameObject sword;
    public GameObject hero;
    public string nomePrev;
    public string nomeNext;
    public Button jogar;
    public Button mainMenu;
    public Scene current;
    public Scene previous;
    public int countDialogo;
    public Image black;

    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");

    }

    // Update is called once per frame
    void Update()
    {
        //mudança de cena para vitória ou derrota de cada cena

        //caso o heroi morra, vai para a cena de derrota equivalente da fase.
        if(hero.GetComponent<Hero>().alive == false)
        {
            if(SceneManager.GetActiveScene().name == "Tutorial")
            {
                SceneManager.LoadScene("feedbackDerrotaT");
            }
            if (SceneManager.GetActiveScene().name == "Fase1")
            {
                SceneManager.LoadScene("feedbackDerrota1");
            }
            if (SceneManager.GetActiveScene().name == "Fase2")
            {
                SceneManager.LoadScene("feedbackDerrota2");
            }
            if (SceneManager.GetActiveScene().name == "Fase3")
            {
                SceneManager.LoadScene("feedbackDerrota3");
            }
            if (SceneManager.GetActiveScene().name == "Fase4")
            {
                SceneManager.LoadScene("feedbackDerrota4");
            }
            if (SceneManager.GetActiveScene().name == "Fase5")
            {
                SceneManager.LoadScene("feedbackDerrota5");
            }
        }

        //caso o heroi vença, vai para a cena de vitória equivalente da fase.
        if (hero.GetComponent<Hero>().final == true)
        {
            if (SceneManager.GetActiveScene().name == "Tutorial")
            {
                SceneManager.LoadScene("feedbackVitoriaT");
            }
            if (SceneManager.GetActiveScene().name == "Fase1")
            {
                SceneManager.LoadScene("feedbackVitoria1");
            }
            if (SceneManager.GetActiveScene().name == "Fase2")
            {
                SceneManager.LoadScene("feedbackVitoria2");
            }
            if (SceneManager.GetActiveScene().name == "Fase3")
            {
                SceneManager.LoadScene("feedbackVitoria3");
            }
            if (SceneManager.GetActiveScene().name == "Fase4")
            {
                SceneManager.LoadScene("feedbackVitoria4");
            }
            if (SceneManager.GetActiveScene().name == "Fase5")
            {
                SceneManager.LoadScene("FinalJogo");
            }
        }
        if(SceneManager.GetActiveScene().name == "FinalJogo")
        {//caso vença a ultima fase, é feito a cutscene final do jogo e fadeout para o crédito.
            hero.GetComponent<Hero>().speed = 8;
            hero.GetComponent<Hero>().anim.speed = 1;
            sword.GetComponent<Sword>().vel = 0;
            if (hero.GetComponent<Hero>().startFade == true)
            {
                StartCoroutine(FadeScene());
            }
            //

        }

    }

    //chamada para a proxima cena.
    public void NextScene ()
    { 
        SceneManager.LoadScene(nomeNext);
    }

    //chamada para a cena anterior.
    public void PreviousScene()
    {
        SceneManager.LoadScene(nomePrev);
    }

    //chamada para o menu principal.
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    //chamada para os créditos.
    public void Credito()
    {
        SceneManager.LoadScene("Credito");
    }
    
    //chamada para os controles.
    public void Controle()
    {
        SceneManager.LoadScene("Controle");
    }

    //chamada para fechar o jogo.
    public void QuitGame()
    {
        Application.Quit();
    }

    //IEnumerator para executar o fadeout para as cenas de crédito.
    IEnumerator FadeScene()
    {
        animate.SetBool("Fade", true);
        yield return new WaitUntil(() => black.color.a == 1);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene("Credito");
        //SceneManager.LoadScene(numCena);
    }


}
