using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{

    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

void CheckToPlayTheMusic() {
    if (GamePreferences.GetMusicState () == 1) {
        MusicController.instance.PlayMusic (true);
        musicBtn.image.sprite = musicIcons [1];
    } else {
        MusicController.instance.PlayMusic (false);
        musicBtn.image.sprite = musicIcons [0];            
    }
}

public void StartGame() {
    GameManager.instance.gameStartedFromMainMenu = true;
    Application.LoadLevel ("Gameplay");
}

public void HighscoreMenu() {
    Application.LoadLevel ("HighscoreScene");
}

public void privacyLink() {
    Application.OpenURL("https://juliuszlewacki.pl/polityka-prywatnosci.html");
}

public void termsLink() {
    Application.OpenURL("https://juliuszlewacki.pl/zasady-korzystania.html");
}

public void QuitGame() {
    Application.Quit ();
}

public void MusicButton() {
    if (GamePreferences.GetMusicState () == 0) {
        GamePreferences.SetMusicState (1);
        MusicController.instance.PlayMusic (true);
        musicBtn.image.sprite = musicIcons [1];
    } else if (GamePreferences.GetMusicState () == 1) {
        GamePreferences.SetMusicState (0);
        MusicController.instance.PlayMusic (false);
        musicBtn.image.sprite = musicIcons [0];            
    }
}

}
