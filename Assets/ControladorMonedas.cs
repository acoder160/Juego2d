using UnityEngine;
using TMPro; // para usar TextMeshPro

public class ControladorMonedas : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;
    private int contadorMonedas = 0;

    void Start()
    {
        ActualizarTexto();
    }

    public void AgregarMoneda()
    {
        contadorMonedas++;
        ActualizarTexto();
    }

    private void ActualizarTexto()
    {
        textoMonedas.text = "" + contadorMonedas;
    }
}
