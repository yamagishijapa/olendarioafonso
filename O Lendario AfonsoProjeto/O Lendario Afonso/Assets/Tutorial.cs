using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//Script para gerenciar os passos do tutorial.

public class Tutorial : MonoBehaviour
{
    public GameObject canvas;
    public Hero heroi;
    public Sword sword;
    public int passos = 0;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject text5;
    public GameObject text6;
    public GameObject text7;
    public GameObject text8;
    public GameObject text9;
    public GameObject text10;
    public GameObject text11;
    public GameObject text12;
    public GameObject text13;
    public GameObject text14;
    public GameObject text15;
    public GameObject text16;
    public GameObject text17;
    public GameObject text18;
    public GameObject text19;
    public GameObject text20;

    public GameObject barreira1;
    public GameObject barreira2;
    public GameObject barreira3;
    public GameObject barreira4;

    //define a velocidade de movimentação da espada para , travando ela na posição inicial.
    void Start()
    {
        sword.vel = 0;
    }

    //checa a posição do jogador no tutorial e altera algumas variáveis para permitir as ações de acordo com a etapa
    void Update()
    {
        //seta a variavel tutorial da espada como verdadeiro, impedindo a transição do estado de ataque e pulo (não permite a espada mudar de forma)
        //seta a espada na forma de ataque.
        if(passos <= 3)
        {
            sword.tutorialAtivo = true;
            sword.ataque = true;
        } else if (passos >= 4 && passos < 6)
        {
            //seta a variavel tutorial da espada como verdadeiro, impedindo a transição do estado de ataque e pulo.
            //seta a espada na forma de ataque.
            sword.tutorialAtivo = true;
            sword.ataque = true;
        }else if(passos > 6 && passos < 9)
        {
            //seta a variavel tutorial da espada como verdadeiro, impedindo a transição do estado de ataque e pulo.
            //seta a espada na forma de pulo.
            sword.tutorialAtivo = true;
            sword.ataque = false;
        }
        else if(passos >= 9)
        {
            //seta a variavel tutorial da espada como falso, permitindo a transição do estado de ataque e pulo.
            sword.tutorialAtivo = false;
        }

    }


    //faz a transição do texto das falas do Afonso e gerencia as variáveis, permitindo ou não movimentação, animação dos personagens e o controle do Afonso.
    //As etapas são passadas pelo clique do jogador no botão continue.
    public void NextStep()
    {
        //falas e personagem parado.
        if(passos == 0)
        {
            text1.SetActive(false);
            text3.SetActive(true);
            heroi.anim.speed = 0;
            passos++;
        } 
        else if (passos == 1)
        {
            //mais falas.
            text3.SetActive(false);
            text5.SetActive(true);
            passos++;
        }
        else if (passos == 2)
        {
            //mais falas.
            text5.SetActive(false);
            text7.SetActive(true);
            passos++;
        }
        else if (passos == 3)
        {
            //mais falas.
            //heroi começa a andar.
            text7.SetActive(false);
            text10.SetActive(true);
            heroi.anim.speed = 1;
            barreira1.SetActive(false);
            passos++;
        }
        else if (passos == 4)
        {
            //mais falas.
            //heroi para de andar.
            //espada muda para forma de ataque.
            text10.SetActive(false);
            text11.SetActive(true);
            heroi.anim.speed = 0;
            sword.animSword.SetBool("transVer", true);
            sword.animSword.SetBool("transAzul", false);
            passos++;
        }
        else if (passos == 5)
        {
            //mais falas.
            //espada começa a seguir o mouse.
            text11.SetActive(false);
            text12.SetActive(true);
            sword.vel = 15;
            passos++;
        }
        else if (passos == 6)
        {
            //mais falas.
            //espada muda para forma de pulo.
            text12.SetActive(false);
            text15.SetActive(true);

            sword.animSword.SetBool("transAzul", true);
            sword.animSword.SetBool("transVer", false);

            passos++;
        }
        else if (passos == 7)
        {
            //mais falas.
            text15.SetActive(false);
            text16.SetActive(true);
            passos++;
        }
        else if (passos == 8)
        {
            //mais falas.
            text16.SetActive(false);
            text20.SetActive(true);
            passos++;
        }
        else if (passos == 9)
        {
            //heroi volta a andar e canvas é desativado.
            //último passo do tutorial.
            heroi.anim.speed = 1;
            canvas.SetActive(false);
            barreira2.SetActive(false);
            passos++;
        }

    }
}
