using UnityEngine;
using System.Collections;


namespace SmallHeart
{
	public class KeyPair<T1, T2>
	{
		private readonly T1 _prevStage;
		private readonly T2 _intake;

		public T1 PrevStage
		{
			get { return _prevStage; }
		}
		public T2 Intake
		{
			get { return _intake; }
		}
		public KeyPair(T1 prevStage, T2 intake)
		{
			this._prevStage = prevStage;
			this._intake 	= intake;
		}
		public override string ToString ()
		{
			return string.Format("PrevStage: {0}; Inake: {1}", _prevStage, _intake);
		}
		public override int GetHashCode()
		{
			return 17 * _prevStage.GetHashCode() + _intake.GetHashCode();
		}
		public override bool Equals(object obj)
		{
			if ( !(obj is KeyPair <T1, T2>) )
			{
				return false;
			}

			var otherKeyPair = (KeyPair<T1,T2>) obj;
			return this == otherKeyPair;

		}

		public static bool operator==(KeyPair<T1, T2> a, KeyPair<T1, T2> b)
		{
			if (object.ReferenceEquals(a, null)) {
				return object.ReferenceEquals(b, null);
			}
			if (a._prevStage == null && b._prevStage != null) return false;
			if (a._intake == null && b._intake != null) return false;
			return
				a._prevStage.Equals(b._prevStage) &&
				a._intake.Equals(b._intake);
		}
		
		public static bool operator!=(KeyPair<T1, T2> a, KeyPair<T1, T2> b)
		{
			return !(a == b);
		}
	}

	public class Info {
		public string SpritePath 	 { get; set; }
		public int 	  CurrStage  	 { get; set; }
		public string CharacterClass { get; set; }
		public string ClassInfo      { get; set; }
		public int    TrainingTime 	 { get; set; }
		public int    HealthTotal    { get; set; }

		public Info()
		{}

		public Info (string path, int currStage)
		{
			SpritePath     = path;
			CurrStage  	   = currStage;
			CharacterClass = "";
			ClassInfo	   = "";
		}
		public bool SetStats (int training, int healthTotal)
		{
			TrainingTime = training;
			HealthTotal  = healthTotal;
			return true;
		}


	}


}

