using UnityEngine;
using System.Collections;

public class TrampolimRede : MonoBehaviour
{
    [Header("FORÇA DO EJEÇÃO")]
    [Tooltip("Força aplicada no jogador para arremessá-lo para cima. Massa do player influencia.")]
    public float forcaImpulso = 35f;

    [Header("CONFIGURAÇÕES")]
    [Tooltip("Tag que o seu Jogador possui")]
    public string tagJogador = "Player";
    
    [Tooltip("Tempo de espera para poder usar a rede novamente (evita bugs de duplo clique)")]
    public float tempoRecarga = 0.3f;

    // Controle interno para não ficar ativando várias vezes seguidas
    private bool podeEjetar = true;

    // Detecta quando o jogador ENCOSTA na rede
    void OnCollisionEnter(Collision collision)
    {
        // Se estiver em recarga, ou se não for o jogador, ignora
        if (!podeEjetar) return;
        if (!collision.gameObject.CompareTag(tagJogador)) return;

        // Pega o Rigidbody do jogador
        Rigidbody rbJogador = collision.rigidbody;
        if (rbJogador == null) return;

        // ZERA a velocidade vertical antes de aplicar o impulso?
        // (Opcional: comente essa linha se quiser somar com a queda)
        // rbJogador.velocity = new Vector3(rbJogador.velocity.x, 0, rbJogador.velocity.z);

        // Aplica o IMPULSO para CIMA (é instantâneo, tipo um "estilingue")
        rbJogador.AddForce(Vector3.up * forcaImpulso, ForceMode.Impulse);

        // Inicia o cooldown para não repetir o pulo enquanto estiver subindo
        StartCoroutine(Cooldown());
    }

    // Corrotina que espera um tempinho antes de liberar a rede novamente
    IEnumerator Cooldown()
    {
        podeEjetar = false;
        yield return new WaitForSeconds(tempoRecarga);
        podeEjetar = true;
    }

    // (Opcional) Se quiser um efeito visual de "achatamento" da rede ao ser pisada, 
    // você pode adicionar um Animation ou mexer no Scale aqui. 
}