// Decompiled with JetBrains decompiler
// Type: ad
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections;
using System.IO;
using System.Text;

public static class ad
{
  public static string a(MemoryStream A_0)
  {
    bool flag1 = true;
    byte[] numArray = new byte[1024];
    int index = -1;
    bool flag2;
    do
    {
      ++index;
      numArray[index] = Convert.ToByte(A_0.ReadByte());
      if (!flag1)
      {
        flag2 = numArray[index] > (byte) 0;
      }
      else
      {
        flag2 = true;
        flag1 = numArray[index] != (byte) 10;
      }
    }
    while (flag1 | flag2);
    return new UnicodeEncoding().GetString(numArray, 0, Array.FindLastIndex<byte>(numArray, new Predicate<byte>(ad.a))).Replace("\r", "");
  }

  private static bool a(byte A_0) => A_0 == (byte) 10;

  public static void a(MemoryStream A_0, string A_1)
  {
    UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
    A_0.Write(unicodeEncoding.GetBytes(A_1 + "\n"), 0, unicodeEncoding.GetByteCount(A_1 + "\n"));
  }

  public static string a(string A_0, int A_1)
  {
    if (A_1 == 0)
      return A_0;
    ArrayList arrayList = new ArrayList();
    string A_0_1 = A_0;
    string str1 = "";
    while (true)
    {
      ad.e(ref A_0_1);
      if (!(A_0_1 == "") && A_0_1[0] != ';')
        arrayList.Add((object) ad.c(ref A_0_1));
      else
        break;
    }
    if (arrayList.Count > 0)
    {
      A_0_1 = (string) arrayList[0];
      if (A_0_1[A_0_1.Length - 1] == ':')
      {
        str1 = (string) arrayList[0];
        arrayList.RemoveAt(0);
      }
    }
    if (arrayList.Count > 0 && !arrayList.Contains((object) "declare"))
    {
      for (int index = 0; index < arrayList.Count; ++index)
      {
        if (MainWindow.ab.IndexOf(arrayList[index]) >= 0 && MainWindow.ac.IndexOf(arrayList[index]) < 0)
          ++MainWindow.y;
        if (MainWindow.ae.IndexOf(arrayList[index]) >= 0)
          ++MainWindow.aa;
      }
    }
    int index1 = -1;
    if (arrayList.IndexOf((object) "declare") >= 0)
    {
      arrayList.Remove((object) "declare");
      int index2 = MainWindow.ac.IndexOf((object) "declare");
      string str2 = str1 + " " + (string) MainWindow.ab[index2];
      foreach (char ch in (string) MainWindow.ad[index2])
      {
        switch (ch)
        {
          case 'f':
            if (arrayList.Count > 0)
            {
              str2 = str2 + " " + arrayList[0]?.ToString();
              arrayList.RemoveAt(0);
              break;
            }
            break;
          case 'l':
            if (arrayList.Count > 0)
            {
              str2 = str2 + " " + arrayList[arrayList.Count - 1]?.ToString();
              arrayList.RemoveAt(arrayList.Count - 1);
              break;
            }
            break;
          case 'r':
            if (arrayList.Count > 0)
            {
              for (int index3 = 0; index3 < arrayList.Count; ++index3)
                str2 = str2 + " " + arrayList[index3]?.ToString();
              arrayList.Clear();
              break;
            }
            break;
        }
      }
      return str2;
    }
    for (int index4 = 0; index4 < arrayList.Count; ++index4)
    {
      index1 = MainWindow.ac.IndexOf(arrayList[index4]);
      if (index1 >= 0)
      {
        arrayList.RemoveAt(index4);
        string str3 = (string) MainWindow.ad[index1];
        str1 = str1 + " " + (string) MainWindow.ab[index1];
        foreach (char ch in (string) MainWindow.ad[index1])
        {
          switch (ch)
          {
            case 'f':
              if (arrayList.Count > 0)
              {
                str1 = str1 + " " + arrayList[0]?.ToString();
                arrayList.RemoveAt(0);
                break;
              }
              break;
            case 'l':
              if (arrayList.Count > 0)
              {
                str1 = str1 + " " + arrayList[arrayList.Count - 1]?.ToString();
                arrayList.RemoveAt(arrayList.Count - 1);
                break;
              }
              break;
            case 'r':
              if (arrayList.Count > 0)
              {
                for (int index5 = 0; index5 < arrayList.Count; ++index5)
                  str1 = str1 + " " + arrayList[index5]?.ToString();
                arrayList.Clear();
                break;
              }
              break;
          }
        }
      }
    }
    if (index1 < 0 && arrayList.Count > 0)
    {
      for (int index6 = 0; index6 < arrayList.Count; ++index6)
        str1 = str1 + " " + arrayList[index6]?.ToString();
    }
    return str1;
  }

  private static bool c(char A_0) => A_0 == ' ' || A_0 == '\t';

  private static bool b(char A_0)
  {
    return A_0 == ' ' || A_0 == '\t' || A_0 == ';' || A_0 == ',' || A_0 == '(' || A_0 == ')' || A_0 == '$' || A_0 == '+' || A_0 == '-' || A_0 == '*' || A_0 == '/' || A_0 == '%' || A_0 == '|' || A_0 == '&' || A_0 == '!' || A_0 == '=' || A_0 == '<' || A_0 == '>' || A_0 == '#';
  }

  public static void e(ref string A_0)
  {
    int num = 0;
    while (num < A_0.Length && ad.c(A_0[num]))
      ++num;
    if (A_0.Length > 0 && A_0[0] == ';')
      A_0 = "";
    else
      A_0 = A_0.Substring(num);
  }

  public static string d(string A_0)
  {
    string str = "";
    if (A_0.Length >= 2)
    {
      if (A_0[0] == '&' && A_0[1] == '&')
        str = "&&";
      if (A_0[0] == '|' && A_0[1] == '|')
        str = "||";
      if (A_0[0] == '=' && A_0[1] == '=')
        str = "==";
      if (A_0[0] == '!' && A_0[1] == '=')
        str = "!=";
      if (A_0[0] == '>' && A_0[1] == '=')
        str = ">=";
      if (A_0[0] == '<' && A_0[1] == '=')
        str = "<=";
      if (A_0[0] == '!' && A_0[1] == '!')
        str = "!!";
    }
    if (str == "" && A_0.Length >= 1)
    {
      switch (A_0[0])
      {
        case '!':
          str = "!";
          break;
        case '%':
          str = "%";
          break;
        case '&':
          str = "&";
          break;
        case '*':
          str = "*";
          break;
        case '+':
          str = "+";
          break;
        case '-':
          str = "-";
          break;
        case '/':
          str = "/";
          break;
        case '<':
          str = "<";
          break;
        case '>':
          str = ">";
          break;
        case '|':
          str = "|";
          break;
      }
    }
    return str;
  }

  public static string c(string A_0)
  {
    ad.e(ref A_0);
    string str = A_0;
    int num = 0;
    while (num < str.Length && !ad.b(str[num]))
      ++num;
    return str.Substring(0, num);
  }

  public static string d(ref string A_0)
  {
    ad.e(ref A_0);
    string str = ad.c(A_0);
    A_0 = A_0.Remove(0, str.Length);
    return str;
  }

  public static string c(ref string A_0)
  {
    ad.e(ref A_0);
    string str;
    if (A_0[0] == '$' || A_0[0] == '(' || A_0[0] == '"' || A_0[0] == '#' || ad.a(A_0[0]) || ad.b(A_0))
    {
      str = ad.a(ref A_0);
    }
    else
    {
      string A_0_1 = ad.c(A_0);
      if (ad.a(A_0_1))
        str = ad.a(ref A_0);
      else if (A_0_1.Length == 0)
      {
        str = A_0;
        A_0 = "";
        ++MainWindow.z;
      }
      else
      {
        A_0 = A_0.Remove(0, A_0_1.Length);
        str = A_0_1;
      }
    }
    return str;
  }

  public static bool a(char A_0)
  {
    return A_0 == '1' || A_0 == '2' || A_0 == '3' || A_0 == '4' || A_0 == '5' || A_0 == '6' || A_0 == '7' || A_0 == '8' || A_0 == '9' || A_0 == '0';
  }

  public static bool b(string A_0)
  {
    string str = ad.d(A_0);
    return str == "-" || str == "!" || str == "!!";
  }

  public static bool a(string A_0)
  {
    return A_0 == "sizeof" || A_0 == "pos" || A_0 == "peek" || A_0 == "dequeue" || A_0 == "qcount" || A_0 == "CurrentSystemName" || A_0 == "SystemTime" || A_0 == "random" || A_0 == "copy" || A_0 == "locguide";
  }

  public static string b(ref string A_0)
  {
    string str1 = ad.c(A_0);
    A_0 = A_0.Remove(0, str1.Length);
    string str2 = str1;
    ad.e(ref A_0);
    string str3;
    if (A_0.Length > 0 && A_0[0] == '(')
    {
      str3 = str2 + A_0[0].ToString();
      A_0 = A_0.Remove(0, 1);
      while (true)
      {
        ad.e(ref A_0);
        if (!(A_0 == ""))
        {
          if (A_0[0] != ')')
          {
            if (A_0[0] == ',')
            {
              str3 += A_0[0].ToString();
              A_0 = A_0.Remove(0, 1);
            }
            else
              str3 += ad.c(ref A_0);
          }
          else
            break;
        }
        else
          goto label_9;
      }
      str3 += A_0[0].ToString();
      A_0 = A_0.Remove(0, 1);
    }
    else
    {
      ++MainWindow.z;
      str3 = str2 + A_0;
      A_0 = "";
    }
label_9:
    return str3;
  }

  public static string a(ref string A_0)
  {
    string str1 = "";
    string str2;
    if (A_0[0] == '$')
    {
      A_0 = A_0.Remove(0, 1);
      string str3 = ad.c(A_0);
      A_0 = A_0.Remove(0, str3.Length);
      ad.e(ref A_0);
      str2 = str1 + "$" + str3;
      if (A_0.Length > 0 && ad.d(A_0) != "")
      {
        str2 += ad.d(A_0);
        A_0 = A_0.Remove(0, ad.d(A_0).Length);
        ad.e(ref A_0);
        if (A_0.Length > 0)
          str2 += ad.a(ref A_0);
      }
    }
    else if (A_0[0] == '(')
    {
      string str4 = str1 + A_0[0].ToString();
      A_0 = A_0.Remove(0, 1);
      ad.e(ref A_0);
      str2 = str4 + ad.a(ref A_0);
      ad.e(ref A_0);
      if (A_0.Length > 0 && A_0[0] == ')')
      {
        str2 += A_0[0].ToString();
        A_0 = A_0.Remove(0, 1);
      }
      ad.e(ref A_0);
      if (A_0.Length > 0 && ad.d(A_0) != "")
      {
        str2 += ad.d(A_0);
        A_0 = A_0.Remove(0, ad.d(A_0).Length);
        ad.e(ref A_0);
        if (A_0.Length > 0)
          str2 += ad.a(ref A_0);
      }
    }
    else if (A_0[0] == '#')
    {
      A_0 = A_0.Remove(0, 1);
      string str5 = ad.c(A_0);
      A_0 = A_0.Remove(0, str5.Length);
      ad.e(ref A_0);
      str2 = str1 + "#" + str5;
      if (A_0.Length > 0 && ad.d(A_0) != "")
      {
        str2 += ad.d(A_0);
        A_0 = A_0.Remove(0, ad.d(A_0).Length);
        ad.e(ref A_0);
        if (A_0.Length > 0)
          str2 += ad.a(ref A_0);
      }
    }
    else if (ad.b(A_0))
    {
      str2 = str1 + ad.d(A_0);
      A_0 = A_0.Remove(0, ad.d(A_0).Length);
      ad.e(ref A_0);
      if (A_0.Length > 0)
        str2 += ad.a(ref A_0);
    }
    else if (A_0[0] == '"')
    {
      str2 = str1 + A_0[0].ToString();
      A_0 = A_0.Remove(0, 1);
      int num;
      for (num = 0; num < A_0.Length && A_0[num] != '"'; ++num)
        str2 += A_0[num].ToString();
      A_0 = A_0.Remove(0, num);
      if (A_0.Length >= 1 && A_0[0] == '"')
      {
        str2 += "\"";
        A_0 = A_0.Remove(0, 1);
      }
      ad.e(ref A_0);
      if (A_0.Length > 0 && ad.d(A_0) != "")
      {
        str2 += ad.d(A_0);
        A_0 = A_0.Remove(0, ad.d(A_0).Length);
        ad.e(ref A_0);
        if (A_0.Length > 0)
          str2 += ad.a(ref A_0);
      }
    }
    else if (ad.a(A_0[0]))
    {
      string str6 = ad.c(A_0);
      A_0 = A_0.Remove(0, str6.Length);
      ad.e(ref A_0);
      str2 = str1 + str6;
      if (A_0.Length > 0 && ad.d(A_0) != "")
      {
        str2 += ad.d(A_0);
        A_0 = A_0.Remove(0, ad.d(A_0).Length);
        ad.e(ref A_0);
        if (A_0.Length > 0)
          str2 += ad.a(ref A_0);
      }
    }
    else if (ad.a(ad.c(A_0)))
    {
      str2 = str1 + ad.b(ref A_0);
      ad.e(ref A_0);
      if (A_0.Length > 0 && ad.d(A_0) != "")
      {
        str2 += ad.d(A_0);
        A_0 = A_0.Remove(0, ad.d(A_0).Length);
        ad.e(ref A_0);
        if (A_0.Length > 0)
          str2 += ad.a(ref A_0);
      }
    }
    else
    {
      ++MainWindow.z;
      str2 = str1 + A_0;
      A_0 = "";
    }
    return str2;
  }
}
