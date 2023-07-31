using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class ControlJugador : MonoBehaviour
{
    const float LIMO = -11.26f, LIME = 11.07f;
    public GameObject balaPrefab;
    GameObject balaActual;
    public GameObject espada;
    public bool arriba = false, diagonalDerecha = false, diagonalIzquierda = false, disparando = false;
    const float _tiempoRetrasoBalas = 0.1f;
    float timestamp;
    public float velocidadMovimientoTirador = 5f, velocidadMovimientoCaballero = 3f, fuerzaSalto = 6.5f;
    private float velocidadMovimientoTiradorInicial, velocidadMovimientoCaballeroInicial, fuerzaSaltoInicial;
    const float velocidadBala = 7f;
    public new Transform transform;
    public Animator animator;
    bool tocandoSuelo = false, saltando = false;


    public AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        if (gameObject.tag == "Player2")
        {
            Instantiate(espada, transform.position, Quaternion.identity);
            espada = GameObject.FindWithTag("Espada");
            espada.GetComponent<Transform>().parent = transform;
            espada.GetComponent<SpriteRenderer>().flipX = false;
            espada.GetComponent<Transform>().localPosition = new Vector3(0.6f, -0.15f);

        }

        velocidadMovimientoCaballeroInicial = velocidadMovimientoCaballero;
        velocidadMovimientoTiradorInicial = velocidadMovimientoTirador;
        fuerzaSaltoInicial = fuerzaSalto;

    }


    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, LIMO, LIME), gameObject.transform.position.y);
            if (!Input.anyKey)
            {
                animator.Rebind();
                arriba = false;
                diagonalDerecha = false;
                diagonalIzquierda = false;
                disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
            }
            else if (Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Vertical") > 0 || (CrossPlatformInputManager.GetAxis("Horizontal") < 0 && CrossPlatformInputManager.GetAxis("Vertical") > 0.2f))
            {
                diagonalIzquierda = true;
                arriba = false;
                diagonalDerecha = false;
                disparando = (Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump")) ? true : false;

                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                if (!disparando)
                    animator.Play("TiradorEstaticoDiagonal");

                if (Time.time >= timestamp && disparando)
                {
                    disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                    if (disparando)
                        animator.Play("TiradorDisparandoDiagonal");
                    audioSource.Play();
                    balaActual = Instantiate(balaPrefab, new Vector3(gameObject.transform.position.x - 0.5f, transform.position.y + 0.5f), Quaternion.identity);
                    balaActual.GetComponent<MovimientoRectilineoUniformementeVariado>().Shoot(velocidadBala, 0f);


                    timestamp = Time.time + _tiempoRetrasoBalas;
                }
            }
            else if (Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Vertical") > 0 || (CrossPlatformInputManager.GetAxis("Horizontal") > 0 && CrossPlatformInputManager.GetAxis("Vertical") > 0.2f))
            {
                diagonalDerecha = true;
                arriba = false;
                diagonalIzquierda = false;
                disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                if (!disparando)
                    animator.Play("TiradorEstaticoDiagonal");

                if (Time.time >= timestamp && Input.GetAxis("Jump") > 0 || (Time.time >= timestamp && CrossPlatformInputManager.GetButton("Jump")))
                {
                    disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                    if (disparando)
                        animator.Play("TiradorDisparandoDiagonal");
                    balaActual = Instantiate(balaPrefab, new Vector3(gameObject.transform.position.x + 0.5f, transform.position.y + 0.5f), Quaternion.identity);
                    balaActual.GetComponent<MovimientoRectilineoUniformementeVariado>().Shoot(velocidadBala, 0f);

                    audioSource.Play();
                    timestamp = Time.time + _tiempoRetrasoBalas;


                }

            }

            else if (Time.time >= timestamp && Input.GetAxis("Horizontal") > 0 && Input.GetAxis("Jump") > 0 || (Time.time >= timestamp && CrossPlatformInputManager.GetAxis("Horizontal") > 0 && CrossPlatformInputManager.GetButton("Jump")))
            {
                disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                balaActual = Instantiate(balaPrefab, new Vector3(gameObject.transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
                balaActual.GetComponent<MovimientoRectilineoUniformementeVariado>().Shoot(velocidadBala, 0f);

                if (disparando)
                    animator.Play("TiradorCorriendoDisparando");
                audioSource.Play();
                timestamp = Time.time + _tiempoRetrasoBalas;
            }
            else if (Time.time >= timestamp && Input.GetAxis("Horizontal") < 0 && Input.GetAxis("Jump") > 0 || (Time.time >= timestamp && CrossPlatformInputManager.GetAxis("Horizontal") < 0 && CrossPlatformInputManager.GetButton("Jump")))
            {
                disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                balaActual = Instantiate(balaPrefab, new Vector3(gameObject.transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
                balaActual.GetComponent<MovimientoRectilineoUniformementeVariado>().Shoot(-velocidadBala, 0f);

                if (disparando)
                    animator.Play("TiradorCorriendoDisparando");
                audioSource.Play();
                timestamp = Time.time + _tiempoRetrasoBalas;
            }
            else
            {
                if (Input.GetAxis("Vertical") > 0 || CrossPlatformInputManager.GetAxis("Vertical") > 0)
                {
                    diagonalDerecha = false;
                    diagonalIzquierda = false;
                    disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                    if (!disparando)
                        animator.Play("TiradorEstaticoArriba");
                    if (Time.time >= timestamp && Input.GetAxis("Jump") > 0 || Time.time >= timestamp && CrossPlatformInputManager.GetButton("Jump"))
                    {
                        disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                        arriba = true;
                        if (disparando)
                            animator.Play("TiradorDisparandoArriba");
                        audioSource.Play();
                        balaActual = Instantiate(balaPrefab, new Vector3(gameObject.transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
                        balaActual.GetComponent<MovimientoRectilineoUniformementeVariado>().Shoot(velocidadBala, 0f);

                        timestamp = Time.time + _tiempoRetrasoBalas;
                    }
                }
                else
                {
                    if (Input.GetAxis("Horizontal") > 0 || CrossPlatformInputManager.GetAxis("Horizontal") > 0)
                    {
                        arriba = false;
                        diagonalDerecha = false;
                        diagonalIzquierda = false;
                        disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                        gameObject.GetComponent<SpriteRenderer>().flipX = false;
                        transform.Translate(new Vector3(Input.GetAxis("Horizontal") > 0 ? Input.GetAxis("Horizontal") : CrossPlatformInputManager.GetAxis("Horizontal"), 0) * Time.deltaTime * velocidadMovimientoTirador);
                        if (!disparando)
                            animator.Play("TiradorCorriendo");


                    }
                    else if (Input.GetAxis("Horizontal") < 0 || CrossPlatformInputManager.GetAxis("Horizontal") < 0)
                    {
                        arriba = false;
                        diagonalDerecha = false;
                        diagonalIzquierda = false;
                        disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                        gameObject.GetComponent<SpriteRenderer>().flipX = true;
                        transform.Translate(new Vector3(Input.GetAxis("Horizontal") < 0 ? Input.GetAxis("Horizontal") : CrossPlatformInputManager.GetAxis("Horizontal"), 0) * Time.deltaTime * velocidadMovimientoTirador);
                        if (!disparando)
                            animator.Play("TiradorCorriendo");

                    }
                    else if (Time.time >= timestamp && Input.GetAxis("Jump") > 0 && gameObject.GetComponent<SpriteRenderer>().flipX || Time.time >= timestamp && CrossPlatformInputManager.GetButtonDown("Jump") && gameObject.GetComponent<SpriteRenderer>().flipX)
                    {
                        disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                        balaActual = Instantiate(balaPrefab, new Vector3(gameObject.transform.position.x - 0.5f, transform.position.y), Quaternion.identity);
                        balaActual.GetComponent<MovimientoRectilineoUniformementeVariado>().Shoot(-velocidadBala, 0f);

                        animator.Play("TiradorEstaticoDisparando");
                        audioSource.Play();
                        timestamp = Time.time + _tiempoRetrasoBalas;
                    }
                    else if (Time.time >= timestamp && Input.GetAxis("Jump") > 0 && !gameObject.GetComponent<SpriteRenderer>().flipX || (Time.time >= timestamp && CrossPlatformInputManager.GetButton("Jump") && !gameObject.GetComponent<SpriteRenderer>().flipX))
                    {
                        disparando = Input.GetAxis("Jump") > 0 || CrossPlatformInputManager.GetButtonDown("Jump") ? true : false;
                        balaActual = Instantiate(balaPrefab, new Vector3(gameObject.transform.position.x + 0.5f, transform.position.y), Quaternion.identity);
                        balaActual.GetComponent<MovimientoRectilineoUniformementeVariado>().Shoot(velocidadBala, 0f);

                        audioSource.Play();
                        if (!disparando)
                            animator.Play("TiradorEstaticoDisparando");

                        timestamp = Time.time + _tiempoRetrasoBalas;
                    }
                }
            }
        }
        else if (gameObject.tag == "Player2")
        {
            if (Input.GetKeyDown(KeyCode.Space) || CrossPlatformInputManager.GetButtonDown("Jump"))
            {

                saltando = true;
            }
            if (!Input.anyKey)
            {
                animator.Rebind();
            }
            if (Input.GetAxis("Horizontal") > 0 || CrossPlatformInputManager.GetAxis("Horizontal") > 0)
            {
                espada.GetComponent<Transform>().localPosition = new Vector3(0.6f, -0.15f);

                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                espada.GetComponent<SpriteRenderer>().flipX = false;
                transform.Translate(new Vector3(Input.GetAxis("Horizontal") > 0 ? Input.GetAxis("Horizontal") : CrossPlatformInputManager.GetAxis("Horizontal"), 0) * Time.deltaTime * velocidadMovimientoCaballero);
                animator.Play("CaballeroCorriendo");
            }
            if (Input.GetAxis("Horizontal") < 0 || CrossPlatformInputManager.GetAxis("Horizontal") < 0)
            {
                espada.GetComponent<Transform>().localPosition = new Vector3(-0.6f, -0.15f);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                espada.transform.GetComponent<SpriteRenderer>().flipX = true;
                transform.Translate(new Vector3(Input.GetAxis("Horizontal") < 0 ? Input.GetAxis("Horizontal") : CrossPlatformInputManager.GetAxis("Horizontal"), 0) * Time.deltaTime * velocidadMovimientoCaballero);
                animator.Play("CaballeroCorriendo");
            }

            gameObject.transform.position = new Vector3(Mathf.Clamp(gameObject.transform.position.x, LIMO, LIME), gameObject.transform.position.y);

            espada.GetComponent<Transform>().localPosition = new Vector3(gameObject.GetComponent<SpriteRenderer>().flipX != true ? 0.6f : -0.6f, -0.15f);

        }

    }

    private void FixedUpdate()
    {
        if (saltando && gameObject.transform.position.y <= -1.06)
        {

            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
            saltando = false;
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Player")
        {
            if (other.gameObject.tag == "Sapo" || other.gameObject.tag == "Rana" || other.gameObject.tag == "Grunt"
           || other.gameObject.tag == "Poke Feo" || other.gameObject.tag == "Muercielago" || other.gameObject.tag == "Ojo"
           || other.gameObject.tag == "Demonio" || other.gameObject.tag == "Fantasma" || other.gameObject.tag == "Murcielago Demoniaco"
           || other.gameObject.tag == "Rata" || other.gameObject.tag == "Slime" || other.gameObject.tag == "Slime Babosa" || other.gameObject.tag == "Esqueleto"
           || other.gameObject.tag == "Bola")
            {

                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().jugadorGolpeado = true;
                gameObject.GetComponent<Animator>().Play("TiradorGolpeado");
            }
        }
        else if (gameObject.tag == "Player2")
        {
            if (other.gameObject.tag == "Sapo" || other.gameObject.tag == "Rana" || other.gameObject.tag == "Grunt"
           || other.gameObject.tag == "Poke Feo" || other.gameObject.tag == "Muercielago" || other.gameObject.tag == "Ojo"
           || other.gameObject.tag == "Demonio" || other.gameObject.tag == "Fantasma" || other.gameObject.tag == "Murcielago Demoniaco"
           || other.gameObject.tag == "Rata" || other.gameObject.tag == "Slime" || other.gameObject.tag == "Slime Babosa" || other.gameObject.tag == "Esqueleto"
           || other.gameObject.tag == "Bola")
            {

                GameObject.Find("ControlJuego").GetComponent<ControlJuego>().jugadorGolpeado = true;
                gameObject.GetComponent<Animator>().Play("CaballeroGolpeado");
            }
        }
    }

    public void RestaurarValoresMovimientos()
    {
        velocidadMovimientoCaballero = velocidadMovimientoCaballeroInicial;
        velocidadMovimientoTirador = velocidadMovimientoTiradorInicial;
        fuerzaSalto = fuerzaSaltoInicial;
    }


}
