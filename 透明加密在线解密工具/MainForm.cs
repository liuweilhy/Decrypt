using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using MyDecrypt;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MainFormNamespace
{

    public partial class MainForm : Form
    {
        // 引用Windows API函数
        #region User32
        // WinForm连个TextBox的CueBanner提示属性都没有
        // 这一点不如MFC的EditBox
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        public const int ECM_FIRST = 0x1500;
        public const int EM_SETCUEBANNER = ECM_FIRST + 1;
        void ApplyCueInfoWin32(TextBox textBox, string text)
        {
            IntPtr handle = textBox.Handle;
            if (handle == IntPtr.Zero)
                return;
            byte[] textArray = System.Text.Encoding.Unicode.GetBytes(text);
            unsafe
            {
                fixed (byte* p = &textArray[0])
                {
                    SendMessage(handle, EM_SETCUEBANNER, 0, (int)p);
                }
            }
        }
        #endregion

        // 定义委托对象
        public EventHandler<MessageEventArgs> myDelegate;
        // 工件线程
        Thread workThread;
        // 解密类的对象
        Decrypt decrypt;

        // 关于对话框
        AboutBox aboutBox;

        public MainForm()
        {
            InitializeComponent();
            // 定义新的解密对象
            decrypt = new Decrypt(this);
            // 关联解密对象的消息事件到UpdateProgressPos方法
            myDelegate = new EventHandler<MessageEventArgs>(UpdateProgressPos);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            ApplyCueInfoWin32(textBoxSourceFiles, "支持拖放操作；多个文件以分号隔开");
            ApplyCueInfoWin32(textBoxSourceFolder, "支持拖放操作；支持整个文件夹处理");
            ApplyCueInfoWin32(textBoxDestinationFolder, "目标文件夹，覆盖保存");
        }

        // 根据单选按钮激活各个控件
        private void radioButtonDecryptFiles_CheckedChanged(object sender, EventArgs e)
        {
            // 选择“解密文件”时
            if (radioButtonDecryptFiles.Checked)
            {
                textBoxSourceFiles.Enabled = true;
                buttonOpenFiles.Enabled = true;
                textBoxSourceFolder.Enabled = false;
                buttonOpenFolder.Enabled = false;
                checkBoxIncludeChildren.Enabled = false;
            }
            // 选择“解密文件夹”时
            else
            {
                textBoxSourceFiles.Enabled = false;
                buttonOpenFiles.Enabled = false;
                textBoxSourceFolder.Enabled = true;
                buttonOpenFolder.Enabled = true;
                checkBoxIncludeChildren.Enabled = true;
            }
            textProgressBar1.Value = 0;
        }

        // 根据单选按钮激活各个控件
        private void radioButtonSaveOriginal_CheckedChanged(object sender, EventArgs e)
        {
            // 选择“保存在原位置”时
            if (radioButtonSaveOriginal.Checked)
            {
                checkBoxMakeBakeup.Enabled = true;
                textBoxDestinationFolder.Enabled = false;
                buttonSaveDestination.Enabled = false;
            }
            // 选择“保存到指定位置”时
            else
            {
                checkBoxMakeBakeup.Enabled = false;
                textBoxDestinationFolder.Enabled = true;
                buttonSaveDestination.Enabled = true;
            }
            textProgressBar1.Value = 0;
        }

        private void buttonOpenFiles_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    textBoxSourceFiles.Text = "";
                    foreach (string filename in ofd.FileNames)
                    {
                        textBoxSourceFiles.Text += filename + ";";
                    }
                }
            }
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = false;
                if (DialogResult.OK == fbd.ShowDialog())
                {
                    textBoxSourceFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void buttonSaveDestination_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.ShowNewFolderButton = true;
                if (DialogResult.OK == fbd.ShowDialog())
                {
                    textBoxDestinationFolder.Text = fbd.SelectedPath;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // 如果线程尚未创建
            if (workThread == null)
            {
                // 初始化解密对象
                decrypt.SourceFiles = textBoxSourceFiles.Text;
                decrypt.SourceFolder = textBoxSourceFolder.Text;
                decrypt.DestinationFolder = textBoxDestinationFolder.Text;
                decrypt.DealFiles = radioButtonDecryptFiles.Checked;
                decrypt.IncludeChildren = checkBoxIncludeChildren.Checked;
                decrypt.SaveOriginal = radioButtonSaveOriginal.Checked;
                decrypt.Backup = checkBoxMakeBakeup.Checked;

                // 创建新线程
                workThread = new Thread(decrypt.EncodeThread);
                // 启动新线程
                workThread.Start();
                groupBoxSource.Enabled = false;
                groupBoxDestination.Enabled = false;
                buttonSave.Text = "中止保存(&S)";
            }
            // 如果线程正在运行，则通知线程中止
            else if (workThread.IsAlive)
            {
                decrypt.RequestStop();
                buttonSave.Enabled = false;
            }
        }

        private void textBoxSourceFiles_TextChanged(object sender, EventArgs e)
        {
            textProgressBar1.Value = 0;
            textProgressBar1.Text = "";
        }

        private void UpdateProgressPos(object sender, MessageEventArgs e)
        {
            textProgressBar1.Maximum = e.total;
            if (e.current < 0 || e.current > e.total)
            {
                textProgressBar1.Text = "进度值出错！";
                return;
            }
            textProgressBar1.Value = e.current;
            Debug.WriteLine(e.cue);
            textProgressBar1.Text = e.cue;

            switch (e.status)
            {
                case MessageEventArgs.Status.beginning:
                case MessageEventArgs.Status.preparing:
                case MessageEventArgs.Status.dealing:
                    {
                        break;
                    }
                case MessageEventArgs.Status.interrupted:
                case MessageEventArgs.Status.finish:
                    {
                        // 清线程
                        workThread.Join();
                        workThread = null;
                        groupBoxSource.Enabled = true;
                        groupBoxDestination.Enabled = true;
                        buttonSave.Text = "保存明文(&S)";
                        buttonSave.Enabled = true;
                        break;
                    }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workThread == null || !workThread.IsAlive)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("关闭窗体将中止解密，是否关闭？",
                "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // 如果单击“是”按钮
            if (dr == DialogResult.Yes)
            {
                // 中止线程
                decrypt.RequestStop();
                workThread.Join();
                workThread = null;
                // 关闭窗体
                e.Cancel = false;
            }
            // 如果单击“否”按钮
            else
            {
                // 不执行操作
                e.Cancel = true;
            }
        }

        private void linkLabelDisclaimer_Click(object sender, EventArgs e)
        {
            string str = "　　本工具针对DG8.0透明加密客户端设计，也支持其它部分透明加密软件。仅供企业内部使用，严禁外泄！\r\n　　因使用本工具而导致的任何后果由使用者自行承担，本工具开发者不承担任何责任！\r\n　　如果您对本声明持有异议，请勿使用。谢谢合作！\r\n\t\t\t\t\t悲鸿向天鸣\r\n\t\t\t\t\t2012-5-20";
            MessageBox.Show(str, "免责声明", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void linkLabelAbout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (aboutBox == null)
            {
                aboutBox = new AboutBox();
                aboutBox.Show(this);
                aboutBox.FormClosed += new FormClosedEventHandler(
                    (sender1, e1) => { aboutBox = null; }
                );
            }
            else
            {
                aboutBox.Activate();
            }
        }

        private void textBoxSourceFiles_DragDrop(object sender, DragEventArgs e)
        {
            textBoxSourceFiles.Text = "";
            foreach (string str in (System.Array)e.Data.GetData(DataFormats.FileDrop))
            {
                if (File.Exists(str))
                    textBoxSourceFiles.Text += str + ";";
            }
        }

        private void textBoxSourceFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void textBoxSourceFolder_DragDrop(object sender, DragEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string str = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            if (Directory.Exists(str))
            {
                textBox.Text = str;
            }
        }

    }
}
