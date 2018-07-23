using System;

namespace Util
{
    public interface Option<TypeValue>
    {
        TResult Match<TResult>(Func<TypeValue, TResult> some, Func<TResult> none);
        Option<TypeResult> Bind<TypeResult>(Func<TypeValue, TypeResult> transform);
    }

    public class Some<TypeValue> : Option<TypeValue>
    {
        private readonly TypeValue _value;
        
        public Some(TypeValue value)
        {
            _value = value;
        }

        public TResult Match<TResult>(Func<TypeValue, TResult> some, Func<TResult> none) => some(_value);
        public Option<TypeResult> Bind<TypeResult>(Func<TypeValue, TypeResult> transform) => new Some<TypeResult>(transform(_value));

        public override string ToString()
        {
            return _value.ToString();
        }
    }

    public class None<TypeValue> : Option<TypeValue>
    {
        public TResult Match<TResult>(Func<TypeValue, TResult> some, Func<TResult> none) => none();
        public Option<TypeResult> Bind<TypeResult>(Func<TypeValue, TypeResult> transform) => new None<TypeResult>();

        public override string ToString()
        {
            return "NoValue";
        }
    }
}