using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToGamePlay(int choice){
        SceneManager.LoadSceneAsync("SampleScene", LoadSceneMode.Single);
        GameObject.FindObjectOfType<GameManager>().Choice(choice);
    }

}
