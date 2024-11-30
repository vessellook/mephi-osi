// Decompiled with JetBrains decompiler
// Type: an
// Assembly: NetLab, Version=1.8.5.0, Culture=neutral, PublicKeyToken=null
// MVID: 87818B4C-12CA-4939-BAF2-FEB995E726E0
// Assembly location: C:\Program Files (x86)\МИФИ\NetLabSetup\NetLab.exe

using NetLab.Properties;
using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

public class EmulationRuntime
{
  private StreamWriter streamWriter;
  public static int e;
  public static bool f;
  private MainWindow mainWindow;
  public int h;
  private int time;
  private ArrayList j;
  public static Random rand;

  [CompilerGenerated]
  [SpecialName]
  public Participant GetSystemA() => this.systemA;

  [CompilerGenerated]
  [SpecialName]
  public void SetSystemA(Participant participant) => this.systemA = participant;

  [CompilerGenerated]
  [SpecialName]
  public Participant GetGuide() => this.guide;

  [CompilerGenerated]
  [SpecialName]
  public void SetGuide(Participant participant) => this.guide = participant;

  [CompilerGenerated]
  [SpecialName]
  public Participant GetSystemB() => this.systemB;

  [CompilerGenerated]
  [SpecialName]
  public void SetSystemB(Participant participant) => this.systemB = participant;

  [SpecialName]
  public int NextTime()
  {
    ++this.time;
    return this.time;
  }

  [SpecialName]
  public void SetTime(int time) => this.time = time;

  public EmulationRuntime(MainWindow mainWindow)
  {
    EmulationRuntime.rand = new Random();
    this.mainWindow = mainWindow;
    this.SetSystemA(new Participant("SystemA", Convert.ToByte(EmulationRuntime.rand.Next(1, 128)), this.mainWindow, this));
    this.SetGuide(new Participant("Guide", byte.MaxValue, this.mainWindow, this));
    this.SetSystemB(new Participant("SystemB", Convert.ToByte(EmulationRuntime.rand.Next(128, (int) byte.MaxValue)), this.mainWindow, this));
    this.h = 0;
    this.SetTime(0);
    this.j = new ArrayList();
  }

  public void AddToLog(string A_0)
  {
    this.streamWriter.WriteLine("[" + this.h.ToString() + "] " + A_0);
    if (!MainWindow.m)
      return;
    this.mainWindow.AddToLog("[" + this.h.ToString() + "] " + A_0);
  }

  public int a(string A_0, SortedList A_1, string A_2, Participant A_3, int A_4, int A_5)
  {
    ah ah = new ah(A_0, A_1, A_2, A_3, A_4, 0);
    for (int index = 0; index < this.j.Count; ++index)
    {
      if ((this.j[index] as ah).b() == A_5)
        ah.a(A_5);
    }
    if (ah.b() == 0)
      ah.a(this.NextTime());
    this.j.Add((object) ah);
    return ah.b();
  }

  public void a(int A_0)
  {
    for (int index = 0; index < this.j.Count; ++index)
    {
      if ((this.j[index] as ah).b() == A_0)
        (this.j[index] as ah).a(true);
    }
  }

  public void startEmulation(string A_0)
  {
    try
    {
      using (this.streamWriter = File.CreateText(A_0))
      {
        try
        {
          this.GetSystemA().GetNetworkLayer().Init();
          this.GetSystemA().GetTransportLayer().Init();
          this.GetSystemA().GetSessionLayer().Init();
          this.GetSystemA().GetPresentationLayer().Init();
          this.GetSystemA().GetApplicationLayer().Init();
          this.GetSystemA().GetUELayer().Init();
          this.GetSystemA().GetProcessLayer().Init();
          this.GetGuide().GetNetworkLayer().Init();
          this.GetGuide().GetTransportLayer().Init();
          this.GetGuide().GetSessionLayer().Init();
          this.GetGuide().GetPresentationLayer().Init();
          this.GetGuide().GetApplicationLayer().Init();
          this.GetGuide().GetUELayer().Init();
          this.GetGuide().GetProcessLayer().Init();
          this.GetSystemB().GetNetworkLayer().Init();
          this.GetSystemB().GetTransportLayer().Init();
          this.GetSystemB().GetSessionLayer().Init();
          this.GetSystemB().GetPresentationLayer().Init();
          this.GetSystemB().GetApplicationLayer().Init();
          this.GetSystemB().GetUELayer().Init();
          this.GetSystemB().GetProcessLayer().Init();
          this.AddToLog(Resources.EmulationStarted);
          this.GetSystemA().b("NetworkEmulator", "N_INIT.REQ", (SortedList) null);
          this.GetGuide().b("NetworkEmulator", "N_INIT.REQ", (SortedList) null);
          this.GetSystemB().b("NetworkEmulator", "N_INIT.REQ", (SortedList) null);
          EmulationRuntime.f = false;
          while (this.j.Count > 0)
          {
            for (int index = this.j.Count - 1; index >= 0; --index)
            {
              if ((this.j[index] as ah).a())
                this.j.RemoveAt(index);
            }
            Application.DoEvents();
            if (EmulationRuntime.e == 6)
            {
              this.AddToLog(Resources.EmulationCancelled);
              this.j.Clear();
            }
            ++this.h;
            for (int index1 = this.j.Count - 1; index1 >= 0; --index1)
            {
              if ((this.j[index1] as ah).c() <= this.h)
              {
                if (EmulationRuntime.e > 0 && (this.j[index1] as ah).g().Length > 1 && (this.j[index1] as ah).g()[1] == '_' && ((this.j[index1] as ah).g().EndsWith(".IND") || (this.j[index1] as ah).g().EndsWith(".CONF")))
                {
                  this.mainWindow.debuggerWindow.ap.Text = (this.j[index1] as ah).g();
                  switch ((this.j[index1] as ah).d().b())
                  {
                    case "SystemA":
                      this.mainWindow.debuggerWindow.ap.Left = 60 - this.mainWindow.debuggerWindow.ap.Width / 2;
                      break;
                    case "Guide":
                      this.mainWindow.debuggerWindow.ap.Left = 175 - this.mainWindow.debuggerWindow.ap.Width / 2;
                      break;
                    case "SystemB":
                      this.mainWindow.debuggerWindow.ap.Left = 290 - this.mainWindow.debuggerWindow.ap.Width / 2;
                      break;
                  }
                  string str = (this.j[index1] as ah).e();
                  if (str != null)
                  {
                    switch (str.Length)
                    {
                      case 2:
                        if (str == "UE")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 85;
                          break;
                        }
                        break;
                      case 7:
                        switch (str[0])
                        {
                          case 'N':
                            if (str == "Network")
                            {
                              this.mainWindow.debuggerWindow.ap.Top = 285;
                              break;
                            }
                            break;
                          case 'P':
                            if (str == "Process")
                            {
                              this.mainWindow.debuggerWindow.ap.Top = 45;
                              break;
                            }
                            break;
                          case 'S':
                            if (str == "Session")
                            {
                              this.mainWindow.debuggerWindow.ap.Top = 205;
                              break;
                            }
                            break;
                        }
                        break;
                      case 9:
                        if (str == "Transport")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 245;
                          break;
                        }
                        break;
                      case 11:
                        if (str == "Application")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 125;
                          break;
                        }
                        break;
                      case 12:
                        if (str == "Presentation")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 165;
                          break;
                        }
                        break;
                    }
                  }
                  for (int index2 = 0; index2 < 37; ++index2)
                  {
                    --this.mainWindow.debuggerWindow.ap.Top;
                    this.mainWindow.debuggerWindow.Update();
                    Application.DoEvents();
                    Thread.Sleep(MainWindow.ag);
                  }
                }
                else if (EmulationRuntime.e > 0 && (this.j[index1] as ah).g().Length > 1 && (this.j[index1] as ah).g()[1] == '_' && ((this.j[index1] as ah).g().EndsWith(".REQ") || (this.j[index1] as ah).g().EndsWith(".RESP")))
                {
                  this.mainWindow.debuggerWindow.ap.Text = (this.j[index1] as ah).g();
                  switch ((this.j[index1] as ah).d().b())
                  {
                    case "SystemA":
                      this.mainWindow.debuggerWindow.ap.Left = 60 - this.mainWindow.debuggerWindow.ap.Width / 2;
                      break;
                    case "Guide":
                      this.mainWindow.debuggerWindow.ap.Left = 175 - this.mainWindow.debuggerWindow.ap.Width / 2;
                      break;
                    case "SystemB":
                      this.mainWindow.debuggerWindow.ap.Left = 290 - this.mainWindow.debuggerWindow.ap.Width / 2;
                      break;
                  }
                  string str = (this.j[index1] as ah).e();
                  if (str != null)
                  {
                    switch (str.Length)
                    {
                      case 2:
                        if (str == "UE")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 45;
                          break;
                        }
                        break;
                      case 7:
                        switch (str[0])
                        {
                          case 'N':
                            if (str == "Network")
                            {
                              this.mainWindow.debuggerWindow.ap.Top = 205;
                              break;
                            }
                            break;
                          case 'P':
                            if (str == "Process")
                            {
                              this.mainWindow.debuggerWindow.ap.Top = 45;
                              break;
                            }
                            break;
                          case 'S':
                            if (str == "Session")
                            {
                              this.mainWindow.debuggerWindow.ap.Top = 125;
                              break;
                            }
                            break;
                        }
                        break;
                      case 9:
                        if (str == "Transport")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 165;
                          break;
                        }
                        break;
                      case 11:
                        if (str == "Application")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 45;
                          break;
                        }
                        break;
                      case 12:
                        if (str == "Presentation")
                        {
                          this.mainWindow.debuggerWindow.ap.Top = 85;
                          break;
                        }
                        break;
                    }
                  }
                  for (int index3 = 0; index3 < 37; ++index3)
                  {
                    ++this.mainWindow.debuggerWindow.ap.Top;
                    this.mainWindow.debuggerWindow.Update();
                    Application.DoEvents();
                    Thread.Sleep(MainWindow.ag);
                  }
                }
                this.mainWindow.debuggerWindow.ap.Text = "";
                (this.j[index1] as ah).d().b((this.j[index1] as ah).e(), (this.j[index1] as ah).g(), (this.j[index1] as ah).f());
                this.j.RemoveAt(index1);
              }
            }
          }
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ex.Message, "NetLab", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
        finally
        {
          this.AddToLog(Resources.EmulationEnded);
          this.streamWriter.Close();
          this.GetSystemA().GetNetworkLayer().e.Clear();
          this.GetSystemA().GetNetworkLayer().f.Clear();
          this.GetSystemA().GetTransportLayer().e.Clear();
          this.GetSystemA().GetTransportLayer().f.Clear();
          this.GetSystemA().GetSessionLayer().e.Clear();
          this.GetSystemA().GetSessionLayer().f.Clear();
          this.GetSystemA().GetPresentationLayer().e.Clear();
          this.GetSystemA().GetPresentationLayer().f.Clear();
          this.GetSystemA().GetApplicationLayer().e.Clear();
          this.GetSystemA().GetApplicationLayer().f.Clear();
          this.GetSystemA().GetUELayer().e.Clear();
          this.GetSystemA().GetUELayer().f.Clear();
          this.GetSystemA().GetProcessLayer().e.Clear();
          this.GetSystemA().GetProcessLayer().f.Clear();
          this.GetGuide().GetNetworkLayer().e.Clear();
          this.GetGuide().GetNetworkLayer().f.Clear();
          this.GetGuide().GetTransportLayer().e.Clear();
          this.GetGuide().GetTransportLayer().f.Clear();
          this.GetGuide().GetSessionLayer().e.Clear();
          this.GetGuide().GetSessionLayer().f.Clear();
          this.GetGuide().GetPresentationLayer().e.Clear();
          this.GetGuide().GetPresentationLayer().f.Clear();
          this.GetGuide().GetApplicationLayer().e.Clear();
          this.GetGuide().GetApplicationLayer().f.Clear();
          this.GetGuide().GetUELayer().e.Clear();
          this.GetGuide().GetUELayer().f.Clear();
          this.GetGuide().GetProcessLayer().e.Clear();
          this.GetGuide().GetProcessLayer().f.Clear();
          this.GetSystemB().GetNetworkLayer().e.Clear();
          this.GetSystemB().GetNetworkLayer().f.Clear();
          this.GetSystemB().GetTransportLayer().e.Clear();
          this.GetSystemB().GetTransportLayer().f.Clear();
          this.GetSystemB().GetSessionLayer().e.Clear();
          this.GetSystemB().GetSessionLayer().f.Clear();
          this.GetSystemB().GetPresentationLayer().e.Clear();
          this.GetSystemB().GetPresentationLayer().f.Clear();
          this.GetSystemB().GetApplicationLayer().e.Clear();
          this.GetSystemB().GetApplicationLayer().f.Clear();
          this.GetSystemB().GetUELayer().e.Clear();
          this.GetSystemB().GetUELayer().f.Clear();
          this.GetSystemB().GetProcessLayer().e.Clear();
          this.GetSystemB().GetProcessLayer().f.Clear();
          this.h = 0;
          this.time = 0;
          this.j.Clear();
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(ex.Message, "NetLab", MessageBoxButtons.OK, MessageBoxIcon.Hand);
    }
  }
}
