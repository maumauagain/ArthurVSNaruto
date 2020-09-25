using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Esta classe é responsável por definir as pausas quando o usuário apertar ESC.
/// </summary>
public class scriptPausa : MonoBehaviour
{
    /// <summary>Este atriburo é responsável por definir se o jogo está pausado ou não.
    /// </summary>
    private bool pausado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PauseGame();
    }

    /// <summary>Este método é usado para pausar o game.
    /// </summary>
    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pausado)
            {
                Time.timeScale = 1;
                SceneManager.UnloadSceneAsync((int)EScenes.Start);
            }
            else
            {
                SceneManager.LoadSceneAsync((int)EScenes.Start, LoadSceneMode.Additive);
                Time.timeScale = 0;
            }

            pausado = !pausado;
        }
    }
}
