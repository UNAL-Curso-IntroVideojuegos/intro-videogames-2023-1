using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipNetwork.UI.Testing
{
    public class UINetTesting : MonoBehaviour
    {
        [SerializeField] private Button _hostBtn;
        [SerializeField] private Button _clientBtn;

        void Start()
        {
            _hostBtn.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartHost();
                Hide();
            });
            
            _clientBtn.onClick.AddListener(() =>
            {
                NetworkManager.Singleton.StartClient();
                Hide();
            });
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}