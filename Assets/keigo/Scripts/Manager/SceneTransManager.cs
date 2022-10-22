using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Manager
{
    public class SceneTransManager : MonoBehaviour
    {
        [SerializeField] private Image transitionImage;

        private void Awake()
        {
            transitionImage.gameObject.SetActive(false);
        }

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


        /// <summary>
        ///     指定したシーンを読み込み
        /// </summary>
        /// <param name="sceneName"></param>
        public async Task TransitionScene(string sceneName)
        {
            var task = new UniTaskCompletionSource();

            transitionImage.gameObject.SetActive(true);
            transitionImage.DOFade(1, 0.5f).OnComplete(async () =>
            {
                await SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
                await SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
                transitionImage.DOFade(0, 0.5f).OnComplete(() =>
                {
                    transitionImage.gameObject.SetActive(false);
                    task.TrySetResult();
                });
            });
            await task.Task;
        }
    }
}