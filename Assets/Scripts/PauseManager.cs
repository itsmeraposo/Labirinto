using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // <-- NOVO: Referência ao sistema de input

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public bool jogoPausado = false;

    void Update()
    {
        // DETECTA O ESC usando o NOVO Sistema de Input
        if (Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (jogoPausado)
                ContinuarJogo();
            else
                PausarJogo();
        }
    }

    public void PausarJogo()
    {
        jogoPausado = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinuarJogo()
    {
        jogoPausado = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void VoltarAoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void SairJogo()
    {
        Application.Quit();
        Debug.Log("Saindo...");
    }
}