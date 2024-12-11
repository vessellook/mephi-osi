// Decompiled with JetBrains decompiler
// Type: j
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

public class EditorWindow : Form
{
  private global::aj[] a;
  private DateTime b;
  private global::EmulationRuntime an;
  private bool insertMode;
  private global::SyntaxHighlighter e;
  private ArrayList states2 = new ArrayList();
  private Stack states = new Stack();
  private bool mutexMaybe;
  private global::EditorWindow.EditorState currentState = new global::EditorWindow.EditorState("", 0);
  private int j = 50;
  private IContainer k;
  private MenuStrip mainMenu;
  private StatusStrip statusBar;
  private ToolStrip toolBar;
  private RichTextBox codeEditor;
  private ToolStripStatusLabel lineColumnPanel;
  private ToolStripMenuItem editMenu;
  private ToolStripMenuItem undoMenuItem;
  private ToolStripMenuItem redoMenuItem;
  private ToolStripSeparator toolStripSeparator1;
  private ToolStripMenuItem cutMenuItem;
  private ToolStripMenuItem copyMenuItem;
  private ToolStripMenuItem pasteMenuItem;
  private ToolStripMenuItem selectAllMenuItem;
  private ToolStripButton undoToolButton;
  private ToolStripButton redoButton;
  private ToolStripSeparator toolStripSeparator2;
  private ToolStripButton cutToolButton;
  private ToolStripButton copyToolButton;
  private ToolStripButton pasteToolButton;
  private ToolStripSeparator toolStripSeparator3;
  private ToolStripStatusLabel statusPanel;
  private ToolStripStatusLabel numlockStatusPanel;
  private ToolStripStatusLabel capslockStatusPanel;
  private ToolStripStatusLabel insStatusPanel;
  private ToolStripStatusLabel timeStatusPanel;
  private Timer timer;
  private ToolStripMenuItem helpMenu;
  private ToolStripMenuItem toolMenu;
  private ToolStripMenuItem upToolStripMenuItem;
  private ToolStripMenuItem downToolStripMenuItem;
  private ToolStripButton helptoolStripButton;

  [SpecialName]
  private bool States2HasSomething() => this.states2.Count > 0;

  [SpecialName]
  private bool StatesHasSomething() => this.states.Count > 0;

  private void ClearStates2()
  {
    while (this.states2.Count > this.j)
      this.states2.RemoveAt(this.j);
  }

  private void Undo()
  {
    if (!this.States2HasSomething())
      return;
    this.mutexMaybe = true;
    this.states.Push((object) new global::EditorWindow.EditorState(this.codeEditor.Text, this.codeEditor.SelectionStart));
    global::EditorWindow.EditorState state = (global::EditorWindow.EditorState) this.states2[0];
    this.states2.RemoveAt(0);
    this.codeEditor.Text = state.Text;
    this.codeEditor.SelectionStart = state.CursorPosition;
    this.currentState = state;
    this.mutexMaybe = false;
  }

  private void Redo()
  {
    if (!this.StatesHasSomething())
      return;
    this.mutexMaybe = true;
    this.states2.Insert(0, (object) new global::EditorWindow.EditorState(this.codeEditor.Text, this.codeEditor.SelectionStart));
    this.ClearStates2();
    global::EditorWindow.EditorState state = (global::EditorWindow.EditorState) this.states.Pop();
    this.codeEditor.Text = state.Text;
    this.codeEditor.SelectionStart = state.CursorPosition;
    this.mutexMaybe = false;
  }

  public EditorWindow(global::aj[] A_0, global::EmulationRuntime an)
  {
    this.Initialize();
    this.b = new DateTime();
    this.a = A_0;
    this.Text = this.a[0].o();
    string[] strArray = new string[this.a[0].k().Count];
    this.a[0].k().CopyTo((Array) strArray);
    this.codeEditor.Lines = strArray;
    this.codeEditor.SelectionStart = this.a[0].f();
    this.an = an;
    this.insertMode = false;
    this.e = new global::SyntaxHighlighter(this.codeEditor);
    string[] array = new string[22]
    {
      "buffer",
      "copy",
      "delete",
      "dequeue",
      "peek",
      "down",
      "up",
      "goto",
      "if",
      "out",
      "pos",
      "qcount",
      "queue",
      "clearqueue",
      "sizeof",
      "timer",
      "unbuffer",
      "untimer",
      "crc",
      "set",
      "declare",
      "random"
    };
    for (int index = 0; index < global::MainWindow.baseKeywords.Count; ++index)
      array[Array.IndexOf<object>((object[]) array, global::MainWindow.baseKeywords[index])] = (string) global::MainWindow.keywords[index];
    try
    {
      using (XmlReader xmlReader = XmlReader.Create(Application.StartupPath + "\\highlightrules.xml"))
      {
        TypeConverter converter1 = TypeDescriptor.GetConverter(typeof (Font));
        TypeConverter converter2 = TypeDescriptor.GetConverter(typeof (Color));
        xmlReader.ReadStartElement("rules");
        xmlReader.ReadStartElement("forbiddenoperators");
        string pattern1 = xmlReader.ReadElementString("Regex").Replace("operators", string.Join("|", (string[]) global::MainWindow.baseKeywords.ToArray(typeof (string))) + "|" + string.Join("|", (string[]) global::MainWindow.ae.ToArray(typeof (string))));
        string text1 = xmlReader.ReadElementString("font");
        Font A_1_1 = (Font) converter1.ConvertFromString(text1);
        string text2 = xmlReader.ReadElementString("color");
        Color A_2_1 = (Color) converter2.ConvertFromString(text2);
        string text3 = xmlReader.ReadElementString("BGcolor");
        Color A_3_1 = (Color) converter2.ConvertFromString(text3);
        this.e.e.Add(new global::SyntaxHighlighter.HighlightRule(new Regex(pattern1, RegexOptions.Multiline), A_1_1, A_2_1, A_3_1));
        xmlReader.ReadEndElement();
        xmlReader.ReadStartElement("operators");
        string pattern2 = xmlReader.ReadElementString("Regex").Replace("operators", string.Join("|", array));
        string text4 = xmlReader.ReadElementString("font");
        Font A_1_2 = (Font) converter1.ConvertFromString(text4);
        string text5 = xmlReader.ReadElementString("color");
        Color A_2_2 = (Color) converter2.ConvertFromString(text5);
        string text6 = xmlReader.ReadElementString("BGcolor");
        Color A_3_2 = (Color) converter2.ConvertFromString(text6);
        this.e.e.Add(new global::SyntaxHighlighter.HighlightRule(new Regex(pattern2, RegexOptions.Multiline), A_1_2, A_2_2, A_3_2));
        xmlReader.ReadEndElement();
        while (xmlReader.IsStartElement())
        {
          xmlReader.ReadStartElement();
          string pattern3 = xmlReader.ReadElementString("Regex");
          string text7 = xmlReader.ReadElementString("font");
          Font A_1_3 = (Font) converter1.ConvertFromString(text7);
          string text8 = xmlReader.ReadElementString("color");
          Color A_2_3 = (Color) converter2.ConvertFromString(text8);
          string text9 = xmlReader.ReadElementString("BGcolor");
          Color A_3_3 = (Color) converter2.ConvertFromString(text9);
          this.e.e.Add(new global::SyntaxHighlighter.HighlightRule(new Regex(pattern3, RegexOptions.Multiline), A_1_3, A_2_3, A_3_3));
          xmlReader.ReadEndElement();
        }
        xmlReader.ReadEndElement();
        xmlReader.Close();
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorLoadSyntaxHighlight, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void OnShown(object A_0, EventArgs A_1)
  {
    this.b = DateTime.Now;
    if (!global::MainWindow.o && this.a[0].g() + this.a[0].i() + this.a[0].j() + this.a[0].h() > 0)
    {
      this.Height = this.a[0].g();
      this.Left = this.a[0].i();
      this.Top = this.a[0].j();
      this.Width = this.a[0].h();
    }
    else
    {
      this.Height = global::MainWindow.k;
      this.Width = global::MainWindow.l;
      this.Left = global::MainWindow.i;
      this.Top = global::MainWindow.j;
    }
    this.timer.Enabled = true;
    this.codeEditor.BackColor = global::MainWindow.backColor;
    this.mutexMaybe = true;
    this.codeEditor.Font = global::MainWindow.font;
    this.currentState = new global::EditorWindow.EditorState(this.codeEditor.Text, this.codeEditor.SelectionStart);
    this.mutexMaybe = false;
    this.downToolStripMenuItem.Checked = this.statusBar.Visible;
    this.upToolStripMenuItem.Checked = this.toolBar.Visible;
    this.e.d_func();
    this.e.b_func();
    this.e.c_func();
  }

  private void b_func()
  {
    for (int index1 = 0; index1 < this.a.Length; ++index1)
    {
      this.a[index1].c(this.codeEditor.SelectionStart);
      this.a[index1].k().Clear();
      this.a[index1].l().Clear();
      for (int index2 = 0; index2 < this.codeEditor.Lines.Length; ++index2)
      {
        this.a[index1].k().Add((object) this.codeEditor.Lines[index2]);
        global::MainWindow.syntaxErrorFlag = 0;
        global::MainWindow.baseSyntaxErrorFlag = 0;
        global::MainWindow.forbiddenWordFlag = 0;
        this.a[index1].l().Add((object) global::SyntaxUtils.ConvertToBaseSyntax(this.codeEditor.Lines[index2], (int) this.a[0].b()));
        if (global::MainWindow.baseSyntaxErrorFlag > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorBaseSyntax + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
        if (global::MainWindow.forbiddenWordFlag > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorForbiddenWord + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          return;
        }
        if (global::MainWindow.syntaxErrorFlag > 0 && MessageBox.Show(Resources.ErrorPossibleSyntaxError + (index2 + 1).ToString() + Resources.MsgIgnore, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
          return;
      }
      global::aj aj = this.a[index1];
      aj.b(aj.d() + 1);
      if (this.states2.Count > 0)
        global::MainWindow.ak = true;
    }
  }

  private void OnFormClosing(object A_0, FormClosingEventArgs A_1)
  {
    for (int index1 = 0; index1 < this.a.Length; ++index1)
    {
      this.a[index1].c(this.codeEditor.SelectionStart);
      this.a[index1].k().Clear();
      this.a[index1].l().Clear();
      for (int index2 = 0; index2 < this.codeEditor.Lines.Length; ++index2)
      {
        this.a[index1].k().Add((object) this.codeEditor.Lines[index2]);
        global::MainWindow.syntaxErrorFlag = 0;
        global::MainWindow.baseSyntaxErrorFlag = 0;
        global::MainWindow.forbiddenWordFlag = 0;
        this.a[index1].l().Add((object) global::SyntaxUtils.ConvertToBaseSyntax(this.codeEditor.Lines[index2], (int) this.a[0].b()));
        if (global::MainWindow.baseSyntaxErrorFlag > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorBaseSyntax + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          A_1.Cancel = true;
          return;
        }
        if (global::MainWindow.forbiddenWordFlag > 0)
        {
          int num = (int) MessageBox.Show(Resources.ErrorForbiddenWord + (index2 + 1).ToString(), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
          A_1.Cancel = true;
          return;
        }
        if (global::MainWindow.syntaxErrorFlag > 0 && MessageBox.Show(Resources.ErrorPossibleSyntaxError + (index2 + 1).ToString() + Resources.MsgIgnore, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        {
          A_1.Cancel = true;
          return;
        }
      }
      this.a[index1].a(DateTime.Now);
      global::aj aj1 = this.a[index1];
      aj1.b(aj1.d() + 1);
      global::aj aj2 = this.a[index1];
      aj2.a(aj2.c() + (DateTime.Now - this.b).Seconds);
      string A_0_1 = "";
      for (int index3 = 0; index3 < this.a[index1].l().Count; ++index3)
      {
        string A_0_2 = (string) this.a[index1].l()[index3];
        global::SyntaxUtils.TrimLeftSpaces(ref A_0_2);
        string str = global::SyntaxUtils.SeparateNextNonSpecialSequence(ref A_0_2);
        if (str.Length > 0 && str[str.Length - 1] == ':')
          str = global::SyntaxUtils.SeparateNextNonSpecialSequence(ref A_0_2);
        A_0_1 += str;
      }
      this.a[index1].m = global::l.a(A_0_1);
      if (this.WindowState != FormWindowState.Normal)
        this.WindowState = FormWindowState.Normal;
      this.a[index1].d(this.Height);
      this.a[index1].f(this.Left);
      this.a[index1].g(this.Top);
      this.a[index1].e(this.Width);
      this.timer.Enabled = false;
      if (this.states2.Count > 0)
        global::MainWindow.ak = true;
    }
  }

  private void OnKeyDown(object A_0, KeyEventArgs A_1)
  {
    switch (A_1.KeyCode)
    {
      case Keys.Escape:
        this.Close();
        break;
      case Keys.Insert:
        this.insertMode = !this.insertMode;
        break;
      case Keys.S:
        if (A_1.Modifiers != Keys.Control)
          break;
        this.b_func();
        break;
    }
  }

  private void OnTimerTick(object A_0, EventArgs A_1)
  {
    ToolStripStatusLabel p = this.lineColumnPanel;
    int num = this.codeEditor.GetLineFromCharIndex(this.codeEditor.SelectionStart) + 1;
    string str1 = num.ToString();
    num = this.codeEditor.SelectionStart - this.codeEditor.GetFirstCharIndexFromLine(this.codeEditor.GetLineFromCharIndex(this.codeEditor.SelectionStart)) + 1;
    string str2 = num.ToString();
    string str3 = "c: " + str1 + " к: " + str2;
    p.Text = str3;
    this.timeStatusPanel.Text = DateTime.Now.ToString();
    this.capslockStatusPanel.Enabled = Control.IsKeyLocked(Keys.Capital);
    this.numlockStatusPanel.Enabled = Control.IsKeyLocked(Keys.NumLock);
    this.insStatusPanel.Enabled = this.insertMode;
  }

  private void OnHelpMenuClick(object A_0, EventArgs A_1) => Help.ShowHelp((Control) this, global::MainWindow.helpPath);

  private void OnHelptoolStripButtonClick(object A_0, EventArgs A_1) => this.helpMenu.PerformClick();

  private void OnUpToolStripMenuItemClick(object A_0, EventArgs A_1) => this.toolBar.Visible = this.upToolStripMenuItem.Checked;

  private void OnDownToolStripMenuItemClick(object A_0, EventArgs A_1) => this.statusBar.Visible = this.downToolStripMenuItem.Checked;

  private void OnSelectAllMenuItemClick(object A_0, EventArgs A_1) => this.codeEditor.SelectAll();

  private void OnUndoMenuItemClick(object A_0, EventArgs A_1) => this.Undo();

  private void OnRedoMenuItemClick(object A_0, EventArgs A_1) => this.Redo();

  private void OnCopyMenuItemClick(object A_0, EventArgs A_1) => this.codeEditor.Copy();

  private void OnPasteMenuItemClick(object A_0, EventArgs A_1) => this.codeEditor.Paste();

  private void OnCutMenuItemClick(object A_0, EventArgs A_1) => this.codeEditor.Cut();

  private void OnTextChange(object A_0, EventArgs A_1)
  {
    if (!this.mutexMaybe)
    {
      this.states.Clear();
      this.states2.Insert(0, (object) this.currentState);
      this.ClearStates2();
      this.currentState = new global::EditorWindow.EditorState(this.codeEditor.Text, this.codeEditor.SelectionStart);
    }
    this.e.d_func();
    this.e.b_func();
    this.e.c_func();
  }

  private void OnLoad(object A_0, EventArgs A_1)
  {
  }

  private void OnPasteToolButtonClick(object A_0, EventArgs A_1) => this.pasteMenuItem.PerformClick();

  private void OnCopyToolButtonClick(object A_0, EventArgs A_1) => this.copyMenuItem.PerformClick();

  private void OnCutToolButtonClick(object A_0, EventArgs A_1) => this.cutMenuItem.PerformClick();

  private void OnUndoButtonClick(object A_0, EventArgs A_1) => this.undoMenuItem.PerformClick();

  private void OnRedoButtonClick(object A_0, EventArgs A_1) => this.redoMenuItem.PerformClick();

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.k != null)
      this.k.Dispose();
    base.Dispose(disposing);
  }

  private void Initialize()
  {
    this.k = (IContainer) new System.ComponentModel.Container();
    this.mainMenu = new MenuStrip();
    this.editMenu = new ToolStripMenuItem();
    this.undoMenuItem = new ToolStripMenuItem();
    this.redoMenuItem = new ToolStripMenuItem();
    this.toolStripSeparator1 = new ToolStripSeparator();
    this.cutMenuItem = new ToolStripMenuItem();
    this.copyMenuItem = new ToolStripMenuItem();
    this.pasteMenuItem = new ToolStripMenuItem();
    this.selectAllMenuItem = new ToolStripMenuItem();
    this.toolMenu = new ToolStripMenuItem();
    this.upToolStripMenuItem = new ToolStripMenuItem();
    this.downToolStripMenuItem = new ToolStripMenuItem();
    this.helpMenu = new ToolStripMenuItem();
    this.statusBar = new StatusStrip();
    this.lineColumnPanel = new ToolStripStatusLabel();
    this.statusPanel = new ToolStripStatusLabel();
    this.numlockStatusPanel = new ToolStripStatusLabel();
    this.capslockStatusPanel = new ToolStripStatusLabel();
    this.insStatusPanel = new ToolStripStatusLabel();
    this.timeStatusPanel = new ToolStripStatusLabel();
    this.toolBar = new ToolStrip();
    this.undoToolButton = new ToolStripButton();
    this.redoButton = new ToolStripButton();
    this.toolStripSeparator2 = new ToolStripSeparator();
    this.cutToolButton = new ToolStripButton();
    this.copyToolButton = new ToolStripButton();
    this.pasteToolButton = new ToolStripButton();
    this.toolStripSeparator3 = new ToolStripSeparator();
    this.helptoolStripButton = new ToolStripButton();
    this.codeEditor = new RichTextBox();
    this.timer = new Timer(this.k);
    this.mainMenu.SuspendLayout();
    this.statusBar.SuspendLayout();
    this.toolBar.SuspendLayout();
    this.SuspendLayout();
    this.mainMenu.Items.AddRange(new ToolStripItem[3]
    {
      (ToolStripItem) this.editMenu,
      (ToolStripItem) this.toolMenu,
      (ToolStripItem) this.helpMenu
    });
    this.mainMenu.Location = new Point(0, 0);
    this.mainMenu.Name = "MainMenu";
    this.mainMenu.Size = new Size(661, 24);
    this.mainMenu.TabIndex = 0;
    this.editMenu.DropDownItems.AddRange(new ToolStripItem[7]
    {
      (ToolStripItem) this.undoMenuItem,
      (ToolStripItem) this.redoMenuItem,
      (ToolStripItem) this.toolStripSeparator1,
      (ToolStripItem) this.cutMenuItem,
      (ToolStripItem) this.copyMenuItem,
      (ToolStripItem) this.pasteMenuItem,
      (ToolStripItem) this.selectAllMenuItem
    });
    this.editMenu.Name = "EditMenu";
    this.editMenu.Size = new Size(59, 20);
    this.editMenu.Text = "Правка";
    this.undoMenuItem.Image = (Image) Resources.Undo;
    this.undoMenuItem.Name = "UndoMenuItem";
    this.undoMenuItem.ShortcutKeys = Keys.Z | Keys.Control;
    this.undoMenuItem.Size = new Size(190, 22);
    this.undoMenuItem.Text = "Отменить";
    this.undoMenuItem.Click += new EventHandler(this.OnUndoMenuItemClick);
    this.redoMenuItem.Image = (Image) Resources.Redo;
    this.redoMenuItem.Name = "RedoMenuItem";
    this.redoMenuItem.ShortcutKeys = Keys.Y | Keys.Control;
    this.redoMenuItem.Size = new Size(190, 22);
    this.redoMenuItem.Text = "Повторить";
    this.redoMenuItem.Click += new EventHandler(this.OnRedoMenuItemClick);
    this.toolStripSeparator1.Name = "toolStripSeparator1";
    this.toolStripSeparator1.Size = new Size(187, 6);
    this.cutMenuItem.Image = (Image) Resources.Cut;
    this.cutMenuItem.Name = "CutMenuItem";
    this.cutMenuItem.ShortcutKeys = Keys.X | Keys.Control;
    this.cutMenuItem.Size = new Size(190, 22);
    this.cutMenuItem.Text = "Вырезать";
    this.cutMenuItem.Click += new EventHandler(this.OnCutMenuItemClick);
    this.copyMenuItem.Image = (Image) Resources.Copy;
    this.copyMenuItem.Name = "CopyMenuItem";
    this.copyMenuItem.ShortcutKeys = Keys.C | Keys.Control;
    this.copyMenuItem.Size = new Size(190, 22);
    this.copyMenuItem.Text = "Копировать";
    this.copyMenuItem.Click += new EventHandler(this.OnCopyMenuItemClick);
    this.pasteMenuItem.Image = (Image) Resources.Paste;
    this.pasteMenuItem.Name = "PasteMenuItem";
    this.pasteMenuItem.ShortcutKeys = Keys.V | Keys.Control;
    this.pasteMenuItem.Size = new Size(190, 22);
    this.pasteMenuItem.Text = "Вставить";
    this.pasteMenuItem.Click += new EventHandler(this.OnPasteMenuItemClick);
    this.selectAllMenuItem.Name = "SelectAllMenuItem";
    this.selectAllMenuItem.ShortcutKeys = Keys.A | Keys.Control;
    this.selectAllMenuItem.Size = new Size(190, 22);
    this.selectAllMenuItem.Text = "Выделить все";
    this.selectAllMenuItem.Click += new EventHandler(this.OnSelectAllMenuItemClick);
    this.toolMenu.DropDownItems.AddRange(new ToolStripItem[2]
    {
      (ToolStripItem) this.upToolStripMenuItem,
      (ToolStripItem) this.downToolStripMenuItem
    });
    this.toolMenu.Name = "панельИнструментовToolStripMenuItem";
    this.toolMenu.Size = new Size(141, 20);
    this.toolMenu.Text = "Панель инструментов";
    this.upToolStripMenuItem.CheckOnClick = true;
    this.upToolStripMenuItem.Name = "UpToolStripMenuItem";
    this.upToolStripMenuItem.Size = new Size(118, 22);
    this.upToolStripMenuItem.Text = "Верхняя";
    this.upToolStripMenuItem.Click += new EventHandler(this.OnUpToolStripMenuItemClick);
    this.downToolStripMenuItem.CheckOnClick = true;
    this.downToolStripMenuItem.Name = "DownToolStripMenuItem";
    this.downToolStripMenuItem.Size = new Size(118, 22);
    this.downToolStripMenuItem.Text = "Нижняя";
    this.downToolStripMenuItem.Click += new EventHandler(this.OnDownToolStripMenuItemClick);
    this.helpMenu.Name = "HelpMenu";
    this.helpMenu.ShortcutKeys = Keys.F1;
    this.helpMenu.Size = new Size(65, 20);
    this.helpMenu.Text = "Справка";
    this.helpMenu.Click += new EventHandler(this.OnHelpMenuClick);
    this.statusBar.Items.AddRange(new ToolStripItem[6]
    {
      (ToolStripItem) this.lineColumnPanel,
      (ToolStripItem) this.statusPanel,
      (ToolStripItem) this.numlockStatusPanel,
      (ToolStripItem) this.capslockStatusPanel,
      (ToolStripItem) this.insStatusPanel,
      (ToolStripItem) this.timeStatusPanel
    });
    this.statusBar.Location = new Point(0, 425);
    this.statusBar.Name = "StatusBar";
    this.statusBar.Size = new Size(661, 25);
    this.statusBar.TabIndex = 1;
    this.lineColumnPanel.AutoSize = false;
    this.lineColumnPanel.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.lineColumnPanel.BorderStyle = Border3DStyle.Bump;
    this.lineColumnPanel.Name = "LineColumnPanel";
    this.lineColumnPanel.Size = new Size(75, 20);
    this.lineColumnPanel.Text = "c: 0 к: 0";
    this.statusPanel.AutoSize = false;
    this.statusPanel.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.statusPanel.BorderStyle = Border3DStyle.Bump;
    this.statusPanel.Enabled = false;
    this.statusPanel.Name = "StatusPanel";
    this.statusPanel.Size = new Size(55, 20);
    this.statusPanel.Text = "Изменен";
    this.numlockStatusPanel.AutoSize = false;
    this.numlockStatusPanel.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.numlockStatusPanel.BorderStyle = Border3DStyle.Bump;
    this.numlockStatusPanel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
    this.numlockStatusPanel.Name = "NUMLOCKStatusPanel";
    this.numlockStatusPanel.Size = new Size(50, 20);
    this.numlockStatusPanel.Text = "NUM";
    this.capslockStatusPanel.AutoSize = false;
    this.capslockStatusPanel.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.capslockStatusPanel.BorderStyle = Border3DStyle.Bump;
    this.capslockStatusPanel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
    this.capslockStatusPanel.Name = "CAPSLOCKStatusPanel";
    this.capslockStatusPanel.Size = new Size(50, 20);
    this.capslockStatusPanel.Text = "CAPS";
    this.insStatusPanel.AutoSize = false;
    this.insStatusPanel.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.insStatusPanel.BorderStyle = Border3DStyle.Bump;
    this.insStatusPanel.Font = new Font("Tahoma", 8.25f, FontStyle.Bold);
    this.insStatusPanel.Name = "INSStatusPanel";
    this.insStatusPanel.Size = new Size(50, 20);
    this.insStatusPanel.Text = "INS";
    this.timeStatusPanel.AutoSize = false;
    this.timeStatusPanel.BorderSides = ToolStripStatusLabelBorderSides.All;
    this.timeStatusPanel.BorderStyle = Border3DStyle.Bump;
    this.timeStatusPanel.Name = "TimeStatusPanel";
    this.timeStatusPanel.Size = new Size(120, 20);
    this.toolBar.GripStyle = ToolStripGripStyle.Hidden;
    this.toolBar.Items.AddRange(new ToolStripItem[8]
    {
      (ToolStripItem) this.undoToolButton,
      (ToolStripItem) this.redoButton,
      (ToolStripItem) this.toolStripSeparator2,
      (ToolStripItem) this.cutToolButton,
      (ToolStripItem) this.copyToolButton,
      (ToolStripItem) this.pasteToolButton,
      (ToolStripItem) this.toolStripSeparator3,
      (ToolStripItem) this.helptoolStripButton
    });
    this.toolBar.Location = new Point(0, 24);
    this.toolBar.Name = "ToolBar";
    this.toolBar.Size = new Size(661, 25);
    this.toolBar.TabIndex = 2;
    this.undoToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.undoToolButton.Image = (Image) Resources.Undo;
    this.undoToolButton.ImageScaling = ToolStripItemImageScaling.None;
    this.undoToolButton.ImageTransparentColor = Color.Magenta;
    this.undoToolButton.Margin = new Padding(0, 1, 5, 2);
    this.undoToolButton.Name = "UndoToolButton";
    this.undoToolButton.Size = new Size(23, 22);
    this.undoToolButton.ToolTipText = "Отменить";
    this.undoToolButton.Click += new EventHandler(this.OnUndoButtonClick);
    this.redoButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.redoButton.Image = (Image) Resources.Redo;
    this.redoButton.ImageScaling = ToolStripItemImageScaling.None;
    this.redoButton.ImageTransparentColor = Color.Magenta;
    this.redoButton.Margin = new Padding(0, 1, 5, 2);
    this.redoButton.Name = "RedoButton";
    this.redoButton.Size = new Size(23, 22);
    this.redoButton.ToolTipText = "Повторить";
    this.redoButton.Click += new EventHandler(this.OnRedoButtonClick);
    this.toolStripSeparator2.Margin = new Padding(0, 0, 5, 0);
    this.toolStripSeparator2.Name = "toolStripSeparator2";
    this.toolStripSeparator2.Size = new Size(6, 25);
    this.cutToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.cutToolButton.Image = (Image) Resources.Cut;
    this.cutToolButton.ImageScaling = ToolStripItemImageScaling.None;
    this.cutToolButton.ImageTransparentColor = Color.Magenta;
    this.cutToolButton.Margin = new Padding(0, 1, 5, 2);
    this.cutToolButton.Name = "CutToolButton";
    this.cutToolButton.Size = new Size(23, 22);
    this.cutToolButton.ToolTipText = "Вырезать";
    this.cutToolButton.Click += new EventHandler(this.OnCutToolButtonClick);
    this.copyToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.copyToolButton.Image = (Image) Resources.Copy;
    this.copyToolButton.ImageScaling = ToolStripItemImageScaling.None;
    this.copyToolButton.ImageTransparentColor = Color.Magenta;
    this.copyToolButton.Margin = new Padding(0, 1, 5, 2);
    this.copyToolButton.Name = "CopyToolButton";
    this.copyToolButton.Size = new Size(23, 22);
    this.copyToolButton.ToolTipText = "Копировать";
    this.copyToolButton.Click += new EventHandler(this.OnCopyToolButtonClick);
    this.pasteToolButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.pasteToolButton.Image = (Image) Resources.Paste;
    this.pasteToolButton.ImageScaling = ToolStripItemImageScaling.None;
    this.pasteToolButton.ImageTransparentColor = Color.Magenta;
    this.pasteToolButton.Margin = new Padding(0, 1, 5, 2);
    this.pasteToolButton.Name = "PasteToolButton";
    this.pasteToolButton.Size = new Size(23, 22);
    this.pasteToolButton.ToolTipText = "Вставить";
    this.pasteToolButton.Click += new EventHandler(this.OnPasteToolButtonClick);
    this.toolStripSeparator3.Margin = new Padding(0, 0, 5, 0);
    this.toolStripSeparator3.Name = "toolStripSeparator3";
    this.toolStripSeparator3.Size = new Size(6, 25);
    this.helptoolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
    this.helptoolStripButton.Image = (Image) Resources.help;
    this.helptoolStripButton.ImageTransparentColor = Color.Teal;
    this.helptoolStripButton.Name = "HelptoolStripButton";
    this.helptoolStripButton.Size = new Size(23, 22);
    this.helptoolStripButton.Text = "Справка";
    this.helptoolStripButton.Click += new EventHandler(this.OnHelptoolStripButtonClick);
    this.codeEditor.AcceptsTab = true;
    this.codeEditor.AutoWordSelection = true;
    this.codeEditor.Dock = DockStyle.Fill;
    this.codeEditor.ForeColor = SystemColors.WindowText;
    this.codeEditor.Location = new Point(0, 49);
    this.codeEditor.Name = "CodeEditor";
    this.codeEditor.Size = new Size(661, 376);
    this.codeEditor.TabIndex = 0;
    this.codeEditor.Text = "Ошибка загрузки файла синтаксиса";
    this.codeEditor.WordWrap = false;
    this.codeEditor.TextChanged += new EventHandler(this.OnTextChange);
    this.codeEditor.KeyDown += new KeyEventHandler(this.OnKeyDown);
    this.timer.Interval = 500;
    this.timer.Tick += new EventHandler(this.OnTimerTick);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(661, 450);
    this.Controls.Add((Control) this.codeEditor);
    this.Controls.Add((Control) this.toolBar);
    this.Controls.Add((Control) this.statusBar);
    this.Controls.Add((Control) this.mainMenu);
    this.MainMenuStrip = this.mainMenu;
    this.Name = "EventEditor";
    this.ShowIcon = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.FormClosing += new FormClosingEventHandler(this.OnFormClosing);
    this.Load += new EventHandler(this.OnLoad);
    this.Shown += new EventHandler(this.OnShown);
    this.mainMenu.ResumeLayout(false);
    this.mainMenu.PerformLayout();
    this.statusBar.ResumeLayout(false);
    this.statusBar.PerformLayout();
    this.toolBar.ResumeLayout(false);
    this.toolBar.PerformLayout();
    this.ResumeLayout(false);
    this.PerformLayout();
  }

  private class EditorState
  {
    public readonly int CursorPosition;
    public readonly string Text;

    public EditorState(string A_0, int A_1)
    {
      this.Text = A_0;
      this.CursorPosition = A_1;
    }
  }
}
