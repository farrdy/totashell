using System;

namespace Total.DealerCom.DataAccessLayer.Utility
{
  public static class ConvertNullable
  {
    public static Int32? ToInt32 (object input)
    {
      if (input != null)
      {
        if (input is Int32)
        {
          return (Int32?) input;
        }

        Int32 result;
        if (Int32.TryParse (input.ToString(), out result))
        {
          return result;
        }
      }
      return null;
    }

    public static DateTime? ToDateTime (object input)
    {
      if (input != null)
      {
        if (input is DateTime)
        {
          return (DateTime?) input;
        }

        DateTime result;
        if (DateTime.TryParse (input.ToString(), out result))
        {
          return result;
        }
      }
      return null;
    }

    public static Double? ToDouble(object input)
    {
      if (input != null)
      {
        if (input is Double)
        {
          return (Double?)input;
        }

        Double result;
        if (Double.TryParse(input.ToString(), out result))
        {
          return result;
        }
      }
      return null;
    }
  }
}