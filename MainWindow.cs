using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Automation;
using System.Windows.Forms;
using WebBrowserControlNet.Common;

namespace WebBrowserControlNet
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            UiAutomation();
        }

        private void UiAutomation()
        {
            //AutomationElement chromeWindow = AutomationElement.RootElement.FindFirst(
            //    TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "새 탭 - Google Chrome"));

            // Chrome 창의 제목이 무엇이든 상관없이 첫 번째 Chrome 창을 찾는다.
            AutomationElement chromeWindow = AutomationElement.RootElement.FindFirst(
                TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"));

            if (chromeWindow == null)
            {
                Console.WriteLine("Chrome window not found");
                return;
            }

            // 주소 표시줄 요소를 찾는다.
            AutomationElement addressBar = chromeWindow.FindFirst(TreeScope.Descendants,
                new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

            if (addressBar == null)
            {
                Console.WriteLine("Address bar not found");
                return;
            }

            // 주소 표시줄의 텍스트 값을 가져옵니다.
            string addressValue = ((ValuePattern)addressBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value;
            Console.WriteLine("Address Bar Text: " + addressValue);
        }

        private void HandleHooking()
        {
            // Chrome 브라우저 메인 윈도우 핸들을 얻음
            IntPtr chromeHandle = WinAPI.FindWindow("Chrome_WidgetWin_1", null);

            if (chromeHandle == IntPtr.Zero)
            {
                Console.WriteLine("Chrome window not found");
                return;
            }

            // 주소 표시줄 핸들을 찾기 위한 하위 창 탐색 (실제로는 더 복잡할 수 있음)
            IntPtr addressBarParentHandle = WinAPI.FindWindowEx(chromeHandle, IntPtr.Zero, "Intermediate D3D Window", null);
            //// GetWindowText를 사용하여 주소 표시줄의 텍스트를 가져옵니다.
            //StringBuilder windowText = new StringBuilder(256);
            //WinAPI.GetWindowText(addressBarParentHandle, windowText, windowText.Capacity);

            IntPtr addressBarHandle = WinAPI.FindWindowEx(addressBarParentHandle, IntPtr.Zero, "Chrome_RenderWidgetHostHWND", null);

            if (addressBarHandle == IntPtr.Zero)
            {
                Console.WriteLine("Address bar handle not found");
                return;
            }

            //// 주소 표시줄 컨트롤을 찾기 위해 여러 단계로 FindWindowEx 호출
            //IntPtr addressBarHandle = WinAPI.FindWindowEx(chromeHandle, IntPtr.Zero, "Chrome_RenderWidgetHostHWND", null);

            //if (addressBarHandle == IntPtr.Zero)
            //{
            //    Console.WriteLine("Address bar not found");
            //    return;
            //}

            // 텍스트 길이 가져오기
            int length = WinAPI.SendMessage(addressBarHandle, WinAPI.WM_GETTEXTLENGTH, IntPtr.Zero, null).ToInt32();

            if (length > 0)
            {
                // 텍스트 가져오기
                StringBuilder sb = new StringBuilder(length + 1);
                WinAPI.SendMessage(addressBarHandle, WinAPI.WM_GETTEXT, (IntPtr)sb.Capacity, sb);
                Console.WriteLine("Address Bar Text: " + sb.ToString());
            }
            else
            {
                Console.WriteLine("Failed to retrieve address bar text");
            }
        }

        private void MemoryHooking()
        {
            Process[] processes = Process.GetProcessesByName("chrome");
            if (processes.Length > 0)
            {
                IntPtr processHandle = WinAPI.OpenProcess(WinAPI.PROCESS_WM_READ, false, processes[0].Id);

                // 메모리에서 읽을 위치와 크기를 지정해야 함
                // 이 위치를 알기 어렵고, 실제로 검색어를 찾는 것은 복잡함
                IntPtr address = (IntPtr)0x000000; // 대충의 메모리 주소
                byte[] buffer = new byte[24];
                int bytesRead;

                if (WinAPI.ReadProcessMemory(processHandle, address, buffer, buffer.Length, out bytesRead))
                {
                    string result = System.Text.Encoding.UTF8.GetString(buffer);
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("Failed to read memory.");
                }
            }
        }
    }
}
