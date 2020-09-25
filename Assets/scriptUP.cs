using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Esta classe é responsável por definir o comportamento da Plataforma que se moverá apenas na Vertical.
/// </summary>
public class scriptUP : MonoBehaviour
{
    float count = 0;
    public float velocidade = 1;
    private Vector2 posInicial;
    public float altura = 6;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        count += velocidade * Time.deltaTime;

        float posY = Mathf.Sin(count) * altura;

        Vector2 posAtual = new Vector2(0, posY);

        transform.position = posInicial + posAtual;

        if (count >= 2 * Mathf.PI)
            count = 2 * Mathf.PI - count;
    }
}
