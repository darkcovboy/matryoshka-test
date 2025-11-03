using System;

using UnityEngine;

using JetBrains.Annotations;

namespace CookingPrototype.Kitchen {
	[RequireComponent(typeof(FoodPlace))]
	public sealed class FoodTrasher : MonoBehaviour {
		private const float DoubleTapThresshold = 0.4f;

		FoodPlace _place = null;
		float     _timer = 0f;

		void Start() {
			_place = GetComponent<FoodPlace>();
			_timer = Time.realtimeSinceStartup;
		}

		/// <summary>
		/// Освобождает место по двойному тапу если еда на этом месте сгоревшая.
		/// </summary>
		[UsedImplicitly]
		public void TryTrashFood() {
			if(_place.IsFree)
				return;
			
			if(_place.CurFood.CurStatus != Food.FoodStatus.Overcooked)
				return;
			
			float currentTime = Time.realtimeSinceStartup;
			float delta = currentTime - _timer;
			
			if (delta < DoubleTapThresshold) {
				_place.FreePlace();
			}
			
			_timer = currentTime;
		}
	}
}
