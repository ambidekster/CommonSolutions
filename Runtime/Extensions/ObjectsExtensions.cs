using UnityEngine;

namespace CommonSolutions.Runtime.Extensions
{
    public static class ObjectsExtensions
    {
        public static GameObject GameObject(this Object uo)
        {
            if (uo is GameObject)
            {
                return (GameObject)uo;
            }

            if (uo is Component)
            {
                return ((Component)uo).gameObject;
            }

            return null;
        }
    }
}