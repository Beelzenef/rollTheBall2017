using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControllerJugador : MonoBehaviour {

    private Rigidbody cuerpoRigido;
    public float velocidad;

    float movHorizontal;
    float movVertical;

    int puntos;
    int puntosFinales;

    public Text marcador;
    public Text info;
    public Toggle toggleSonido;

    AudioSource sonidoItem;

    Vector3 movimiento;

	void Awake () {
        cuerpoRigido = GetComponent<Rigidbody>();

        puntosFinales = 8;

        movHorizontal = 0;
        movVertical = 0;

        sonidoItem = GetComponent<AudioSource>();
	}
	
	void FixedUpdate () {

        movVertical = Input.GetAxis("Vertical");
        movHorizontal = Input.GetAxis("Horizontal");

        movimiento = new Vector3(movHorizontal, 0, movVertical);

        cuerpoRigido.AddForce(movimiento * velocidad);

        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    void OnTriggerEnter(Collider c)
    {
        puntos++;
        actualizarMarcador();

        Destroy(c.gameObject);

        if (toggleSonido.isOn)
            sonidoItem.Play();

        if (puntos == puntosFinales) {
            info.text = "¡Has ganado!";
            marcador.text = string.Empty;
            velocidad = 0;
        }
    }

    void actualizarMarcador()
    {
        marcador.text = "Puntos " + puntos.ToString();
    }
}
