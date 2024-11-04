// Decompiled with JetBrains decompiler
// Type: k
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
public class k
{
  private const int a = 1024;
  private const int b = 1093;
  private const int c = 11;
  private RichTextBox d;
  public List<k.a> e = new List<k.a>();
  private IntPtr f;

  [DllImport("User32.dll")]
  private static extern int SendMessage(IntPtr A_0, int A_1, IntPtr A_2, IntPtr A_3);

  public k(RichTextBox A_0) => this.d = A_0;

  private void a(int A_0, int A_1)
  {
    int selectionStart = this.d.SelectionStart;
    int selectionLength = this.d.SelectionLength;
    Font selectionFont = this.d.SelectionFont;
    Color selectionColor = this.d.SelectionColor;
    Color selectionBackColor = this.d.SelectionBackColor;
    this.d.Select(A_0, A_1 - A_0);
    this.d.SelectionFont = v.e;
    this.d.SelectionColor = this.d.ForeColor;
    this.d.SelectionBackColor = v.b;
    foreach (k.a a in this.e)
    {
      foreach (Match match in a.a.Matches(this.d.Text.Substring(A_0, A_1 - A_0)))
      {
        this.d.Select(match.Index, match.Length);
        this.d.SelectionFont = a.b;
        this.d.SelectionColor = a.c;
        this.d.SelectionBackColor = a.d;
      }
    }
    this.d.Select(selectionStart, selectionLength);
  }

  public void d()
  {
    k.SendMessage(this.d.Handle, 11, IntPtr.Zero, IntPtr.Zero);
    this.f = (IntPtr) k.SendMessage(this.d.Handle, 1093, IntPtr.Zero, IntPtr.Zero);
  }

  public void c()
  {
    k.SendMessage(this.d.Handle, 11, (IntPtr) 1, IntPtr.Zero);
    k.SendMessage(this.d.Handle, 1093, IntPtr.Zero, this.f);
  }

  public void b()
  {
    int selectionStart = this.d.SelectionStart;
    int selectionLength = this.d.SelectionLength;
    int indexFromPosition = this.d.GetCharIndexFromPosition(new Point(0, 1));
    Font selectionFont = this.d.SelectionFont;
    Color selectionColor = this.d.SelectionColor;
    Color selectionBackColor = this.d.SelectionBackColor;
    this.d.Select(0, this.d.TextLength);
    this.d.SelectionFont = v.e;
    this.d.SelectionColor = this.d.ForeColor;
    this.d.SelectionBackColor = v.b;
    foreach (k.a a in this.e)
    {
      foreach (Match match in a.a.Matches(this.d.Text))
      {
        this.d.Select(match.Index, match.Length);
        this.d.SelectionFont = a.b;
        this.d.SelectionColor = a.c;
        this.d.SelectionBackColor = a.d;
      }
    }
    this.d.Select(indexFromPosition, 0);
    this.d.ScrollToCaret();
    this.d.Select(selectionStart, selectionLength);
  }

  public void a(int A_0)
  {
    int A_0_1 = this.d.GetFirstCharIndexFromLine(A_0);
    int charIndexFromLine;
    int A_1 = (charIndexFromLine = this.d.GetFirstCharIndexFromLine(++A_0)) > -1 ? charIndexFromLine - 1 : this.d.Text.Length;
    if (A_0_1 < 0)
      A_0_1 = 0;
    this.a(A_0_1, A_1);
  }

  public void a()
  {
    int indexFromPosition1 = this.d.GetCharIndexFromPosition(new Point(0, 0));
    RichTextBox d = this.d;
    Size clientSize = this.d.ClientSize;
    int width = clientSize.Width;
    clientSize = this.d.ClientSize;
    int height = clientSize.Height;
    Point pt = new Point(width, height);
    int indexFromPosition2 = d.GetCharIndexFromPosition(pt);
    this.a(indexFromPosition1, indexFromPosition2);
  }

  public class a
  {
    public Regex a;
    public Font b;
    public Color c;
    public Color d;

    public a(Regex A_0, Font A_1, Color A_2, Color A_3)
    {
      this.a = A_0;
      this.b = A_1;
      this.c = A_2;
      this.d = A_3;
    }
  }
}
