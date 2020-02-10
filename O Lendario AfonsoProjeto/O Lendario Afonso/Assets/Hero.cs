using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Script responsável pelo comportamento e gerenciamento do herói que carrega o Afonso (espada).

public class Hero : MonoBehaviour
{
    //Declaração de variáveis
    public GameObject sword;
    public float jump;
    public float speed;
    public Rigidbody2D rgbd;
    public float jumpForce;
    private Vector3 movement;
    public bool alive;
    public bool final;
    public bool noChao;
    public Animator anim;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public bool startFade;

    // Definição de variáveis e relações com outros objetos
    void Start()
    {
        startFade = false;
        noChao = true;
        anim = this.GetComponent<Animator>();
        final = false;
        alive = true;
        jump = 0;
        sword = GameObject.FindGameObjectWithTag("Player");
        speed = 18;
        jumpForce = 1;
        rgbd = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
       
    }

    //checa através de uma circunferência posicionada abaixo do pesonagem (groundCheck) se o mesmo está contato com o chão (layer Ground), definindo status
    //de corrida (default) e queda do personagem (saiu em contato do chão sem performar um pulo).
    private void FixedUpdate()
    {
        //checagem de valores físicos, sem depender do frame-rate.
        noChao = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        if(sword.GetComponent<Sword>().isJumping == false)
        {
            //se a espada está com o status isJumping em falso (estado inicial da variável, que verifica se a ação do usuário resultou em pulo), 
            //o personagem somente anda para frente (jump = 0).
            rgbd.velocity = new Vector2(1 * speed, jump * jumpForce);
        }
        if(noChao == false && sword.GetComponent<Sword>().isJumping == false)
        {
            //se o personagem não está no chão e isJumping da espada é falso (usuário não performou um pulo), significa que o peronsagem está caindo,
            //logo a velocidade vetorial do personagem será para baixo (diagonal).
            rgbd.velocity = new Vector2(1 * speed, -15);
            anim.speed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //checa se o personagem colidiu com o chão (normalmente após um pulo ou queda de plataforma), ativando sua animação de corrida 
        //e setando o status de pulo da espada para falso.
        if(collision.gameObject.CompareTag("Ground"))
        {
            sword.GetComponent<Sword>().isJumping = false;
            anim.speed = 1;
        }
        else
        {
            //se o personagem não colidiu com o chão após o pulo ou queda, ele está caindo para a morte e a animação não volta a ocorrer.
            anim.speed = 0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //se o personagem colide com a parede, ele é arremessado para trás (valor pré-definido de -15).
        if (collision.gameObject.CompareTag("Wall"))
        {
            speed = -15;
            //Depois de ser arremessado para trás, após 0.8 segundos a velocidade é normalizada e o personagem segue em frente.
            Invoke("ForwardNormalized", 0.8f);

        }

        //em colisão com o inimigo, o personagem morre (status alive pra falso).
        if (collision.gameObject.CompareTag("Enemy"))
        {
            alive = false;
        }

        //em colisão com o limite da fase (queda), o personagem morre (status alive pra falso).
        if (collision.gameObject.CompareTag("Fall"))
        {
            alive = false;
        }

        //em colisão com espinhos, o personagem morre (status alive pra falso).
        if (collision.gameObject.CompareTag("Spike"))
        {
            alive = false;
        }

        //em colisão com o limite do final da fase, o personagem venceu a fase (final = true).
        if (collision.gameObject.CompareTag("Final"))
        {
            final = true;
        }

        //utilizada somente na cutscene final, quando o personagem entra na casa, atravessando a porta.
        //desativa o colisor e inicia o fade out para os créditos.
        if(collision.gameObject.CompareTag("Porta"))
        {
            collision.GetComponent<SpriteRenderer>().enabled = false;
            startFade = true;
        }
    }

    private void Forward()
    {
        //chamada de retorno ao statuso de corrida -- OBSOLETO - Substituído pelo ForwardNormalized().
        speed = 10f;
    }

    private void ForwardNormalized()
    {
        //chamada de retorno ao statuso de corrida.
        speed = 18;
    }

}
