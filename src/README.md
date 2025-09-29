
# TodoList API

이 프로젝트는 Todo 리스트를 관리하기 위한 Clean Architecture 기반의 .NET 9.0 웹 API입니다. 이 문서에서는 프로젝트를 실행하고 학습하는 방법을 설명합니다.

## 프로젝트 구조

```
TodoList.sln
src/
  TodoList.API/                # API 프로젝트
  TodoList.Application/        # 애플리케이션 계층
  TodoList.Domain/             # 도메인 계층
  TodoList.Infrastructure/     # 인프라 계층
tests/
  TodoList.UnitTests/          # 단위 테스트
  TodoList.IntegrationTests/   # 통합 테스트
```

## 요구 사항

- [.NET SDK 9.0](https://dotnet.microsoft.com/download/dotnet/9.0)
- SQLite (내장 데이터베이스 사용)

## 실행 방법

1. **레포지토리 클론**
   ```bash
   git clone https://github.com/your-repo-url/CleanArchitecture.git
   cd CleanArchitecture
   ```

2. **데이터베이스 마이그레이션 적용**
   ```bash
   cd src/TodoList.API
   dotnet ef database update
   ```

3. **애플리케이션 실행**
   ```bash
   dotnet run
   ```

4. **API 문서 확인**
   - 브라우저에서 `https://localhost:5001/swagger`로 이동하여 Swagger UI를 통해 API를 테스트할 수 있습니다.

## 주요 엔드포인트

| 메서드 | 경로                  | 설명                     |
|--------|-----------------------|--------------------------|
| GET    | `/api/todo`           | 모든 Todo 조회           |
| GET    | `/api/todo/{id}`      | 특정 Todo 조회           |
| POST   | `/api/todo`           | 새로운 Todo 생성         |
| PUT    | `/api/todo/{id}`      | 기존 Todo 업데이트       |
| POST   | `/api/todo/{id}/complete` | Todo 완료 처리         |
| DELETE | `/api/todo/{id}`      | Todo 삭제               |

## 학습 포인트

1. **Clean Architecture**
   - 프로젝트는 Clean Architecture 원칙을 따르며, 각 계층이 명확히 분리되어 있습니다.
   - `TodoList.Application`은 비즈니스 로직을 포함하며, `TodoList.Infrastructure`는 데이터베이스와 같은 외부 리소스와의 상호작용을 처리합니다.

2. **Entity Framework Core**
   - SQLite를 사용하여 데이터베이스를 관리하며, `AppDbContext`를 통해 데이터베이스 작업을 수행합니다.

3. **Swagger**
   - Swagger를 통해 API 문서를 자동으로 생성하고 테스트할 수 있습니다.

4. **테스트(적용 예정정)**
   - `tests/TodoList.UnitTests`와 `tests/TodoList.IntegrationTests`에서 각각 단위 테스트와 통합 테스트를 확인할 수 있습니다.
