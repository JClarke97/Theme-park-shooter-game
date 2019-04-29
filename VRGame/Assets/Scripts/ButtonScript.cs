namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEngine.UI;
    using VRTK.Controllables;
    using UnityEngine.SceneManagement;


    public class ButtonScript : MonoBehaviour
    {
        public VRTK_BaseControllable controllable;
        public Text displayText;
        public string OutputOnMax = "Maximum Reached";
        bool isTriggered=false;
        //chose which scene to load in editer
        public int sceneToSwitch;

        protected virtual void OnEnable()
        {
            //
            controllable = (controllable == null ? GetComponent<VRTK_BaseControllable>() : controllable);

            controllable.MaxLimitReached += maxLimitReached;
            controllable.MinLimitReached += MinLimitReached;
        }
        protected virtual void maxLimitReached(object sender, ControllableEventArgs e)
        {
            // if the button as been fully pressed then load the scene that has been chosen in the editor
            if (OutputOnMax != ""&&isTriggered==true)
            {               
                Debug.Log(OutputOnMax);
                SceneManager.LoadScene(sceneToSwitch);
            }
            isTriggered = true;
        }
        protected virtual void MinLimitReached(object sender, ControllableEventArgs e)
        {
            if (OutputOnMax != "")
            {
                Debug.Log("min");
               
            }
        }
    }
}