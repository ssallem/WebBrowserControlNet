# WebBrowser Control for .Net
### UI Automation 방식 이용
  ---
**1. AutomationElement**

* 설명: UI Automation 트리의 각 요소를 나타냅니다. 예를 들어, 버튼, 텍스트 상자, 창, 메뉴 등과 같은 화면에 표시되는 모든 UI 요소는 AutomationElement로 표현됩니다.

* 역할: 프로그램에서 UI 요소를 탐색하고 조작하기 위한 기본 객체입니다. 이 객체를 사용하여 UI 요소의 속성, 상태, 위치 등을 가져올 수 있습니다.
Control Patterns:

**2. Control Patterns**

* 설명: UI 요소가 제공하는 기능을 나타냅니다. 예를 들어, 버튼에는 InvokePattern이 있으며, 이는 버튼을 클릭하는 기능을 나타냅니다. 텍스트 상자에는 ValuePattern이 있으며, 이는 텍스트를 설정하거나 가져오는 기능을 나타냅니다.

* 주요 패턴
   * InvokePattern: 버튼을 클릭할 수 있는 패턴.
   * ValuePattern: 텍스트 상자에서 텍스트를 가져오거나 설정할 수 있는 패턴.
   * SelectionPattern: 선택 가능한 항목을 가진 목록 컨트롤에 대한 패턴.
   * TogglePattern: 체크박스나 토글 버튼을 제어할 수 있는 패턴.

**3. Tree Structure**

* 설명: UI Automation API는 UI 요소들을 트리 구조로 표현합니다. 트리의 루트는 일반적으로 화면 전체를 나타내는 AutomationElement.RootElement입니다. 트리의 각 노드는 AutomationElement로 표현되며, 부모-자식 관계를 가집니다.

* 역할: 트리 구조를 탐색하여 특정 UI 요소를 찾고, 해당 요소에 대해 작업을 수행할 수 있습니다.

**4. Properties**

* 설명: UI 요소의 속성을 나타냅니다. 예를 들어, 요소의 이름, 컨트롤 유형, 활성 상태 등을 나타낼 수 있습니다. 각 AutomationElement는 다양한 속성을 가지며, 이 속성들을 통해 UI 요소의 상태를 파악할 수 있습니다.

* 주요 속성
   * AutomationIdProperty: UI 요소의 고유 식별자.
   * NameProperty: UI 요소의 이름(예: 버튼 텍스트).
   * ControlTypeProperty: UI 요소의 컨트롤 유형(예: 버튼, 텍스트 박스 등).
   * IsEnabledProperty: UI 요소가 활성화되어 있는지 여부.

**5. Events**

* 설명: UI 요소에서 발생하는 이벤트를 나타냅니다. 예를 들어, 버튼 클릭, 텍스트 변경, 창 열림/닫힘 등의 이벤트가 있습니다. UI Automation은 이러한 이벤트를 감지하고 처리할 수 있습니다.

* 주요 이벤트
   * InvokePattern.InvokedEvent: 버튼이 클릭될 때 발생하는 이벤트.
   * TextPattern.TextChangedEvent: 텍스트 상자의 내용이 변경될 때 발생하는 이벤트.
   * WindowPattern.WindowOpenedEvent: 창이 열릴 때 발생하는 이벤트.
---

* 프로젝트 참조 추가
  > UIAutomationClient.dll<br>
  > UIAutomationTypes.dll 
