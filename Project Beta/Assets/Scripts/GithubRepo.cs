using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GithubRepo : MonoBehaviour
{
    public void OpenChannel()
    {
        //Open the link when the Github Button is pressed on the home screen
        Application.OpenURL("https://github.com/Luke-Daly/Project_Beta");
    }
}
