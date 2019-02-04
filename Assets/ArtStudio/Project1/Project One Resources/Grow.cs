
    namespace VRTK.Examples
{
    using UnityEngine;

    public class Grow : MonoBehaviour
    {
        public VRTK_InteractableObject growingObject;
        public float growthRate = 10f/10000;

       
        protected bool growing;

        protected virtual void OnEnable()
        {
            growing = false;
           

            if (growingObject != null)
            {
                growingObject.InteractableObjectUsed += InteractableObjectUsed;
                growingObject.InteractableObjectUnused += InteractableObjectUnused;
            }


        }

        protected virtual void OnDisable()
        {
            if (growingObject != null)
            {
                growingObject.InteractableObjectUsed -= InteractableObjectUsed;
                growingObject.InteractableObjectUnused -= InteractableObjectUnused;
            }
        }

        protected virtual void Update()
        {
            if (growing)
            {
                //// EDIT THIS LINE TO EXPERIMENT!!!!!
                growingObject.transform.localScale += (new Vector3(growthRate, growthRate, growthRate));
               
            }
        }

        protected virtual void InteractableObjectUsed(object sender, InteractableObjectEventArgs e)
        {
            growing = true;
        }

        protected virtual void InteractableObjectUnused(object sender, InteractableObjectEventArgs e)
        {
            growing = false;
        }
    }
}
