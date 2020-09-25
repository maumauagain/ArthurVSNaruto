using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Esta classe é responsável por definir o comportamento da Plataforma que se moverá apenas na Horizontal.
/// </summary>
public class scriptRight : MonoBehaviour
{
    float count = 0;
    public float velocidade = 1.5f;
    private Vector2 posInicial;
    public float largura = 4;
    // Start is called before the first frame update
    void Start()
    {
        posInicial = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        count += velocidade * Time.deltaTime;

        float posX = Mathf.Cos(count) * largura;

        Vector2 posAtual = new Vector2(posX, 0);

        transform.position = posInicial + posAtual;

        if (count >= 2 * Mathf.PI)
            count = 2 * Mathf.PI - count;
    }
}
