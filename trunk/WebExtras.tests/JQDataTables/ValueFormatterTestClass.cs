using WebExtras.Core;

namespace WebExtras.tests.JQDataTables
{
  public class ValueFormatterTestClass : DefaultValueFormatter
  {
    public override string Format(object propertyValue, string formatString, object sender)
    {
      return "i am an Int32 with value: " + propertyValue.ToString();
    }
  }
}
