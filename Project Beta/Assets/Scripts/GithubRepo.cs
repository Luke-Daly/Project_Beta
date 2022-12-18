using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GithubRepo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChannel()
    {
        //Open the link when the Github Button is pressed on the home screen
        Application.OpenURL("https://github.com/Luke-Daly/Project_Beta");
    }
}
