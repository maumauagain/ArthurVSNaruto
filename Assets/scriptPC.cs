using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Esta classe é responsável por definir o comportamento do PC.
/// </summary>
public class scriptPC : MonoBehaviour
{
    /// <summary>Este atributo é responsável pelo componente do corpo rígido do PC.
    /// </summary>
    private Rigidbody2D rbd;
    /// <summary>Este atributo é responsável pelo componente de Animator do PC
    /// É utilizado apenas para conseguir setar o valor da variável "Parado".
    /// </summary>
    private Animator anim;
    /// <summary>Este atributo é responsável pela velocidade PC.
    /// </summary>
    public float velocidade = 5;
    /// <summary>Este atributo é responsável pela força do pulo do PC.
    /// </summary>
    public float pulo = 600;
    /// <summary>Este atributo é responsável por definir se o PC está no chão ou não.
    /// </summary>
    public bool chao = false;
    /// <summary>Este atributo é responsável por definir se o PC está virado para direita ou não.
    /// </summary>
    public bool dir = true;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Time.timeScale = 1;
        rbd.gravityScale = 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        chao = true;
        ///Define o componente que colidiu como pai para o PC ser filho
        ///da plataforma, para não ficar sambando enquanto estiver em cima.
        transform.parent = collision.transform;
        if (collision.gameObject.tag == "Jumper")
        {
            chao = false;
            rbd.AddForce(new Vector2(0, 900));
        }
        else if (collision.gameObject.tag == "PassagemSecreta")
            transform.position = new Vector2(45.44f, 2.14f);
        else if (collision.gameObject.tag == "PortaFinal")
            SceneManager.LoadSceneAsync((int)EScenes.Win);
        else if (collision.collider.gameObject.tag == "head")
            Destroy(transform.parent.gameObject);
        else if(collision.collider.gameObject.tag == "body")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene((int)EScenes.GameOver);
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        chao = false;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        var x = Input.GetAxis("Horizontal");

        SetParado(x);

        RotatePc(x);

        SetVelocity(x);

        Jump();

    }
    /// <summary>Este método é usado para setar o estado do PC para parado ou não parado.
    /// <param name="x">Usado para indicar se o PC está se movimentando horizontalmente</param>
    /// </summary>
    public void SetParado(float x)
    {
            anim.SetBool("Parado", x ==0);
    }

    /// <summary>Este método é usado para Rotacionar o PC para direita ou esquerda.
    /// <param name="x">Usado para indicar se o PC está se movimentando horizontalmente</param>
    /// </summary>
    public void RotatePc(float x)
    {
        if (dir && x < 0 || !dir && x > 0)
        {
            transform.Rotate(new Vector2(0, 180));
            dir = !dir;
        }
    }

    /// <summary>Este método é usado para setar a velocidade do PC de acordo com o valor de x.
    /// <param name="x">Usado para indicar se o PC está se movimentando horizontalmente</param>
    /// </summary>
    public void SetVelocity(float x)
    {
        rbd.velocity = new Vector2(x * velocidade, rbd.velocity.y);
    }

    /// <summary>Este método é usado para fazer o PC pular.
    /// </summary>
    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && chao)
        {
            chao = false;
            rbd.AddForce(new Vector2(0, pulo));
        }
    }

}
