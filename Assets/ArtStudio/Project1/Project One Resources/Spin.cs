namespace VRTK.Examples
{
    using UnityEngine;

    public class Spin : MonoBehaviour
    {
        public VRTK_InteractableObject spinObject;
        public float spinRate = 360f;


        protected bool spinning;

        protected virtual void OnEnable()
        {
            spinning = false;


            if (spinObject != null)
            {
                spinObject.InteractableObjectUsed += InteractableObjectUsed;
                spinObject.InteractableObjectUnused += InteractableObjectUnused;
            }


        }

        protected virtual void OnDisable()
        {
            if (spinObject != null)
            {
                spinObject.InteractableObjectUsed -= InteractableObjectUsed;
                spinObject.InteractableObjectUnused -= InteractableObjectUnused;
            }
        }

        protected virtual void Update()
        {
            if (spinning)
            {
                //// EDIT THIS LINE TO EXPERIMENT!!!!!
                spinObject.transform.Rotate(new Vector3(0f, 0f, spinRate * Time.deltaTime));

            }
        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            spinning = true;
        }

        protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
        {
            spinning = false;
        }
    }
}
