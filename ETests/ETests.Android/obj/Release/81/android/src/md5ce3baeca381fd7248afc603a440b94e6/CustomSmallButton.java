package md5ce3baeca381fd7248afc603a440b94e6;


public class CustomSmallButton
	extends md51558244f76c53b6aeda52c8a337f2c37.ButtonRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("ETests.Droid.CustomSmallButton, ETests.Android", CustomSmallButton.class, __md_methods);
	}


	public CustomSmallButton (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomSmallButton.class)
			mono.android.TypeManager.Activate ("ETests.Droid.CustomSmallButton, ETests.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomSmallButton (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomSmallButton.class)
			mono.android.TypeManager.Activate ("ETests.Droid.CustomSmallButton, ETests.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomSmallButton (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomSmallButton.class)
			mono.android.TypeManager.Activate ("ETests.Droid.CustomSmallButton, ETests.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
