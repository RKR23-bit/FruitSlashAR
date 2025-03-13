using UnityEngine;

public class GameManager : MonoBehaviour {
    void Start() {
        string url = Application.absoluteURL;
        if (url.Contains("location=") && url.Contains("table=")) {
            string location = url.Split("location=")[1].Split('&')[0];
            string table = url.Split("table=")[1].Split('&')[0];
            Debug.Log($"Playing at: {location}, Table {table}");
        }
    }
}