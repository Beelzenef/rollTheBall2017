using UnityEngine;

public class ControllerCamara : MonoBehaviour {

    public GameObject jugador;
    private Vector3 posicionRelativa;

	void Start () {
        posicionRelativa = transform.position - jugador.transform.position;
	}
	
	void LateUpdate () {
        transform.position = jugador.transform.position + posicionRelativa;
	}
}
