namespace CV.Converters
{
    public class BoolToVisibilityConverter
    {
        public static string Convert(bool isVisible)
        {
            return isVisible ? "display: block;" : "display: none;";
        }
    }
}
