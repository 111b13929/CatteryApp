
# 貓咪管理系統 API

本專案是一個基於 ASP.NET Core Web API 的貓咪管理系統，用於管理貓舍中的貓咪資料。透過此 API，使用者可以進行 CRUD 操作，管理貓咪的基本資訊。此專案展示了 ASP.NET Core Web API 的基礎應用，包含多層架構設計、資料庫操作、錯誤處理和 API 文件生成。

## 功能概述
- **新增貓咪資料**：新增一筆貓咪資料至資料庫。
- **查詢所有貓咪資料**：獲取所有貓咪的詳細資訊。
- **查詢單筆貓咪資料**：根據貓咪的 ID 獲取其詳細資訊。
- **更新貓咪資料**：更新指定 ID 的貓咪資料。
- **刪除貓咪資料**：根據貓咪的 ID 刪除其資料。

## 專案架構
- **Models**：包含 `Cat` 類別，定義了貓咪的資料結構，包括 `Name`、`Age`、`Breed`、`IsVaccinated` 和 `Description` 等欄位。
- **Interfaces**：包含 `ICatRepository` 介面，定義了所有 CRUD 操作的方法。
- **Repositories**：實作 `ICatRepository`，負責處理與資料庫的互動。
- **Controllers**：包含 `CatsController`，負責接收和處理 HTTP 請求，並調用相應的 Repository 方法。

## 技術細節
- **資料庫**：使用 Entity Framework Core 與 SQL Server LocalDB 進行資料庫操作。
- **依賴注入**：使用 ASP.NET Core 的 DI 容器注入 `AppDbContext` 和 `ICatRepository`。
- **資料驗證**：使用 Data Annotations（如 `[Required]` 和 `[StringLength]`）來確保必填欄位和字串長度的限制。
- **Swagger 文件**：利用 Swagger 自動生成 API 文件，方便測試和 API 說明。

## 安裝與設定
1. **克隆此專案**：
   ```bash
   git clone https://github.com/your-username/cattery-app.git
   cd cattery-app
   ```

2. **建立資料庫**：
   - 確認 `appsettings.json` 中的連接字串配置正確，例如：
     ```json
     "ConnectionStrings": {
       "CatteryContext": "Server=(localdb)\MSSQLLocalDB;Database=CatteryDB;Trusted_Connection=True;"
     }
     ```
   - 在專案目錄下運行遷移命令：
     ```bash
     dotnet ef migrations add InitialCreate
     dotnet ef database update
     ```

3. **運行應用程式**：
   ```bash
   dotnet run
   ```
   或者在 Visual Studio 中按下 `F5` 來啟動應用程式。

## 使用方式
### Swagger 測試
運行應用程式後，您可以在瀏覽器中開啟 Swagger UI（預設為 `https://localhost:5001/swagger`），通過視覺化介面來測試每個 API 端點。

### 範例 API 請求
#### 新增貓咪資料
- `POST /api/Cats`
- 範例 JSON 請求體：
  ```json
  {
    "name": "Milo",
    "age": 3,
    "breed": "Siamese",
    "isVaccinated": true,
    "description": "A playful and friendly cat"
  }
  ```

#### 查詢所有貓咪資料
- `GET /api/Cats`

#### 查詢單筆貓咪資料
- `GET /api/Cats/{id}`

#### 更新貓咪資料
- `PUT /api/Cats/{id}`
- 範例 JSON 請求體：
  ```json
  {
    "name": "Leo",
    "age": 4,
    "breed": "Bengal",
    "isVaccinated": false,
    "description": "Active and playful"
  }
  ```

#### 刪除貓咪資料
- `DELETE /api/Cats/{id}`

## 測試與驗證
- 使用 Swagger 或 Postman 測試各個 CRUD 端點，確保所有操作正常。
- 可以使用多組不同的 JSON 資料（如 `name`、`age` 和 `breed` 等）來模擬不同情境，驗證 API 的功能和資料驗證邏輯。

## 結語
此 API 展示了 ASP.NET Core Web API 的基礎應用，從多層架構設計、依賴注入到資料庫操作和 Swagger 文件生成。此專案提供了貓咪管理系統的基本功能，並以此為範例展示如何使用 ASP.NET Core 架構來開發 RESTful API。
