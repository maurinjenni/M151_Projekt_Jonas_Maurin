namespace HomeworX.Models
{
    public partial class Subject
    {
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(Code) || Code.Length < 2 || Code.Length > 10)
            {
                return false;
            }

            if (string.IsNullOrEmpty(Description) || Description.Length < 3 || Description.Length > 100)
            {
                return false;
            }

            return true;
        }
    }
}