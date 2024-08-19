using System;
using System.Text;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WebBrowserControlNet
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFindSearchText_Click(object sender, EventArgs e)
        {
            InitSearchText();
            FindChromeActivedTabSearchText();
        }

        private void InitSearchText()
        {
            txtSearchBrowser.Clear();
            txtSearchAddress.Clear();
        }

        // Google, YouTube, Bing, Naver는 AddressBar의 Text를 가져올 수 있지만, Yahoo는 가져올 수 없다.
        // YouTube = results?search_query=ssallemTestApiyoutube
        // Bing = search?q=ssallemTestApiBing
        // Naver = &query=ssallemTestApinaver&
        // Google = search?q=ssallemTestApigoogle&
        private void FindChromeActivedTabSearchText()
        {
            try
            {
                StringBuilder searchBrowser = new StringBuilder();
                StringBuilder searchAddress = new StringBuilder();

                // 모든 Chrome 브라우저를 찾는다.
                AutomationElementCollection chromeWindows = AutomationElement.RootElement.FindAll(
                    TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"));

                if (chromeWindows.Count == 0)
                {
                    searchBrowser.AppendLine("No Chrome windows found");
                    return;
                }

                foreach (AutomationElement chromeWindow in chromeWindows)
                {
                    searchBrowser.AppendLine($"chromeWindow.Current.Name : {chromeWindow.Current.Name}");

                    // 특정 사이트에서는 FindFirst로 주소 표시줄을 찾을 수 없다. (ex. Yahoo..)
                    //AutomationElement addressBar = chromeWindow.FindFirst(TreeScope.Descendants,
                    //    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                    // 디버깅용도로 전체 AutomationElementCollection를 조회해본다.
                    //AutomationElementCollection addressBars = chromeWindow.FindAll(TreeScope.Descendants,
                    //    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                    // ★★★ AccessKey가 Ctrl+L이거나 Name이 "주소창 및 검색창"인 요소를 찾는다.
                    // FindFirst : ControlType.Edit와 AccessKeyProperty 속도 차이
                    AutomationElement addressBar = chromeWindow.FindFirst(TreeScope.Descendants,
                        new OrCondition(
                            new PropertyCondition(AutomationElement.AccessKeyProperty, "Ctrl+L"),
                            new PropertyCondition(AutomationElement.NameProperty, "주소창 및 검색창")
                        ));

                    if (addressBar == null)
                    {
                        searchAddress.AppendLine($"No address bars found in chrome window : {chromeWindow.Current.Name}");
                        return;
                    }
                    else
                    {
                        string addressValue = ((ValuePattern)addressBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value;

                        if (string.IsNullOrEmpty(addressValue) == false)
                        {
                            searchAddress.AppendLine("Address Bar Text: " + addressValue);
                            searchAddress.AppendLine();
                        }
                    }
                }
                txtSearchBrowser.Text = searchBrowser.ToString();
                txtSearchAddress.Text = searchAddress.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 전체 열린 Tab의 주소 표시줄을 가져오는 기능은 보안상 불가능해 보인다.
        private void FindChromeSearchAllTab()
        {
            try
            {
                StringBuilder searchBrowser = new StringBuilder();
                StringBuilder searchAddress = new StringBuilder();

                // 모든 Chrome 브라우저를 찾는다.
                AutomationElementCollection chromeWindows = AutomationElement.RootElement.FindAll(
                    TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"));

                if (chromeWindows.Count == 0)
                {
                    searchBrowser.AppendLine("No Chrome windows found");
                    return;
                }

                foreach (AutomationElement chromeWindow in chromeWindows)
                {
                    // 모든 에디트 컨트롤 (주소 표시줄 가능성 있는 요소) 찾기
                    // chromeWindow.FindAll --> 결국 활성화된 탭의 주소 표시줄만 찾게 된다.
                    AutomationElementCollection addressBars = chromeWindow.FindAll(TreeScope.Descendants,
                        new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));

                    searchBrowser.AppendLine($"chromeWindow.Current.Name : {chromeWindow.Current.Name}");

                    if (addressBars.Count == 0)
                    {
                        searchAddress.AppendLine($"No address bars found in chrome window : {chromeWindow.Current.Name}");
                        return;
                    }

                    foreach (AutomationElement addressBar in addressBars)
                    {
                        if (addressBar != null)
                        {
                            Console.WriteLine($"addressBar.Current.Name : {addressBar.Current.Name}");
                            // 주소 표시줄의 텍스트 값 취득
                            string addressValue = ((ValuePattern)addressBar.GetCurrentPattern(ValuePattern.Pattern)).Current.Value;

                            if (string.IsNullOrEmpty(addressValue) == false)
                            {
                                searchAddress.AppendLine("Address Bar Text: " + addressValue);
                            }
                        }
                    }
                }
                txtSearchBrowser.Text = searchBrowser.ToString();
                txtSearchAddress.Text = searchAddress.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
