using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>Esta classe é responsável por definir o som de fundo do jogo.
/// </summary>
public class scriptAudio : MonoBehaviour
{
    /// <summary>Este atributo é responsável pelo Audio do componente.
    /// </summary>
    private AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        som = GetComponent<AudioSource>();
        som.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
