using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba1 : MonoBehaviour
{
    public bool gameOver;
    public bool hasBeenClick;

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
        points = 0;
        hasBeenClick = false;
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
            hasBeenClick = true;
        }
    }

}
