using UnityEngine;
using System.Collections;


namespace SmallHeart
{
	public class KeyPair<T1, T2>
	{
		private readonly T1 _value1;
		private readonly T2 _value2;

		public T1 PrevStage
		{
			get { return _value1; }
		}
		public T2 Intake
		{
			get { return _value2; }
		}
		public KeyPair(T1 value1, T2 value2)
		{
			this._value1 = value1;
			this._value2 	= value2;
		}
		public override string ToString ()
		{
			return string.Format("PrevStage: {0}; Inake: {1}", _value1, _value2);
		}
		public override int GetHashCode()
		{
			return 17 * _value1.GetHashCode() + _value2.GetHashCode();
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
			if (a._value1 == null && b._value1 != null) return false;
			if (a._value2 == null && b._value2 != null) return false;
			return
				a._value1.Equals(b._value1) &&
				a._value2.Equals(b._value2);
		}
		
		public static bool operator!=(KeyPair<T1, T2> a, KeyPair<T1, T2> b)
		{
			return !(a == b);
		}
	}

}

