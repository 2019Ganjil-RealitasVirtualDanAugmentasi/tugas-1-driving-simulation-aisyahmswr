using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{
    [SerializeField] private Texture2D[] textures = new Texture2D[3] ;
    [SerializeField] private Material body;
    // Start is called before the first frame update
    void Start()
    {
        body.mainTexture = textures[GameObject.FindObjectOfType<GameManager>().GetChoice()]; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
