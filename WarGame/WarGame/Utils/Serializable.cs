namespace WarGame.Utils
{
    public class Serializable
    {
        protected static Serializer Serializer;

        public virtual string Serialize()
        {
            return Serializer.Serialize(this);
        }
    }
}
