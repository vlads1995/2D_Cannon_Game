using System.Collections;
using UnityEngine;
using Facebook.Unity;

public class FacebookScript : MonoBehaviour
{
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else
                {
                    Debug.LogError("Cant initialize");
                }
            },
            isGameShown =>
            {
                if (!isGameShown)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }

            });
        }
        else
        {
            FB.ActivateApp();
        }

    }

    public void FacebookShare()
    {
        
        FB.ShareLink
        (            
        contentURL: new System.Uri("https://github.com/vlads1995/Cannon_Game"), 
        contentTitle: "Check My Score!",
        contentDescription: "Score: " + UIManager.Score                   
         );

    }    
   
}
