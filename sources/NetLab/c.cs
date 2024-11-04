// Decompiled with JetBrains decompiler
// Type: c
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
internal class c : Form
{
  private IContainer a;
  private PictureBox b;
  private Button c;
  private Label d;
  private Panel e;
  private Label f;
  private Label g;

  public c() => this.a();

  [SpecialName]
  public string g()
  {
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
    if (customAttributes.Length != 0)
    {
      AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
      if (assemblyTitleAttribute.Title != "")
        return assemblyTitleAttribute.Title;
    }
    return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
  }

  [SpecialName]
  public string f() => Assembly.GetExecutingAssembly().GetName().Version.ToString();

  [SpecialName]
  public string e()
  {
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
    return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
  }

  [SpecialName]
  public string d()
  {
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
    return customAttributes.Length == 0 ? "" : ((AssemblyProductAttribute) customAttributes[0]).Product;
  }

  [SpecialName]
  public string c()
  {
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
    return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
  }

  [SpecialName]
  public string b()
  {
    object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
    return customAttributes.Length == 0 ? "" : ((AssemblyCompanyAttribute) customAttributes[0]).Company;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.a != null)
      this.a.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.b = new PictureBox();
    this.c = new Button();
    this.d = new Label();
    this.e = new Panel();
    this.f = new Label();
    this.g = new Label();
    ((ISupportInitialize) this.b).BeginInit();
    this.e.SuspendLayout();
    this.SuspendLayout();
    this.b.Image = (Image) Resources.horse;
    this.b.Location = new Point(3, 3);
    this.b.Name = "pictureBox";
    this.b.Size = new Size(149, 137);
    this.b.SizeMode = PictureBoxSizeMode.StretchImage;
    this.b.TabIndex = 0;
    this.b.TabStop = false;
    this.c.DialogResult = DialogResult.Cancel;
    this.c.Location = new Point((int) sbyte.MaxValue, 171);
    this.c.Name = "button";
    this.c.Size = new Size(75, 23);
    this.c.TabIndex = 1;
    this.c.Text = "ОК";
    this.c.UseVisualStyleBackColor = true;
    this.d.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
    this.d.Location = new Point(158, 21);
    this.d.Name = "label1";
    this.d.Size = new Size(159, 23);
    this.d.TabIndex = 2;
    this.d.Text = "NetLab";
    this.d.TextAlign = ContentAlignment.MiddleCenter;
    this.e.BorderStyle = BorderStyle.Fixed3D;
    this.e.Controls.Add((Control) this.f);
    this.e.Controls.Add((Control) this.g);
    this.e.Controls.Add((Control) this.d);
    this.e.Controls.Add((Control) this.b);
    this.e.Location = new Point(8, 9);
    this.e.Name = "panel1";
    this.e.Size = new Size(324, 147);
    this.e.TabIndex = 3;
    this.f.Location = new Point(158, 72);
    this.f.Name = "label3";
    this.f.Size = new Size(158, 23);
    this.f.TabIndex = 4;
    this.f.Text = "Версия";
    this.f.TextAlign = ContentAlignment.MiddleCenter;
    this.g.Location = new Point(158, 95);
    this.g.Name = "label2";
    this.g.Size = new Size(159, 23);
    this.g.TabIndex = 3;
    this.g.Text = "1.8.6.24";
    this.g.TextAlign = ContentAlignment.MiddleCenter;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.CancelButton = (IButtonControl) this.c;
    this.ClientSize = new Size(345, 209);
    this.Controls.Add((Control) this.c);
    this.Controls.Add((Control) this.e);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = "AboutBox";
    this.Padding = new Padding(9);
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterParent;
    this.Text = "О программе";
    ((ISupportInitialize) this.b).EndInit();
    this.e.ResumeLayout(false);
    this.ResumeLayout(false);
  }
}
