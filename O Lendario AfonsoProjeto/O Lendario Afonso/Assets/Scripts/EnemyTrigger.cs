using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script responsável pela detecção de colisão na hitbox de trigger dos inimigos.
//A hitbox de trigger foi setada não diretamente no Objeto dos Inimigos, mas sim em um Objeto Pai.
public class EnemyTrigger : MonoBehaviour
{
    //Declarãção de variáveis para o colisor funcionar corretamente e tratar a ação no trigger.
    private Rigidbody2D rgbd;
    public bool triggerOn;
    public GameObject enemyChild;
    
    // Seta o trigger como false e checa o nome e quantidade de filhos do objeto pai.
    void Start()
    {
        triggerOn = false;
        rgbd = this.GetComponent<Rigidbody2D>();
        Debug.Log(enemyChild.name);
        Debug.Log(transform.childCount);
    }

    // Checa se o trigger é verdadeiro. 
    void Update()
    {
        //Se sim, chama a ação de movimentação do objeto Inimigo.
        if(this.triggerOn == true)
        {
            enemyChild.GetComponent<Enemy>().goDown();
        }
        //Se não houverem mais Inimigos como filho, seta o trigger para falso.
        if(this.transform.childCount <= 0)
        {
            triggerOn = false;
        }
    }

    //checa por Trigger por entrada do herói na hitbox. Quando ocorre, seta a variável triggerOn para true.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Hero"))
        {
            Debug.Log("Trigou");
            triggerOn = true;
        }
        
    }
}
