using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Script responsável pela classe da Espada (Afonso). 
public class Sword : MonoBehaviour
{
    //declaração de variáveis e definição de alguns valores.
    public GameObject target;
    public float vel;
    public bool isJumping;
    public Vector3 mousePos;
    public Vector3 eulerAngles;
    public Vector2 direction;
    public Rigidbody2D rb;
    public Quaternion rotation;
    public bool ataque;
    public Animator animSword;
    public string nomeAnimacao;
    public bool tutorialAtivo;

    public float minRotation = -5;
    public float maxRotation = 185;

    //definição de alguns estados, valores e relações com objetos no início de cada fase.
    void Start()
    {
        tutorialAtivo = false;
        ataque = true;
        isJumping = false;
        target = GameObject.FindGameObjectWithTag("Hero");
        rotation = this.GetComponent<Transform>().rotation;
        animSword = this.GetComponent<Animator>();
        vel = 15f;
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //checa se o botão esquerdo do mouse é clicado. 
        if (Input.GetMouseButtonDown(0))
        {
            //se o tutorial não esta ativado (no tutorial, o status da espada é limitado de acordo com a etapa do tutorial),
            //checa se a espada esta no status de ataque. Se sim, reproduz a animação de troca da espada pra azul e seta o 
            //status de ataque para falso.
            if (ataque == true && tutorialAtivo == false)
            {
                animSword.SetBool("transVer", false);
                ataque = false;
                animSword.SetBool("transAzul", true);

            } else if (ataque == false && tutorialAtivo == false)
            {
                //se o tutorial não esta ativado (no tutorial, o status da espada é limitado de acordo com a etapa do tutorial),
                //e a espada NÃO esta no status de ataque, reproduz a animação de troca da espada pra vermelha e seta o 
                //status de ataque para verdadeiro.
                animSword.SetBool("transAzul", false);
                ataque = true;
                animSword.SetBool("transVer", true);
            }
        }

        //checa para qual direção a espada deve se movimentar (direction) e o angulo de rotação em que ela vai rotacionar.
        transform.position = (new Vector3(target.GetComponent<Transform>().position.x + 0.45f, target.GetComponent<Transform>().position.y - 0.25f,
            target.GetComponent<Transform>().position.z));
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, vel * Time.deltaTime);

        //define o limite de rotação que a espada pode girar.
        Vector3 euler = transform.eulerAngles;
        if (euler.z > 220) euler.z = euler.z - 360;
        euler.z = Mathf.Clamp(euler.z, minRotation, maxRotation);
        transform.eulerAngles = euler;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && ataque == true)
        {
            //se a espada colide com um objeto Inimigo em seu estado de ataque, desabilita todas as propriedades/funções do inimigo que poderiam afetar
            //o jogador/o fluxo do jogo.
            collision.gameObject.GetComponent<Enemy>().speed = 0;
            collision.gameObject.GetComponent<Enemy>().speedDown = 0;
            collision.gameObject.GetComponent<Enemy>().speedLeft = 0;
            collision.gameObject.GetComponent<Animator>().SetBool("death", true);
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;            
        }

        if (collision.gameObject.CompareTag("Ground") && target.GetComponent<Hero>().noChao == true && ataque == false)
        {
            //se a espada colide com o chão, o personagem está no chão (noChão é verdadeiro) e o status de ataque espada está como falso, seta o 
            //estado de pulo da espada para verdadeiro (sempre que o personagem sai do chão performando uma ação que resultou em pulo), acrescenta a 
            //velocidade do rigid body do personagem para resultar em um pulo e para a animação de caminhada do personagem.
            isJumping = true;
            target.GetComponent<Hero>().rgbd.velocity = new Vector2(1 * target.GetComponent<Hero>().speed, 15);
            target.GetComponent<Hero>().anim.speed = 0;

        }

        if (collision.gameObject.CompareTag("Wall") && target.GetComponent<Hero>().noChao == true)
        {
            //se a espada colide com a parede, o personagem é arremessado para trás (valor pré-definido de -15).
            target.GetComponent<Hero>().speed = -15;
            Invoke("ForwardNormalized", 0.5f);

        }
    }

    private void Forward()
    {
        //chamada de retorno ao statuso de corrida -- OBSOLETO - Substituído pelo ForwardNormalized().
        target.GetComponent<Hero>().speed = 10f;
    }

    private void ForwardNormalized()
    {
        //chamada de retorno ao statuso de corrida.
        target.GetComponent<Hero>().speed = 18f;
    }
}
