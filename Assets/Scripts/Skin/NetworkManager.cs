using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Skin.UI;
using UnityEngine;
using UnityEngine.Networking;

namespace Skin
{
    [Serializable]
    public abstract class NetworkErrorHandler : MonoBehaviour
    {
        public abstract void HandleError(string error);
    }

    /**
 * This class is used to make the request to the backend
 * The method is called from Skin Manager, which is responsible for providing the code
 * The Sprite is saved using the SpriteSaver
 * The continuation of the process is triggered by the Sprite Library Generator
 */
    public class NetworkManager : MonoBehaviour
    {
        [SerializeField] private string uri = "http://localhost:8080/sprites/";
        [SerializeField] private List<NetworkErrorHandler> errorHandlers;
        private CharacterSkinManager characterSkinManager;
        private SpriteLibraryGenerator _spriteLibraryGenerator;

        private void Awake()
        {
            characterSkinManager = FindObjectOfType<CharacterSkinManager>();
            _spriteLibraryGenerator = gameObject.GetComponent<SpriteLibraryGenerator>();
        }

        public void GetSprite(string code)
        {
            if (code.Length > 0) StartCoroutine(GetSpriteNetworkRequest(code));
        }

        private IEnumerator GetSpriteNetworkRequest(string id)
        {
            // GET
            var getRequest = CreateRequest(uri + id);
            yield return getRequest.SendWebRequest();

            if (getRequest.error != null)
            {
                HandleError(getRequest.error);
                yield break;
            }

            var deserializedGetData = JsonUtility.FromJson<SpriteDto>(getRequest.downloadHandler.text);
            
            var spriteLibraryAsset = _spriteLibraryGenerator.GenerateSpriteLibrary(deserializedGetData);
            SkinRegistry.AddSkin(spriteLibraryAsset, deserializedGetData.name, id);
            characterSkinManager.RefreshSpriteLibraryAssets();
            // Trigger continuation of game flow
        }

        private void HandleError(string error)
        {
            foreach (var networkErrorHandler in errorHandlers)
                networkErrorHandler.HandleError(error);
        }


        private static UnityWebRequest CreateRequest(string path, RequestType type = RequestType.GET, object data = null)
        {
            var request = new UnityWebRequest(path, type.ToString());

            if (data != null)
            {
                var bodyRaw = Encoding.UTF8.GetBytes(JsonUtility.ToJson(data));
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            }

            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            return request;
        }
    }

    public enum RequestType
    {
        GET = 0,
        POST = 1,
        PUT = 2
    }

    public class SpriteDto
    {
        // Ensure no getters / setters
        // Typecase has to match exactly
        public string id;
        public string name;
        public string[] front;
        public string[] back;
        public string[] right;
        public string[] left;
    }
}