namespace clarotech.openehr.AOM.aom
{
    public class CDefinedObject<T> : CObject
    {
        public bool? Frozen { get; set; }

        public T DefaultValue { get; set; }
    }
}
