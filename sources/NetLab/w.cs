// Decompiled with JetBrains decompiler
// Type: w
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
internal class w
{
  private readonly string[] a = new string[27]
  {
    "OK [0]",
    "User abort [1]",
    "General MAPI failure [2]",
    "MAPI login failure [3]",
    "Disk full [4]",
    "Insufficient memory [5]",
    "Access denied [6]",
    "-unknown- [7]",
    "Too many sessions [8]",
    "Too many files were specified [9]",
    "Too many recipients were specified [10]",
    "A specified attachment was not found [11]",
    "Attachment open failure [12]",
    "Attachment write failure [13]",
    "Unknown recipient [14]",
    "Bad recipient type [15]",
    "No messages [16]",
    "Invalid message [17]",
    "Text too large [18]",
    "Invalid session [19]",
    "Type not supported [20]",
    "A recipient was specified ambiguously [21]",
    "Message in use [22]",
    "Network failure [23]",
    "Invalid edit fields [24]",
    "Invalid recipients [25]",
    "Not supported [26]"
  };
  private List<z> b = new List<z>();
  private List<string> c = new List<string>();
  private int d;
  private const int e = 1;
  private const int f = 8;
  private const int g = 20;

  public bool d(string A_0) => this.a(A_0, w.a.b);

  public bool c(string A_0) => this.a(A_0, w.a.b);

  public bool b(string A_0) => this.a(A_0, w.a.b);

  public void a(string A_0) => this.c.Add(A_0);

  public int b(string A_0, string A_1) => this.a(A_0, A_1, 9);

  public int a(string A_0, string A_1) => this.a(A_0, A_1, 1);

  [DllImport("MAPI32.DLL")]
  private static extern int MAPISendMail(IntPtr A_0, IntPtr A_1, x A_2, int A_3, int A_4);

  private int a(string A_0, string A_1, int A_2)
  {
    x A_0_1 = new x() { b = A_0, c = A_1 };
    A_0_1.j = this.b(out A_0_1.i);
    A_0_1.l = this.a(out A_0_1.k);
    this.d = w.MAPISendMail(new IntPtr(0), new IntPtr(0), A_0_1, A_2, 0);
    if (this.d > 1)
    {
      int num = (int) MessageBox.Show("MAPISendMail failed! " + this.a(), "MAPISendMail");
    }
    this.a(ref A_0_1);
    return this.d;
  }

  private bool a(string A_0, w.a A_1)
  {
    this.b.Add(new z() { b = (int) A_1, c = A_0 });
    return true;
  }

  private IntPtr b(out int A_0)
  {
    A_0 = 0;
    if (this.b.Count == 0)
      return IntPtr.Zero;
    int num1 = Marshal.SizeOf(typeof (z));
    IntPtr num2 = Marshal.AllocHGlobal(this.b.Count * num1);
    int ptr = (int) num2;
    foreach (object structure in this.b)
    {
      Marshal.StructureToPtr(structure, (IntPtr) ptr, false);
      ptr += num1;
    }
    A_0 = this.b.Count;
    return num2;
  }

  private IntPtr a(out int A_0)
  {
    A_0 = 0;
    if (this.c == null || this.c.Count <= 0 || this.c.Count > 20)
      return IntPtr.Zero;
    int num1 = Marshal.SizeOf(typeof (y));
    IntPtr num2 = Marshal.AllocHGlobal(this.c.Count * num1);
    y structure = new y();
    structure.c = -1;
    int ptr = (int) num2;
    foreach (string path in this.c)
    {
      structure.e = Path.GetFileName(path);
      structure.d = path;
      Marshal.StructureToPtr((object) structure, (IntPtr) ptr, false);
      ptr += num1;
    }
    A_0 = this.c.Count;
    return num2;
  }

  private void a(ref x A_0)
  {
    int num1 = Marshal.SizeOf(typeof (z));
    if (A_0.j != IntPtr.Zero)
    {
      int j = (int) A_0.j;
      for (int index = 0; index < A_0.i; ++index)
      {
        Marshal.DestroyStructure((IntPtr) j, typeof (z));
        j += num1;
      }
      Marshal.FreeHGlobal(A_0.j);
    }
    if (A_0.l != IntPtr.Zero)
    {
      int num2 = Marshal.SizeOf(typeof (y));
      int l = (int) A_0.l;
      for (int index = 0; index < A_0.k; ++index)
      {
        Marshal.DestroyStructure((IntPtr) l, typeof (y));
        l += num2;
      }
      Marshal.FreeHGlobal(A_0.l);
    }
    this.b.Clear();
    this.c.Clear();
    this.d = 0;
  }

  public string a() => this.d <= 26 ? this.a[this.d] : "MAPI error [" + this.d.ToString() + "]";

  private enum a
  {
    a,
    b,
    c,
    d,
  }
}
