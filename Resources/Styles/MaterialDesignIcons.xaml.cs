namespace CMS.Resources.Styles;

public partial class MaterialDesignIcons : ResourceDictionary
{
	public MaterialDesignIcons()
	{
		InitializeComponent();
	}

	public static string MaterialIcon(string key)
    {
        if (Application.Current.Resources.TryGetValue(key, out var value) && value is string)
        {
            return (string)value;
        }

        return string.Empty;
    }
}