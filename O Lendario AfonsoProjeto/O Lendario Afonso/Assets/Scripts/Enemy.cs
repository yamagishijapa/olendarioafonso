using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script resposnsável pela classe dos Inimigos. Movimentação padrão, movimentação por trigger, animação padrão.

public class Enemy : MonoBehaviour
{
    //Declaração de variáveis, definindo o tipo de inimigo e movimentação que terá no trigger.
    //Variaveis são modificadas pelos componentes da Unity.
    public Animator anim;
    private bool dirUp;
    private bool dirLerft;
    public bool vertical = false;
    public bool horizontal = false;
    public bool ataqueDown = false;
    public float limit = 10.0f;
    public float speed = 10f;
    public float speedDown;
    public float speedLeft;


    //Declara o animator do objeto.
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        //Movimentação padrão do personagem -- movimento de direita/esquerda 
        if (horizontal == true)
        {
            if (dirLerft)
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            else
                transform.Translate(-Vector2.left * speed * Time.deltaTime);

            if (transform.position.y >= limit)
            {
                dirLerft = false;
            }

            if (transform.position.y <= -(limit))
            {
                dirLerft = true;
            }
        }

        //Movimentação padrão do personagem -- movimento de cima/baixo
        if (vertical == true)
        {
            if (dirUp)
                transform.Translate(Vector2.up * speed * Time.deltaTime);
            else
                transform.Translate(-Vector2.up * speed * Time.deltaTime);

            if (transform.position.y >= limit)
            {
                dirUp = false;
            }

            if (transform.position.y <= -(limit))
            {
                dirUp = true;
            }
        }

    }

    //chamada pelo EnmeyTrigger.cs, quando o personagem entra na hitbox de trigger do inimigo.
    //dependendo das variáveis setadas no componente da Unity, a movimentação do Inimigo muda (vertical, horizontal ou diagonal).
    public void goDown()
    {
        
        if (speedDown != 0 && speedLeft != 0)
        {
            //movimentação diagonal.
            transform.Translate(new Vector2(1 * speedLeft, 1 * -speedDown) * Time.deltaTime);
        }
        else if (speedDown != 0)
        {
            //movimentação horizontal.
            transform.Translate(Vector2.down * speedDown * Time.deltaTime);
        } else if (speedLeft != 0)
        {
            //movimentação vertical.
            transform.Translate(Vector2.left * speedLeft * Time.deltaTime);
        }
    }

}
