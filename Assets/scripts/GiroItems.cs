using UnityEngine;

public class GiroItems : MonoBehaviour {

    const float GRADOSGIRO = 30f;

    Vector3 rotacion;

	void Start () {
        rotacion = new Vector3(GRADOSGIRO, GRADOSGIRO, GRADOSGIRO);
	}
	
	void Update () {
        transform.Rotate(rotacion * Time.deltaTime);
	}
}
