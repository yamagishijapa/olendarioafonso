using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script de Movimentação do Afonso na tela de morte. 

public class UpDownDead : MonoBehaviour
{
    private bool dirUp = true;
    public float speed = 20.0f;
    public float limit = 10.0f;
    public float offsetDown;
    public float offsetUp;

    void Start()
    {

    }

    //alterana a movimentação da espada para cima e para baixo
    void Update()
    {
        if (dirUp)
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.up * speed * Time.deltaTime);

        if (transform.position.y >= (limit+ offsetUp))
        {
            dirUp = false;
        }

        if (transform.position.y <= -(limit + offsetDown))
        {
            dirUp = true;
        }
    }
}