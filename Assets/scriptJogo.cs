using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>Esta classe é responsável pelo gerenciamento das telas do Jogo.
/// </summary>
public class scriptJogo : MonoBehaviour
{
    /// <summary>Este método é usado para carregar a cena do jogo ao clicar no botão Iniciar.
    /// </summary>
    public void iniciar()
    {
        SceneManager.LoadScene((int)EScenes.Game);
    }

    /// <summary>Este método é usado para sair do jogo ao clicar no botão Sair
    /// Funciona apenas se o jogo estiver sendo executado pela build.
    /// </summary>
    public void sair()
    {
        Application.Quit();
    }

    /// <summary>Este método é usado para carregar a cena de instruções do jogo
    /// ao clicar no botão Instruções
    /// </summary>
    public void instrucoes()
    {
        SceneManager.LoadScene((int)EScenes.Instructions);
    }

    /// <summary>Este método é usado para carregar a cena do menu do jogo 
    /// ao clicar no botão Voltar, dentro da tela de Instruções.
    /// </summary>
    public void voltar()
    {
        SceneManager.LoadScene((int)EScenes.Start);
    }

}
