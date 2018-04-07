
// is copied from script on unity forum - available at http://answers.unity3d.com/questions/39638/how-do-i-implement-the-kongregate-api.html
var isKongregate = false;
var userId = 0;
static var username = "None";
var gameAuthToken = "";

function OnGUI(){
GUI.Box(Rect(0,0,100,20), username);

}

function OnKongregateAPILoaded(userInfoString){
  // We now know we're on Kongregate
  isKongregate = true;
  Debug.Log("ON KONG");

  // Split the user info up into tokens
  var params = userInfoString.Split("|"[0]);
  userId = parseInt(params[0]);
  username = params[1];
  gameAuthToken = params[2];
}


function Awake()
    {
    // This game object needs to survive multiple levels
    DontDestroyOnLoad (this);

    // Begin the API loading process if it is available
Application.ExternalEval(
  "if(typeof(kongregateUnitySupport) != 'undefined'){" +
  " kongregateUnitySupport.initAPI('KongregateAPI', 'OnKongregateAPILoaded');" +
  "}"
);
    }