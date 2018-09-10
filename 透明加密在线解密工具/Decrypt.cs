using System;
using System.Collections;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;
using MainFormNamespace;

namespace MyDecrypt
{
    // 定义事件数据类，用于向主线程传递信息
    public class MessageEventArgs : EventArgs
    {
        // 当前处理文件数和文件总数
        public int current, total;
        // 当前处理状态
        public enum Status
        {
            beginning,
            preparing,
            dealing,
            interrupted,
            finish
        };
        public Status status;
        // 提示信息
        public string cue;
        public MessageEventArgs(int current, int total, Status status, string cue)
        {
            this.current = current;
            this.total = total;
            this.status = status;
            this.cue = cue;
        }
    }

    // 解密类
    class Decrypt
    {
        // 父窗口
        private MainForm parent;
        // 文件名数组
        private ArrayList fileArray;
        // 文件夹名数组
        private ArrayList directoryArray;

        // 要处理的文件总数
        private int nFileNum;
        // 已处理的文件数
        private int nProcessed;
        // 文件内容缓冲区
        private byte[] pBuffer;
        // 文件内容缓冲区大小
        private int bufferSize;
        // 定义Volatile属性的监视值，用于中止线程
        private volatile bool shouldStop;

        // 处理文件还是文件夹
        public bool DealFiles { get; set; }
        // 是否包含子文件夹
        public bool IncludeChildren { get; set; }
        // 是否保留备份
        public bool Backup { get; set; }
        // 是否保留在原位置
        public bool SaveOriginal { get; set; }
        // 源文件名
        public string SourceFiles { get; set; }
        // 源文件夹名
        public string SourceFolder { get; set; }
        // 目标文件夹
        public string DestinationFolder { get; set; }

        // 构造函数
        public Decrypt(MainForm form)
        {
            this.parent = form;
        }

        // 对外部线程提供的方法，用于中止线程
        public void RequestStop()
        {
            shouldStop = true;
        }

        // 解密线程函数
        public void EncodeThread()
        {
            // 此线程采用异步方式
            // 函数执行过程中，外部不可对Decrypt的公共属性进行修改
            fileArray = new ArrayList();
            directoryArray = new ArrayList();
            shouldStop = false;
            nFileNum = 0;
            nProcessed = 0;
            // 文件内容缓冲区大小设为1MB
            bufferSize = 0x100000;
            pBuffer = new byte[bufferSize];
            // 状态提示
            string cue;

            // 向父线程发送消息
            // 不要用Invoke，会与主线程形成死锁

            // 处理开始
            parent.BeginInvoke(parent.myDelegate, new Object[] {
                this, new MessageEventArgs(nProcessed, nFileNum,
                    MessageEventArgs.Status.beginning, "") });

            // 准备待处理的文件
            parent.BeginInvoke(parent.myDelegate, new Object[] {
                this, new MessageEventArgs(nProcessed, nFileNum,
                    MessageEventArgs.Status.preparing, "正在准备待处理的文件...") });
            if (!PrepareFiles())
            {
                parent.BeginInvoke(parent.myDelegate, new Object[] {
                    this, new MessageEventArgs(nProcessed, nFileNum,
                        MessageEventArgs.Status.finish, "准备待处理的文件失败！") });
                return;
            }

            // 准备目标文件夹
            if (!SaveOriginal)
            {
                if (!Directory.Exists(DestinationFolder))
                {
                    parent.BeginInvoke(parent.myDelegate, new Object[] {
                    this, new MessageEventArgs(nProcessed, nFileNum,
                        MessageEventArgs.Status.finish, "准备目标文件夹失败！") });
                    return;
                }
                else if (!DealFiles)  // 创建目标文件夹
                {
                    parent.BeginInvoke(parent.myDelegate, new Object[] {
                        this, new MessageEventArgs(nProcessed, nFileNum,
                    MessageEventArgs.Status.dealing, "正在创建目标文件夹...") });
                    if (!CreateDirectories(out cue))
                    {
                        parent.BeginInvoke(parent.myDelegate, new Object[] {
                    this, new MessageEventArgs(nProcessed, nFileNum,
                        MessageEventArgs.Status.finish, "创建目标文件夹失败！" + cue) });
                        return;
                    }
                }
            }

            // 处理文件
            foreach (string sourcefile in fileArray)
            {
                cue = "正在处理第" + (nProcessed + 1) + "个文件，共" + nFileNum + "个文件";
                parent.BeginInvoke(parent.myDelegate, new Object[] {
                    this, new MessageEventArgs(nProcessed, nFileNum,
                        MessageEventArgs.Status.dealing, cue) });
                // 正在处理的源文件
                FileInfo sFile = new FileInfo(sourcefile);
                FileInfo dFile;
                if (SaveOriginal)
                {
                    // 目标文件
                    dFile = sFile;
                }
                else
                {
                    // 目标文件夹
                    DirectoryInfo dDir = new DirectoryInfo(DestinationFolder);
                    if (DealFiles)
                    {
                        dFile = new FileInfo(dDir.FullName + "\\" + sFile.Name);
                    }
                    else
                    {
                        // 正在处理的源文件夹
                        DirectoryInfo sDir = new DirectoryInfo(SourceFolder);
                        // 目标文件
                        dFile = new FileInfo(dDir.FullName + sFile.FullName.Remove(0, sDir.FullName.Length));
                    }
                }
                if (Encode(sFile, dFile))
                {
                    nProcessed++;
                    continue;
                }                    

                // 如果收到中断信号
                if (shouldStop)
                {
                    cue = "已处理" + nProcessed + "个文件，共" + nFileNum + "个文件。处理中止！";
                    // 处理中断
                    parent.BeginInvoke(parent.myDelegate, new Object[] {
                        this, new MessageEventArgs(nProcessed, nFileNum,
                            MessageEventArgs.Status.interrupted, cue) });
                    return;
                }
            }
            // 处理结束
            cue = "已处理" + nProcessed + "个文件，共" + nFileNum + "个文件。处理完成！";
            parent.BeginInvoke(parent.myDelegate, new Object[] {
                this, new MessageEventArgs(nProcessed, nFileNum,
                    MessageEventArgs.Status.finish, cue) });
        }

        // 准备文件
        private bool PrepareFiles()
        {
            string[] array;
            fileArray.Clear();
            directoryArray.Clear();
            if (DealFiles)
            {
                array = SourceFiles.Split(';');
                foreach(string str in array)
                {
                    if (File.Exists(str))
                        fileArray.Add(str);
                }
                nFileNum = fileArray.Count;
            }
            else
            {
                if (!Directory.Exists(SourceFolder))
                    return false;
                if (IncludeChildren)
                {
                    directoryArray.Add(SourceFolder);
                    GetChildrenFiles(SourceFolder);
                }
                else
                {
                    array = Directory.GetFiles(SourceFolder);
                    directoryArray.Add(SourceFolder);
                    fileArray.AddRange(array);
                }
                nFileNum = fileArray.Count;
            }
            if (nFileNum < 1)
                return false;
            return true;
        }

        // 遍历文件夹取文件
        private void GetChildrenFiles(string folder)
        {
            string[] array;
            array = Directory.GetFiles(folder);
            fileArray.AddRange(array);
            array = Directory.GetDirectories(folder);
            directoryArray.AddRange(array);
            foreach (string item in array)
            {
                GetChildrenFiles(item);
            }
        }

        // 创建目标文件夹
        private bool CreateDirectories(out string ex)
        {
            foreach (string folder in directoryArray)
            {
                try
                {
                    // 正在处理的源文件夹(根)
                    DirectoryInfo sDir = new DirectoryInfo(SourceFolder);
                    // 当前源文件夹
                    DirectoryInfo sFolder = new DirectoryInfo(folder);
                    // 目标文件夹
                    DirectoryInfo dDir = new DirectoryInfo(DestinationFolder);
                    // 要创建的目标文件夹
                    DirectoryInfo dFolder = new DirectoryInfo(dDir.FullName + sFolder.FullName.Remove(0, sDir.FullName.Length));
                    dFolder.Create();
                }
                catch (Exception e)
                {
                    ex = e.ToString();
                    return false;
                }
            }
            ex = "";
            return true;
        }

        // 单个文件的解密函数
        public bool Encode(FileInfo sFile, FileInfo dFile)
        {
            /*if (shouldStop)
                return false;
            Thread.Sleep(300);
            return true;*/

            // 临时文件名，以cui为扩展名，并消除中间扩展名
            string temp;
            temp = dFile.DirectoryName + "\\" + dFile.Name.Replace('.', '_') + ".cui";
            FileStream sf = sFile.OpenRead();
            FileStream tf = new FileStream(temp, FileMode.Create, FileAccess.Write);

            // 读取的字节数
            int count = 0;
            // 读写操作完成
            bool finish = false;
            while (!shouldStop)
            {
                count = sf.Read(pBuffer, 0, bufferSize);
                // 如果count非0，则表示文件未读取结束
                if (count > 0)
                {
                    tf.Write(pBuffer, 0 , count);
                }
                else  // 读写操作完成
                {
                    finish = true;
                    break;
                }
            }

            sf.Close();
            tf.Close();

            if (!finish)
            {
                File.Delete(temp);
                return false;
            }

            // 定义命令行
            string cmdline;
            if (SaveOriginal && Backup)
            {
                cmdline = string.Format("cmd /c move /y \"{0}\" \"{1}\" && move /y \"{2}\" \"{3}\"",
                    sFile.FullName, sFile.FullName + ".bak", temp, dFile.FullName);
            }
            else
            {
                cmdline = string.Format("cmd /c move /y \"{0}\" \"{1}\"", temp, dFile.FullName);
            }

            /*Process cmd = new Process();
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.Start();
            cmd.StandardInput.WriteLine(cmdline);
            cmd.StandardInput.WriteLine("exit");
            //string info = cmd.StandardOutput.ReadToEnd();
            cmd.WaitForExit();
            cmd.Close();
            */
            // 之所以使用WinExec这个原始的Windows API函数，是为了Move时不被二次加密
            WinExec(cmdline, 0);
            return true;
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        public static extern int WinExec(string exeName, int operType);

    }
}
