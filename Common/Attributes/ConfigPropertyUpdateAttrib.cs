namespace DomainModel.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ConfigPropertyUpdateAttrib : Attribute
    {

        //  VARIABLES

        public bool AllowUpdate { get; set; } = true;


        //  METHODS

        #region CLASS METHODS

        public ConfigPropertyUpdateAttrib()
        {
            //
        }

        #endregion CLASS METHODS

    }
}
