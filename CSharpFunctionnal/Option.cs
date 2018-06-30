namespace CSharpFunctionnal
{
    public interface Option { }

    public class Some<TypeValue> : Option
    {
        private readonly TypeValue _value;
        
        public Some(TypeValue value)
        {
            _value = value;
        }

        public TypeValue Value => _value;
    }
    
    public class None : Option { }
}