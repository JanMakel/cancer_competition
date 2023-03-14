using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class prueba1 : MonoBehaviour
{
    public bool gameOver;
    public bool hasBeenClick;
    public TextMeshProUGUI vidas;

    public AudioClip sonidos;
    public AudioSource musica;
    private int lives = 3;
    public Material mat;
    public int points;
    private float minX = -10;
    private float maxX = 10;
    private float minY = -6;
    private float maxY = 6;
    private float minZ = -7;
    private float maxZ = 7;
    void Start()
    {
        lives = 3;
        vidas.text = $"Lives {lives}";
        points = 0;
        hasBeenClick = false;
        musica = GetComponent<AudioSource>();
    mat = GetComponent<MeshRenderer>().material;
        StartCoroutine(GenerateNextRandomPos());
    }
    public Vector3 GenerateRandomPos()
    {
         return new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    private IEnumerator GenerateNextRandomPos()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(2);
            if(hasBeenClick == false)
            {
                lives--;
                vidas.text = $"Lives {lives}";
                if(lives == 0)
                {
                    gameOver = true;
                    break;
                }
            }
            
            transform.position = GenerateRandomPos();
            mat.color = Color.blue;
            hasBeenClick = false;
            
        }
        
    }
    private void OnMouseDown ()
    {
        if (!hasBeenClick)
        {
            mat.color = Color.green;
            points++;
            musica.PlayOneShot(sonidos, 100);
            hasBeenClick = true;
        }
        
    }

}
