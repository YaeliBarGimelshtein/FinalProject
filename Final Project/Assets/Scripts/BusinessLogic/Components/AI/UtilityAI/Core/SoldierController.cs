using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UtilityAI.Core
{
    public class SoldierController : MonoBehaviour
    {
        public MoveController mover { get; set; }
        public AIBrain aiBrain { get; set; }
        public Action[] actionsAvailable;

        // Start is called before the first frame update
        void Start()
        {
            mover = GetComponent<MoveController>();
            aiBrain = GetComponent<AIBrain>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DoFallback(int time)
        {
            StartCoroutine(FallbackCoroutine(time));
        }

        IEnumerator FallbackCoroutine(int time)
        {
            int counter = time;
            while (counter > 0)
            {
                yield return new WaitForSeconds(1);
                counter--;
            }
            Debug.Log("I Fallback once");

            //logic to Fallback
        }
    }
}
