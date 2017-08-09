using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformBasic
{
    public class Util
    {
        public static void DoWithDelay(MonoBehaviour mono, float delay, System.Action action)
        {
            mono.StartCoroutine(DoCor(delay, action));
        }

        private static IEnumerator DoCor(float delay, System.Action action)
        {
            yield return new WaitForSeconds(delay);

            if (action != null) {
                action.Invoke();
            }
        }
    }
}
