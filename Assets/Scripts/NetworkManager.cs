using System;
using System.Collections;
using System.Text;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManager : MonoBehaviour
{

    [SerializeField] private string uri = "http://localhost:8080/sprites/2";
    
    private void Start() {
        // StartCoroutine(MakeRequests());
    }

    private IEnumerator MakeRequests() {
        // GET
        var getRequest = CreateRequest(uri);
        yield return getRequest.SendWebRequest();
        var deserializedGetData = JsonUtility.FromJson<SpriteDto>(getRequest.downloadHandler.text);
        
        AssetDatabase.CreateFolder("Assets/Artwork/Character/Resources", deserializedGetData.name);

        var n = 0;
        for (int i = 0; i < deserializedGetData.front.Length; i++)
        {
            var imageRequest = CreateRequest(uri);
            yield return imageRequest.SendWebRequest();
            var image = JsonUtility.FromJson<string>(getRequest.downloadHandler.text);
            SaveImage(image, deserializedGetData.name, n);
            n++;
        }
        
        for (int i = 0; i < deserializedGetData.back.Length; i++)
        {
            var imageRequest = CreateRequest(uri);
            yield return imageRequest.SendWebRequest();
            var image = JsonUtility.FromJson<string>(getRequest.downloadHandler.text);
            SaveImage(image, deserializedGetData.name, n);
            n++;
        }
        
        for (int i = 0; i < deserializedGetData.right.Length; i++)
        {
            var imageRequest = CreateRequest(uri);
            yield return imageRequest.SendWebRequest();
            var image = JsonUtility.FromJson<string>(getRequest.downloadHandler.text);
            SaveImage(image, deserializedGetData.name, n);
            n++;
        }

        // Trigger continuation of game flow
    }


    private static UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null) {
        var request = new UnityWebRequest(path, type.ToString());

        if (data != null) {
            var bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        }

        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        return request;
    }
    
    private static void SaveImage(string base64, string name, int n)
    {
        var fileNameResources = $"Assets/Artwork/Character/Resources/{name}/{name}_{n}.asset";

        byte[]  imageBytes = Convert.FromBase64String(base64);
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage( imageBytes );
        Sprite sprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        
        // Save the sprite (doesn't work on build)
        AssetDatabase.CreateAsset(sprite, fileNameResources);
    }
}

public enum RequestType {
    GET = 0,
    POST = 1,
    PUT = 2
}

public class SpriteDto {
    // Ensure no getters / setters
    // Typecase has to match exactly
    public int id;
    public string name;
    public string[] front;
    public string[] back;
    public string[] right;
}