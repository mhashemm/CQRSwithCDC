using System;

namespace CQRSwithCDC.Logic.Core
{
	public abstract class Entity
	{
		public long Id { get; }

		public override bool Equals(object obj)
		{
			return obj is Entity other &&
				ReferenceEquals(this, other) &&
				GetRealType() == other.GetRealType() &&
				Id != 0 &&
				other.Id != 0 &&
				Id == other.Id;
		}

		public static bool operator ==(Entity a, Entity b)
		{
			return (a is null && b is null) || (a is not null && b is not null && a.Equals(b));
		}

		public static bool operator !=(Entity a, Entity b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return (GetRealType().ToString() + Id).GetHashCode();
		}

		private Type GetRealType()
		{
			Type type = GetType();
			return type.ToString().Contains("Castle.Proxies.") ? type.BaseType : type;
		}
	}
}
