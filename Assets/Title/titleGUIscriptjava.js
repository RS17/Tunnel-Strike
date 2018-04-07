
function Update () {
		GetComponent.<GUITexture>().pixelInset.width = Screen.width;
		GetComponent.<GUITexture>().pixelInset.height = Screen.height;
		GetComponent.<GUITexture>().pixelInset.x = -Screen.width/2;
		GetComponent.<GUITexture>().pixelInset.y = -Screen.height/2;
}