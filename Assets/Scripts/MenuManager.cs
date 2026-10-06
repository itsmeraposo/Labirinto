using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar cenas

public class MenuManager : MonoBehaviour
{
    [Header("Nomes das cenas (iguais aos arquivos .unity)")]
    public string cenaFase1 = "Labirinto";
    public string cenaFase2 = "Enemies";

    // Botão "Iniciar Jogo"
    public void IniciarJogo()
    {
        SceneManager.LoadScene(cenaFase1);
    }

    // Botão "Fase 2"
    public void IniciarFase2()
    {
        SceneManager.LoadScene(cenaFase2);
    }

    // Opcional: um botão qualquer pode carregar uma cena digitando o nome
    // no campo do OnClick (aceita um parâmetro string).
    public void CarregarCena(string nomeDaCena)
    {
        SceneManager.LoadScene(nomeDaCena);
    }

    // Botão "Sair"
    public void SairJogo()
    {
        // Sai do jogo (funciona no build, não no Editor)
        Application.Quit();

        // Mensagem para debug (só aparece no Editor)
        Debug.Log("Saindo do jogo...");
    }
}
