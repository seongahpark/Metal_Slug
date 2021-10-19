# Mootal Slug
- 팀명 : 메탈 슬라임

## Contributor
|이름|GitHub|
|---|---|
|성아|[@seongahpark](https://github.com/seongahpark)|
|섭균|[@JooSK314](https://github.com/JooSK314)|

### Git Error : CRLF 관련 에러 발생 시
```
git config --global core.autocrlf true
```

### 작업 순서
1. ``pull``을 통해 최신 상태로 업데이트 후 작업 시작
```
git pull upstream main
```
2. 작업 후 ``add``와 ``commit`` 생성
```
git add .
git commit -m "커밋 내용"
```
3. 본인 브랜치인지 확인 후 본인 브랜치에다 푸쉬
```
git push -u upstream joo
```
4. 깃허브 홈페이지에서 풀리퀘스트 신청
