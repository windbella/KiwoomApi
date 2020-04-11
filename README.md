# KiwoomApi
- 키움의 OCX 형태의 API를 웹 서버 형태로 제공하는 프로젝트
- https://www2.kiwoom.com/nkw.templateFrameSet.do?m=m1408000000 > 키움 Open API+ 모듈 다운로드
- 위 페이지의 개발가이드의 메소드와 이벤트를 따름
- POST / http://localhost:5000/Method , POST / http://localhost:5000/Event 를 이용하여 통신  

```
POST http://localhost:5000/Method
Content-Type: application/json

{
    "Name": "CommConnect"
}
###
POST http://localhost:5000/Method
Content-Type: application/json

{
    "Name": "GetLoginInfo",
    "Parameters": ["USER_ID"]
}
```
위와 같은 요청을 하면 단순 텍스트 형태의 응답을 받음
```
POST http://localhost:5000/Event
Content-Type: application/json

{
    "Name": "OnEventConnect",
    "Uri": "http://..."
}
```
위와 같은 요청으로 이벤트가 일어 났을 때 응답을 받을 주소를 설정할 수 있으며, POST 메소드로 json 형태의 body가 응답으로 주어짐
