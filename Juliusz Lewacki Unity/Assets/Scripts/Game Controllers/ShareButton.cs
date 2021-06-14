using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ShareButton : MonoBehaviour {

private string shareMessage;

public void ClickShare() {
    shareMessage = "Zobaczcie jak daleko udało mi się zajść z Juliuszem Lewackim! Dołączcie do nas!: https://juliuszlewacki.pl";

    StartCoroutine(TakeScreenshotAndShare());
}

private IEnumerator TakeScreenshotAndShare()
{
	yield return new WaitForEndOfFrame();

	Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
	ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
	ss.Apply();

	string filePath = Path.Combine( Application.temporaryCachePath, "shared img.png" );
	File.WriteAllBytes( filePath, ss.EncodeToPNG() );

        // To avoid memory leaks
    Destroy( ss );

	new NativeShare().AddFile( filePath ).SetSubject( "Juliusz Lewacki" ).SetText(shareMessage).Share();

}
}
