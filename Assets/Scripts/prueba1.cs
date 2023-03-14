using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class prueba1 : MonoBehaviour
{
    public bool gameOver;
    public bool hasBeenClick;
    public TextMeshProUGUI vidas;
    private float randSecs;
    public AudioClip gameOverSound;
    public AudioClip sonidos_good;
    public AudioClip sonidos_mal;
    public AudioSource musica;
    private int lives = 3;
    public Material mat;
    public int points;
    private float minX = -8;
    private float maxX = 8;
    private float minY = -6;
    private float maxY = 6;
    private float minZ = -3;
    private float maxZ = 7;
    public GameObject gameOverPanel;
    public TextMeshProUGUI puntos;
    

    void Start()
    {
        gameOverPanel.SetActive(false);
        lives = 3;
        points = 0;
        vidas.text = $"Lives {lives}";
        puntos.text = $"Score : {points}";
        points = 0;
        hasBeenClick = false;
        musica = GetComponent<AudioSource>();
        mat = GetComponent<MeshRenderer>().material;
        StartCoroutine(GenerateNextRandomPos());
    }

    //Funcion que se encarga de generar un Vector aleatorio para luego usarlo para transladar la esfera a una posición aleatoria
    public Vector3 GenerateRandomPos()
    {
         return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }


    //Corrutina que se encarga mantener el juego funcionando mientras no se de el caso de Game Over
    private IEnumerator GenerateNextRandomPos()
    {
        while (!gameOver)
        {
            randSecs = Random.Range(1.0f, 2.5f);
            yield return new WaitForSeconds(randSecs);
            if(hasBeenClick == false)
            {
                lives--;
                vidas.text = $"Lives {lives}";
                musica.PlayOneShot(sonidos_mal, 20);
                if(lives == 0)
                {
                    gameOver = true;
                    gameOverPanel.SetActive(true);
                    mat.color = Color.red;
                    musica.PlayOneShot(gameOverSound, 20);               
                    break;
                }
            }
            
            transform.position = GenerateRandomPos();
            mat.color = Color.magenta;           
            hasBeenClick = false;          
        }
        
    }
    private void OnMouseDown ()
    {
        //Condicion que comprueba si hemos clickado en la pelota, si hemos clickado le cambia el color, suma puntos, reproduce un sonido y cambia la condición has been click para no perder una vida dado que hemos acertado
        if (!hasBeenClick)
        {
            mat.color = Color.green;
            points++;
            puntos.text = $"Score : {points}";
            musica.PlayOneShot(sonidos_good, 20);
            hasBeenClick = true;
        }
        
    }

    //Funcion que se encarga de Reiniciar la escena
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
