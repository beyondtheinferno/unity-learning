﻿//----------------------------------------------
// Flip Web Apps: Game Framework
// Copyright © 2016 Flip Web Apps / Mark Hewitt
//
// Please direct any bugs/comments/suggestions to http://www.flipwebapps.com
// 
// The copyright owner grants to the end user a non-exclusive, worldwide, and perpetual license to this Asset
// to integrate only as incorporated and embedded components of electronic games and interactive media and 
// distribute such electronic game and interactive media. End user may modify Assets. End user may otherwise 
// not reproduce, distribute, sublicense, rent, lease or lend the Assets. It is emphasized that the end 
// user shall not be entitled to distribute or transfer in any way (including, without, limitation by way of 
// sublicense) the Assets in any other way than as integrated components of electronic games and interactive media. 

// The above copyright notice and this permission notice must not be removed from any files.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//----------------------------------------------

using System.Collections;
using GameFramework.GameStructure.GameItems.ObjectModel;
using UnityEngine;

#if BEAUTIFUL_TRANSITIONS
using FlipWebApps.BeautifulTransitions.Scripts.Transitions;
#endif

namespace GameFramework.GameStructure.GameItems.Components.AbstractClasses
{
    /// <summary>
    /// Enabled or a disabled a gameobject based upon a condition.
    /// </summary>
    public abstract class GameItemContextEnableDisableGameObject<T> : GameItemContextBaseRunnable<T> where T : GameItem
    {
        /// <summary>
        /// GameObject to show if the specified GameItem is selected
        /// </summary>
        [Header("Enable")]
        [Tooltip("GameObject to show if the specified GameItem is selected")]
        public GameObject ConditionMetGameObject;

        /// <summary>
        /// GameObject to show if the specified GameItem is not selected
        /// </summary>
        [Tooltip("GameObject to show if the specified GameItem is not selected")]
        public GameObject ConditionNotMetGameObject;


        /// <summary>
        /// Called by the base class from start and optionally if the selection chages.
        /// </summary>
        /// <param name="gameItem"></param>
        /// <param name="isStart"></param>
        public override void RunMethod(T gameItem, bool isStart = true)
        {
            var isConditionMet = IsConditionMet(gameItem);

//#if BEAUTIFUL_TRANSITIONS
//            StartCoroutine(TransitionOutIn(_selectedPrefabInstance, _newPrefabInstance));
//#else
            if (ConditionMetGameObject != null)
                ConditionMetGameObject.SetActive(isConditionMet);
            if (ConditionNotMetGameObject != null)
                ConditionNotMetGameObject.SetActive(!isConditionMet);
//#endif
        }


        /// <summary>
        /// Implement this to return whether to show the condition met gameobject (true) or the condition not met one (false)
        /// </summary>
        /// <returns></returns>
        public abstract bool IsConditionMet(T gameItem);


#if BEAUTIFUL_TRANSITIONS
        IEnumerator TransitionOutIn(GameObject oldGameObject, GameObject newGameObject)
        {
            if (oldGameObject != null)
            {
                if (TransitionHelper.ContainsTransition(oldGameObject))
                {
                    var transitions = TransitionHelper.TransitionOut(oldGameObject);
                    yield return new WaitForSeconds(TransitionHelper.GetTransitionOutTime(transitions));
                }
                oldGameObject.SetActive(false);
            }
            newGameObject.SetActive(true);
        }
#endif
    }
}