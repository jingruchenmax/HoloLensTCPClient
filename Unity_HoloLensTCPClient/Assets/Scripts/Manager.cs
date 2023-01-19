using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System.Threading.Tasks;
using Microsoft.MixedReality.Toolkit.SceneSystem;
using Microsoft.MixedReality.Toolkit.Extensions.SceneTransitions;
using Microsoft.MixedReality.Toolkit;

public class Manager : MonoBehaviour
{

    public async void SwitchScene(string name)
    {
        IMixedRealitySceneSystem sceneSystem = MixedRealityToolkit.Instance.GetService<IMixedRealitySceneSystem>();
        ISceneTransitionService transition = MixedRealityToolkit.Instance.GetService<ISceneTransitionService>();
        await transition.DoSceneTransition(() => sceneSystem.LoadContent(name));
    }

}
