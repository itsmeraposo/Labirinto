using UnityEngine;
using UnityEngine.UI;      // Para mexer com UI Text
using System.Collections;  // Para usar Coroutine (esconder a mensagem depois)

public class AlignmentTarget : MonoBehaviour
{
    public float targetAngle = 90f;
    public float tolerance = 5f;
    public Rigidbody portaTravada;

    [Header("Mensagem UI")]
    public GameObject mensagemUI; // Arraste um objeto Text/Canvas aqui

    private bool unlocked = false;

    void Update()
    {
        if (unlocked) return;

        float currentAngle = transform.localEulerAngles.y;
        float diff = Mathf.Abs(Mathf.DeltaAngle(currentAngle, targetAngle));

        if (diff <= tolerance)
        {
            Unlock();
        }
    }

    void Unlock()
    {
        unlocked = true;
        Debug.Log("Alvo alinhado! Porta destravada.");

        // 1. Mostra a mensagem na tela
        if (mensagemUI != null)
        {
            mensagemUI.SetActive(true);
            // Opcional: esconde a mensagem automaticamente depois de 3 segundos
            StartCoroutine(EsconderMensagem());
        }

        // 2. Destrava a porta (permite que ela se mova)
        if (portaTravada != null)
        {
            portaTravada.isKinematic = false;
        }
    }

    // Coroutine para esconder a mensagem após 3 segundos
    IEnumerator EsconderMensagem()
    {
        yield return new WaitForSeconds(3f);
        if (mensagemUI != null)
        {
            mensagemUI.SetActive(false);
        }
    }
}