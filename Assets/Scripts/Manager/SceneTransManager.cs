using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class SceneTransManager : MonoBehaviour
    {
        /// <summary>
        ///     ゲーム開始時にベースシーン読み込み
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void LoadBaseScene()
        {
            var baseSceneFlag = false;
            for (var i = 0; i < SceneManager.sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (scene.name != "BaseScene") continue;
                baseSceneFlag = true;
                break;
            }

            if (!baseSceneFlag) SceneManager.LoadSceneAsync("BaseScene", LoadSceneMode.Additive);
        }

        [SerializeField] private Image transitionImage;

        private void Awake()
        {
            transitionImage.gameObject.SetActive(false);
        }


        public async Task TransitionScene(string sceneName)
        {
            transitionImage.gameObject.SetActive(true);
            // TODO: パネルを暗転、読み込みをawait
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            SceneManager.LoadSceneAsync(sceneName);
            // TODO: パネルを透明
            transitionImage.gameObject.SetActive(false);
        }
    }
}