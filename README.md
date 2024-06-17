[기획]
1. 주기적으로 리스폰되는 Box를 클릭해서 부수면 재화를 얻을 수 있다.
2. 재화는 사과, 바나나, 체리 3종류로 각각의 재화로 구매할 수 있는 클릭에 도움을 주는 다양한 아이템 또는 업그레이드 구매 가능
3. 상점 UI기능으로 살 수 있는 아이템 구현, 적절한 가격 설정

[필수 구현사항]

1. 클릭 이벤트 처리
   
![image](https://github.com/amor1523/ClickME/assets/167174802/6152b40f-65ee-4e9d-8345-77484852a5b2)

ClickManager 스크립트에 클릭 이벤트를 처리하고, Update함수로 지속적으로 갱신



2. 자동 클릭 기능
   
![image](https://github.com/amor1523/ClickME/assets/167174802/00b91850-e718-48b9-bf1a-9974c20c9016)

코루틴을 이용한 자동클릭 기능 구현



3. 점수 시스템

![image](https://github.com/amor1523/ClickME/assets/167174802/04a95582-3022-4ffc-9de8-d73ed8f334b2)

![image](https://github.com/amor1523/ClickME/assets/167174802/b6e2ed59-f4b8-4ab0-8046-89ba065deea5)

RewardManager 스크립트에 Reward에 대한 전반적인 내용 구현 및 UI갱신



4. 아이템 및 업그레이드 시스템

![image](https://github.com/amor1523/ClickME/assets/167174802/4495c5e3-6c4c-4937-8db8-632e11a91a46)

ShopBTN스크립트로 상점을 열고닫는 기능 구현

TroubldShooting : 상점을 열었을 때도 자동클릭이 발생하여 TimeScale을 변경하여 해결

ShopManager스크립트를 통해 상점에대한 전반적인 기능 구현
UI 기능 중 하나인 Scroll View 기능을 사용하였는데 생각보다 사용이 어려웠다.
시간을 오래써서 Content를 스크립트로 다루고 싶었으나 하드코딩으로 직접 Button들을 등록하고 사용해주었다...
Context를 스크립트로 등록하고, 상점목록을 따로 스크립트나 스크립터블오브젝트로 관리할 수 있을까? 나중에 해봐야겠다.


![image](https://github.com/amor1523/ClickME/assets/167174802/6c9ba181-d883-49ba-9c3e-88554e23a1b2)

OnPurchaseClick 함수를 구현하는데 막혀버렸다... 다행히 여기저기 찾아서 해결!


![image](https://github.com/amor1523/ClickME/assets/167174802/8d7e0ef7-29f2-492b-953b-d0ae7deb315f)

![image](https://github.com/amor1523/ClickME/assets/167174802/9899ac60-3738-4e02-8b70-85efab4fe5dd)

OnClick 매개변수를 전달하던 중 Friend1~3이 아닌 Apple, Banana, Cherry로 잘못 적어 Friend들이 생성되지 않았다.
여러가지 TroubleShooting을 할 수 있어 좋았다...(?)
처음에는 Time.deltaTime문제인줄 알았지만 스위치문과 OnClick매개변수들에 디버그로그 공격을 한 결과 TimeScale의 문제는 아니였다.
하드코딩을 하면 안된다는 교훈을 얻었다...

Friends들에 오토클릭 기능을 넣어놨는데 상자가 사라질 때 오토클릭이 발생하면 Nullreference오류가 뜬다.
currentBox가 null이면 코루틴을 한번 쉬는 방식으로 해결해보려고 했지만 잘 해결되지 않았다.
다행히 게임진행에는 크게 문제가 없어 안고가기로 결정..(도움요청!!)


5. 게임 내 통화 시스템
점수시스템을 만들면서 구현하였으니 넘어가도록 하겠습니다.


![image](https://github.com/amor1523/ClickME/assets/167174802/d9a97744-409a-475a-9a1e-fa3c3a8b4c01)

원인 모를 버그 발생... Graphs.Edge.WakeUp()...?




[선택 구현사항] - 나머지는 시간이 많으면 가능할 거 같은데... BigInteger기능을 최우선적으로 해보자.

1. 파티클 시스템


   
2. 사운드 이펙트


   
3. 애니메이션

![image](https://github.com/amor1523/ClickME/assets/167174802/b3ba9985-f5c5-436e-bbee-42f9126f7201)

Friends들이 가만히 서있는게 밋밋해서 랜덤한 위치로 달려가는 코드를 구현해보았다.

  
4. 저장 및 로드 시스템

   
5. BigInteger 기능
   
   https://github.com/keiwando/biginteger

   참조해보기
