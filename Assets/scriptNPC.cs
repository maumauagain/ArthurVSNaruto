using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Esta classe é responsável por definir o comportamento do NPC.
/// </summary>
public class scriptNPC : MonoBehaviour
{
    /// <summary>Este atributo é responsável pelo componente do corpo rígido do NPC.
    /// </summary>
    private Rigidbody2D rbd;
    /// <summary>Este atributo é responsável pela velocidade NPC.
    /// </summary>
    public float velocidade = 4;
    // Start is called before the first frame update
    void Start()
    {
        rbd = GetComponent<Rigidbody2D>();       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "PortaFinal" ||
            collision.gameObject.tag == "Pedra")
        {
            transform.Rotate(new Vector2(0, 180));
            velocidade = -velocidade;
        }
    }

    // Update is called once per frame
    void Update()
    {
        rbd.velocity = new Vector2(velocidade, 0);
    }
}
