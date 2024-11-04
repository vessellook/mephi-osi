// Decompiled with JetBrains decompiler
// Type: n
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using Ionic.Zip;
using Ionic.Zlib;
using NetLab.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

#nullable disable
public class n : Form
{
  private int a;
  private string b;
  private DateTime c;
  private IContainer d;
  private RichTextBox e;

  public n(int A_0, string A_1)
  {
    this.a();
    this.a = A_0;
    this.b = A_1;
  }

  private void a(object A_0, EventArgs A_1)
  {
    try
    {
      using (MemoryStream data = new MemoryStream())
      {
        using (ZipFile zipFile = new ZipFile(Application.StartupPath + "\\materials.dsc"))
        {
          zipFile.CompressionMethod = (CompressionMethod) 8;
          zipFile.CompressionLevel = (CompressionLevel) 6;
          zipFile.Encryption = (EncryptionAlgorithm) 3;
          zipFile.Password = v.af;
          zipFile[this.b].Extract((Stream) data);
          zipFile.Dispose();
        }
        data.Position = 0L;
        this.e.LoadFile((Stream) data, RichTextBoxStreamType.RichText);
        data.Close();
      }
      this.c = DateTime.Now;
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, Resources.ErrorString, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }

  private void a(object A_0, FormClosedEventArgs A_1)
  {
    switch (this.a)
    {
      case 0:
        ++v.q.e;
        v.q.d += DateTime.Now.Subtract(this.c);
        break;
      case 1:
        ++v.q.g;
        v.q.f += DateTime.Now.Subtract(this.c);
        break;
      case 2:
        ++v.q.i;
        v.q.h += DateTime.Now.Subtract(this.c);
        break;
      case 3:
        ++v.q.k;
        v.q.j += DateTime.Now.Subtract(this.c);
        break;
      case 4:
        ++v.q.m;
        v.q.l += DateTime.Now.Subtract(this.c);
        break;
      case 5:
        ++v.q.o;
        v.q.n += DateTime.Now.Subtract(this.c);
        break;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.d != null)
      this.d.Dispose();
    base.Dispose(disposing);
  }

  private void a()
  {
    this.e = new RichTextBox();
    this.SuspendLayout();
    this.e.Dock = DockStyle.Fill;
    this.e.Location = new Point(0, 0);
    this.e.Name = "richTextBox";
    this.e.ReadOnly = true;
    this.e.Size = new Size(625, 474);
    this.e.TabIndex = 0;
    this.e.Text = "Идет загрузка...";
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(625, 474);
    this.Controls.Add((Control) this.e);
    this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
    this.Name = "MaterialViewerForm";
    this.FormClosed += new FormClosedEventHandler(this.a);
    this.Shown += new EventHandler(this.a);
    this.ResumeLayout(false);
  }
}
