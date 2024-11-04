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
public class SyntaxHighlighter
{
  private const int a = 1024;
  private const int b = 1093;
  private const int c = 11;
  private RichTextBox richTextBox;
  public List<SyntaxHighlighter.HighlightRule> e = new List<SyntaxHighlighter.HighlightRule>();
  private IntPtr f;

  [DllImport("User32.dll")]
  private static extern int SendMessage(IntPtr A_0, int A_1, IntPtr A_2, IntPtr A_3);

  public SyntaxHighlighter(RichTextBox textBox) => this.richTextBox = textBox;

  private void a_func2(int A_0, int A_1)
  {
    int selectionStart = this.richTextBox.SelectionStart;
    int selectionLength = this.richTextBox.SelectionLength;
    Font selectionFont = this.richTextBox.SelectionFont;
    Color selectionColor = this.richTextBox.SelectionColor;
    Color selectionBackColor = this.richTextBox.SelectionBackColor;
    this.richTextBox.Select(A_0, A_1 - A_0);
    this.richTextBox.SelectionFont = MainWindow.font;
    this.richTextBox.SelectionColor = this.richTextBox.ForeColor;
    this.richTextBox.SelectionBackColor = MainWindow.backColor;
    foreach (SyntaxHighlighter.HighlightRule a in this.e)
    {
      foreach (Match match in a.regex.Matches(this.richTextBox.Text.Substring(A_0, A_1 - A_0)))
      {
        this.richTextBox.Select(match.Index, match.Length);
        this.richTextBox.SelectionFont = a.font;
        this.richTextBox.SelectionColor = a.color;
        this.richTextBox.SelectionBackColor = a.bgColor;
      }
    }
    this.richTextBox.Select(selectionStart, selectionLength);
  }

  public void d_func()
  {
    SyntaxHighlighter.SendMessage(this.richTextBox.Handle, 11, IntPtr.Zero, IntPtr.Zero);
    this.f = (IntPtr) SyntaxHighlighter.SendMessage(this.richTextBox.Handle, 1093, IntPtr.Zero, IntPtr.Zero);
  }

  public void c_func()
  {
    SyntaxHighlighter.SendMessage(this.richTextBox.Handle, 11, (IntPtr) 1, IntPtr.Zero);
    SyntaxHighlighter.SendMessage(this.richTextBox.Handle, 1093, IntPtr.Zero, this.f);
  }

  public void b_func()
  {
    int selectionStart = this.richTextBox.SelectionStart;
    int selectionLength = this.richTextBox.SelectionLength;
    int indexFromPosition = this.richTextBox.GetCharIndexFromPosition(new Point(0, 1));
    Font selectionFont = this.richTextBox.SelectionFont;
    Color selectionColor = this.richTextBox.SelectionColor;
    Color selectionBackColor = this.richTextBox.SelectionBackColor;
    this.richTextBox.Select(0, this.richTextBox.TextLength);
    this.richTextBox.SelectionFont = MainWindow.font;
    this.richTextBox.SelectionColor = this.richTextBox.ForeColor;
    this.richTextBox.SelectionBackColor = MainWindow.backColor;
    foreach (SyntaxHighlighter.HighlightRule a in this.e)
    {
      foreach (Match match in a.regex.Matches(this.richTextBox.Text))
      {
        this.richTextBox.Select(match.Index, match.Length);
        this.richTextBox.SelectionFont = a.font;
        this.richTextBox.SelectionColor = a.color;
        this.richTextBox.SelectionBackColor = a.bgColor;
      }
    }
    this.richTextBox.Select(indexFromPosition, 0);
    this.richTextBox.ScrollToCaret();
    this.richTextBox.Select(selectionStart, selectionLength);
  }

  public void a_func1(int A_0)
  {
    int A_0_1 = this.richTextBox.GetFirstCharIndexFromLine(A_0);
    int charIndexFromLine;
    int A_1 = (charIndexFromLine = this.richTextBox.GetFirstCharIndexFromLine(++A_0)) > -1 ? charIndexFromLine - 1 : this.richTextBox.Text.Length;
    if (A_0_1 < 0)
      A_0_1 = 0;
    this.a_func2(A_0_1, A_1);
  }

  public void a_func0()
  {
    int indexFromPosition1 = this.richTextBox.GetCharIndexFromPosition(new Point(0, 0));
    RichTextBox d = this.richTextBox;
    Size clientSize = this.richTextBox.ClientSize;
    int width = clientSize.Width;
    clientSize = this.richTextBox.ClientSize;
    int height = clientSize.Height;
    Point pt = new Point(width, height);
    int indexFromPosition2 = d.GetCharIndexFromPosition(pt);
    this.a_func2(indexFromPosition1, indexFromPosition2);
  }

  public class HighlightRule
  {
    public Regex regex;
    public Font font;
    public Color color;
    public Color bgColor;

    public HighlightRule(Regex A_0, Font A_1, Color A_2, Color A_3)
    {
      this.regex = A_0;
      this.font = A_1;
      this.color = A_2;
      this.bgColor = A_3;
    }
  }
}
