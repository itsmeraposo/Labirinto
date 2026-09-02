using UnityEngine;
using UnityEngine.UI;      // Para mexer na UI
using UnityEngine.SceneManagement; // Para reiniciar o jogo

public class TapeteVitoria : MonoBehaviour
{
    [Header("UI da Vitória")]
    public GameObject telaVitoria; // Arraste o Painel (Panel) do Canvas aqui

    [Header("Configurações")]
    public string mensagem = "Você pisou no tapete mágico! Parabéns!";

    // Essa função é chamada automaticamente quando algo entra no Trigger
    void OnTriggerEnter(Collider other)
    {
        // Verifica se quem pisou foi o Jogador (pela Tag)
        if (other.CompareTag("Player"))
        {
            // 1. Mostra o menu de vitória
            if (telaVitoria != null)
            {
                telaVitoria.SetActive(true);
            }

            // 2. Congela o jogo (o jogador não pode mais se mexer)
            Time.timeScale = 0f;

            // 3. Libera o cursor do mouse para clicar nos botões
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // 4. Mostra uma mensagem no Console (opcional)
            Debug.Log(mensagem);
        }
    }

    // Método público para o botão "Reiniciar" (vamos conectar depois)
    public void ReiniciarJogo()
    {
        Time.timeScale = 1f; // Descongela o jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarrega a cena
    }

    // Método público para o botão "Sair"
    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saiu do jogo!");
    }
}