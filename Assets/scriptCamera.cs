using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Esta classe é responsável por definir o comportamento da Camera do Jogo.
/// </summary>
public class scriptCamera : MonoBehaviour
{
    /// <summary>Este atributo é responsável pelo GameObject do PC.
    /// </summary>
    public GameObject pc;
    /// <summary>Este atributo é responsável pelo offset da câmera no eixo Y em relação ao PC.
    /// </summary>
    public float offset_Y = -1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ///Vai definir a posição da camera para a mesma posição do PC, com um offset de altura
        var pos = new Vector3(pc.transform.position.x, pc.transform.position.y + offset_Y, -10);
        this.transform.position = pos;
    }
}
