using UnityEngine;
using UnityEngine.SceneManagement; // Para carregar cenas

public class MenuManager : MonoBehaviour
{
    // Método chamado pelo botão "Iniciar Jogo"
    public void IniciarJogo()
    {
        // Carrega a cena do jogo (substitua "Fase1" pelo nome exato da sua cena)
        SceneManager.LoadScene("Labirinto");
    }

    // Método chamado pelo botão "Sair"
    public void SairJogo()
    {
        // Sai do jogo (funciona no build, não no Editor)
        Application.Quit();
        
        // Mensagem para debug (só aparece no Editor)
        Debug.Log("Saindo do jogo...");
    }
}