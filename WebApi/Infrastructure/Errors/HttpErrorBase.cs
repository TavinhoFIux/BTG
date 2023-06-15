using System.Reflection;

namespace WebApi.Infrastructure.Errors
{
    public abstract class HttpErrorBase : IComparable
    {
        protected HttpErrorBase(string id, string name, int statusCode)
        {
            Id = id;
            Name = name;
            Status = statusCode;
        }

        public string Id { get; }

        public string Name { get; }

        public int Status { get; }

        public static IEnumerable<T> GetAll<T>() where T : HttpErrorBase
        {
            FieldInfo[] fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public static T FromValue<T>(string value) where T : HttpErrorBase
        {
            return Parse<T, string>(value, "value", item => item.Id == value);
        }

        public static T FromDisplayName<T>(string displayName) where T : HttpErrorBase
        {
            return Parse<T, string>(displayName, "display name", item => item.Name == displayName);
        }

        public override string ToString() => Name;

        public override bool Equals(object? obj)
        {
            if (obj is not HttpErrorBase otherValue)
            {
                return false;
            }

            bool typeMatches = GetType().Equals(obj.GetType());
            bool valueMatches = Id.Equals(otherValue.Id, StringComparison.OrdinalIgnoreCase);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode() => Id.GetHashCode();

        public int CompareTo(object? obj)
        {
            if (obj is null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            return string.Compare(Id, ((HttpErrorBase)obj).Id, StringComparison.OrdinalIgnoreCase);
        }

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : HttpErrorBase
        {
            T? matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem is null)
            {
                throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");
            }

            return matchingItem;
        }

        public static bool operator ==(HttpErrorBase left, HttpErrorBase right)
        {
            if (left is null)
            {
                return right is null;
            }

            return left.Equals(right);
        }

        public static bool operator !=(HttpErrorBase left, HttpErrorBase right)
        {
            return !(left == right);
        }

        public static bool operator <(HttpErrorBase left, HttpErrorBase right)
        {
            return left is null ? right is not null : left.CompareTo(right) < 0;
        }

        public static bool operator <=(HttpErrorBase left, HttpErrorBase right)
        {
            return left is null || left.CompareTo(right) <= 0;
        }

        public static bool operator >(HttpErrorBase left, HttpErrorBase right)
        {
            return left?.CompareTo(right) > 0;
        }

        public static bool operator >=(HttpErrorBase left, HttpErrorBase right)
        {
            return left is null ? right is null : left.CompareTo(right) >= 0;
        }
    }
}
