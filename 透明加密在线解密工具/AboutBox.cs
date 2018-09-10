using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace MyDecrypt
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            // this.Text = String.Format("关于 {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format("版本 {0}", AssemblyVersion);
            this.labelCopyright.Text = AssemblyCopyright;
            this.labelCompanyName.Text = AssemblyCompany;
            this.textBoxDescription.Text = 
                "升级日志：\r\n"+
                "Version 4.1 (2014-08-14)\r\n" +
                "*  修正上一版本对“铁卷”3.2破解失败的Bug\r\n" +
                "*  改进用户界面\r\n" +
                "Version 4.0 (2014-08-07)\r\n" +
                "*  代码重构，由MFC迁移到WinForm\r\n" +
                "*  增加文件夹处理功能\r\n" +
                "*  增加中止处理功能\r\n" +
                "Version 3.2 (2013-10-28)\r\n" +
                "*  修正文件处理进度提示\r\n"+
                "Version 3.1 (2013-10-15)\r\n"+
                "*  增加英文系统的支持\r\n"+
                "Version 3.0 (2013-09-17)\r\n"+
                "*  增加对“铁卷”3.2版的支持\r\n"+
                "Version 2.0 (2012-08-13)\r\n"+
                "*  增加多文件处理功能（暂不支持文件夹）\r\n"+
                "*  解决上一版本中处理大文件时界面假死的bug\r\n"+
                "Version 1.3 (2012-06-16)\r\n"+
                "*  突破通软桌面管理系统的应用程序限制策略\r\n"+
                "Version 1.2 (2012-05-28)\r\n"+
                "*  修正上一版本破解失败的bug\r\n"+
                "Version 1.1 (2012-05-26)\r\n"+
                "*  优化文件生成方式\r\n"+
                "Version 1.0 (2012-05-23)\r\n"+
                "*  实现DG8.0客户端加密文件在线破解\r\n"+
                "*  支持文件拖拽";
        }

        #region 程序集特性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
